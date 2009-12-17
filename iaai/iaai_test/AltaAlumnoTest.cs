using iaai.alumno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Forms;
using iaai.Data_base;
using System.Threading;




namespace iaai_test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para AltaAlumnoTest y se pretende que
    ///contenga todas las pruebas unitarias AltaAlumnoTest.
    ///</summary>
    [TestClass()]
    public class AltaAlumnoTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        
        /// <summary>
        ///Una prueba de Show
        ///</summary>
        [TestMethod()]
        public void ShowTest()
        {

            
            bool esperado;
            List<string> datos_A_Cargar = new List<string>();
            Data_base db = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            bool resultado;


//-------------------------------------------------------------------------------------------------
            //un dni no valido 6 numeros
            string[] cadena = {"Perez","Jose","3885935","25/09/1981","0342","4856321","Pazo 325","correo@correo.com","",""};          
            datos_A_Cargar.AddRange(cadena);
            AltaAlumno formulario = new AltaAlumno(datos_A_Cargar);
            esperado = false;
            

            resultado=formulario.cargar();


            Assert.AreEqual(esperado, resultado);

            formulario.Dispose();
            datos_A_Cargar.Clear();

//-------------------------------------------------------------------------------------------------
            //un alumno valido
            string [] cadena2 = {"Perez","Jose","28859353","25/09/1981","0342","4856321","Pazo 325","correo@correo.com","",""};
            datos_A_Cargar.AddRange(cadena2);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = true;                              //debe ser dado de alta con exito
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado);
            formulario.Dispose();
            datos_A_Cargar.Clear();


//-------------------------------------------------------------------------------------------------
            //alumno con otro nombre pero igual dni que el anterior ingresado
            string[] cadena3 = { "D'luca", "Carlos", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena3);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = false;                             //debe fallar la carga
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado);
            formulario.Dispose();
            datos_A_Cargar.Clear();


//-------------------------------------------------------------------------------------------------
            //ejecuto el procedimiento de eliminar para chequear luego que me intente reactivar el alumno
            db.eliminarAlumno("28859353");

//-------------------------------------------------------------------------------------------------
            //intento volver a cargar el alumno que fue eliminado en la sentencia anterior
            //para verificar que se reactiva con exito

            string[] cadena4 = { "Perez", "Jose", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena4);

            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = true;                              //debe ser reactivado con exito
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado);
            formulario.Dispose();
            datos_A_Cargar.Clear();


//-------------------------------------------------------------------------------------------------
            //intento volver a cargar el alumno que fue reactivado anteriormente
            string[] cadena5 = { "Perez", "Jose", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena5);

            formulario = new AltaAlumno(datos_A_Cargar);
            
            esperado = false;                              //debe generar error
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado);
            formulario.Dispose();
            datos_A_Cargar.Clear();


//-------------------------------------------------------------------------------------------------
            //eliminio nuevamente para volver a intentar cargar con otros datos filiatorios
            db.eliminarAlumno("28859353");


//-------------------------------------------------------------------------------------------------
            //intento volver a cargar el dni con otros datos filiatorios
            string[] cadena6 = { "L'hospital", "Carlitos", "28859353", "23/12/1981", "0343", "4456321", "Pazo 286", "cor_reo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena6);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = false;                              //debe generar error el alumno con ese dni esta activo


            resultado = formulario.cargar();

            
            

            Assert.AreEqual(esperado, resultado);
            formulario.Dispose();
            datos_A_Cargar.Clear();


            db.consulta("delete from alumno where dni = 28859353");


        }
    }
}
