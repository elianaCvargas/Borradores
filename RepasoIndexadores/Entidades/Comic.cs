using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public class Comic : Libro
    {
        private int cantCuadros;
        public Comic(int cantCuadros, string titulo, float tamanioLetra, int ancho, int alto)
            : base(titulo, tamanioLetra, ancho, alto)
        {
            this.cantCuadros = cantCuadros;
        }

        public override EtipoImpresion TipoImpresion
        {
            get
            {
                return EtipoImpresion.Color;
            }
        }

        
        public override string Mostrar()
        {
            string aux = string.Format(base.Mostrar() + "Cantidad de Cuadros: " + this.cantCuadros + "Tipo de Impresion: " + this.TipoImpresion);
            return aux;
        }
    }
}
