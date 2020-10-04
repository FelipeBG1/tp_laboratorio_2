using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Clase publica Ciclomotor deriva de la clase Vehiculo
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor de tipo Ciclomotor, invoca al constructor de su clase padre(Vehiculo) y este inicializa los atributos marca,chasis y color
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
        }
        #endregion

        #region Propiedad

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return  ETamanio.Chico;
            }
        }

        #endregion

        #region Metodo
        /// <summary>
        /// Sobreescribe el método virtual Mostrar de la clase vehículo, para mostrar los datos del ciclomotor
        /// </summary>
        /// <returns>Retorna un string con los datos del ciclomotor</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine(" ");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
