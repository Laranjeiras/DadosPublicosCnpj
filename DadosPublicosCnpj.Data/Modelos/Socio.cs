using DadosPublicosCnpj.Data.Tipos;
using DadosPublicosCnpj.Data.Utilidades;
using System;

namespace DadosPublicosCnpj.Data.Modelos
{
    public class Socio
    {
        public long Id { get; set; }

        private string _cnpjEmpresa;
        public string CnpjEmpresa
        {
            get { return _cnpjEmpresa; }
            set { _cnpjEmpresa = ParseHelpers.TratarString(value); }
        }

        public eIdentificadorSocio IdentificadorSocio { get; set; }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = ParseHelpers.TratarString(value); }
        }

        private string _cpfCnpj;
        public string CpfCnpj
        {
            get { return _cpfCnpj; }
            set { _cpfCnpj = ParseHelpers.TratarString(value); }
        }

        private string _qualificacao;
        public string Qualificacao
        {
            get { return _qualificacao; }
            set { _qualificacao = ParseHelpers.TratarString(value); }
        }

        public int CapitalSocial { get; set; }
        public DateTime? DataEntrada { get; set; }

        private string _codigoPais;
        public string CodigoPais
        {
            get { return _codigoPais; }
            set { _codigoPais = ParseHelpers.TratarString(value); }
        }

        private string _nomePais;
        public string NomePais
        {
            get { return _nomePais; }
            set { _nomePais = ParseHelpers.TratarString(value); }
        }

        private string _cpfRepresentanteLegal;
        public string CpfRepresentanteLegal
        {
            get { return _cpfRepresentanteLegal; }
            set { _cpfRepresentanteLegal = ParseHelpers.TratarString(value); }
        }

        private string _nomeRepresentanteLegal;
        public string NomeRepresentanteLegal
        {
            get { return _nomeRepresentanteLegal; }
            set { _nomeRepresentanteLegal = ParseHelpers.TratarString(value); }
        }

        private string _codigoQualificacaoRepresentanteLegal;
        public string CodigoQualificacaoRepresentanteLegal
        {
            get { return _codigoQualificacaoRepresentanteLegal; }
            set { _codigoQualificacaoRepresentanteLegal = value; }
        }
    }
}
