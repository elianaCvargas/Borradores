using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;

namespace Entidades
{
    public class Galletita: Producto
    {
        private ESaborJugo sabor;
        private static bool deConsumo;

        static  Galletita()
        {
      
            deConsumo = true;
        }

        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor)
            :base(codigoBarra,marca,precio)
        {
            this.sabor = sabor;
        }

        public float CalcularCostoProduccion { 
            get {
                float porcentaje = (33 * this.precio) / 100;
                float retorno = this.precio + porcentaje;
                return retorno;
                
            } 
        }
        public string Consumir( ){return "Comestible";}
        public string MostrarGalletita(Galletita g)
        {
           return string.Format("Sabor: {0}", g.sabor.ToString());
        }
        public override string ToString(Galletita g)
        {
            return this.MostrarGalletita(g);
        }

    }
}
