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
        private float litros;
        private static bool deConsumo;

        static  Gaseosa()
        {
      
            deConsumo = true;
        }

        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros)
            :base(codigoBarra,marca,precio)
        {
            this.litros = litros;
        }
        public Gaseosa(Producto p, float litros)
            :this((int)p, p.Precio, p.Marca,litros)
        {

            
        }

        public override float CalcularCostoProduccion
        { 
            get {
                float porcentaje = (42 * this.precio) / 100;
                float retorno = this.precio + porcentaje;
                return retorno;
                
            } 
        }
        public override string Consumir( ){return "Bebible";}
        private string MostrarGaseosa()
        {
           return string.Format("Litros: {0}", this.litros.ToString());
        }
        public override string ToString()
        {
            return this.MostrarGaseosa();
        }
    }
}
