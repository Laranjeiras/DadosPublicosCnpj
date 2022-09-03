using DadosPublicos.CNPJ2022.Dominio.Enums;
using DadosPublicos.CNPJ2022.Dominio.Utils;

namespace DadosPublicos.CNPJ2022.Dominio.Entidades
{
    public class Empresa
    {
        public Guid Id { get; set; }

        private string _cnpjBasico;
        public string CnpjBasico
        {
            get { return _cnpjBasico; }
            set { _cnpjBasico = ParseHelpers.TratarString(value); }
        }

        public int NaturezaJuridica { get; set; }

        private string _razaoSocial;
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial = ParseHelpers.TratarString(value); }
        }

        public int QualificacaoResponsavel { get; set; }
        public decimal CapitalSocial { get; set; }
        public PorteEmpresa PorteEmpresa { get; set; }

        public string? EnteFederativo { get; set; }
    }
}
