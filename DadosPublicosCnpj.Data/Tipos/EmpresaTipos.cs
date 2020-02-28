using System.ComponentModel;

namespace DadosPublicosCnpj.Data.Tipos
{
    public enum eIdentificadorEmpresa
    {
        Matriz = 1,
        Filial = 2
    }

    public enum eSituacaoCadastral
    {
        [Description("01")]
        Nula = 1,
        [Description("02")]
        Ativa = 2,
        [Description("03")]
        Suspensa = 3,
        [Description("04")]
        Inapta = 4,
        [Description("08")]
        Baixada = 8
    }

    public enum ePorteEmpresa
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

    public enum eOpcaoSimples
    {
        [Description("Não Optante")]
        NãoOptante = 0,
        [Description("Optante Pelo Simples")]
        OptantePeloSimples = 5,
        [Description("Excluído do Simples")]
        ExcluidoSimples = 6,
        [Description("Optante Pelo Simples")]
        Optante = 7,
        [Description("Excluído do Simples")]
        Excluido = 8
    }
}
