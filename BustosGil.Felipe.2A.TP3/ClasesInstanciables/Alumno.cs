using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    //Clase sealed que deriva de Universitario
    public sealed class Alumno:Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #region Enum

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Alumno sin parametros, invoca al constructor sin parametros de la clase Universitario
        /// </summary>
        public Alumno():base()
        {

        }

        /// <summary>
        /// Constructor de Persona que inicializara el atributo claseQueToma con la claseQueToma pasada por parametro
        /// Invoca al constructor de la clase Universitario al cual le pasa los parametros restantes
        /// </summary>
        /// <param name="id">Id de tipo int,se pasara al constructor de la clase Universitario</param>
        /// <param name="nombre">Nombre de tipo string,se pasara al constructor de la clase Universitario</param>
        /// <param name="apellido">Apellido de tipo string,se pasara al constructor de la clase Universitario</param>
        /// <param name="dni">Dni de tipo string,se pasara al constructor de la clase Universitario</param>
        /// <param name="nacionalidad">Nacionalidad de tipo ENacionalidad,se pasara al constructor de la clase Universitario</param>
        /// <param name="claseQueToma">claseQueToma de tipo EClases, con la cual se inicializara el atributo claseQueToma</param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de Persona que inicializara el atributo estadoCuenta con el estadoCuenta pasado por parametro
        /// Invoca al constructor de arriba y le pasa los parametros restantes
        /// </summary>
        /// <param name="id">Id de tipo int,se pasara al constructor de arriba</param>
        /// <param name="nombre">Nombre de tipo string,se pasara al constructor de arriba</param>
        /// <param name="apellido">Apellido de tipo string,se pasara al constructor de arriba</param>
        /// <param name="dni">Dni de tipo string,se pasara al constructor de de arriba</param>
        /// <param name="nacionalidad">Nacionalidad de tipo ENacionalidad,se pasara al constructor de arriba</param>
        /// <param name="claseQueToma">claseQueToma de tipo EClases, se pasara al constructor de arriba</param>
        /// <param name="estadoCuenta">estadoCuenta de tipo EEstadoCuenta con el cual se inicializara el atributo estadoCuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta) :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del metodo MostrarDatos de la clase Universitario,muestra todos los datos del alumno.
        /// </summary>
        /// <returns>Retorna un string con todos los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("ESTADO DE CUENTA: {0}\n", this.estadoCuenta);
            sb.AppendFormat("TOMA CLASES DE {0}\n",this.claseQueToma);
            

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo ParticiparEnClase de la clase Universitario,muestra que clase toma el alumno
        /// </summary>
        /// <returns>Retorna un string con la leyenda "Toma clase de" concatenado con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma;
        }

        /// <summary>
        /// Sobrecarga del ToString, hace publicos los datos del alumno,invocando al metodo MostrarDatos
        /// </summary>
        /// <returns>Retorna un string con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobrecarga del operador "==" que verifica si un alumno es igual a la clase, si el alumno toma esa clase y su estado de cuenta es distinto de deudor
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si son iguales o false si no lo son</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool respueta = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                respueta = true;
            }

            return respueta;
        }

        /// <summary>
        /// Sobrecarga del operador "!=",verfica que el Alumno es distinto a la clase si este no la toma
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>Retorna true si son distintos o false si no lo son</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool respueta = false;

            if (a.claseQueToma != clase)
            {
                respueta = true;
            }

            return respueta;
        }
        #endregion
    }
}
