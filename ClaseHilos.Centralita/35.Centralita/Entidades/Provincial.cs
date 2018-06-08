using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;

namespace Entidades
{
    public class Provincial:Llamada
    {
        private Franja franja; 

        public Provincial(Franja miFranja, Llamada llamada)
            :this(llamada.NumeroOrigen, miFranja, llamada.Duracion,llamada.NumeroDestino)
        { 

        }
        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            :base(duracion, destino, origen)
        {
            this.franja = miFranja;
        }

        public  override float CostoLlamada { get { return this.CalcularCosto(); } }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} -- Local: {1}", base.Mostrar(), this.CostoLlamada.ToString(), this.franja.ToString());
            return sb.ToString();
        }

        private  float CalcularCosto()
        {
            double retorno = 0;
            if (this.franja == Franja.Franja_1)
            {
                retorno = 0.99 * this.duracion;
                return (float)retorno;
            }
            if (this.franja == Franja.Franja_2)
            {
                retorno = 1.25 * this.duracion;
                return (float)retorno;
            }
            retorno = 0.66 * this.duracion;
            return (float)retorno;
        }

    }
}
