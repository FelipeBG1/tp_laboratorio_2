using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace TestUnitariosTP3
{
    [TestClass]
    public class Testeos
    {
        [TestMethod]

        // Test que valida que al agregar un alumno ya hay otro igual dentro de la lista lance la excepcion AlumnoRepetidoException
        public void Verificar_AlumnoRepetidoException()
        {
            try
            {
                Universidad u = new Universidad();

                Alumno a1 = new Alumno(1, "Carlos", "Ballester", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
                Alumno a2 = new Alumno(2, "Carlos", "Ballester", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

                u += a1;
                u += a2;

            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

        }

        //Test que valida que al quere agregar un por ejemplo un alumno con un DNI que no coincida con la nacionalidad lance la excepcion NacionalidadInvalidaException
        [TestMethod]
        public void Verificar_NacionalidadInvalidaException()
        {
            try
            {

                Alumno a1 = new Alumno(1, "Jose", "Medina", "75000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }


        }

        //Test que valida que al querer agregar,por ejemplo, un alumno con un DNI no valido lance la excepcion DniInvalidoException
        [TestMethod]
        public void Verificar_DniInvalidoException()
        {

            try
            {

                Alumno a1 = new Alumno(1, "Juan", "Medina", "a", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

            }
            catch (Exception e)
            {

                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }

        }

        //Test que valida que al instanciar una Universidad se instancien las listas, es decir que las listas no sean null
        [TestMethod]
        public void Verificar_InstanciaColeccionLista()
        {
            Universidad uni = new Universidad();
        
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);
        }

        //Test que valida que al instanciar una Jornada se instancie las lista de alumno, es decir que las lista no sea null
        [TestMethod]
        public void Verificar_InstanciaColeccionLista2()
        {
            Profesor p1 = new Profesor(1, "Agustin", "Perez", "95000076", Persona.ENacionalidad.Extranjero);
            Jornada jor = new Jornada(Universidad.EClases.Programacion,p1);
            
            Assert.IsNotNull(jor.Alumnos);
        }


    }
        
}
