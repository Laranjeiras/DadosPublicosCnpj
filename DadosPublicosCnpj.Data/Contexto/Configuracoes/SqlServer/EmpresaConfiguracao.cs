using DadosPublicosCnpj.Data.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DadosPublicosCnpj.Data.Contexto.Configuracoes.SqlServer
{
    internal class EmpresaConfiguracao : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.RazaoSocial).HasMaxLength(150);
            builder.Property(x => x.NomeFantasia).HasMaxLength(55);
            builder.Property(x => x.Cnpj).HasMaxLength(14);
            builder.Property(x => x.NomeCidadeExterior).HasMaxLength(55);
            builder.Property(x => x.CodigoPais).HasMaxLength(3);
            builder.Property(x => x.NomePais).HasMaxLength(70);
            builder.Property(x => x.DescricaoTipoLogradouro).HasMaxLength(20);
            builder.Property(x => x.Logradouro).HasMaxLength(60);
            builder.Property(x => x.Numero).HasMaxLength(6);
            builder.Property(x => x.Complemento).HasMaxLength(156);
            builder.Property(x => x.Bairro).HasMaxLength(50);
            builder.Property(x => x.UF).HasMaxLength(2);
            builder.Property(x => x.Municipio).HasMaxLength(50);
            builder.Property(x => x.DddTelefone1).HasMaxLength(4);
            builder.Property(x => x.DddTelefone2).HasMaxLength(4);
            builder.Property(x => x.Telefone1).HasMaxLength(8);
            builder.Property(x => x.Telefone2).HasMaxLength(8);
            builder.Property(x => x.Email).HasMaxLength(115);
            builder.Property(x => x.SituacaoEspecial).HasMaxLength(23);
        }
    }
}
