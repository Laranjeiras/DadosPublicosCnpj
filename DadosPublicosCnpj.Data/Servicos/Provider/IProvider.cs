using DadosPublicosCnpj.Data.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadosPublicosCnpj.Data.Servicos.Provider
{
    public interface IProvider
    {
        Task SalvarAlteracoesAsync(IList<Empresa> empresas, IList<Socio> socios, IList<Cnae> cnaes);
    }
}
