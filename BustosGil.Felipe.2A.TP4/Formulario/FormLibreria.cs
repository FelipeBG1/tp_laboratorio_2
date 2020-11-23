using EntidadesTP4;
using Excepciones;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Formulario
{
    public partial class FormLibreria : Form
    {
        private DataTable dt;
        private AccesoDatos ac;
        private Libreria venta;
        private Libro libro;
        private bool flagComprobante;
        private bool flagAgregado;
        private bool flagVendido;
        private Thread hiloSecundario;

        #region Constructor
        /// <summary>
        /// Constructor, instancia un formLibreria
        /// Instancia el hilo secundario y lo inicia
        /// </summary>
        public FormLibreria()
        {
            InitializeComponent();
            this.ac = new AccesoDatos();
            this.venta = new Libreria();
            this.flagComprobante = false;
            this.flagAgregado = false;
            this.flagVendido = false;
            this.Text = "Libreria";
            this.hiloSecundario = new Thread(this.ActualizarBD);
            this.hiloSecundario.Start();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Configura la grilla
        /// </summary>
        private void ConfigurarGrilla()
        {
            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.Beige;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dataGridView1.BackgroundColor = Color.DarkSeaGreen;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Italic);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.GridColor = Color.Black;
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Gray;
            this.dataGridView1.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.DataSource = this.dt;

        }

        /// <summary>
        /// Metodo vender, vendera el libro lo agregara a una lista de venta y mostrara el precio en un label
        /// </summary>
        private void Vender()
        {
            try
            {
                int i = this.dataGridView1.CurrentRow.Index;
                DataRow fila = this.dt.Rows[i];

                string editorial = fila["editorial"].ToString();
                string titulo = fila["titulo"].ToString();
                string tipo = fila["tipo"].ToString();
                int precio = int.Parse(fila["precio"].ToString());
                string caracteristica = fila["caracteristica"].ToString();

                switch (tipo)
                {
                    case "Cuento":
                        this.libro = new Cuento(editorial, titulo, precio, caracteristica);
                        this.venta += this.libro;
                        break;

                    case "Novela":
                        if (caracteristica == "Autografiado")
                        {
                            this.libro = new Novela(editorial, titulo, precio, true);
                        }
                        else
                        {
                            this.libro = new Novela(editorial, titulo, precio, false);
                        }
                        this.venta += this.libro;
                        break;

                    case "Investigacion":
                        if (caracteristica == "2 tomos")
                        {
                            this.libro = new Investigacion(editorial, titulo, precio, 2);
                        }
                        else
                        {
                            this.libro = new Investigacion(editorial, titulo, precio, 4);
                        }
                        this.venta += this.libro;
                        break;
                }

                this.lblPrecioLibro.Text = "Libro vendido precio: " + precio.ToString();
                MessageBox.Show("Se ha vendido un ejemplar de este libro");
                this.flagVendido = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Metodo(paso su direccion de memoria para el hilo secundario), actualiza cada 1 segundo la base de datos y muestra un mensaje en el label Actualizar si se actualizo o si no hay que actualizar
        /// </summary>
        private void ActualizarBD()
        {

            do
            {
                Thread.Sleep(1000);


                if (this.flagAgregado)
                {
                    ac.ActualizarStock(this.dt);

                    if (this.lblActualizar.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.lblActualizar.Text = "Base de datos actualizada";
                        }
                        );
                    }
                }
                else
                {
                    if (this.lblActualizar.InvokeRequired)
                    {
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            this.lblActualizar.Text = "No hay cambios que actualizar";
                        }
                        );
                    }
                }

            }
            while (this.hiloSecundario.IsAlive);

        }
        #endregion

        #region Click

        /// <summary>
        /// Manejador del evento click del boton agregar, instancia un formualrio de tipo FormLibro, obtiene los datos y agrega al dataTable el nuevo libre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormLibro frm = new FormLibro();
            bool iguales = false;
            try
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow fila = this.dt.NewRow();
                    fila["editorial"] = frm.Libro.Editorial;
                    fila["titulo"] = frm.Libro.Titulo;
                    fila["tipo"] = frm.Libro.GetType().Name;
                    fila["precio"] = frm.Libro.Precio;
                    fila["caracteristica"] = frm.Caracteristica;

                    foreach (DataRow item in this.dt.Rows)
                    {
                        if (item["editorial"].ToString() == fila["editorial"].ToString() && item["titulo"].ToString() == fila["titulo"].ToString())
                        {
                            iguales = true;
                            break;
                        }
                    }


                    if (!iguales)
                    {
                        this.dt.Rows.Add(fila);
                        this.dt = (DataTable)this.dataGridView1.DataSource;
                        this.flagAgregado = true;
                    }
                    else
                    {
                        throw new LibroRepetidoException();
                    }
                }
            }
            catch (LibroRepetidoException ex)
            {
                MessageBox.Show(ex.InformarLibroRepetido(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Manejador del evento click del boton Vender, invocara al metodo Vender y vendera un libro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            this.Vender();
        }


        /// <summary>
        /// Manejador del evento click del boton Comprobante, mientars se haya realizado una venta genera un comprobante con la lista de venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprobante_Click(object sender, EventArgs e)
        {
            bool verifica;
            if (this.flagVendido)
            {
                verifica = this.venta.GuardarTexto("ComprobanteVenta.txt");

                if (verifica)
                {
                    MessageBox.Show("Se generó el comprobante de compra con exito,lo encontrará en Documentos", "Comprobante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.flagComprobante = true;                  
                }
                else
                {
                    MessageBox.Show("No se pudo generar el comprobante de compra", "Error con el comprobante", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No ha vendido nigún producto,no hace falta imprimir un comprobante", "Comprobante innecesario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Manejador del evento click del boton Venta Xml, mientras se haya realizado una venta serializa la lista de venta en xmml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXml_Click(object sender, EventArgs e)
        {
            bool verifica;
            if (this.flagVendido)
            {
                verifica = this.venta.Xml(this.venta, "VentaXml.xml");

                if (verifica)
                {
                    MessageBox.Show("Se guardo correctamente la venta,encontrará el archivo xml en su escritorio", "Venta Xml", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo crear el archivo xml con la venta", "Error: venta Xml", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No ha vendido nigún producto,no hace falta imprimir un xml con los datos", "Xml innecesario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Manejador del evento click del boton Cerrar,cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (!this.flagAgregado && !this.flagVendido)
            {
                this.Close();
            }
            else
            {
                if (this.flagVendido && !this.flagComprobante)
                {
                    MessageBox.Show("El cliente solicitó el comprobante de compra, hay que imprimirlo", "Comprobante solicitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Close();
                }
            }
        }



        #endregion

        #region Load y Closing

        /// <summary>
        /// Cuando carga el form obtiene la tabla y configura la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                this.dt = ac.ObtenerTablaLibros();
                this.ConfigurarGrilla();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Realiza el abort al hilo secundario siempre y cuando este vivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.flagVendido && !this.flagComprobante)
            {
                MessageBox.Show("El cliente solicitó el comprobante de compra, hay que imprimirlo", "Comprobante solicitado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                if (this.hiloSecundario.IsAlive)
                {
                    this.hiloSecundario.Abort();
                }
                
            }        
        }

    #endregion
    }
}
