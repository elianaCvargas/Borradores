using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IInterfaces;
using System.Threading;
 

namespace Entidades
{
    public class InfoHilos
    {
        private IRespuesta<int> callBack;
        private Thread hilo;
        private int id;
        private static Random randomizer;

        static InfoHilos()
        {
            InfoHilos.randomizer = new Random();
        }
        public InfoHilos(int id, IRespuesta<int> callBack)

        {
            this.id = id;
            this.callBack = callBack;
            this.hilo = new Thread(Ejecutar);
        }
        
        
        public void Ejecutar()
        {
            Thread.Sleep(InfoHilos.randomizer.Next(1000,5000));
            this.callBack.RespuestaHilo(this.id);
        }


        /*public class InfoHilo
    {     
        
        public InfoHilo(int id, IRespuesta<int> callback)
        {
            this.id = id;
            this.callback = callback;
            this.hilo = new Thread(Ejecutar);
        }

        private void Ejecutar()
        {
            Thread.Sleep(InfoHilo.randomizer.Next(1000, 5000));
            this.callback.RespuestaHilo(this.id);
        }
    }*/

    }
}
