using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    //Clase publica Sedan que deriva de la clase Vehículo
    public class Sedan : Vehiculo
    {

        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            this.tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Constructor que inicializa el tipo con el parametro tipo que se le pasa, invoca al constructor de arriba que a la vez ese invoca al constructor de la clase Vehiculo
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro ConsoleColor</param>
        /// <param name="tipo">Parametro de tipo ETipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color,ETipo tipo)
            : this(marca, chasis, color)
        {
            this.tipo=tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Sobreescribe el método virtual Mostrar de la clase vehículo, para mostrar los datos del sedan
        /// </summary>
        /// <returns>Retorna un string con todos los datos del sedan</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\n", this.Tamanio);
            sb.AppendFormat("TIPO :  {0}",this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
