using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IInterfaces
{
    public interface IRespuesta<T>// el  parametro  es ID
    {
        //La interface IRespuesta sólo contará con el método RespuestaHilo que recibirá un atributo genérico id
        public void RespuestaHilo(int id)
        {
            
        }
    }
}
