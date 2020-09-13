using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Valida si el operardor es +,-,/ o *
        /// </summary>
        /// <param name="operador"></param>
        /// <returns> Si es uno de los 4 operadores mencionados lo devuelvee en formato string y sino devuelve "+"
        /// </returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador.ToString(); ;
            }

            return "+";
        }

        /// <summary>
        /// Llama a validarOperador para validar el operador y lleva a cabo las operaciones matemáticas utilizando las sobrecargas de los operadores
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador que especifica que tipo de operacion se quiere llevar acabo con los operandos anteriores</param>
        /// <returns>El resultado de la operacion o 0
        /// </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;
            string operadorValidado;

            if (operador != "")
            {
                operadorValidado = Calculadora.ValidarOperador(Convert.ToChar(operador));

                if (operadorValidado == "+")
                {
                    resultado = num1 + num2;
                }
                else
                {
                    if (operadorValidado == "-")
                    {
                        resultado = (num1 - num2);
                    }
                    else
                    {
                        if (operadorValidado == "/")
                        {
                            resultado = (num1 / num2);
                        }
                        else
                        {
                            resultado = num1 * num2;
                        }
                    }
                }

                return resultado;
            }
            else
            {
                return 0;
            }



        }
        #endregion
    }
}
