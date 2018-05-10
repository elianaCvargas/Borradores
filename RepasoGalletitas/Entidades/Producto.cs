using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public abstract class Producto
    {
        protected int codigoBarra;
        protected EMarcaProducto marca;
        protected float precio;

        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
        {
            this.codigoBarra = codigoBarra;
            this.marca = marca;
            this.precio = precio;
        }

        public abstract float CalcularCostoProduccion { get; }
        
        public EMarcaProducto Marca { get { return this.marca; } }
        public float Precio { get { return this.precio; } }

        public virtual string Consumir()
        {
            return "Parte de una mezcla";
        }

        public override bool Equals(Object obj)
        {
           return (!(ReferenceEquals(null, obj)) && ReferenceEquals(this, obj) && obj.GetType() == this.GetType());
           // return base.Equals(obj);
             
        }

        public static explicit operator int(Producto p)
        {
            return p.codigoBarra;
        }
        public  static implicit operator string(Producto p)
        {
            return p.MostrarProducto(p);
        }
        public string MostrarProducto(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            string codigo = "\nCódigo de Barra:";
            string marca = "\nMarca:";
            string precio = "\nPrecio:";
            sb.Append(codigo);
            sb.Append(this.codigoBarra.ToString());
            sb.Append(marca);
            sb.Append(this.marca);
            sb.Append(precio);
            sb.Append(this.precio.ToString());
            return sb.ToString();
        }
        public static bool operator ==(Producto p, EMarcaProducto  marca)
        {
            if (p.marca == marca)
                return true;
            return false;
        }

        public static bool operator !=(Producto p, EMarcaProducto marca)
        {
            return !(p.marca == marca);
        }

        public static bool operator ==(Producto p1, Producto p2)
        {
            if (p1 == p2)
                return true;
            return false;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
 

    }
}
