using DadosPublicosCnpj.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DadosPublicosCnpj.Data.Contexto.Configuracoes.SqlServer
{
    internal class CnaeConfiguracao : IEntityTypeConfiguration<Cnae>
    {
        public void Configure(EntityTypeBuilder<Cnae> builder)
        {
            builder.ToTable("Cnaes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Cnpj).HasMaxLength(14);
        }
    }
}
