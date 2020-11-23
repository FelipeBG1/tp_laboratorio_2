using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EntidadesTP4
{
    //Clase publica Libreria, implementa la interfaz ISerializa
    public class Libreria:ISerializa<Libreria>
    {
        public List<Libro> libros;

        #region Propiedades
        /// <summary>
        /// Retorna la lista de libros
        /// </summary>
        public List<Libro> Libros
        {
            get
            {
                return this.libros;
            }
        }

        /// <summary>
        /// Suma los precios de todos los libros de la lista y retorna el valor de esa suma
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                double total = 0;
                foreach (Libro item in this.libros)
                {
                    total += item.Precio;
                }

                return total;
            }
        }

        /// <summary>
        /// Implementacion de la propiedad Path de ISerializam, retorna una ubicacion
        /// </summary>
        public string Path
        {
            get { return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop).ToString();}
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor, instancia una libreria,crea la lista
        /// </summary>
        public Libreria()
        {
            this.libros = new List<Libro>();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Implementacion del metodo Xml de ISerializa
        /// </summary>
        /// <param name="dato">Dato a serializar</param>
        /// <param name="archivo">Archivo donde se guardara el resultado</param>
        /// <returns>True o false segun corresponda</returns>
        public bool Xml(Libreria dato, string archivo)
        {
            bool verifica = true;

            try
            {
                using (XmlTextWriter xw = new XmlTextWriter(this.Path + "//" + archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Libreria));
                    ser.Serialize(xw, dato);
                }
            }
            catch (Exception ex)
            {
                verifica = false;
                Console.WriteLine(ex.Message);
            }

            return verifica;
        }

        /// <summary>
        /// Guarda en un archivo de texto una libreria(datos de los libros de la lista,el total de la suma y agrega la fecha y hora)
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public bool GuardarTexto(string nombreArchivo)
        {
            bool verifica = true;
            string archivo = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"/ " + nombreArchivo;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, Encoding.UTF8))
                {
                    sw.WriteLine("Fecha: {0}", System.DateTime.Now);
                    foreach (Libro item in this.Libros)
                    {
                        sw.WriteLine(item.ToString());
                    }
                    sw.WriteLine("-------------------------------");
                    sw.WriteLine("----------------------Total: {0}", this.PrecioTotal);
                }

            }
            catch (Exception)
            {
                verifica = false;
            }

            return verifica;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del ToString
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la libreria y los datos de los libros de la lista</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("\nCantidad de elementos: {0}\n", this.libros.Count);
            sb.AppendFormat("Precio total: {0}\n", this.PrecioTotal);
            sb.AppendFormat("Lista de libros:\n");

            foreach (Libro item in this.libros)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

  
        /// <summary>
        /// Sobrecarca del +,agrega un libro a la lista mientras no este, utiliza el == para verificar esto
        /// </summary>
        /// <param name="libreria">Libreria</param>
        /// <param name="l1">Libro a agregar</param>
        /// <returns>Retorna la libreria</returns>
        public static Libreria operator +(Libreria libreria, Libro l1)
        {            
            libreria.libros.Add(l1);
            
            return libreria;
        }

        #endregion
    }
}
