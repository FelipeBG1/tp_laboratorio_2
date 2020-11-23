using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class LibroRepetidoException:Exception
    {
        public LibroRepetidoException() : base("Ya se encuentra en el stock,no es necesario agregarlo")
        {

        }
    }
}
