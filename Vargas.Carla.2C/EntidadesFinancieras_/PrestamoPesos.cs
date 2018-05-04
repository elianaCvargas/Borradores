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

        PrestamoPesos(float monto, DateTime vencimiento, float porcentajeInteres)
            :base(monto, vencimiento)
        {
            this.porcentajeIntereses = porcentajeInteres;
        }

        PrestamoPesos(Prestamo prestamo, float porcentajeInteres)
            :this(prestamo.Monto, prestamo.Vencimiento, porcentajeInteres)
        { }


        public float Interes { get; }
        //  
        public float CalcularInteres() 
        {
            float monto = base.Monto;
            float interes = (this.porcentajeIntereses * monto) / 100;
            return monto + interes;
            
        }

        public void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            DateTime vencimientoAcual = base.Vencimiento ;
           // DateTime fechaActual = DateTime.Now;
            System.TimeSpan diferencia = nuevoVencimiento.Subtract(vencimientoAcual);
            int interesAgregadoPorDia = (int)diferencia.TotalDays;
            float nuevoInteres = interesAgregadoPorDia * (float)0.25;
            //Sumar el interes al  monto (FALTA)
            base.Monto = base.Monto + (nuevoInteres); 

        }

        public string Mostrar()
        { }





    }
}
