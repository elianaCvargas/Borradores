using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enumerados;
namespace Entidades
{
    public abstract class Libro
    {
        private int altoHoja;
        private int anchoHoja;
        private List<string> pagina;
        private float tamanioLetra;
        private string titulo;

        private Libro()
        {
            this.pagina = new List<string>();
        }
        public Libro(string titulo, float tamanioLetra, int ancho, int alto )
            :this()
        {
            this.titulo = titulo;
            this.tamanioLetra = tamanioLetra;
            this.altoHoja = alto;
            this.anchoHoja = ancho;
        }


        public int AnchoHoja { get { return this.anchoHoja; } }
        public int CantidadPaginas { get { return this.pagina.Count; } }
        
        public float TamanioLetra {
            get { return this.tamanioLetra; } 
            //validar que este sea menor al 10% de la suma del ancho y alto de la hoja. Caso contrario, se asignará un tamaño de letra 12. 
            set
            {
                float sumaAltoAncho = this.altoHoja + this.anchoHoja;
                float porcentaje = (10 * sumaAltoAncho)/100;
                if (value < porcentaje)
                    this.tamanioLetra = value;
                this.tamanioLetra = 12;

            }
        }
        public int AltoHoja { get { return this.altoHoja; } }

        public string this[int i]
        {
            get
            {
                string retorno = "";
                if (pagina != null)
                {
                    foreach (string item in pagina)
                    {
                        if (pagina[i] == item)
                        {
                            retorno = this.pagina[i];
                        }
                    }
                }
                return retorno;
            }
            set
            {
                this.pagina.Add(value);
            }
        }

        public abstract EtipoImpresion TipoImpresion { get; }


        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Titulo: ");
            sb.Append(this.titulo);
            return sb.ToString();
        }


    }
}
