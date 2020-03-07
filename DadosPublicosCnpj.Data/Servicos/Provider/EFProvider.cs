using DadosPublicosCnpj.Data.Contexto;
using DadosPublicosCnpj.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadosPublicosCnpj.Data.Servicos.Provider
{
    public class EFProvider : IProvider
    {
        readonly EFContexto _contexto;

        public EFProvider()
        {
            _contexto = new EFContexto();
            _contexto.Database.Migrate();
        }

        public async Task SalvarAlteracoesAsync(IList<Empresa> empresas, IList<Socio> socios, IList<Cnae> cnaes)
        {
            _contexto.Salvar(empresas);
            await _contexto.SalvarAlteracoes();
            _contexto.Salvar(socios);
            await _contexto.SalvarAlteracoes();
            _contexto.Salvar(cnaes);
            await _contexto.SalvarAlteracoes();
        }
    }
}
