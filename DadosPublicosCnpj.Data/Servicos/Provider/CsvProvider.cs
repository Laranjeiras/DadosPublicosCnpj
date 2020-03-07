using CsvHelper;
using DadosPublicosCnpj.Data.Modelos;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DadosPublicosCnpj.Data.Servicos.Provider
{
    public class CsvProvider : IProvider
    {
        readonly string _diretorioTrabalho;

        public CsvProvider(string diretorioTrabalho)
        {
            _diretorioTrabalho = diretorioTrabalho;
            EscreverCabecalhoCsv<Empresa>();
            EscreverCabecalhoCsv<Socio>();
            EscreverCabecalhoCsv<Cnae>();
        }

        public async Task SalvarAlteracoesAsync(IList<Empresa> empresas, IList<Socio> socios, IList<Cnae> cnaes)
        {
            SalvarCsv(empresas);
            SalvarCsv(socios);
            SalvarCsv(cnaes);
        }

        #region Arquivo CSV
        private string ObterNomeArquivo<T>()
        {
            var sTipo = typeof(T).ToString();
            sTipo = sTipo.Replace("DadosPublicosCnpj.Data.Modelos.", string.Empty);
            var nomeArquivo = $@"{_diretorioTrabalho}\{sTipo}s.csv";
            return nomeArquivo;
        }

        public void EscreverCabecalhoCsv<T>()
        {
            var nomeArquivo = ObterNomeArquivo<T>();

            using (var fileStream = new FileStream(nomeArquivo, FileMode.Append))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.GetCultureInfo("pt-br")))
                    {
                        csvWriter.Configuration.Delimiter = ";";
                        csvWriter.Configuration.HasHeaderRecord = true;
                        csvWriter.Configuration.AutoMap<T>();
                        csvWriter.WriteHeader<T>();
                        csvWriter.NextRecord();
                        writer.Flush();
                    }
                }
            }
        }

        public void SalvarCsv<T>(IList<T> lista)
        {
            var sTipo = typeof(T).ToString();

            var nomeArquivo = ObterNomeArquivo<T>();
            using (var fileStream = new FileStream(nomeArquivo, FileMode.Append))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    using (var csvWriter = new CsvWriter(writer, System.Globalization.CultureInfo.GetCultureInfo("pt-br")))
                    {
                        csvWriter.Configuration.Delimiter = ";";
                        csvWriter.Configuration.HasHeaderRecord = false;
                        csvWriter.Configuration.AutoMap<T>();

                        csvWriter.WriteRecords(lista);
                        writer.Flush();
                    }
                }
            }
        }
        #endregion
    }
}
