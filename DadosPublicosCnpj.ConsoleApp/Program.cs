using DadosPublicosCnpj.Data.Contexto;
using DadosPublicosCnpj.Data.Servicos;
using DadosPublicosCnpj.Data.Servicos.Provider;
using System.Threading.Tasks;

namespace DadosPublicosCnpj.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new OpcoesServico();            
            config.DirArqImportar = @"C:\Laranjeiras\OutputCnpjPublico\Fontes";
            config.DirTrabalho = @"C:\Laranjeiras\OutputCnpjPublico";
            config.TamanhoLote = 100_000;
            config.RegistroInicial = 0_000_000;
            config.QuantRegistrosImportar = 1_000_000_000;

            EFContexto.SqlLiteDatabaseName = $"SqlLite_DadosPublicosCnpj.db";

            // Provider para EF/Sqlite
            //var provider = new EFProvider();
            var provider = new CsvProvider(config.DirTrabalho);
            var servico = new ImportarServico(provider, config);
            await servico.ExecutarAsync();
        }
    }
}
