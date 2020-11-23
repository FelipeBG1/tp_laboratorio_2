using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesTP4;
using Excepciones;

namespace Formulario
{
    public partial class FormLibro : Form
    {
        private Libro libro;
        public delegate int EventoPrecioInvalido(object sender, EventArgs e);
        public event EventoPrecioInvalido PrecioInvalido;

        #region Propiedades
        
        /// <summary>
        /// Retorna el libro que se instanciara mas abajo
        /// </summary>
        public Libro Libro
        {
            get { return libro; }
        }

        /// <summary>
        /// Retorna el contenido del label de Caracteristica
        /// </summary>
        public string Caracteristica
        {
            get { return this.CaracteristicaBox.Text; }
        }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor del formulario,asigna al evento PrecioInvalido un manejador
        /// </summary>
        public FormLibro()
        {
            InitializeComponent();
            this.PrecioInvalido += this.libroPrecioInvalido;
            this.Text = "Agregar stock";

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Manejador del evento PrecioInvalido
        /// Verifica si se puede parsear el contenido del textBox de precio, si no establece un precio determinado para el cuento,novela o investigacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Retorna el precio </returns>
        private int libroPrecioInvalido(object sender, EventArgs e)
        {
            int precioParseado;
            bool todoOK = int.TryParse(this.PrecioBox.Text, out precioParseado);

            if (!todoOK)
            {
                MessageBox.Show("El precio es inválido, se asigno un precio según el mercado", "Advertencia precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                switch (this.TipoBox.Text)
                {
                    case "Cuento":
                        precioParseado = 450;
                        break;

                    case "Novela":
                        precioParseado = 1000;
                        break;

                    case "Investigacion":
                        precioParseado = 2400;
                        break;
                }

            }

            return precioParseado;
        }


        /// <summary>
        /// Modifica el label dependiendo del contenido del comboBox de Tipo e invoca al metodo cambiarCaracteristica, pasandole un array de objects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TipoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.TipoBox.SelectedIndex)
            {
                case 0:
                    this.lblCaracteristica.Text = "Ilustraciones:";
                    this.cambiarCaracteristicas(new object[] { "Incluye ilustraciones", "No incluye ilustraciones" });
                    break;
                case 1:
                    this.lblCaracteristica.Text = "Autógrafo:";
                    this.cambiarCaracteristicas(new object[] { "Autografiado", "Sin autografiar" });
                    break;
                case 2:
                    this.lblCaracteristica.Text = "Cantidad de tomos:";
                    this.cambiarCaracteristicas(new object[] { "2 tomos", "4 tomos" });
                    break;
            }
        }

        /// <summary>
        /// Limpia y luego Modifica el comboBox de Caracteristica con los datos que estan en el array de objects pasado por parametro
        /// </summary>
        /// <param name="datos"></param>
        private void cambiarCaracteristicas(object[] datos)
        {
            this.CaracteristicaBox.Items.Clear();
            this.CaracteristicaBox.Items.AddRange(datos); //Se le agregan estos parametros al combobox de caracteristica
        }

        #endregion

        #region Click y SelectedIndex

        /// <summary>
        /// Manejador del evento click del boton Aceptar
        /// Se invoca al evento PrecioInvalido,se instancia un cuento,una novela o un investigacion dependiendo el contenido el comboBox de tipo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int precio;
            try
            {
                if (this.EditorialBox.Text != "" && this.TituloBox.Text != "" && this.TipoBox.SelectedIndex != -1 && this.CaracteristicaBox.SelectedIndex != -1)
                {
                    precio = this.PrecioInvalido.Invoke(this, EventArgs.Empty); ;
                    switch (this.TipoBox.Text)
                    {
                        case "Cuento":
                            this.libro = new Cuento(this.EditorialBox.Text, this.TituloBox.Text, precio, this.CaracteristicaBox.Text);
                            break;

                        case "Novela":
                            if (this.CaracteristicaBox.Text == "Autografiado")
                            {
                                this.libro = new Novela(this.EditorialBox.Text, this.TituloBox.Text, precio, true);
                            }
                            else
                            {
                                this.libro = new Novela(this.EditorialBox.Text, this.TituloBox.Text, precio, false);
                            }
                            break;

                        case "Investigacion":
                            if (this.CaracteristicaBox.Text == "2 tomos")
                            {
                                this.libro = new Investigacion(this.EditorialBox.Text, this.TituloBox.Text, precio, 2);
                            }
                            else
                            {
                                this.libro = new Investigacion(this.EditorialBox.Text, this.TituloBox.Text, precio, 4);
                            }
                            break;
                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    throw new CampoVacioException();
                }
            }
            catch (CampoVacioException ex)
            {
                MessageBox.Show(ex.Message, "Error campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Manejador del evento click del boton Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCncelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        #endregion

    }
}
