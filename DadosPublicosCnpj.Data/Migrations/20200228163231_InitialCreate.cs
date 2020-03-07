using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DadosPublicosCnpj.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cnaes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    CnaeSecundaria = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnaes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    IdentificadorEmpresa = table.Column<int>(nullable: false),
                    RazaoSocial = table.Column<string>(maxLength: 150, nullable: true),
                    NomeFantasia = table.Column<string>(maxLength: 55, nullable: true),
                    SistuacaoCadastral = table.Column<int>(nullable: false),
                    DataSituacaoCadastral = table.Column<DateTime>(nullable: true),
                    MotivoSituacaoCadastral = table.Column<int>(nullable: false),
                    NomeCidadeExterior = table.Column<string>(maxLength: 55, nullable: true),
                    CodigoPais = table.Column<string>(maxLength: 3, nullable: true),
                    NomePais = table.Column<string>(maxLength: 70, nullable: true),
                    CodigoNaturezaJuridica = table.Column<int>(nullable: false),
                    DataInicioAtividade = table.Column<DateTime>(nullable: true),
                    CnaeFiscal = table.Column<int>(nullable: false),
                    DescricaoTipoLogradouro = table.Column<string>(maxLength: 20, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 60, nullable: true),
                    Numero = table.Column<string>(maxLength: 6, nullable: true),
                    Complemento = table.Column<string>(maxLength: 156, nullable: true),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    CodigoMunicipio = table.Column<int>(nullable: false),
                    Municipio = table.Column<string>(maxLength: 50, nullable: true),
                    DddTelefone1 = table.Column<string>(maxLength: 4, nullable: true),
                    Telefone1 = table.Column<string>(maxLength: 8, nullable: true),
                    DddTelefone2 = table.Column<string>(maxLength: 4, nullable: true),
                    Telefone2 = table.Column<string>(maxLength: 8, nullable: true),
                    Email = table.Column<string>(maxLength: 115, nullable: true),
                    QualificacaoResponsavel = table.Column<int>(nullable: false),
                    CapitalSocial = table.Column<long>(nullable: false),
                    PorteEmpresa = table.Column<int>(nullable: false),
                    OpcaoSimples = table.Column<int>(nullable: false),
                    DataOpcaoSimples = table.Column<DateTime>(nullable: true),
                    DataExclusaoSimples = table.Column<DateTime>(nullable: true),
                    OpcaoPeloMEI = table.Column<bool>(nullable: false),
                    SituacaoEspecial = table.Column<string>(maxLength: 23, nullable: true),
                    DataSituacaoEspecial = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CnpjEmpresa = table.Column<string>(maxLength: 14, nullable: true),
                    IdentificadorSocio = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    CpfCnpj = table.Column<string>(maxLength: 14, nullable: true),
                    Qualificacao = table.Column<string>(maxLength: 2, nullable: true),
                    CapitalSocial = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: true),
                    CodigoPais = table.Column<string>(maxLength: 3, nullable: true),
                    NomePais = table.Column<string>(maxLength: 70, nullable: true),
                    CpfRepresentanteLegal = table.Column<string>(maxLength: 11, nullable: true),
                    NomeRepresentanteLegal = table.Column<string>(maxLength: 60, nullable: true),
                    CodigoQualificacaoRepresentanteLegal = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cnaes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Socios");
        }
    }
}
