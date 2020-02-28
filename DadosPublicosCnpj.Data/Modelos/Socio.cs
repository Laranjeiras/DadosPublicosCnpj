using DadosPublicosCnpj.Data.Tipos;
using DadosPublicosCnpj.Data.Utilidades;

namespace DadosPublicosCnpj.Data.Modelos
{
    public class Socio
    {
        private string _cnpjEmpresa;
        public string CnpjEmpresa
        {
            get { return _cnpjEmpresa; }
            set { _cnpjEmpresa = StringHelpers.TratarString(value); }
        }

        public eIdentificadorSocio IdentificadorSocio { get; set; }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = StringHelpers.TratarString(value); }
        }

        private string _cpfCnpj;
        public string CpfCnpj
        {
            get { return _cpfCnpj; }
            set { _cpfCnpj = StringHelpers.TratarString(value); }
        }

        private string _qualificacao;
        public string Qualificacao
        {
            get { return _qualificacao; }
            set { _qualificacao = StringHelpers.TratarString(value); }
        }

        public int CapitalSocial { get; set; }
        public int DataEntrada { get; set; }

        private string _codigoPais;
        public string CodigoPais
        {
            get { return _codigoPais; }
            set { _codigoPais = StringHelpers.TratarString(value); }
        }

        private string _nomeNacionalidade;
        public string NomeNacionalidade
        {
            get { return _nomeNacionalidade; }
            set { _nomeNacionalidade = StringHelpers.TratarString(value); }
        }

        private string _cpfRepresentanteLegal;
        public string CpfRepresentanteLegal
        {
            get { return _cpfRepresentanteLegal; }
            set { _cpfRepresentanteLegal = StringHelpers.TratarString(value); }
        }

        private string _nomeRepresentanteLegal;
        public string NomeRepresentanteLegal
        {
            get { return _nomeRepresentanteLegal; }
            set { _nomeRepresentanteLegal = StringHelpers.TratarString(value); }
        }

        private string _codigoQualificacaoRepresentanteLegal;
        public string CodigoQualificacaoRepresentanteLegal
        {
            get { return _codigoQualificacaoRepresentanteLegal; }
            set { _codigoQualificacaoRepresentanteLegal = value; }
        }
    }
}
