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

        public float ValorEstanteTotal { get { return this.GetValorEstante(); } }

        public List<Producto> GetProductos() { return this.listaProductos; }
        private float GetValorEstante ()
        {
            return this.GetValorEstante(ETipoProducto.Todos);
        }
        public float GetValorEstante(ETipoProducto tipoProducto) 
        {

            float valorTodos = 0;
            foreach (Producto element in listaProductos)
            {
                switch (tipoProducto)
                {
                    case ETipoProducto.Galletita:
                        if (element is Galletita)
                        { 
                            valorTodos += element.Precio;
                        }                        
                        break;
                    case ETipoProducto.Gaseosa:
                        if (element is Gaseosa)
                        {
                            valorTodos += element.Precio;
                        } 
                        break;
                    case ETipoProducto.Harina:
                        if (element is Harina)
                        {
                            valorTodos += element.Precio;
                        } 
                        break;
                    case ETipoProducto.Jugo:
                        if (element is Jugo)
                        {
                            valorTodos += element.Precio;
                        } 
                        break;
                    default:
                        return valorTodos += element.Precio;
                        break;
                }

            }
            return valorTodos;
        }


        

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Estante:\n Capacidad: ");
            sb.Append(e.capacidad.ToString());
            foreach (Producto item in e.listaProductos)
            {
                sb.Append(item.MostrarProducto(item));
                sb.Append(item.ToString());
                
            }
            return sb.ToString();
        }

        public static bool operator ==(Estante e, Producto p)
        {
            if (e.listaProductos != null)
            {
                foreach (Producto item in e.listaProductos)
                {
                    if (item == p)
                    {
                        return true;
                        break;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

     

        

        public static bool operator +(Estante e, Producto p)
        {
            if (e.listaProductos != null)
            {
                if (e.listaProductos.Count < e.capacidad && e != p)
                {
                    e.listaProductos.Add(p);
                    return true; 
                }
            }
            return false;
        }

        public static bool operator -(Estante e, Producto p)
        {
            if (e.listaProductos != null && e == p)
            {
                e.listaProductos.Remove(p);
                return true;
            }
            return false;
        }

        public static Estante operator -(Estante e, ETipoProducto tp)
        { 
            if (e.listaProductos != null )
            {
                foreach (Producto item in e.listaProductos)
                {
                    if (tp == ETipoProducto.Galletita && item is Galletita)
                    {
                        bool  add = e - item;
                        if (add)
                         return e; 
                    }
                }
                
            }
            return e;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == this.GetType();
        }
    }
}
