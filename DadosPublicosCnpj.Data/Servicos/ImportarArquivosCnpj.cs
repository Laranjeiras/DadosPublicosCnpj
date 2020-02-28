using DadosPublicosCnpj.Data.Modelos;
using DadosPublicosCnpj.Data.Tipos;
using DadosPublicosCnpj.Data.Utilidades;
using System;
using System.Diagnostics;
using System.IO;

namespace DadosPublicosCnpj.Data.Servicos
{
    public class ImportarArquivosCnpj
    {
        int _totalErros = 0;
        int _idRegistro = 0;
        string _arquivo;
        readonly string _diretorioTrabalho;
        readonly string _arquivoLog;
        readonly long _registroInicial;

        public ImportarArquivosCnpj(string diretorioTrabalho, string arquivoLog, long registroInicial = 0)
        {
            _diretorioTrabalho = diretorioTrabalho;
            _arquivoLog = arquivoLog;
            _registroInicial = registroInicial;
        }

        public void Executar()
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);

            DirectoryInfo dirInfo = new DirectoryInfo(_diretorioTrabalho);

            var listaNomeArquivos = FileHelpers.BuscarArquivosCompativeis(dirInfo);

            sw.Start();
            foreach (var nomeArquivo in listaNomeArquivos)
            {
                _arquivo = nomeArquivo;
                TratarArquivo(nomeArquivo);
            }
            sw.Stop();

