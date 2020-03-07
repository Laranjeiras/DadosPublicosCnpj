using System;
using System.Globalization;

namespace DadosPublicosCnpj.Data.Utilidades
{
    public class ParseHelpers
    {
        public static string TratarString(string value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value))
                return null;
            return value.Trim();
        }

        public static DateTime? StringToDateTime(string value)
        {
            try
            {
                value = $"{value.Substring(6, 2)}/{value.Substring(4, 2)}/{value.Substring(0, 4)}";
                var sucesso = DateTime.TryParse(value, out DateTime data);
                if (sucesso)
                    return data;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
