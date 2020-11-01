using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Runtime.CompilerServices;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #region Enum
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de Universidad sin parametros, inicializa todas las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Propiedades e Indexador

        /// <summary>
        /// Propiedad de lectura y escritura,devuelve la lista de alumnos, o setea una lista
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura,devuelve la lista de jornadas, o setea una lista
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura,devuelve la lista de profesores, o setea una lista
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        /// <summary>
        /// Indexador de jornada,setea una jornada en el indice indicado, retorna el elemento del indice indicado si este no es ni menor a 0 ni mayor a la cantidad de elementos de la lista,sino retorna null
        /// </summary>
        /// <param name="index">Indice indicado</param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get 
            { 
                if(index<0 && index>this.jornada.Count)
                {
                    return null;
                }
                else
                {
                    return this.jornada[index];
                }
                
            }
            set 
            { 
                if(index >=0 && index<this.jornada.Count)
                {
                    this.jornada[index] = value;
                }
                else
                {
                    if(index == this.jornada.Count)
                    {
                        this.jornada.Add(value);
                    }
                }
                
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo MostrarDatos, mostrar todos los datos de la Universidad pasada por parametro
        /// </summary>
        /// <param name="uni">Universidad de la cual voy a mostrar los datos</param>
        /// <returns>Retorna un string con los datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Metodo estatico que guardara los datos de la universidad pasada por parametro en un archivo Xml.
        /// Invoca al metodo GUardar de la clase XML
        /// </summary>
        /// <param name="uni">Universidad de la cual voy a guardar los datos</param>
        /// <returns>Retorna true si puedo guardar los datos,false si no pudo</returns>
        public static bool Guardar(Universidad uni)
        {
            bool guardado = false;
            Xml<Universidad> xml = new Xml<Universidad>();

            if (xml.Guardar("Universidad.xml", uni))
            {
                guardado = true;
            }

            return guardado;
        }

        /// <summary>
        /// Metodo estatico que leera los datos de un archivo de XML.
        /// Invoca al metodo Leer de la clase XML
        /// </summary>
        /// <returns>Retorna una variable de tipo string con los datos leidos</returns>
        public static Universidad Leer()
        {
            Universidad datos;
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Universidad.xml", out datos);

            return datos;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del ToString hace publicos los datos de la Universidad
        /// </summary>
        /// <returns>Retorna un string con los datos dela Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador "==", una Universidad sera igual a un Alumno si este esta inscripto en esa universidad
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna true si son iguales o false si no lo son</returns>
        public static bool operator ==(Universidad g,Alumno a)
        {
            bool finded = false;

            foreach(Alumno item in g.alumnos)
            {
                if(item.Equals(a))
                {
                    finded = true;
                    break;
                }
            }

            return finded;
        }

        /// <summary>
        /// Sobrecarga del operador "!=", reutiliza la sobrecarga del operador "=="
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>Retorna true si son distintos o false si son iguales</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g==a);
        }

        /// <summary>
        /// Sobrecarga del operdor "==", una Universidad sera igual a un Profesor si este da clases en ella
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Retorna true si son iguales o false si no lo son</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool finded = false;

            foreach (Profesor item in g.profesores)
            {
                if (item.Equals(i))
                {
                    finded = true;
                    break;
                }
            }

            return finded;
        }

        /// <summary>
        /// Sobrecarga del operdador "!=",reutiliza la sobrecarga del operador "=="
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>Retorna true si son distintos o false si no lo son</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga del operador "+",agrega una clase a la universidad
        /// </summary>
        /// <param name="g">Universidad donde se va a agregar la clase</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Retorna la Universidad</returns>

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada aux = new Jornada(clase, g == clase);

            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                {
                    aux += item;
                }
            }
            if (aux.Alumnos.Count > 0)
            {
                g.Jornadas.Add(aux);
            }

            return g;
        }
    
        /// <summary>
        /// Sobrecarga del operador "+",agrega un alumno a la Universidad validando antes que no se encuentra ya en la Universidad, sino lanza una excepcion AlumnoRepetidoException
        /// </summary>
        /// <param name="u">Universidad donde se agregara el alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
           
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador "+",agrega un profesor a la Universidad validando antes que no se encuentra ya en la Universidad
        /// </summary>
        /// <param name="u">Universidad donde se agregara el alumno</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>Retorna la Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }

            return u;
        }

        /// <summary>
        /// Sobrecarga del operador "==", busca al primero profesor apto para dar la clase pasada por parametro
        /// </summary>
        /// <param name="u">Universidad donde buscar el profesor</param>
        /// <param name="clase">Clase a la cual buscarle profesor</param>
        /// <returns>Retorna el profesor en caso de encontrar uno o lanza una Excepcion de tipo SinProfesorException</returns>
        public static Profesor operator ==(Universidad u,EClases clase)
        {
            Profesor apto = null;
            bool flagApto = false;

            foreach(Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    apto = item;
                    flagApto = true;
                    break;
                }
            }

            if(flagApto==false)
            {
               throw new SinProfesorException();   
            }
            else
            {
                return apto;
            }
            
        }

        /// <summary>
        /// Sobrecarga del operador "!=",busca al primero profesor que no sea capaz de dar la clase pasada por parametros
        /// </summary>
        /// <param name="u">Universidad donde buscar al profesor</param>
        /// <param name="clase">Clase que no pueda dar el profesor</param>
        /// <returns>Retorna el primer Profesor no apto</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor apto = null;

            foreach (Profesor item in u.profesores)
            {
                if (item != clase)
                {
                    apto = item;
                    break;
                }              
            }

            return apto;
        }

        #endregion


    }
}
