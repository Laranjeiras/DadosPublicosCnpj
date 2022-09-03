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

    public enum IdentificadorEstabelecimento
    {
        Matriz = 1,
        Filial = 2
    }

    public enum SituacaoCadastral
    {
        Nula = 1,
        Ativa = 2,
        Suspensa = 3,
        Inapta = 4,
        Baixada = 8
    }
}
