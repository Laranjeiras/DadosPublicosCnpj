
namespace DadosPublicos.CNPJ2022.Dominio.Utils
{
    public class FileHelpers
    {
        public static IList<string> BuscarArquivosCompativeis(DirectoryInfo dir, string extensao)
        {
            var listaNomeArquivos = new List<string>();
            var files = dir.GetFiles().OrderBy(x => x.FullName);
            foreach (FileInfo file in files)
            {
                if (file.Extension != $".{extensao}")
                    continue;              

                listaNomeArquivos.Add(file.FullName);
            }

            foreach (DirectoryInfo subDir in dir.GetDirectories())
                listaNomeArquivos.AddRange(BuscarArquivosCompativeis(subDir, extensao));

            return listaNomeArquivos;
        }
    }
}
