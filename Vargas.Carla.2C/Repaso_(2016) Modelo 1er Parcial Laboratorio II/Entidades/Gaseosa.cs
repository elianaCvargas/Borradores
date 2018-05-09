using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public class Gaseosa:Producto
    {
        private ESaborJugo sabor;
        private static bool deConsumo;

        static  Gaseosa()
        {
      
            deConsumo = true;
        }

        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor)
            :base(codigoBarra,marca,precio)
        {
            this.sabor = sabor;
        }

        public float CalcularCostoProduccion { 
            get {
                float porcentaje = (42 * this.precio) / 100;
                float retorno = this.precio + porcentaje;
                return retorno;
                
            } 
        }
        public string Consumir( ){return "Bebible";}
        private string MostrarGaseosa()
        {
           return string.Format("Sabor: {0}", this.sabor.ToString());
        }
        public override string ToString()
        {
            return this.MostrarGaseosa();
        }
    }
}
