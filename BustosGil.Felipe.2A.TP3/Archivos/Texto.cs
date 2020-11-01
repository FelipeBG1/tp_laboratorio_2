using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        /// <summary>
        /// Implementacion del metodo Guardar de la interfaz IArchivo para archivo de texto
        /// </summary>
        /// <param name="archivo">archivo de texto donde se guardaran los datos</param>
        /// <param name="datos">datos a guardar en el archivo</param>
        /// <returns></returns>
        public bool Guardar(string archivo,string datos)
        {
            try
            {
                bool verifica = false;
            
                using (StreamWriter sw = new StreamWriter(archivo,true,Encoding.UTF8))
                {
                    sw.WriteLine(datos);
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
        /// Implementacion del metodo Leer de la interfaz IArchivo para archivo de texto
        /// </summary>
        /// <param name="archivo">archivo de texto del cual se va a leer el contenido </param>
        /// <param name="datos">variable donde se guardara lo leido</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool verifica = false;
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    verifica = true;
                }

                return verifica;
            }
            catch(ArchivosException e)
            {
                throw new ArchivosException(e);
            }
            
        }
    }
}
