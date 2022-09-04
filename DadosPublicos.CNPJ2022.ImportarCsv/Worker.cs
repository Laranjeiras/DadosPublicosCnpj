using DadosPublicos.CNPJ2022.Dominio.Servicos;

namespace DadosPublicos.CNPJ2022.ImportarCsv
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            this.serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                var servicoEmp = scope.ServiceProvider.GetService<ImportarCsvEmpresaServico>();
                //var servicoEmp = new ImportarCsvEmpresaServico(@"I:\DadosPublicos CNPJ\2022\Empresas", 0);
                await servicoEmp.Executar(@"I:\DadosPublicos CNPJ\2022\Empresas", 0);
            }
        }
    }
}