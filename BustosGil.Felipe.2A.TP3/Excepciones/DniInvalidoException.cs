using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        public DniInvalidoException():base("El DNI tiene un formato que no corresponde un DNI oficial")
        {
        }

        public DniInvalidoException(Exception e):base("El DNI tiene un formato que no corresponde un un DNI oficial",e)
        {

        }

        public DniInvalidoException(string message):base(message)
        {

        }

        public DniInvalidoException(string message,Exception e):base(message,e)
        {

        }
    }
}
