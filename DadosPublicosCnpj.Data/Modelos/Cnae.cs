using DadosPublicosCnpj.Data.Utilidades;

namespace DadosPublicosCnpj.Data.Modelos
{
	public class Cnae
    {
		private string _cnpj;
		public string Cnpj
		{
			get { return _cnpj; }
			set { _cnpj = StringHelpers.TratarString(value); }
		}

		public long CnaeSecundaria { get; set; }
	}
}
