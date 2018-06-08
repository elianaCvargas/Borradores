using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Llamada
    {
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public Llamada(float duracion, string numeroDestino, string numeroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = numeroDestino;
            this.nroOrigen = numeroOrigen;
        }

        public float Duracion { get { return this.duracion; } }
        public string NumeroOrigen { get { return this.nroOrigen; } }
        public string NumeroDestino { get { return this.nroDestino; } }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Llamada: {0} - {1} - {2}\n", this.duracion, this.nroDestino, this.nroOrigen);
            return sb.ToString();
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if (llamada1.duracion > llamada2.duracion)
                return 1;
            if (llamada1.duracion < llamada2.duracion)
                return -1;
            return 0;
        }

        public abstract float CostoLlamada { get;  }
      
        

    }
}
