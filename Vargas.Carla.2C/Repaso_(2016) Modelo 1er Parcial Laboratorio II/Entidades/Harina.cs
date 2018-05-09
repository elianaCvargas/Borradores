using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public class Harina: Producto
    {
        private ESaborJugo sabor;
        private static bool deConsumo;

        static  Harina()
        {
      
            deConsumo = true;
        }

        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor)
            :base(codigoBarra,marca,precio)
        {
            this.sabor = sabor;
        }

        public float CalcularCostoProduccion { 
            get {
                float porcentaje = (60 * this.precio) / 100;
                float retorno = this.precio + porcentaje;
                return retorno;
                
            } 
        }
    
        private string MostrarHarina()
        {
           return string.Format("Sabor: {0}", this.sabor.ToString());
        }
        public override string ToString()
        {
            return this.MostrarHarina();
        }
    }
}
