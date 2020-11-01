using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Definicion del metodo Guardar sin implementacion.
        /// </summary>
        /// <param name="archivo">archivo en donde se guardaran los datos</param>
        /// <param name="datos">datos que se van a guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Definicion del metodo Leer sin implementacion
        /// </summary>
        /// <param name="archivo">archivo que se va a leer</param>
        /// <param name="datos">variable donde se guardara el contenido del archivo para ser leida</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);

    }
}
