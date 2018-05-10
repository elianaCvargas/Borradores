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
        private ETipoHarina harina;
        private static bool deConsumo;

        static  Harina()
        {
      
            deConsumo = true;
        }

        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina harina)
            :base(codigoBarra,marca,precio)
        {
            this.harina = harina;
        }


        public override float CalcularCostoProduccion
        { 
            get {
                float porcentaje = (60 * this.precio) / 100;
                float retorno = this.precio + porcentaje;
                return retorno;
                
            } 
        }
    
        private string MostrarHarina()
        {
           return string.Format("Sabor: {0}", this.harina.ToString());
        }
        public override string ToString()
        {
            return this.MostrarHarina();
        }
    }
}
