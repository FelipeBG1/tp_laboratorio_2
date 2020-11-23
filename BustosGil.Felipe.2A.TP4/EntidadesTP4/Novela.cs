using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesTP4
{
    //Clase publica Novela,deriva de Libro
    public class Novela:Libro
    {
        private Random paginas;
        private bool autografiado;

        #region Propiedades
        /// <summary>
        ///Implementacion de la propiedad CantPag de Libro,retorna un numero aleatorioa entre 90 y 150 correspondiente a las paginas
        /// </summary>
        public override int CantPag
        {
            get { return this.paginas.Next(90, 150); }
        }

        /// <summary>
        /// Implementacion de la propiedad Cubierta de Libro,retorna tapa blanda
        /// </summary>
        public override string Cubierta
        {
            get { return "Tapa blanda"; }
        }

        /// <summary>
        /// Retorna si esta autografiada la novela
        /// </summary>
        public string Autografiado
        {
            get
            {
                if(this.autografiado==true)
                {
                    return "Si";
                }
                else
                {
                    return "No";
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Cosntructor,instancia una novela,invoca al constructor de Libro
        /// </summary>
        /// <param name="editorial"></param>
        /// <param name="titulo"></param>
        /// <param name="precio"></param>
        /// <param name="autografo"></param>
        public Novela(string editorial, string titulo, int precio,bool autografo) : base(editorial, titulo, precio)
        {
            paginas = new Random();
            this.autografiado = autografo;
        }

        /// <summary>
        /// Constructor sin parametros,default
        /// </summary>
        public Novela():base()
        {

        }
        #endregion

        #region SobrecargaToString
        /// <summary>
        /// Sobrecarga del ToString, reutiliza el ToString de Libro
        /// </summary>
        /// <returns>Retorna un string con los datos de la novela</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("Cant.Paginas: {0}\n", this.CantPag);
            sb.AppendFormat("Cubierta: {0}\n", this.Cubierta);
            sb.AppendFormat("Autografiado: {0}\n", this.Autografiado);

            return sb.ToString();
        }
        #endregion
    }
}
