using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public class Novela : Libro
    {
        private int cantPaginas;

        public Novela(int cantPaginas, string titulo, float tamanioLetra, int ancho, int alto)
            : base(titulo, tamanioLetra, ancho, alto)
        {
            this.cantPaginas = cantPaginas;
        }

        public override EtipoImpresion TipoImpresion
        {
            get
            {
                return EtipoImpresion.BlancoNegro;
            }
        }

        public override string Mostrar()
        {
            string aux;
            aux = string.Format(base.Mostrar() + " \n Cantidad de Paginas: " + this.cantPaginas + "\nTipo de impresion: " + this.TipoImpresion);

            return aux;
        }

        

    }
}
