using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesTP4
{
    // Clase abstracta Libro
    
    [XmlInclude(typeof(Libro))]
    [XmlInclude(typeof(Cuento))]
    [XmlInclude(typeof(Novela))]
    [XmlInclude(typeof(Investigacion))]
    
    public abstract class Libro
    {
        private string editorial;
        private int precio;
        private string titulo;

        #region Propiedades
        /// <summary>
        /// Propiedad abstracta sin implementacion,debera retornar la cantidad de paginas
        /// </summary>
        public abstract int CantPag 
        {
            get;
        }

        /// <summary>
        /// Propiedad abstracta sin implementacion,debera retornar el tipo de cubierta
        /// </summary>
        public abstract string Cubierta
        {
            get;
        }

        /// <summary>
        /// Retorna la editorial,setea una editorial
        /// </summary>
        public string Editorial
        {
            get { return this.editorial; }
            set { this.editorial = value; }
        }

        /// <summary>
        /// Retorna el precio,setea un precio
        /// </summary>
        public int Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        /// <summary>
        /// Retorna el titulo,setea un titulo
        /// </summary>
        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor,instancia un libro
        /// </summary>
        /// <param name="editorial">Editorial a setear</param>
        /// <param name="titulo">Titulo a setear</param>
        /// <param name="precio">Precio a setear</param>
        public Libro(string editorial,string titulo,int precio)
        {
            this.editorial = editorial;
            this.titulo = titulo;
            this.precio = precio;
        }

        /// <summary>
        /// Constructor sin parametros,default
        /// </summary>
        public Libro()
        {

        }

        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve un string con los datos del libro
        /// </summary>
        /// <returns>String con los datos del libro</returns>
        private string LibroToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Editorial: {0}\n", this.editorial);
            sb.AppendFormat("Titulo: {0}\n", this.titulo);
            sb.AppendFormat("Precio: {0}", this.precio);

            return sb.ToString();
        }



        /// <summary>
        /// Hace publicos los datos del metodo LibroToString
        /// </summary>
        /// <returns>String con los datos del libro</returns>
        public override string ToString()
        {
            return this.LibroToString();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del ==, compara si un libro es igual a otro
        /// </summary>
        /// <param name="l1">Libro 1</param>
        /// <param name="l2">Libro 2</param>
        /// <returns>True o false segun corresponda</returns>
        public static bool operator ==(Libro l1,Libro l2)
        {
            bool verifica=false;
            
            if(l1.Editorial==l2.Editorial && l1.Titulo==l2.Titulo)
            {
                verifica = true;
            }

            return verifica;
 
        }

        /// <summary>
        /// Reutiliza la sobrecarga del ==
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns>True o false segun corresponda</returns>
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }
        #endregion
    }
}
