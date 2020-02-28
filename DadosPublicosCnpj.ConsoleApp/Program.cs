using DadosPublicosCnpj.Data.Servicos;
using System;

namespace DadosPublicosCnpj.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var registroInicialImportacao = 0;
            var servico = new ImportarArquivosCnpj(@"E:\DadosPublicos CNPJ", @"E:\DadosPublicos CNPJ\Log.txt", registroInicialImportacao);
            servico.Executar();
            Console.ReadKey();
        }
    }
}
