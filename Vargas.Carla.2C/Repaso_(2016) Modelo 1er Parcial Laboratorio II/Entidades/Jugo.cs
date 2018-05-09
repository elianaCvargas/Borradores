using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public class Jugo: Producto
    {
        private ESaborJugo sabor;
        private static bool deConsumo;

        static  Jugo()
        {
      
            deConsumo = true;
        }
        
        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor)
            :base(codigoBarra,marca,precio)
        {
            this.sabor = sabor;
        }

        public float CalcularCostoProduccion { 
            get {
                float retorno = (40 * this.precio) / 100;
                return retorno;
                
            } 
        }
        public string Consumir( ){return "Bebible";}
        public string MostrarJugo()
        {
           return string.Format("Sabor: {0}", this.sabor.ToString());
        }
        public override string ToString()
        {
            return this.MostrarJugo();
        }


    }
}
