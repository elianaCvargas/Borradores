using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresamosPersonales;

namespace PrestamosPersonales
{
    public class PrestamoPesos:Prestamo
    {
        private float porcentajeIntereses;

        public PrestamoPesos(float monto, DateTime vencimiento, float porcentajeInteres)
            :base(monto, vencimiento)
        {
            this.porcentajeIntereses = porcentajeInteres;
        }

        public PrestamoPesos(Prestamo prestamo, float porcentajeInteres)
            :this(prestamo.Monto, prestamo.Vencimiento, porcentajeInteres)
        { }


        public float Interes { 
            get 
            { 
                return this.CalcularInteres(); 
            } 
        }
        //  
        public float CalcularInteres() 
        {
            float monto = base.Monto;
            float interes = (this.porcentajeIntereses * monto) / 100;
            return monto + interes;
            
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            DateTime vencimientoAcual = base.Vencimiento ;
           // DateTime fechaActual = DateTime.Now;
            System.TimeSpan diferencia = nuevoVencimiento.Subtract(vencimientoAcual);
            int interesAgregadoPorDia = (int)diferencia.TotalDays;
            float nuevoInteres = interesAgregadoPorDia * (float)0.25;
            float MontoConInteres = (nuevoInteres * base.Monto) / 100;
            //Sumar el interes al  monto (FALTA)
            base.Monto = base.Monto + (MontoConInteres); 

        }

        public override string Mostrar()
        {
            return String.Format("Base data: {0}\n Prestamo periodicidad: {1}", base.Mostrar(), this.porcentajeIntereses.ToString());
        }





    }
}
