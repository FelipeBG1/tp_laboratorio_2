using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    //Clase sealed Profesor, deriva de Universitario
    public sealed class Profesor:Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores

        /// <summary>
        /// Constructor estatico de Profesor,inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de Profesor sin parametros.
        /// Invoca al constructor de abajo pasandole valores por defecto
        /// </summary>
        public Profesor():this(default,default,default,default,default)
        {
            
        }

        /// <summary>
        /// Constructor de Profesor,inicializa la Queue e invoca al metodo _randomClases
        /// Invoca al constructor de la clase Universitario pasandole todos los parametros
        /// </summary>
        /// <param name="id">Id de tipo int</param>
        /// <param name="nombre">Nombre de tipo string</param>
        /// <param name="apellido">Apellido de tipo string</param>
        /// <param name="dni">Dni de tipo string</param>
        /// <param name="nacionalidad">Nacionalidad de tipo ENacionalidad</param>
        public Profesor(int id, string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Agrega dos clases al Queue de clases,utilizando el atributo random
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del metodo Mostrar datos de MostrarDatos de Universitario,muetra todos los datos del Profesor
        /// </summary>
        /// <returns>Retorna un string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());           
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Implementacion del metodo ParticiparEnClase de la clase Universitario
        /// </summary>
        /// <returns>Retorna un string con las clases del dia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASES DEL DIA : \n");            
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del ToString,hace publicos los datos del profesor
        /// </summary>
        /// <returns>Retorna un string con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobrecarga del operador "==",compara un Profesor con una clase, seran iguales si el porfesor da esa clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si son iguales, false si no lo son</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool respueta = false;

            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    respueta = true;
                    break;
                }
            }

            return respueta;
        }

        /// <summary>
        /// Sobrecarga del operador "!=",reutiliza la sobrecarga del "=="
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si son distintos o false si son iguales</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
