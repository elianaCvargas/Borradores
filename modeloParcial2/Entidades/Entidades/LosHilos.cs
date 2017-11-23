using IInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LosHilos: IRespuesta<int>
    {
        /*
            a. El atributo id deberá inicializar el 0.
            b. La propiedad Bitacora utilizará el set para generar un archivo en el escritorio de la máquina
                donde se ejecute llamado "bitacora.txt". El get retornará el contenido del mismo archivo.
            c. Método de clase AgregarHilo hará los siguientes pasos, en el siguiente orden:
                i. Incrementará id.
                ii. creará un nuevo InfoHilo y lo agregará a misHilos.
                d. RespuestaHilo hará los siguientes pasos, en el siguiente orden:
                i. Creará un mensaje con el siguiente formato: "Terminó el hilo {0}.".
                ii. Guardará el mensaje en la bitácora.
                iii. Ejecutará el evento AvisoFin.
            e. El operador + lanzará la excepción CantidadInvalidaException en el caso de que la cantidad
                sea menor a 1.
            f. Si cantidad es mayor a 0, deberá agregar tantos hilos cómo indique dicha cantidad.
         */
        public delegate void nombreDelegado(int id);//delegado
        public event nombreDelegado AvisoFin;//evento

        private static int id;
        private static List<InfoHilos> listaMisHilos;

        public LosHilos()
        {
            LosHilos.id = 0;
        }
       // b. La propiedad Bitacora utilizará el set para generar un archivo en el escritorio de la máquina
      //          donde se ejecute llamado "bitacora.txt". El get retornará el contenido del mismo archivo.
        public string Bitacora 
        { get;

            set 
            {
                
                StreamWriter sw = new StreamWriter("Bitacora.txt");//lo deja por defecto en nuestro  proyecto 
                sw.Write("");
            }
        }
        /*
            c. Método de clase AgregarHilo hará los siguientes pasos, en el siguiente orden:
                i. Incrementará id.
                ii. creará un nuevo InfoHilo y lo agregará a misHilos.
         */

        public static LosHilos AgregarHilos(LosHilos hilos)
        {
            LosHilos.id += 1;
            InfoHilos infoHilo = new InfoHilos(id, hilos);
            LosHilos.listaMisHilos.Add(infoHilo);           
            return hilos;
        }
             //d. RespuestaHilo hará los siguientes pasos, en el siguiente orden:
             //   i. Creará un mensaje con el siguiente formato: "Terminó el hilo {0}.".
             //   ii. Guardará el mensaje en la bitácora.
             //   iii. Ejecutará el evento AvisoFin.
        public  void RespuestaHilo(int id)
        {
            String mensaje = String.Format("Terminó el hilo {0}");
            this.Bitacora = mensaje;
            AvisoFin.Invoke(id);
        }

        public static LosHilos operator +(LosHilos hilos , int cantidad)
        {
            if (cantidad < 0)
            {
                throw new CantidadInvalidaException();
            }
            else { 
                for (int i = 0; i < cantidad; i++)
			    {
                    LosHilos.AgregarHilos(hilos);
			    }
                
            }            
            return hilos;
        }


    }
}
