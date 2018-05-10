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
        private float peso;
        private static bool deConsumo;

        static  Galletita()
        {
      
            deConsumo = true;
        }

        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso)
            :base(codigoBarra,marca,precio)
        {
            this.peso = peso;
        }

        public override float CalcularCostoProduccion { 
            get {
                float porcentaje = (33 * this.precio) / 100;
                float retorno = this.precio + porcentaje;
                return retorno;
                
            } 
        }
        public override string Consumir( ){return "Comestible";}

        private static string MostrarGalletita(Galletita g)
        {
           return string.Format("Peso: {0}", g.peso.ToString());
        }
        public override string ToString()
        {
            return Galletita.MostrarGalletita(this);
        }

        

    }
}
