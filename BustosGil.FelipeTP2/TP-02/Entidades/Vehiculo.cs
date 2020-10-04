using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        
        EMarca marca;
        string chasis;
        ConsoleColor color;

        #region Constructor
        /// <summary>
        /// Constructor de tipo Vehiculo, inicializa los atributos marca,chasis y color con los datos pasados por parametro
        /// </summary>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        protected Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }

        #endregion

        #region Propiedad
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected virtual ETamanio Tamanio { get;  }
        #endregion

        #region Metodo
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga de string, muestra los datos del vehiculo, es invocada por el metodo Mostrar haciendo un casteo explicito de this a tipo string
        /// </summary>
        /// <param name="p">Parametro de tipo Vehiculo</param>
        /// <returns>Retorna un string con todos los datos del vehiculo</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }


        /// <summary>
        /// Sobrecarga de Object.Equals especificando el tipo Vehiculo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Retorna true si this y obj casteado a Vehiculo son iguales, y si no lo son terona false</returns>
        public override bool Equals(object obj)
        {
            bool rta = false;

            if (obj is Vehiculo)
            {
                rta = this == (Vehiculo)obj;
            }

            return rta;
        }

        /// <summary>
        /// Sobrecarga de Object.GetHashCode para Vehiculo
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion




    }
}
