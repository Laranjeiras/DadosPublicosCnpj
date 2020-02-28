using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DadosPublicosCnpj.Data.Utilidades
{
    public class FileHelpers
    {
        private static Regex regex = new Regex(@"^[.]{1}[L]{1}\d{5}");
        

        public static IList<string> BuscarArquivosCompativeis(DirectoryInfo dir)
        {
            var listaNomeArquivos = new List<string>();
            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.FullName.Length < 6)
                    continue;

                var extensao = file.FullName.Substring(file.FullName.Length - 7, 7);
                
                Match match = regex.Match(extensao);
                if (!match.Success)
                    continue;
                
                listaNomeArquivos.Add(file.FullName);
            }

            foreach (DirectoryInfo subDir in dir.GetDirectories())
                listaNomeArquivos.AddRange(BuscarArquivosCompativeis(subDir));

            return listaNomeArquivos;
        }
    }
}
