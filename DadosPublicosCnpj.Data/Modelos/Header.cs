using DadosPublicosCnpj.Data.Utilidades;

namespace DadosPublicosCnpj.Data.Modelos
{
	public class Header
    {
		private string _nomeArquivo;
		public string NomeArquivo
		{
			get { return _nomeArquivo; }
			set { _nomeArquivo = StringHelpers.TratarString(value); }
		}

		public int DataGravacao { get; set; }
		public int NumeroRemessa { get; set; }
	}
}
