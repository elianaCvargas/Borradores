using PresamosPersonales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrestamosPersonales;

namespace EntidadFinanciera
{
    public class Financiera
    {
        private List<Prestamo> listaPrestamos;
        private string razonSocial;

        private  Financiera()
        {
            this.listaPrestamos = new List<Prestamo>();
        }
        public Financiera(string razonSocial)
            :this()
        {
            this.razonSocial = razonSocial;
        }

        public float InteresesEnDolares {
            get {
                float interesGanado = 0;
                if (this.listaPrestamos != null)
                {
                    foreach (Prestamo item in this.listaPrestamos)
                    {
                        if (item is PrestamoDolar)
                        {
                            interesGanado = interesGanado + item.Monto;
                        }
                    }
                }
                return interesGanado;
            } 
        }
        public float InteresesEnPesos {
            get
            {
                float interesGanado = 0;
                if (listaPrestamos != null)
                {
                    foreach (Prestamo item in this.listaPrestamos)
                    {
                        if (item is PrestamoDolar)
                        {
                            interesGanado = interesGanado + item.Monto;
                        }
                    }
                    
                }
                return interesGanado;
            } 
        }
        public float InteresesTotales 
        {
            get
            {
                float interesGanado = 0;
                if (this.listaPrestamos != null)
                {
                    foreach (Prestamo item in this.listaPrestamos)
                    {
                        
                            interesGanado = interesGanado + InteresesEnDolares + InteresesEnPesos;
                        
                    }
                }
                return interesGanado;
            } 
        
        }
        public List<Prestamo> ListaDePrestamos { get { return this.listaPrestamos; } }
        public string RazonSocial { get { return this.razonSocial; } }

        public float CalcularInteresGanado(TipoDePrestamo tipodePrestamo) 
        {
       
            if (tipodePrestamo == TipoDePrestamo.Pesos)
            {
                return InteresesEnPesos;
            }
            if (tipodePrestamo == TipoDePrestamo.Dolares)
            {
                return InteresesEnDolares;
            }
           return InteresesTotales;
        }

        public static explicit operator string(Financiera financiera)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Razón Social: ");
            sb.Append(financiera.razonSocial.ToString());
            sb.Append("\nIntereses en Pesos: ");
            sb.Append(financiera.InteresesEnPesos.ToString());
            sb.Append("\nIntereses en Dólares: ");
            sb.Append(financiera.InteresesEnDolares.ToString());
            sb.Append("\nIntereses Totales: ");
            sb.Append(financiera.InteresesTotales.ToString());
            sb.Append("\nProductos: ");
            financiera.OrdenarPrestamos();
            if (financiera.listaPrestamos != null)
            {
                foreach (Prestamo item in financiera.listaPrestamos)
                {
                    sb.Append(item.Mostrar());
                }
            }
            return sb.ToString();

        }

        public static string Mostrar(Financiera financiera)
        {
            return (string)financiera;
        }
        public static bool operator ==(Financiera f, Prestamo p)
        {
            if(f.listaPrestamos != null)
            {
                foreach (Prestamo item in f.listaPrestamos)
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

        public static bool operator !=(Financiera f, Prestamo p)
        {
            return !(f == p);
        }
        public static Financiera operator +(Financiera f, Prestamo p)
        {
            if(f.listaPrestamos != null)
            {
                if (f != p)
                {
                    f.listaPrestamos.Add(p);
                }
            }
            return f;
        }

        public void OrdenarPrestamos()
        {
            Comparison<Prestamo> prestamoComparer = new Comparison<Prestamo>(compareDate);
            if (listaPrestamos != null)
            {
                listaPrestamos.Sort(compareDate);
            }
        }

        public int compareDate(Prestamo p1, Prestamo p2)
        {
            return p1.Vencimiento.CompareTo(p2.Vencimiento);
        }
    }
}
