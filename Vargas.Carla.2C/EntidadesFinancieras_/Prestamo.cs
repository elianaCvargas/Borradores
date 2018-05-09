using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresamosPersonales
{
    public abstract class Prestamo
    {
        private float monto;
        private DateTime vencimiento;

        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            this.vencimiento = vencimiento;
        }
        //Preguntar si se puede comparar fechas de esta forma
        public float Monto { get; set; }
        public DateTime Vencimiento
        {
            get { return this.vencimiento; }
            set
            {

                if (this.vencimiento > DateTime.Now)
                {
                    this.vencimiento = value;
                }
                this.vencimiento = DateTime.Now;
            }
        }


        public abstract void ExtenderPlazo(DateTime vencimiento);
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Monto: ");
            sb.Append(monto.ToString());
            sb.Append("Vencimiento: ");
            sb.Append(vencimiento.ToString());
            return sb.ToString();
        }

        public static int OrdenarPorFecha(Prestamo p1, Prestamo p2)
        {
            if (p1.vencimiento > p2.vencimiento)
                return 1;
            return 0;
        }

    }
}
