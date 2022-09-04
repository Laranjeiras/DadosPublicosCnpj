namespace DadosPublicos.CNPJ2022.Dominio.Repositorios
{
    public abstract class BaseRepositorio
    {
        protected string ConnectionString { get; set; }

        public BaseRepositorio(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
