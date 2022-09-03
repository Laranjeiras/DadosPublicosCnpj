using DadosPublicos.CNPJ2022.Dominio.Enums;

namespace DadosPublicos.CNPJ2022.Dominio.Entidades
{
    public class Estabelecimento
    {
        public string CnpjBasico { get; set; }
        public string CnpjOrdem { get; set; }
        public string CnpjDv { get; set; }
        public IdentificadorEstabelecimento IdentificadorEstabelecimento { get; set; }
        public SituacaoCadastral SituacaoCadastral { get; set; }
        public string DataSituacaoCadastral { get; set; }
        public string MotivoSituacaoCadastral { get; set; }
        public string NomeCidadeExterior { get; set; }
        public int CodigoPais { get; set; }
        public string DataInicioAtividade { get; set; }
        public int CnaeFiscalPrincipal { get; set; }
        public int CnaeFiscalSecundaria { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public int CodigoMunicipio { get; set; }
        public string DDD1 { get; set; }
        public string Telefone1 { get; set; }
        public string DDD2 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }

        public string SituacaoEspecial { get; set; }
        public string DataSituacaoEspecial { get; set; }

    }
}
