using DadosPublicosCnpj.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DadosPublicosCnpj.Data.Contexto.Configuracoes.SqlServer
{
    internal class SocioConfiguracao : IEntityTypeConfiguration<Socio>
    {        
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.ToTable("Socios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CnpjEmpresa).HasMaxLength(14);
            builder.Property(x => x.Nome).HasMaxLength(150);
            builder.Property(x => x.CpfCnpj).HasMaxLength(14);
            builder.Property(x => x.Qualificacao).HasMaxLength(2);
            builder.Property(x => x.CodigoPais).HasMaxLength(3);
            builder.Property(x => x.NomePais).HasMaxLength(70);
            builder.Property(x => x.CpfRepresentanteLegal).HasMaxLength(11);
            builder.Property(x => x.NomeRepresentanteLegal).HasMaxLength(60);
            builder.Property(x => x.CodigoQualificacaoRepresentanteLegal).HasMaxLength(2);
        }
    }
}