            Console.WriteLine($"Total de Registros: {_idRegistro}");

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #2  : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1  : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0  : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("Done!");
        }
        
        private void TratarArquivo(string nomeArquivo)
        {
            string linha;
            StreamReader file = new StreamReader(nomeArquivo);
            Trailler trailler = null;
            while ((linha = file.ReadLine()) != null)
            {
                _idRegistro++;
                if (_idRegistro < _registroInicial)
                    continue;

                var tipoRegistro = linha.Substring(0, 1);

                switch (tipoRegistro)
                {
                    case "0":
                        var header = MapearHeader(linha);
                        break;
                    case "1":
                        var empresa = MapearEmpresa(linha);
                        break;
                    case "2":
                        var socio = MapearSocio(linha);
                        break;
                    case "6":
                        var cnae = MapearCnae(linha);
                        break;
                    case "9":
                        trailler = MapearTrailler(linha);
                        break;
                }
            }
        }

        private Header MapearHeader(string linha)
        {
            try
            {
                var header = new Header();
                header.NomeArquivo = linha.Substring(17, 11);
                header.DataGravacao = int.Parse(linha.Substring(28, 8));
                header.NumeroRemessa = int.Parse(linha.Substring(36, 8));
                return header;
            }
            catch (Exception ex)
            {
                GerarLog(ex, linha);
            }
            return null;
        }

        private Trailler MapearTrailler(string linha)
        {
            try
            {
                var trailler = new Trailler()
                {
                    TotalRegistros = long.Parse(linha.Substring(44, 11)),
                    TotalRegistrosT1 = long.Parse(linha.Substring(17, 9)),
                    TotalRegistrosT2 = long.Parse(linha.Substring(26, 9)),
                    TotalRegistrosT3 = long.Parse(linha.Substring(35, 9))
                };
                return trailler;
            }
            catch (Exception ex)
            {
                GerarLog(ex, linha);
            }
            return null;
        }

        public Empresa MapearEmpresa(string linha)
        {
            try
            {
                var empresa = new Empresa();
                empresa.Cnpj = linha.Substring(3, 14);
                empresa.IdentificadorEmpresa = (eIdentificadorEmpresa)int.Parse(linha.Substring(17, 1));
                empresa.RazaoSocial = linha.Substring(18, 150);
                empresa.NomeFantasia = linha.Substring(168, 55);
                empresa.SistuacaoCadastral = (eSituacaoCadastral)int.Parse(linha.Substring(223, 2));
                empresa.DataSituacaoCadastral = int.Parse(linha.Substring(225, 8));
                empresa.MotivoSituacaoCadastral = int.Parse(linha.Substring(233, 2));
                empresa.NomeCidadeExterior = linha.Substring(235, 55);
                empresa.CodigoPais = linha.Substring(290, 3);
                empresa.NomePais = linha.Substring(293, 70);
                empresa.CodigoNaturezaJuridica = int.Parse(linha.Substring(363, 4));
                empresa.DataInicioAtividade = int.Parse(linha.Substring(367, 8));
                empresa.CnaeFiscal = int.Parse(linha.Substring(375, 7));
                empresa.DescricaoTipoLogradouro = linha.Substring(382, 20);
                empresa.Logradouro = linha.Substring(402, 60);
                empresa.Numero = linha.Substring(462, 6);
                empresa.Complemento = linha.Substring(468, 156);
                empresa.Bairro = linha.Substring(624, 50);
                empresa.CEP = linha.Substring(674, 8);
                empresa.UF = linha.Substring(682, 2);
                empresa.CodigoMunicipio = int.Parse(linha.Substring(684, 4));
                empresa.Municipio = linha.Substring(688, 50);
                empresa.DddTelefone1 = linha.Substring(738, 4);
                empresa.Telefone1 = linha.Substring(742, 8);
                empresa.DddTelefone2 = linha.Substring(750, 4);
                empresa.Telefone2 = linha.Substring(754, 8);
                empresa.Email = linha.Substring(774, 115);
                empresa.QualificacaoResponsavel = int.Parse(linha.Substring(889, 2));
                empresa.CapitalSocial = long.Parse(linha.Substring(891, 14));
                empresa.PorteEmpresa = (ePorteEmpresa)int.Parse(linha.Substring(905, 2));
                empresa.OpcaoSimples = (eOpcaoSimples)int.Parse(linha.Substring(907, 1));
                empresa.DataOpcaoSimples = int.Parse(linha.Substring(908, 8));
                empresa.DataExclusaoSimples = int.Parse(linha.Substring(916, 8));
                empresa.OpcaoPeloMEI = linha.Substring(924, 1) == "S" ? true : false;
                empresa.SituacaoEspecial = linha.Substring(925, 23);
                int.TryParse(linha.Substring(948, 8), out int dataSituacaoEspecial);
                empresa.DataSituacaoEspecial = dataSituacaoEspecial;
                return empresa;

            }
            catch (Exception ex)
            {
                GerarLog(ex, linha);
            }
            return null;
        }

        public Socio MapearSocio(string linha)
        {
            try
            {
                var socio = new Socio();
                socio.CnpjEmpresa = linha.Substring(3, 14);
                socio.IdentificadorSocio = (eIdentificadorSocio)int.Parse(linha.Substring(17, 1));
                socio.Nome = linha.Substring(18, 150);
                socio.CpfCnpj = linha.Substring(168, 14);
                socio.Qualificacao = linha.Substring(182, 2);
                socio.CapitalSocial = int.Parse(linha.Substring(184, 5));
                socio.DataEntrada = int.Parse(linha.Substring(189, 8));
                socio.CodigoPais = linha.Substring(197, 3);
                socio.NomeNacionalidade = linha.Substring(200, 70);
                socio.CpfRepresentanteLegal = linha.Substring(270, 11);
                socio.NomeRepresentanteLegal = linha.Substring(281, 60);
                socio.CodigoQualificacaoRepresentanteLegal = linha.Substring(341, 2);
                return socio;
            }
            catch (Exception ex)
            {
                GerarLog(ex, linha);
            }
            return null;
        }

        public Cnae MapearCnae(string linha)
        {
            try
            {
                var cnae = new Cnae();
                cnae.Cnpj = linha.Substring(3, 14);
                cnae.CnaeSecundaria = long.Parse(linha.Substring(17, 7));
                return cnae;
            }
            catch (Exception ex)
            {
                GerarLog(ex, linha);
            }
            return null;
        }

        public void GerarLog(Exception ex, string linha)
        {
            using (StreamWriter w = File.AppendText(_arquivoLog))
            {
                w.WriteLine($"\r\nLog Entry: {_idRegistro} | {DateTime.UtcNow}");
                w.WriteLine(_arquivo);
                w.WriteLine(ex.Message);
                w.WriteLine($"{linha}<=EOF");
                w.WriteLine("-------------------------------");
            }
            _totalErros++;
        }
    }
}
