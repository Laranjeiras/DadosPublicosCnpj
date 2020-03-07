using DadosPublicosCnpj.Data.Tipos;
using DadosPublicosCnpj.Data.Utilidades;
using System.Collections.Generic;

namespace DadosPublicosCnpj.Data.Modelos
{
    internal class Mapeador
    {
        internal static void MapearEmpresa(ref IList<Empresa> empresas, string linha, long id)
        {
            var empresa = new Empresa();
            empresa.Id = id;
            empresa.Cnpj = linha.Substring(3, 14);
            empresa.IdentificadorEmpresa = (eIdentificadorEmpresa)int.Parse(linha.Substring(17, 1)); 
            empresa.RazaoSocial = linha.Substring(18, 150);
            empresa.NomeFantasia = linha.Substring(168, 55);
            empresa.SistuacaoCadastral = (eSituacaoCadastral)int.Parse(linha.Substring(223, 2));
            empresa.DataSituacaoCadastral = ParseHelpers.StringToDateTime(linha.Substring(225, 8));
            empresa.MotivoSituacaoCadastral = int.Parse(linha.Substring(233, 2));
            empresa.NomeCidadeExterior = linha.Substring(235, 55);
            empresa.CodigoPais = linha.Substring(290, 3);
            empresa.NomePais = linha.Substring(293, 70);
            empresa.CodigoNaturezaJuridica = int.Parse(linha.Substring(363, 4));
            empresa.DataInicioAtividade = ParseHelpers.StringToDateTime(linha.Substring(367, 8));
            empresa.CnaeFiscal = int.Parse(linha.Substring(375, 7));
            empresa.DescricaoTipoLogradouro = linha.Substring(382, 20);
            empresa.Logradouro = linha.Substring(402, 60);
            empresa.Numero = linha.Substring(462, 6);
            empresa.Complemento = linha.Substring(468, 156);
            empresa.Bairro = linha.Substring(624, 50);
            empresa.CEP = linha.Substring(674, 8);
            empresa.UF = linha.Substring(682, 2);
            empresa.CodigoMunicipio = int.Parse(linha.Substring(684, 4));
            empresa.Municipio = linha.Substring(688, 50);
            empresa.DddTelefone1 = linha.Substring(738, 4);
            empresa.Telefone1 = linha.Substring(742, 8);
            empresa.DddTelefone2 = linha.Substring(750, 4);
            empresa.Telefone2 = linha.Substring(754, 8);
            empresa.Email = linha.Substring(774, 115);
            empresa.QualificacaoResponsavel = int.Parse(linha.Substring(889, 2));
            empresa.CapitalSocial = long.Parse(linha.Substring(891, 14));
            empresa.PorteEmpresa = (ePorteEmpresa)int.Parse(linha.Substring(905, 2));
            empresa.OpcaoSimples = (eOpcaoSimples)int.Parse(linha.Substring(907, 1));
            empresa.DataOpcaoSimples = ParseHelpers.StringToDateTime(linha.Substring(908, 8));
            empresa.DataExclusaoSimples = ParseHelpers.StringToDateTime(linha.Substring(916, 8));
            empresa.OpcaoPeloMEI = linha.Substring(924, 1) == "S" ? true : false;
            empresa.SituacaoEspecial = linha.Substring(925, 23);
            empresa.DataSituacaoEspecial = ParseHelpers.StringToDateTime(linha.Substring(948, 8));
            empresas.Add(empresa);
        }

        internal static void MapearSocio(ref IList<Socio> socios, string linha, long id)
        {
            var socio = new Socio();
            socio.Id = id;
            socio.CnpjEmpresa = linha.Substring(3, 14);
            socio.IdentificadorSocio = (eIdentificadorSocio)int.Parse(linha.Substring(17, 1));
            socio.Nome = linha.Substring(18, 150);
            socio.CpfCnpj = linha.Substring(168, 14);
            socio.Qualificacao = linha.Substring(182, 2);
            socio.CapitalSocial = int.Parse(linha.Substring(184, 5));
            socio.DataEntrada = ParseHelpers.StringToDateTime(linha.Substring(189, 8));
            socio.CodigoPais = linha.Substring(197, 3);
            socio.NomePais = linha.Substring(200, 70);
            socio.CpfRepresentanteLegal = linha.Substring(270, 11);
            socio.NomeRepresentanteLegal = linha.Substring(281, 60);
            socio.CodigoQualificacaoRepresentanteLegal = linha.Substring(341, 2);
            socios.Add(socio);
        }

        internal static void MapearCnae(ref IList<Cnae> _cnaes, string linha, long id)
        {
            var lista = ExtrairCnaes(linha);

            foreach (var item in lista)
            {
                var cnae = new Cnae();
                cnae.Id = id;
                cnae.Cnpj = linha.Substring(3, 14);
                cnae.CnaeSecundaria = long.Parse(item);
                _cnaes.Add(cnae);
            }
        }

        internal static List<string> ExtrairCnaes(string linha)
        {
            var cnaesTmp = new List<string>();

            for (int i = 0; i < 99; i += 7)
            {
                var tmp = linha.Substring(i + 17, 7);
                if (tmp == "0000000")
                    return cnaesTmp;
                cnaesTmp.Add(tmp);
            }
            return cnaesTmp;
        }

        internal static Header MapearHeader(string linha)
        {
            var header = new Header();
            header.NomeArquivo = linha.Substring(17, 11);
            header.DataGravacao = int.Parse(linha.Substring(28, 8));
            header.NumeroRemessa = int.Parse(linha.Substring(36, 8));
            return header;
        }

        internal static Trailler MapearTrailler(string linha)
        {
            var trailler = new Trailler();
            trailler.TotalRegistros = long.Parse(linha.Substring(44, 11));
            trailler.TotalRegistrosT1 = long.Parse(linha.Substring(17, 9));
            trailler.TotalRegistrosT2 = long.Parse(linha.Substring(26, 9));
            trailler.TotalRegistrosT2 = long.Parse(linha.Substring(26, 9));
            trailler.TotalRegistrosT3 = long.Parse(linha.Substring(35, 9));
            return trailler;
        }
    }
}
