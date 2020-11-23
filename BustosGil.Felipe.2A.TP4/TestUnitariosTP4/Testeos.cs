using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesTP4;
using Excepciones;
using System.Data.SqlClient;
using System.Data;

namespace TestUnitariosTP4
{
    [TestClass]
    public class Testeos
    {
        /// <summary>
        /// Testea que se agregue correctamente un libro a una libreria
        /// </summary>
        [TestMethod]
        public void Test_AgregarCuento()
        {
            Libreria libreria = new Libreria();
            Cuento cuento = new Cuento("Apagogue", "Blue Exorcist", 525,"Incluye ilustaciones");
            int countLibreria;

            libreria += cuento;
            countLibreria = libreria.Libros.Count;
            Assert.AreEqual(1, countLibreria);
        }

        /// <summary>
        /// Testea que al instanciar una libreria, la lista de libros no sea null
        /// </summary>
        [TestMethod]
        public void Test_LibreriaIsNotNull()
        {
            Libreria libreria = new Libreria();
            Assert.IsNotNull(libreria.Libros);
        }

        /// <summary>
        /// Testea la conexion a la base de datos
        /// </summary>
        [TestMethod]
        public void Test_ConexionBD()
        {
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            
            conexion.Open();

            Assert.IsTrue(conexion.State == ConnectionState.Open);
            conexion.Close();
        }

    }
}
