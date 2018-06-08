using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Local:Llamada
    {
        private float costo;

        public Local(Llamada llamada, float costo)
            :this(llamada.NumeroOrigen, llamada.Duracion, llamada.NumeroDestino,costo)
        { 

        }
        public Local(string origen, float duracion, string destino, float costo)
            :base(duracion, destino, origen)
        {
            this.costo = CalcularCosto();
        }

        public override float CostoLlamada { get { return this.costo; } }

        public override string Mostrar()
        {
           
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} -- Local: {1}", base.Mostrar(), this.costo.ToString());
            return sb.ToString();
        }

        private  float CalcularCosto()//a partir de la duracion y el costo
        {
            this.costo = duracion * costo;
            return costo;
        }



        //////

    }
}
