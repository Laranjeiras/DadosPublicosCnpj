namespace DadosPublicosCnpj.Data.Utilidades
{
    public class StringHelpers
    {
        public static string TratarString(string value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value))
                return null;
            return value.Trim();
        }
    }
}
