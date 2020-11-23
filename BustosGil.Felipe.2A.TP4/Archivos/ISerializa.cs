using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    //Interfaz publica y generica
   public interface ISerializa<T>
   {
        /// <summary>
        /// Serializara en xml
        /// </summary>
        /// <param name="dato">Dato a serializar</param>
        /// <param name="archivo">Archivo donde se guardara lo serializado</param>
        /// <returns>True o flase segun corresponda</returns>
        bool Xml(T dato,string archivo);

        /// <summary>
        /// Propiedad que retornara la direccion donde se guardara el archivo
        /// </summary>
        string Path
        {
            get;
        }
   }
}
