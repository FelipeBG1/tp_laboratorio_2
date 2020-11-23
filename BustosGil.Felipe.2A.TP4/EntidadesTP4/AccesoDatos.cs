using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;


namespace EntidadesTP4
{
    public class AccesoDatos
    {
        private DataTable dt;
        private SqlConnection conexion;
        private SqlDataAdapter da;

        #region Constructor
        /// <summary>
        /// Constructor, instancia un AccesoDatos,asigna la conexion
        /// </summary>
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionBD);
            
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Crea el DataTable
        /// </summary>
        /// <returns>Retorna el DataTable</returns>
        public DataTable CrearDataTable()
        {
           

            try
            {
                this.dt = new DataTable("libros");
                this.dt.Columns.Add("id", typeof(int));
                this.dt.Columns.Add("editorial", typeof(string));
                this.dt.Columns.Add("titulo", typeof(string));
                this.dt.Columns.Add("tipo", typeof(string));
                this.dt.Columns.Add("precio", typeof(int));
                this.dt.Columns.Add("caracteristica", typeof(string));

                
                this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };
                this.dt.Columns["id"].AutoIncrement = true;
                this.dt.Columns["id"].AutoIncrementSeed = 1;
                this.dt.Columns["id"].AutoIncrementStep = 1;
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return dt;

        }


        /// <summary>
        /// Configura el dataAdapter
        /// </summary>
        /// <returns>Retorna el DataAdapter</returns>
        public SqlDataAdapter ConfigurarDataAdapter()
        {
             this.da = new SqlDataAdapter();

            try
            {
                this.da.SelectCommand = new SqlCommand("SELECT * FROM libros", this.conexion);
                this.da.InsertCommand = new SqlCommand("INSERT INTO libros (editorial, titulo, tipo, precio, caracteristica) VALUES (@editorial, @titulo, @tipo, @precio, @caracteristica)", this.conexion);
                this.da.UpdateCommand = new SqlCommand("UPDATE libros SET editorial=@editorial, titulo=@titulo, tipo=@tipo, precio=@precio, caracteristica=@caracteristica WHERE id=@id", this.conexion);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM libros WHERE id=@id", this.conexion);
                
                this.da.InsertCommand.Parameters.Add("@editorial", SqlDbType.VarChar, 50, "editorial");
                this.da.InsertCommand.Parameters.Add("@titulo", SqlDbType.VarChar, 50, "titulo");
                this.da.InsertCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.InsertCommand.Parameters.Add("@precio", SqlDbType.Int, 10, "precio");
                this.da.InsertCommand.Parameters.Add("@caracteristica", SqlDbType.VarChar, 50, "caracteristica");

                this.da.UpdateCommand.Parameters.Add("@editorial", SqlDbType.VarChar, 50, "editorial");
                this.da.UpdateCommand.Parameters.Add("@titulo", SqlDbType.VarChar, 50, "titulo");
                this.da.UpdateCommand.Parameters.Add("@tipo", SqlDbType.VarChar, 50, "tipo");
                this.da.UpdateCommand.Parameters.Add("@precio", SqlDbType.Int, 10, "precio");
                this.da.UpdateCommand.Parameters.Add("@caracteristica", SqlDbType.VarChar, 50, "caracteristica");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
            }
            catch (Exception e)
            {   
                Console.WriteLine(e.Message);
            }

            return da;
        }

        /// <summary>
        /// Utiliza los emtodos crearDataTable y configurarDataAdapter para obtener la tabla de libros de la BD
        /// </summary>
        /// <returns>Retorna el DataTable</returns>
        public DataTable ObtenerTablaLibros()
        {
            DataTable tabla = this.CrearDataTable();
            this.da = this.ConfigurarDataAdapter();

            try
            {
                this.da.Fill(tabla);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return tabla;
        }

        /// <summary>
        /// Actualiza la BD con los cambios realizados en el dataTable
        /// </summary>
        public void ActualizarStock(DataTable tabla)
        {
            
            try
            {
                this.da.Update(tabla);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }          

        }

        #endregion
    }
}
