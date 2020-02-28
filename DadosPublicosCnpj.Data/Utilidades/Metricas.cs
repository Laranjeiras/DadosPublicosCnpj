using System;
using System.Diagnostics;

namespace DadosPublicosCnpj.Data.Utilidades
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
            Before2 = GC.CollectionCount(2);
            Before1 = GC.CollectionCount(1);
            Before0 = GC.CollectionCount(0);
        }

        public void Inicializar()
        {
            Sw.Start();
        }

        public void Finalizar()
        {
            Sw.Stop();
        }
    }
}
