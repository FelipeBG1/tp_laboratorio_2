using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            this.Text = "Calculadora de Felipe Bustos Gil del curso 2A";
            this.StartPosition = FormStartPosition.CenterScreen;         
            
        }
        #region Metodos
        /// <summary>
        /// Invoca al metodo operar del la clase calculadora
        /// </summary>
        /// <param name="numero1">Primer operando en formato string</param>
        /// <param name="numero2">Segundo operando en formato string</param>
        /// <param name="operador">Operador en formato string</param>
        /// <returns>El resultado de la operacion matematica</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            double resultado;   

            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;
        }

        /// <summary>
        /// Limpia las casillas de los operandos,la del operador y la del resultado
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.SelectedIndex = 0;

        }
        #endregion

        #region Eventos(Click)
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(this.txtNumero1.Text,this.txtNumero2.Text,this.cmbOperador.Text);

            this.lblResultado.Text = resultado.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string numero;

            if (this.lblResultado.Text != "")
            {
                Numero auxNum = new Numero();

                numero = auxNum.DecimalBinario(this.lblResultado.Text);

                this.lblResultado.Text = numero;
            }
            else
            {
                this.lblResultado.Text = "Valor inválido";
            }

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero;

            if (this.lblResultado.Text != "")
            {
                Numero auxNum = new Numero();

                numero = auxNum.BinarioDecimal(this.lblResultado.Text);

                this.lblResultado.Text = numero;
            }
            else
            {
                this.lblResultado.Text = "Valor inválido";
            }

        }

        #endregion

    }
}
