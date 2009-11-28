using iaai.metodos_comunes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace iaai_test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para UtilesTest y se pretende que
    ///contenga todas las pruebas unitarias UtilesTest.
    ///</summary>
    [TestClass()]
    public class UtilesTest
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
        ///Una prueba de ValidarDni
        ///</summary>
        [TestMethod()]
        public void ValidarDniTest()
        {
            Utiles target = new Utiles(); // TODO: Inicializar en un valor adecuado
            string dni = "28889394"; // TODO: Inicializar en un valor adecuado
            bool expected = true; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(expected, actual);
            
        }
    }
}
