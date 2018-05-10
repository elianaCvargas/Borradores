using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Biblioteca
    {
        private static short cantidad;
        private List<Libro> libros;

        static Biblioteca()
        {
            Biblioteca.cantidad = 10;
        }
        private Biblioteca()
        {
            libros = new List<Libro>();
        }

        public Biblioteca(short cantidad)
            : this()
        {
            Biblioteca.cantidad = cantidad;
        }

        public static explicit operator List<Libro>(Biblioteca b)
        {
          //  if(b.libros != null)
                return b.libros;

        }

        public static Biblioteca operator +(Biblioteca b, Libro l)
        {
            if (b.libros != null && Biblioteca.cantidad < b.libros.Count)
                b.libros.Add(l);           
            return b;
        }
    }
}
