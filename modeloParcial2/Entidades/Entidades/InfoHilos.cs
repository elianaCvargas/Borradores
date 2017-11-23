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
        /*
            a. Atributo estático randomizer. El mismo se inicializará en un constructor de clase.
            b. El Thread hilo ejecutará el método Ejecutar.
         * NOTA_: si  tenemos atributos de instancia no  inicializados,  los inicializamos por convencion  en  el  constructor
            c. Ejecutar frenará el código durante un tiempo aleatorio de entre 1 y 5 segundos. Luego de
                transcurrir este tiempo, utilizará el método RespuestaHilo de callback pasando como
                parámetro el atributo id.
         
         */
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
            this.hilo = new Thread(Ejecutar);//hilo  inicializa el metodo ejecutar
            hilo.Start();
        }
        
        
        public void Ejecutar()
        {
            Thread.Sleep(InfoHilos.randomizer.Next(1000,5000));
            this.callBack.RespuestaHilo(this.id);
        }

    }
}
