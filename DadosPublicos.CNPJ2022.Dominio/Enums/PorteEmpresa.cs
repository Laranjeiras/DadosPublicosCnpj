using System.ComponentModel;

namespace DadosPublicos.CNPJ2022.Dominio.Enums
{
    public enum PorteEmpresa
    {
        [Description("Não Informado")]
        NaoInformado = 0,
        [Description("Micro Empresa")]
        MicroEmpresa = 1,
        [Description("Empresa Pequeno Porte")]
        EmpresaPequenoPorte = 3,
        [Description("Demais")]
        Demais = 5
    }
}
