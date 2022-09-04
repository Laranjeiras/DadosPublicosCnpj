using DadosPublicos.CNPJ2022.Dominio.Entidades;

namespace DadosPublicos.CNPJ2022.Dominio.Repositorios
{
    public interface IEmpresaRepositorio
    {
        Task SalvarLote(IList<Empresa> empresas);
    }
}
