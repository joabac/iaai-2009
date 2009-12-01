using iaai.metodos_comunes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using System.Windows.Forms;

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
                   
            Utiles target = new Utiles(); 
            // TODO: Inicializar en un valor adecuado
            
            string dni = "28889394";  //caso de prueba
            bool esperado= true;      //valor esperado
            bool actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);
            

            dni="28889.394";
            esperado= false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "288593MF";
            esperado = false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "288593FM";
            esperado = false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "288593";
            esperado = false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "288593F0123";
            esperado = false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni= "28s89394";
            esperado =false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);


            dni = "28F893944";
            esperado = false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "28893943F";  
            esperado = true;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "28893943M";
            esperado = true;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);

            dni = "12345678F0";
            esperado = false;
            actual = target.ValidarDni(dni);
            Assert.AreEqual(esperado, actual);


        }




        /// <summary>
        ///Una prueba de validar_Nombre_App
        ///</summary>
        [TestMethod()]
        public void validar_Nombre_AppTest()
        {
            Utiles target = new Utiles();
            bool actual;

            string cadena = "joaquin";
            bool expected = true; 
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "Joaquin Andres";
            expected = true;
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "Joaquin ^Andres";
            expected = false;
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "";
            expected = false;
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);


            cadena = ". - _";
            expected = false;
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "&/$";
            expected = false;
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "Anrés Ñares D`Luca";
            expected = true;
            actual = target.validar_Nombre_App(cadena);
            Assert.AreEqual(expected, actual);
            


        }

        /// <summary>
        ///Una prueba de validar_Direccion
        ///</summary>
        [TestMethod()]
        public void validar_DireccionTest()
        {
            Utiles target = new Utiles(); 
            bool actual;

            string cadena = "Urquiza 3225"; 
            bool expected = true; 
            actual = target.validar_Direccion(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "D'agostino 325 7º B"; 
            expected = true; 
            actual = target.validar_Direccion(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "Avda. San Martin 3452";
            expected = true;
            actual = target.validar_Direccion(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "San juan 3225 (Pasillo) dto. 2º";
            expected = true;
            actual = target.validar_Direccion(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "[Pasillo] dto. 2º";
            expected = false;
            actual = target.validar_Direccion(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "{Pasillo} dto. 2º";
            expected = false;
            actual = target.validar_Direccion(cadena);
            Assert.AreEqual(expected, actual);

            
        }

        /// <summary>
        ///Una prueba de validar_Telefono
        ///</summary>
        [TestMethod()]
        public void validar_TelefonoTest()
        {
            Utiles target = new Utiles();

            string cadena = "123456789";
            bool expected = true;
            bool actual;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "1234567890";
            expected = false;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "12345678s";
            expected = false;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "a23456789";
            expected = false;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "12&%390$";
            expected = false;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "12345";
            expected = true;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "1234";
            expected = false;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "";
            expected = false;
            actual = target.validar_Telefono(cadena);
            Assert.AreEqual(expected, actual);
            

        }

        /// <summary>
        ///Una prueba de validar_Caracteristica
        ///</summary>
        [TestMethod()]
        public void validar_CaracteristicaTest()
        {
            Utiles target = new Utiles(); 
            
            string cadena = "12345"; 
            bool expected = true; 
            bool actual;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "123456"; 
            expected = false; 
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "234,5";
            expected = false;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "asgh5";
            expected = false;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "3ghdr";
            expected = false;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);

            cadena = "";
            expected = false;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "123";
            expected = true;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);


            cadena = "12";
            expected = false;
            actual = target.validar_Caracteristica(cadena);
            Assert.AreEqual(expected, actual);
        }
    }
}
