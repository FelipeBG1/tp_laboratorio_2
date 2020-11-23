using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CampoVacioException:Exception
    {
        /// <summary>
        /// Excepcion que se lanzara si al tartar de agregar stock de libros no se completa un campo, o ninguno
        /// </summary>
        public CampoVacioException():base("Debe completar todos los campos")
        {

        }
    }
}
