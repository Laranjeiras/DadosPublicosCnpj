using DadosPublicos.CNPJ2022.Dominio.Entidades;

namespace DadosPublicos.CNPJ2022.Dominio.Repositorios
{
    public class EmpresaRepositorioPostgre : BaseRepositorio, IEmpresaRepositorio
    {
        public EmpresaRepositorioPostgre(string connectionString) : base(connectionString)
        {

        }

        public Task SalvarLote(IList<Empresa> empresas)
        {
            throw new NotImplementedException();
        }
    }
}
