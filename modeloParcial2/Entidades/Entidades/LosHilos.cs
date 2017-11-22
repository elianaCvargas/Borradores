using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LosHilos
    {
        private int id;
        private List<InfoHilos> listaMisHilos;

        public LosHilos()
        { }

        public string Bitacora { get; set; }

        public LosHilos AgregarHilos(LosHilos hilos)
        {
            LosHilos h = new LosHilos();
            return h;
        }

        public void RespuestaHilo(int id)
        { }

        public static LosHilos operator +(LosHilos hilos , int cantidad)
        {
            LosHilos h = new LosHilos();
            return h;
        }
    }
}
