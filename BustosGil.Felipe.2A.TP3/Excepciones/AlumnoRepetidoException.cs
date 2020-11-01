using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException:Exception
    {
        public AlumnoRepetidoException():base("No es posible agregar el alumno a al lista porque ya se encuentra en ella")
        {

        }

        public AlumnoRepetidoException(string message):base(message)
        {

        }
        
    }
}
