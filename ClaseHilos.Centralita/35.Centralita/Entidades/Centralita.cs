using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;

namespace Entidades
{
    public class Centralita
    {

        private List<Llamada> listaDeLlamadas;
        private string razonSocial;

        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string razonSocial):this()
        {
            this.razonSocial = razonSocial;
        }

        public float GananciasPorLocal { get { return this.CalcularGanancia(TipoLlamada.Local); } }
        public float GananciasPorProvincial { get { return this.CalcularGanancia(TipoLlamada.Provincial); } }
        public float GananciasPorTotal { get { return this.CalcularGanancia(TipoLlamada.Todas); } }
        public List<Llamada> Llamadas { get { return this.listaDeLlamadas; } }

        private float CalcularGanancia(TipoLlamada tipoLlamada)
        {
            float valorRecaudado = 0;

                foreach (Llamada item in this.listaDeLlamadas)
                {
                    if (tipoLlamada == TipoLlamada.Local && item is Local)
                    {                                                
                        valorRecaudado += item.CostoLlamada;
                    }
                    if (tipoLlamada == TipoLlamada.Provincial && item is Provincial)
                    {
                        valorRecaudado += item.CostoLlamada;
                    }
                    if (tipoLlamada == TipoLlamada.Todas)
                    {
                        valorRecaudado += item.CostoLlamada;
                    }

                }           
                return valorRecaudado;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Llamada: {0} - {1} - {2} - {3} - {4} ",this.razonSocial, this.GananciasPorLocal, this.GananciasPorProvincial, this.GananciasPorTotal);
            return sb.ToString();
        }

        public void OrdenarLlamadas()
        {
            
        }

    }
}
