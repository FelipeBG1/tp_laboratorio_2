using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        public NacionalidadInvalidaException():base("El DNI no concuerda con una nacionalidad válida")
        {
            
        }

        public NacionalidadInvalidaException(string message):base(message)
        {

        }

    }
}
