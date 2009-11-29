using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using iaai.metodos_comunes;


namespace iaai_test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para AltaprofesorTest y se pretende que
    ///contenga todas las pruebas unitarias AltaprofesorTest.
    ///</summary>
    [TestClass()]
    public class Valida_mail_Test
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
            Utiles target = new Utiles(); // TODO: Inicializar en un valor adecuado         



            string mail = "joabac@gmail.com";  //caso de prueba
            bool esperado = true;      //valor esperado
            bool actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            mail = ".joabac@gmail.com";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);


            mail = "";  //caso de prueba
            esperado = true;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);


            mail = "_";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            mail = "-";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);


            mail = "^joabac@gmail.com";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            mail = "joabacgmail.com";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "joa@bac@gmail.com";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "joabac@gmail.com.";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "@gmail.com";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "joabac@";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "@gmail.org.edu.ar";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "joabac@gmail.net.edu.ar";  //caso de prueba
            esperado = true;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "joabac@^gmail.com";  //caso de prueba
            esperado = false;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);

            
            mail = "jo-a.ba_c@gm-a_il.com";  //caso de prueba
            esperado = true;      //valor esperado
            actual = target.validar_email(mail);
            Assert.AreEqual(esperado, actual);
            
        }
    }
}
