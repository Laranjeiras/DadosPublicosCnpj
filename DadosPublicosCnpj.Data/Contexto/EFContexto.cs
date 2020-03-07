using DadosPublicosCnpj.Data.Contexto.Configuracoes.SqlServer;
using DadosPublicosCnpj.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DadosPublicosCnpj.Data.Contexto
{
    public class EFContexto : DbContext
    {
        public static string SqlLiteDatabaseName = "CpfCnpjPublico.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Filename={SqlLiteDatabaseName}");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new CnaeConfiguracao());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguracao());
            modelBuilder.ApplyConfiguration(new SocioConfiguracao());
        }

        public DbSet<Cnae> Cnaes { get; protected set; }
        public DbSet<Empresa> Empresas { get; protected set; }
        public DbSet<Socio> Socios { get; protected set; }

        internal void Salvar(IList<Empresa> empresas)
        {
            Empresas.AddRange(empresas);
        }

        internal void Salvar(IList<Socio> socios)
        {
            Socios.AddRange(socios);
        }

        internal void Salvar(IList<Cnae> cnaes)
        {
            Cnaes.AddRange(cnaes);
        }

        internal async Task SalvarAlteracoes()
        {
            await SaveChangesAsync();
        }
    }
}
