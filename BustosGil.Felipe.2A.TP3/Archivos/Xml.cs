using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        /// <summary>
        /// Implementacion del metodo Guardar de la interfaz IArchivo para archivo XML
        /// </summary>
        /// <param name="archivo">archivo de texto donde se guardaran los datos</param>
        /// <param name="datos">datos a guardar en el archivo</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                bool verifica = false;

                using (XmlTextWriter xw = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(xw, datos);
                    verifica = true;
                }

                return verifica;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            
        }

        /// <summary>
        /// Implementacion del metodo Leer de la interfaz IArchivo para archivo XML
        /// </summary>
        /// <param name="archivo">archivo XML del cual se va a leer el contenido</param>
        /// <param name="datos">variable donde se guardara lo leido</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                bool verifica = false;

                using (XmlTextReader xr = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(xr);

                    verifica = true;
                }

                return verifica;
            }
            catch (ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            
        }
    }
}
