using iaai.alumno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Forms;
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


            //un dni no valido
            string[] cadena = {"Perez","Jose","3885935","25/09/1981","0342","4856321","Pazo 325","correo@correo.com","",""};          
            datos_A_Cargar.AddRange(cadena);
            AltaAlumno formulario = new AltaAlumno(datos_A_Cargar);
            
            esperado = false;
            Assert.AreEqual(esperado, formulario.cargar());
            formulario.Dispose();


            //un alumno valido
            string [] cadena2 = {"Perez","Jose","28859353","25/09/1981","0342","4856321","Pazo 325","correo@correo.com","",""};
            datos_A_Cargar.AddRange(cadena2);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = true;
           
            Assert.AreEqual(esperado, formulario.cargar());
            formulario.Dispose();

            
        }
    }
}
