using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #region Enum
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de Persona sin parametros, inicializa todos los atributos con valores por defecto
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Constructor de Persona inicializa el atributo dni ,invocando a la propiedad StringToDni, con el dni en formato string pasado por parametro.
        /// Invoca al constructor de Persona que tiene tres parametros
        /// </summary>
        /// <param name="nombre">Nombre en formato string pasado por parametro al constructor de 3 parametros</param>
        /// <param name="apellido">Apellido en formato string pasado por parametro al constructor de 3 parametros</param>
        /// <param name="dni">DNI en formato string que inicializara el atributo dni</param>
        /// <param name="nacionalidad">Nacionalidad en formato ENacionalidad pasado por parametro al constructor de 3 parametros</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Constructor de Persona inicializa el atributo dni con el dni pasado por parametro
        /// Invoca al constructor de Persona que tiene tres parametros
        /// </summary>
        /// <param name="nombre">Nombre en formato string pasado por parametro al constructor de 3 parametros</param>
        /// <param name="apellido">Apellido en formato string pasado por parametro al constructor de 3 parametros</param>
        /// <param name="dni">DNI en formato int que inicializara el atributo dni</param>
        /// <param name="nacionalidad">Nacionalidad en formato ENacionalidad pasado por parametro al constructor de 3 parametros</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }

        /// <summary>
        /// Constructor de Persona que inicializara los atributos con los datos pasados por parametros
        /// Invoca al constructor sin parametros para que inicialice el atributo dni,ya que este constructor no lo inicializa
        /// </summary>
        /// <param name="nombre">Nombre en formato string con el que se inicializara el atributo nombre</param>
        /// <param name="apellido">Apellido en formato string con el que se inicializara el atributo apellido</param>
        /// <param name="nacionalidad">Nacionalidad en formato ENacionalidad con el que se inicializara el atributo nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            :this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura, que devolvera el apellido o se lo asignara al atributo apellido, invoca al metodo ValidarNombreApellido para validar antes de asignar
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }
            set
            {

                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }

            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, que devolvera el dni o se lo asignara al atributo dni, invoca al metodo ValidarDni para validar antes de asignar
        /// </summary>
        public int DNI
        {
            get { return this.dni; }
            set
            {
                 this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, que devolvera la nacionalidad o se la asignara al atributo nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura, que devolvera el nombre o se lo asignara al atributo nombre, invoca al metodo ValidarNombreApellido para validar antes de asignar
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }

            }                         
        }

        /// <summary>
        /// Propiedad de escritura, que asignara el dni al atributo dni, invoca al metodo ValidarDni para validar antes de asignar
        /// </summary>
        public string StringToDNI
        {
            set
            {

                if (ValidarDni(this.nacionalidad, value) == Convert.ToInt32(value))
                {
                    this.dni = Convert.ToInt32(value);
                }

            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Valida el dni pasado por parametro, utilizando para esto la nacionalidad pasada por parametro
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de tipo ENacionalidad utilizada para validar el dni</param>
        /// <param name="dato">DNI de tipo int que se validara</param>
        /// <returns>Retorna el dni validado o lanza una excepcion</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {

            if ((nacionalidad == ENacionalidad.Argentino && dato >= 1 && dato <= 89999999)||nacionalidad == ENacionalidad.Extranjero && dato >= 90000000 && dato <= 99999999)
            {

                return dato;

            }
            else
            {
                throw new NacionalidadInvalidaException("Error. La nacionalidad no coincide con el DNI.");
            }

        }

        /// <summary>
        /// Valida el dni pasado por parametro,utilizando para esto la nacionalidad pasada por parametro
        /// Ambos parametros se pasaran por parametro al ValidarDNI de arriba que sera invocado para que lleve a cabo la validacion
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de tipo ENacionalidad utilizada para validar el dni</param>
        /// <param name="dato">DNI de tipo string que se validara</param>
        /// <returns>Lo que retorne el ValidarDNI de arriba</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            int numeroDni = -1;

            if (dato.Length < 1 || dato.Length > 8 || !(int.TryParse(dato, out numeroDni)))
            {
                throw new DniInvalidoException("El DNI no coincide con el formato");
            }
            return ValidarDni(nacionalidad, numeroDni);

        }

        /// <summary>
        /// Valida el Nombre o el Apellido
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Si ese nombre o apellido se puede validar lo devuelve, pero si no devuelve null</returns>
        private string ValidarNombreApellido(string dato)
        {
            if (dato.Any(char.IsSymbol) || dato.Any(char.IsDigit))
            {
                return null;
            }
            else
            {
                return dato;
            }
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga del metodo ToString, que mostrara todos los datos de la Persona
        /// </summary>
        /// <returns>Retorna los datos de la Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("NOMBRE COMPLETO: {0},{1}\n",this.apellido,this.nombre);
            sb.AppendFormat("Nacionalidad: {0} \n", this.nacionalidad);

            return sb.ToString();
        }
        
        #endregion

    }
}
