using DadosPublicos.CNPJ2022.Dominio.Repositorios;
using DadosPublicos.CNPJ2022.Dominio.Servicos;
using DadosPublicos.CNPJ2022.ImportarCsv;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        //services.AddSingleton<IEmpresaRepositorio, EmpresaRepositorioSqlServer>(x => new EmpresaRepositorioSqlServer("Server=(localdb)\\mssqllocaldb;Database=DadosPublicos;Trusted_Connection=True;MultipleActiveResultSets=true;"));
        services.AddSingleton<IEmpresaRepositorio, EmpresaRepositorioPostgre>(x => new EmpresaRepositorioPostgre(""));
        services.AddSingleton<ImportarCsvEmpresaServico>();
    })
    .Build();

await host.RunAsync();
