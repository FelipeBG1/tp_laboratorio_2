using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Propiedad Set
        /// <summary>
        /// Valida y setea el valor del atributo privado numero
        /// </summary>
        public string SetNumero
        {
            set
            {
                double numero;

                numero = this.ValidarNumero(value);

                if (numero != 0)
                {
                    this.numero = numero;
                }
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que establece el valor del atributo numero en 0
        /// </summary>
        public Numero()
        {
            this.SetNumero = "0";
        }

        /// <summary>
        /// Constructor que recibe un parametro de tipo double e iguala el atributo numero a el numero pasado por parametro
        /// </summary>
        /// <param name="numero">Numero que le dara valor al atributo privado numero</param>
        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        /// <summary>
        /// Constructor que recibe un parametro de tipo string e iguala el atributo numero a el numero pasado por parametro
        /// </summary>
        /// <param name="strNumero">Numero que le dara valor al atributo privado numero</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>El numero en binario(cadena), 0 si el numero es menor a 0 o "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            int auxNum;
            bool esNumero;


            esNumero = int.TryParse(numero.ToString(), out auxNum);

            if (esNumero)
            {
                if(auxNum<0)
                {
                    auxNum = auxNum * (-1);
                }             
                    int aux = 0;
                    string auxString = "";
                    string retorno = "";

                    while (auxNum > 0)
                    {
                        aux = auxNum % 2;
                        auxString = Convert.ToString(aux);
                        retorno = auxString + retorno;
                        auxNum = auxNum / 2;
                    }

                    return retorno;
               
            }
            else
            {
                return "Valor inválido";
            }


        }

        /// <summary>
        /// Convierte un numero decimal a binario, llama al DecimalBinario al cual se le pasa un double
        /// </summary>
        /// <param name="numero">Numero a convertir en formato string</param>
        /// <returns>El numero en binario o si no se pudo parsear el numero "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            string numeroBinario;
            bool numeroValidado;
            double auxNumero;

            numeroValidado = double.TryParse(numero, out auxNumero);
            if (numeroValidado)
            {
                numeroBinario = DecimalBinario(auxNumero);

                return numeroBinario;
            }
            else
            {
                return "Valor inválido";
            }

        }
        /// <summary>
        /// Convierte un numero binario en decimal
        /// </summary>
        /// <param name="numero">Numero a convertir en formato string</param>
        /// <returns>El numero convertido a decimal y si el numero a convertir no es binario "Valor invalido"</returns>
        public string BinarioDecimal(string numero)
        {
            bool validado;

            validado = EsBinario(numero);

            if (validado)
            {
                char[] array = numero.ToCharArray();

                Array.Reverse(array);

                int auxNum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        if (i == 0)
                        {
                            auxNum += 1;
                        }
                        else
                        {
                            auxNum += (int)Math.Pow(2, i);
                        }
                    }

                }

                return Convert.ToString(auxNum);
            }
            else
            {
                return "Valor inválido";
            }


        }
        /// <summary>
        /// Valida el numero pasado por parametro
        /// </summary>
        /// <param name="strNumero">Numero a validar</param>
        /// <returns>El numero en formato double y si no se pudo parsear devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            bool validado;

            validado = double.TryParse(strNumero, out double numero);

            if (validado == true)
            {
                return numero;
            }

            return 0;
        }



        /// <summary>
        /// Valida si el numero pasado por parametro es binario
        /// </summary>
        /// <param name="str">Numero en formato string a validar</param>
        /// <returns>True si es binario False si no lo es</returns>
        private bool EsBinario(string str)
        {
            bool aux = false;

            foreach (char item in str)
            {
                if (item == '0' || item == '1')
                {
                    aux = true;

                }
                else
                {
                    aux = false;
                    return aux;
                }
            }
            return aux;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador "+", realiza la operacion suma
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double suma;

            suma = n1.numero + n2.numero;

            return suma;
        }

        /// <summary>
        /// Sobrecarga del operador "-", realiza la operacion resta
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado de la resta</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resta;

            resta = n1.numero - n2.numero;

            return resta;
        }

        /// <summary>
        /// Sobrecarga del operador "/", realiza la operacion division
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado de la division si el segundo operando es mayo a 0 o si no lo es el minimo valor posible de un double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double division;

            if (n2.numero != 0)
            {
                division = n1.numero / n2.numero;
                return division;
            }

            return double.MinValue;
        }

        /// <summary>
        /// Sobrecarga del operador "*", realiza la operacion multiplicacion
        /// </summary>
        /// <param name="n1">Primer operando</param>
        /// <param name="n2">Segundo operando</param>
        /// <returns>El resultado de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double multiplicacion;

            multiplicacion = n1.numero * n2.numero;

            return multiplicacion;
        }
        #endregion
    }
}
