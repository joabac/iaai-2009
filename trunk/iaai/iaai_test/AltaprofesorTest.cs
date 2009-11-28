using iaai.profesor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace iaai_test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para AltaprofesorTest y se pretende que
    ///contenga todas las pruebas unitarias AltaprofesorTest.
    ///</summary>
    [TestClass()]
    public class AltaprofesorTest
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
        ///Una prueba de validar_email
        ///</summary>
        [TestMethod()]
        [DeploymentItem("iaai.exe")]
        public void validar_emailTest()
        {
            Altaprofesor_Accessor target = new Altaprofesor_Accessor(); // TODO: Inicializar en un valor adecuado
            string email = "joabac@gmail.com"; // Valor ingresado
            bool expected = true; //Valor esperado
            bool actual;
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);


            email = ".joabac@gmail.com"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "^joabac@gmail.com"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "joabacgmail.com"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "joa@bac@gmail.com"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "joabac@gmail.com."; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "@gmail.com"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "joabac@"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "@gmail.org.edu.ar"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "joabac@gmail.net.edu.ar"; // Valor ingresado
            expected = true; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "joabac@^gmail.com"; // Valor ingresado
            expected = false; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            email = "jo-a.ba_c@gm-a_il.com"; // Valor ingresado
            expected = true; //Valor esperado
            actual = target.validar_email(email);
            Assert.AreEqual(expected, actual);

            
        }
    }
}
