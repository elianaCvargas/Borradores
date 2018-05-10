using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresamosPersonales;

namespace PrestamosPersonales
{
    public class PrestamoDolar: Prestamo
    {

        private PeriodicidadDePagos periodicidad;

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad)
             :base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo prestamo, PeriodicidadDePagos periodicidad)
            :this(prestamo.Monto, prestamo.Vencimiento,periodicidad)
        { 
            
        }


        public float Interes { get { return this.CalcularInteres();} }

        public float CalcularInteres() 
        {
            float monto = base.Monto;
            float interes = 0;
            if (periodicidad == PeriodicidadDePagos.Mensual)
            {
                interes = (25 * monto) / 100;
                return interes + monto;
            }           
                if (periodicidad == PeriodicidadDePagos.Bimestral)
                {
                    interes = (35 * monto) / 100;
                    return interes + monto;
                }
            interes = (40 * monto) / 100;
            return monto + interes;                                     
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            DateTime vencimientoAcual = base.Vencimiento ;
           // DateTime fechaActual = DateTime.Now;
            System.TimeSpan diferencia = nuevoVencimiento.Subtract(vencimientoAcual);
            int interesAgregadoPorDia = (int)diferencia.TotalDays;
            float nuevoInteres = interesAgregadoPorDia *(float) 2.5;
            float MontoConInteres = (nuevoInteres * base.Monto) / 100;
            //Sumar el interes al  monto (FALTA)
            float monto = base.Monto;
             monto= monto + (MontoConInteres); 

        }

        public string Mostrar()
        {
            base.Mostrar();
            return String.Format("\n Prestamo periodicidad: {1}", this.periodicidad.ToString());
        }


    }
}
