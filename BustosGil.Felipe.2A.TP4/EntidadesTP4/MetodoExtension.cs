using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesTP4
{
    public static class MetodoExtension
    {
        /// <summary>
        /// Extension de la clase LibroRepetidoException
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>Retorna un string advirtiendo que el lirbo ya se encuentra en al lista</returns>
        public static string InformarLibroRepetido(this LibroRepetidoException ex)
        {
            return "Ese libro ya se encuentra en la libreria, no hace falta agregarlo";
        }
    }
}
