using DadosPublicos.CNPJ2022.Dominio.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace DadosPublicos.CNPJ2022.Dominio.Repositorios
{
    public class EmpresaRepositorioSqlServer : BaseRepositorio, IEmpresaRepositorio
    {
        private readonly SqlConnection db;

        public EmpresaRepositorioSqlServer(string connectionString) : base(connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        public async Task SalvarLote(IList<Empresa> empresas)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                await db.OpenAsync();
                foreach (var empresa in empresas)
                {
                    try
                    {
                        var query = @"INSERT INTO EMPRESAS (CnpjBasico, NaturezaJuridica, RazaoSocial, QualificacaoResponsavel, CapitalSocial, PorteEmpresa, EnteFederativo) " +
                            "VALUES (@CnpjBasico, @NaturezaJuridica, @RazaoSocial, @QualificacaoResponsavel, @CapitalSocial, @PorteEmpresa, @EnteFederativo)";
                        await db.ExecuteAsync(query, empresa);
                    } 
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
                            Console.WriteLine("Registro Duplicado");
                        else 
                            throw ex;
                    }

                }
            }
        }
    }
}
