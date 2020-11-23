using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    public class Investigacion:Libro
    {
        private Random paginas;
        private int cantTomos;

        #region Propiedades
        /// <summary>
        /// Implementacion de la propiedad CantPag de Libro,retorna un numero aleatorioa entre 170 y 300 correspondiente a las paginas
        /// </summary>
        public override int CantPag
        {
            get { return this.paginas.Next(170, 300); }
        }

        /// <summary>
        /// Implementacion de la propiedad Cubierta de Libro,retorna tapa dura
        /// </summary>
        public override string Cubierta
        {
            get { return "Tapa dura"; }
        }

        /// <summary>
        /// Retorna la cantidad de tomos 
        /// </summary>
        public int CantTomos
        {
            get { return this.cantTomos; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor, instancia un Investigacion, invoca al constructor de Libro
        /// </summary>
        /// <param name="editorial">Editorial</param>
        /// <param name="titulo">Titulo</param>
        /// <param name="precio">Precio</param>
        /// <param name="cantTomos">Cantidad de tomos</param>
        public Investigacion(string editorial, string titulo, int precio,int cantTomos) : base(editorial, titulo, precio)
        {
            paginas = new Random();
            this.cantTomos = cantTomos;
        }

        /// <summary>
        /// Constructor sin aprametros,default
        /// </summary>
        public Investigacion():base()
        {

        }

        #endregion

        #region SobrecargaToString
        /// <summary>
        /// Sobrecarga del ToString, invoca al ToString de Libro
        /// </summary>
        /// <returns>Retorna un string con los datos del Investigacion</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("Cant.Paginas: {0}\n", this.CantPag);
            sb.AppendFormat("Cubierta: {0}\n", this.Cubierta);
            sb.AppendFormat("Cant. Tomos: {0}\n", this.CantTomos);

            return sb.ToString();
        }
        #endregion
    }
}
