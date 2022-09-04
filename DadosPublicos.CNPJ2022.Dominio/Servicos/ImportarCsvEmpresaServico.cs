using DadosPublicos.CNPJ2022.Dominio.Entidades;
using DadosPublicos.CNPJ2022.Dominio.Enums;
using DadosPublicos.CNPJ2022.Dominio.Repositorios;
using DadosPublicos.CNPJ2022.Dominio.Utils;
using Microsoft.Extensions.Logging;

namespace DadosPublicos.CNPJ2022.Dominio.Servicos
{
    public class ImportarCsvEmpresaServico
    {
        private int _arquivosProcessados = 0;        
        private string dirImportar;
        private int registroInicial;
        private int tamanhoLote;
        private readonly IList<Empresa> Empresas;
        private readonly IEmpresaRepositorio repositorio;
        private readonly ILogger<ImportarCsvEmpresaServico> logger;
        private int registroErrados = 0;
        protected int _idRegistro = 0;

        private Metricas metricas;

        public ImportarCsvEmpresaServico(IEmpresaRepositorio repositorio, ILogger<ImportarCsvEmpresaServico> logger)
        {
            this.Empresas = new List<Empresa>();
            this.metricas = new Metricas();
            this.repositorio = repositorio;
            this.logger = logger;
        }

        public async Task Executar(
            string dirImportar,
            int registroInicial,
            int tamanhoLote = 10000)
        {
            this.dirImportar = dirImportar;
            this.registroInicial = registroInicial;
            this.tamanhoLote = tamanhoLote;

            metricas.Inicializar();
            var _dirInfo = new DirectoryInfo(dirImportar);

            var listaNomeArquivos = FileHelpers.BuscarArquivosCompativeis(_dirInfo, "EMPRECSV");
            await ProcessarArquivosAsync(listaNomeArquivos);
            metricas.Finalizar();
            SalvarMetricas(metricas);
        }

        private async Task ProcessarArquivosAsync(IList<string> listaNomeArquivos)
        {
            foreach (var nomeArquivo in listaNomeArquivos)
            {
                ImprimirInfoArquivo(nomeArquivo);
                await PercorrerArquivoAsync(nomeArquivo);
                _arquivosProcessados++;
            }
            Console.WriteLine($"REGISTRO ERRADOS: {registroErrados}");
            Console.WriteLine($"REGISTRO IMPORTADOS: {_idRegistro}");
        }

        private async Task PercorrerArquivoAsync(string arquivo)
        {
            string linha;
            using (StreamReader file = new StreamReader(arquivo))
            {
                while ((linha = await file.ReadLineAsync()) != null)
                {
                    _idRegistro++;

                    if (_idRegistro < registroInicial)
                        continue;

                    var retorno = TratarLinha(linha);
                    if (retorno != null)
                        Empresas.Add(retorno);

                    if (!(tamanhoLote <= 0) && _idRegistro % tamanhoLote == 0) {

                        try
                        {
                            await repositorio.SalvarLote(Empresas);
                            Empresas.Clear();
                            logger.LogInformation($"Lote processado {_idRegistro % tamanhoLote}");
                        }
                        catch (Exception ex)
                        {
                            logger.LogError("Ocorreu um erro ao salvar o lote", ex);
                        }
                    }
                }
            }
        }

        private Empresa TratarLinha(string linha)
        {
            try
            {
                var colunas = linha.Split("\";\"");
                var empresa = new Empresa();

                empresa.CnpjBasico = colunas[0].Replace("\"", string.Empty);
                empresa.RazaoSocial = colunas[1].Replace("\"", string.Empty);
                empresa.NaturezaJuridica = Convert.ToInt32(colunas[2].Replace("\"", string.Empty));
                empresa.QualificacaoResponsavel = Convert.ToInt32(colunas[3].Replace("\"", string.Empty));
                empresa.CapitalSocial = Convert.ToDecimal(colunas[4].Replace("\"", string.Empty));
                empresa.PorteEmpresa = TratarPorteEmpresa(colunas[5]);
                if (colunas.Count() == 7)
                    empresa.EnteFederativo = colunas[6].Replace("\"", string.Empty);

                return empresa;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na linha: {linha}");
                Console.WriteLine(ex.Message);
                registroErrados++;
                return null;
            }
        }

        private PorteEmpresa TratarPorteEmpresa(string porteEmpresa)
        {
            var porte = porteEmpresa.Replace("\"", string.Empty);

            if (int.TryParse(porte, out int iPorte))
                return (PorteEmpresa)iPorte;

            return PorteEmpresa.NaoInformado;
        }


        private void ImprimirInfoArquivo(string arquivo)
        {
            Console.WriteLine($"Aguarde... importando registros do arquivo {arquivo}");
        }

        private void SalvarMetricas(Metricas metricas)
        {
            var arquivoMetricas = $@"Metricas.log";
            using (StreamWriter w = File.AppendText(arquivoMetricas))
            {
                w.WriteLine($"\r\nLog Métricas: {DateTime.Now}");
                w.WriteLine($"Registros processados: {_idRegistro} em {_arquivosProcessados} arquivo(s)");
                w.WriteLine($"Empresas: {_idRegistro}");

                //w.WriteLine($"Tamanho Lote: {_opcoes.TamanhoLote}");
                w.WriteLine($"Tempo total: {metricas.Sw.ElapsedMilliseconds}ms");
                w.WriteLine($"GC Gen #2: {GC.CollectionCount(2) - metricas.Before2}");
                w.WriteLine($"GC Gen #1: {GC.CollectionCount(1) - metricas.Before1}");
                w.WriteLine($"GC Gen #0: {GC.CollectionCount(0) - metricas.Before0}");
                w.WriteLine("----------------------------------------------------------------------------------------");
            }
        }
    }
}
