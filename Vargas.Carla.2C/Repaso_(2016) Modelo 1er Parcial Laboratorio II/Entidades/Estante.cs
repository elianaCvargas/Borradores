using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public class Estante
    {
        protected sbyte capacidad;
        protected List<Producto> listaProductos;

        private Estante() 
        { this.listaProductos = new List<Producto>(); }
        public Estante(sbyte capacidad) 
            :this()
        { this.capacidad = capacidad;  }

        public float ValorEstanteTotal { get;  }

        public List<Producto> GetProductos() { return this.listaProductos; }
        public float GetValorEstante ()
        {
            
        }
        public float GetValorEstante(ETipoProducto tipoProducto) 
        {
            float sumaProductos = 0;
            foreach (Producto element in listaProductos)
            {
                
                if (element.Equals(ETipoProducto.Galletita))
                {
                    sumaProductos += 1;
                }
                if (element.Equals(ETipoProducto.Gaseosa))
                {
                    sumaProductos += 1;
                }
                if (element.Equals(ETipoProducto.Harina))
                {
                    sumaProductos += 1;
                }
                if (element.Equals(ETipoProducto.Jugo))
                {
                    sumaProductos += 1;
                }
                else sumaProductos += 1;
            }
            return sumaProductos;
        }

        public string MostrarEstante() { }

        public static bool operator ==(Estante e, Producto p)
        {
            if (e.marca == marca)
                return true;
            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(p.marca == marca);
        }

        public static bool operator ==(Estante e, ETipoProducto tp)
        {
            if (p1 == p2)
                return true;
            return false;
        }

        public static bool operator !=(Estante e, ETipoProducto tp)
        {
            return !(p1 == p2);
        }

        public static bool operator +(Estante e, Producto p)
        {
            if (p1 == p2)
                return true;
            return false;
        }

        public static bool operator -(Estante e, Producto p)
        {
            return !(p1 == p2);
        }

    }
}
