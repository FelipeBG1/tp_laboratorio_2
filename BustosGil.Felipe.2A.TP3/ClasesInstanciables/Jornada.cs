using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    //Clase publica Jornada
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores

        /// <summary>
        /// Constructor privado de Jornada,inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de Jornada,inicializa el atributo clase y el atributo instructor con los datos pasados por parametro
        /// Invoca al constructor de arriba para que inicialice la lista
        /// </summary>
        /// <param name="clase">Clase de tipo EClase con la cual se inicializara el atributo clase</param>
        /// <param name="instructor">Instructor de tipo Porfesor con el cual se inicializara el atributo instructor</param>
        public Jornada(Universidad.EClases clase,Profesor instructor):this()
        {
            this.clase = clase; 
            this.instructor = instructor;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura, devuelve la lista de alumnos o setea una lista
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura,devuelve la clase o setea una clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, devuelve el instructor o setea uno
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo estatico, que guardara los datos de la jornada pasada por parametro en un archivo de texto
        /// Invoca al metodo guardar de la clase Texto
        /// </summary>
        /// <param name="jornada">Jornada,de donde se obtendran los datos para ser guardados</param>
        /// <returns>Retorna true si se pudo guardar, o false si no se pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool guardado = false;
            Texto txt = new Texto();
            string archivo = "Jornada.txt";

            if (txt.Guardar(archivo, jornada.ToString()))
            {
                guardado = true;
            }

            return guardado;
        }

        /// <summary>
        /// Metodo estatico que leera los datos de un archivo de texto.
        /// Invoca al metodo Leer de la clase Texto
        /// </summary>
        /// <returns>Retorna una variable de tipo string con los datos leidos</returns>
        public static string Leer()
        {
            Texto txt = new Texto();
            string datos;

            txt.Leer("Jornada.txt", out datos);

            return datos;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador "==",verifica si una Jornada es igual al Alumno, si este toma la clase(atributo clase de Jornada)
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna true si son iguales o false si no lo son</returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            return a == j.Clase;
        }

        /// <summary>
        /// Sobrecarga del operador "!=", reutiliza la sobrecarga del operador "=="
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna true si son distintos o false si no lo son</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del operador "+",agrega un alumno a la jornada,verificando primero que no este en la lista
        /// </summary>
        /// <param name="j">Jornada donde se agregara al alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la jornada pasada por parametro</returns>

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Sobrecarga del ToString, muestra todos los datos de la jornada
        /// </summary>
        /// <returns>Retorna un string con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}\n", this.clase,this.instructor.ToString());
            sb.AppendFormat("ALUMNOS:\n");
            foreach (Alumno item in this.alumnos)
            {
                sb.AppendLine(item.ToString());
                sb.AppendLine("<------------------------------------------------>");
            }
            

            return sb.ToString();
        }

        #endregion

    }
}
