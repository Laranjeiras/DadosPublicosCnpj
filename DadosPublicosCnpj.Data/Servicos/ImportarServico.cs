using DadosPublicosCnpj.Data.Modelos;
using DadosPublicosCnpj.Data.Servicos.Provider;
using DadosPublicosCnpj.Data.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DadosPublicosCnpj.Data.Servicos
{
    public class ImportarServico
    {
        IProvider _provider;

        protected int _totalErros = 0;
        protected int _idRegistro = 0;
        protected int _arquivosProcessados = 0;
        protected int _quantEmpresas = 0;
        protected int _quantCnaes = 0;
        protected int _quantSocios = 0;

        protected string _arquivo;

        protected readonly OpcoesServico _opcoes;
        protected long _idRegistroFinal;

        protected Metricas _metricas;
        protected DirectoryInfo _dirInfo;
        protected Trailler _trailler = new Trailler();

        protected IList<Empresa> _empresas;
        protected IList<Socio> _socios;
        protected IList<Cnae> _cnaes;

        public ImportarServico(IProvider provider, OpcoesServico opcoes)
        {
            _provider = provider;

            _opcoes = opcoes;

            _idRegistroFinal = opcoes.RegistroInicial + opcoes.QuantRegistrosImportar;

            _dirInfo = new DirectoryInfo(opcoes.DirArqImportar);

            _metricas = new Metricas();
            _empresas = new List<Empresa>();
            _socios = new List<Socio>();
            _cnaes = new List<Cnae>();
        }

        public async Task ExecutarAsync()
        {
            var listaNomeArquivos = FileHelpers.BuscarArquivosCompativeis(_dirInfo);
            _metricas.Inicializar();
            await ProcessarArquivosAsync(listaNomeArquivos);
            _metricas.Finalizar();
            SalvarMetricas(_metricas);

            Console.WriteLine($"Fim da importação");
            Console.WriteLine($"Total de Registros: {_idRegistro}");
        }

        private async Task ProcessarArquivosAsync(IList<string> listaNomeArquivos)
        {
            foreach (var nomeArquivo in listaNomeArquivos)
            {
                if (!Continua())
                    return;
                _arquivo = nomeArquivo;
                ImprimirInfoArquivo();
                await PercorrerArquivoAsync();
                _arquivosProcessados++;
            }
        }

        private async Task PercorrerArquivoAsync()
        {
            string linha;
            using (StreamReader file = new StreamReader(_arquivo))
            {
                while ((linha = await file.ReadLineAsync()) != null)
                {
                    _idRegistro++;

                    if (_idRegistro < _opcoes.RegistroInicial)
                        continue;
                    if (!Continua())
                        return;
                    TratarLinha(linha);
                }
            }
            await SalvarAlteracoesAsync();
        }

        private void TratarLinha(string linha)
        {
            try
            {
                var objeto = Mapear(linha, 0);

                if ((_idRegistro % _opcoes.TamanhoLote) == 0)
                    SalvarAlteracoesAsync();
            }
            catch (Exception ex)
            {
                SalvarLog(ex, linha);
            }
        }

        private object Mapear(string linha, long id)
        {
            var tipoRegistro = linha.Substring(0, 1);
            object objeto = null;
            try
            {
                switch (tipoRegistro)
                {
                    case "0":
                        objeto = Mapeador.MapearHeader(linha);
                        break;
                    case "1":
                        Mapeador.MapearEmpresa(ref _empresas, linha, id);
                        break;
                    case "2":
                        Mapeador.MapearSocio(ref _socios, linha, id);                        
                        break;
                    case "6":
                        Mapeador.MapearCnae(ref _cnaes, linha, id);
                        break;
                    case "9":
                        objeto = Mapeador.MapearTrailler(linha);
                        break;
                    default:
                        Console.WriteLine(tipoRegistro);
                        Console.WriteLine(linha);
                        break;
                }
            }
            catch (Exception ex)
            {
                SalvarLog(ex, linha);
            }
            return objeto;
        }

        private async Task SalvarAlteracoesAsync()
        {
            try
            {
                await _provider.SalvarAlteracoesAsync(_empresas, _socios, _cnaes);
                SalvarLogImportacao();
                Console.WriteLine($"Salvando Registros ... {_idRegistro}");
                _quantEmpresas += _empresas.Count;
                _quantSocios += _socios.Count;
                _quantCnaes += _cnaes.Count;
                ZerarListas();
            }
            catch(Exception ex)
            {
                SalvarLog(ex, "Ocorreu um erro ao salvar Alterações");
            }
        }

        private void ZerarListas()
        {
            _empresas = new List<Empresa>();
            _socios = new List<Socio>();
            _cnaes = new List<Cnae>();
        }

        private bool Continua()
        {
            if (_idRegistro >= _idRegistroFinal)
                return false;
            return true;
        }

        private void ImprimirInfoArquivo()
        {
            Console.WriteLine($"Aguarde... importando registros do arquivo {_arquivo}");
        }

        #region Logs
        private void SalvarMetricas(Metricas metricas)
        {
            var arquivoMetricas = $@"{_opcoes.DirTrabalho}\Metricas.log";
            using (StreamWriter w = File.AppendText(arquivoMetricas))
            {
                w.WriteLine($"\r\nLog Métricas: {DateTime.Now}");
                w.WriteLine($"Registros processados: {_idRegistro} em {_arquivosProcessados} arquivo(s)");
                w.WriteLine($"Empresas: {_quantEmpresas}");
                w.WriteLine($"Sócios: {_quantSocios}");
                w.WriteLine($"Cnaes: {_quantCnaes}");

                w.WriteLine($"Tamanho Lote: {_opcoes.TamanhoLote}");
                w.WriteLine($"Tempo total: {metricas.Sw.ElapsedMilliseconds}ms");
                w.WriteLine($"GC Gen #2: {GC.CollectionCount(2) - metricas.Before2}");
                w.WriteLine($"GC Gen #1: {GC.CollectionCount(1) - metricas.Before1}");
                w.WriteLine($"GC Gen #0: {GC.CollectionCount(0) - metricas.Before0}");
                w.WriteLine("----------------------------------------------------------------------------------------");
            }
        }

        private void SalvarLog(Exception ex, string linha = null)
        {
            var arquivoLog = $@"{_opcoes.DirTrabalho}\Erros.log";
            using (StreamWriter w = File.AppendText(arquivoLog))
            {
                w.WriteLine($"\r\nLog Entry: {_idRegistro} | {DateTime.UtcNow}");
                w.WriteLine(_arquivo);
                w.WriteLine(ex.Message);
                if (linha != null)
                    w.WriteLine($"{linha}<=EOF");
                w.WriteLine("-------------------------------");
            }
            _totalErros++;
        }

        private void SalvarLogImportacao()
        {
            try
            {
                var arquivoLogImportacao = $@"{_opcoes.DirTrabalho}\Importacao.log";
                using (StreamWriter w = File.AppendText(arquivoLogImportacao))
                {
                    w.WriteLine($"{DateTime.Now} | Registros processados: {_idRegistro} em {_arquivo}");
                }
            }
            catch
            {

            }
        }
        #endregion
    }
}
