using System.Diagnostics;

namespace DadosPublicos.CNPJ2022.Dominio.Utils
{
    public class Metricas
    {
        public Stopwatch Sw { get; private set; }
        public int Before0 { get; private set; }
        public int Before1 { get; private set; }
        public int Before2 { get; private set; }

        public Metricas()
        {
            Sw = new Stopwatch();
        }

        public void Inicializar()
        {
            Before2 = GC.CollectionCount(2);
            Before1 = GC.CollectionCount(1);
            Before0 = GC.CollectionCount(0);
            Sw.Start();
        }

        public void Finalizar()
        {
            Sw.Stop();
        }
    }
}
