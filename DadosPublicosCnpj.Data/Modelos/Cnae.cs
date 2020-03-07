using DadosPublicosCnpj.Data.Utilidades;
using System;

namespace DadosPublicosCnpj.Data.Modelos
{
	public class Cnae
    {
		public long Id { get; set; }

		private string _cnpj;
		public string Cnpj
		{
			get { return _cnpj; }
			set { _cnpj = ParseHelpers.TratarString(value); }
		}

		public long CnaeSecundaria { get; set; }
	}
}
