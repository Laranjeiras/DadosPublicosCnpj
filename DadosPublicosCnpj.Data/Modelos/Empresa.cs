
using DadosPublicosCnpj.Data.Tipos;
using DadosPublicosCnpj.Data.Utilidades;

namespace DadosPublicosCnpj.Data.Modelos
{
    public class Empresa
    {
        private string _cnpj;
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = StringHelpers.TratarString(value); }
        }

        public eIdentificadorEmpresa IdentificadorEmpresa { get; set; }

        private string _razaoSocial;
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial = StringHelpers.TratarString(value); }
        }

        private string _nomeFantasia;
        public string NomeFantasia
        {
            get { return _nomeFantasia; }
            set { _nomeFantasia = StringHelpers.TratarString(value); }
        }

        public eSituacaoCadastral SistuacaoCadastral { get; set; }

        public int DataSituacaoCadastral { get; set; }
        public int MotivoSituacaoCadastral { get; set; }

        private string _nomeCidadeExterior;
        public string NomeCidadeExterior
        {
            get { return _nomeCidadeExterior; }
            set { _nomeCidadeExterior = StringHelpers.TratarString(value); }
        }

        private string _codigoPais;
        public string CodigoPais
        {
            get { return _codigoPais; }
            set { _codigoPais = StringHelpers.TratarString(value); }
        }

        private string _nomePais;
        public string NomePais
        {
            get { return _nomePais; }
            set { _nomePais = StringHelpers.TratarString(value); }
        }

        public int CodigoNaturezaJuridica { get; set; }
        public int DataInicioAtividade { get; set; }
        public int CnaeFiscal { get; set; }

        private string _descricaoTipoLogradouro;
        public string DescricaoTipoLogradouro
        {
            get { return _descricaoTipoLogradouro; }
            set { _descricaoTipoLogradouro = StringHelpers.TratarString(value); }
        }

        private string _logradouro;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = StringHelpers.TratarString(value); }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set { _numero = StringHelpers.TratarString(value); }
        }

        private string _complemento;
        public string Complemento
        {
            get { return _complemento; }
            set { _complemento = StringHelpers.TratarString(value); }
        }

        private string _bairro;
        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = StringHelpers.TratarString(value); }
        }

        private string _cep;
        public string CEP
        {
            get { return _cep; }
            set { _cep = StringHelpers.TratarString(value); }
        }

        private string _uf;
        public string UF
        {
            get { return _uf; }
            set { _uf = StringHelpers.TratarString(value); }
        }

        public int CodigoMunicipio { get; set; }

        private string _municipio;
        public string Municipio
        {
            get { return _municipio; }
            set { _municipio = StringHelpers.TratarString(value); }
        }

        private string _dddTelefone1;
        public string DddTelefone1
        {
            get { return _dddTelefone1; }
            set { _dddTelefone1 = StringHelpers.TratarString(value); }
        }

        private string _telefone1;
        public string Telefone1
        {
            get { return _telefone1; }
            set { _telefone1 = StringHelpers.TratarString(value); }
        }

        private string _dddTelefone2;
        public string DddTelefone2
        {
            get { return _dddTelefone2; }
            set { _dddTelefone2 = StringHelpers.TratarString(value); }
        }

        private string _telefone2;
        public string Telefone2
        {
            get { return _telefone2; }
            set { _telefone2 = StringHelpers.TratarString(value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = StringHelpers.TratarString(value); }
        }

        public int QualificacaoResponsavel { get; set; }
        public long CapitalSocial { get; set; }

        public ePorteEmpresa PorteEmpresa { get; set; }
        public eOpcaoSimples OpcaoSimples { get; set; }
        public int DataOpcaoSimples { get; set; }
        public int DataExclusaoSimples { get; set; }
        public bool OpcaoPeloMEI { get; set; }

        private string _situacaoEspecial;
        public string SituacaoEspecial
        {
            get { return _situacaoEspecial; }
            set { _situacaoEspecial = StringHelpers.TratarString(value); }
        }
        public int DataSituacaoEspecial { get; set; }


    }
}
