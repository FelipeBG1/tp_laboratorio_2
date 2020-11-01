using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntidadesAbstractas
{
    //Clase abstracta Universitario, deriva de Persona
    public abstract class Universitario:Persona
    {
        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor de Universitario, inicializa con un valor por defecto al atributo legajo e invoca al constructor sin parametros de la clase Persona
        /// </summary>
        public Universitario():base()
        {
        }

        /// <summary>
        /// Constructor de Universitario, inicializa el atributo legajo con el legajo pasado por parametro
        /// Invoca al constructor de la clase Persona al cual le pasa los parametros restantes
        /// </summary>
        /// <param name="legajo">Legajo de tipo int que se asignara al atributo legajo</param>
        /// <param name="nombre">Nombre de tipo string, pasado por parametro al constructor de la clase Persona</param>
        /// <param name="apellido">Apellido de tipo string, pasado por parametro al constructor de la clase Persona</param>
        /// <param name="dni">Dni de tipo int, pasado por parametro al constructor de la clase Persona</param>
        /// <param name="nacionalidad">Nacionalidad de tipo ENacionalidad, pasado por parametro al constructor de la clase Persona</param>
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo virtual que devolvera un string con los datos del universitario
        /// </summary>
        /// <returns>String con los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto,que sera implementado en las clases que deriven de Universitario
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del operador "==" que verificara que dos Universitarios sean iguales
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>Retorna true si son iguales y false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool respueta = false;

            if(pg1.GetType() == pg2.GetType() && pg1.legajo==pg2.legajo || pg1.DNI == pg2.DNI)
            {
                respueta = true;
            }

            return respueta;
        }

        /// <summary>
        /// Sobrecarga del operador "!=" reutiliza la sobrecarga del "=="
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>Retorna lo que devuelve el == y lo niega</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        
        /// <summary>
        /// Sobrecarga del Equals para Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna un booleano</returns>
        public override bool Equals(object obj)
        {
            bool rta = false;

            if (obj is Universitario)
            {
                rta = this == (Universitario)obj;
            }

            return rta;
        }
        #endregion
    }
}
