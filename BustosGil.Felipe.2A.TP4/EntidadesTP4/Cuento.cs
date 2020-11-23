using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesTP4
{
    //Clase publica Cuento, deriva de Libro
    public class Cuento:Libro
    {
        private Random paginas;
        private string ilustraciones;

        #region Propiedades
        /// <summary>
        /// Implementacion de la propiedad CantPag de Libro,retorna un numero aleatorioa entre 40 y 80 correspondiente a las paginas
        /// </summary>
        public override int CantPag
        {
            get { return this.paginas.Next(40,80); }
        }

        /// <summary>
        /// Implementacion de la propiedad Cubierta de Libro,retorna tapa blanda
        /// </summary>
        public override string Cubierta
        {
            get { return "Tapa blanda"; }
        }

        /// <summary>
        /// Retorna lo que contiene el atributo ilustraciones
        /// </summary>
        public string Ilustraciones
        {
            get { return this.ilustraciones; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor, instancia un cuento, llama al constructor de Libro
        /// </summary>
        /// <param name="editorial">Editorial</param>
        /// <param name="titulo">Titulo</param>
        /// <param name="precio">Precio</param>
        /// <param name="ilustraciones">Ilustraciones a setear</param>
        public Cuento(string editorial,string titulo,int precio,string ilustraciones):base(editorial,titulo,precio)
        {
            paginas = new Random();
            this.ilustraciones = ilustraciones;
        }

        /// <summary>
        /// Constructor sin parametros,default
        /// </summary>
        public Cuento():base()
        {

        }
        #endregion

        #region SobrecargaToString
        /// <summary>
        /// Sobrecarga del ToString,reutiliza el ToString de libro
        /// </summary>
        /// <returns>Reotrna un string con los datos del cuento</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("Cant.Paginas: {0}\n", this.CantPag);
            sb.AppendFormat("Cubierta: {0}\n", this.Cubierta);
            sb.AppendFormat("Ilustraciones: {0}\n", this.Ilustraciones);

            return sb.ToString();
        }
        #endregion
    }
}
