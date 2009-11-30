using iaai.Data_base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iaai.profesor;
using iaai.responsable;
using iaai.alumno;
using System.Collections.Generic;

namespace iaai_test
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para Data_baseTest y se pretende que
    ///contenga todas las pruebas unitarias Data_baseTest.
    ///</summary>
    [TestClass()]
    public class Data_baseTest
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
        ///Una prueba de open_db
        ///</summary>
        [TestMethod()]
        public void open_dbTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.open_db();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        

        /// <summary>
        ///Una prueba de buscarResponsable
        ///</summary>
        [TestMethod()]
        public void buscarResponsableTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string consulta = string.Empty; // TODO: Inicializar en un valor adecuado
            List<List<string>> expected = null; // TODO: Inicializar en un valor adecuado
            List<List<string>> actual;
            actual = target.buscarResponsable(consulta);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de buscarDniResponsable
        ///</summary>
        [TestMethod()]
        public void buscarDniResponsableTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string dni = string.Empty; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.buscarDniResponsable(dni);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de buscarDniProfesor
        ///</summary>
        [TestMethod()]
        public void buscarDniProfesorTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string dni_profesor = string.Empty; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.buscarDniProfesor(dni_profesor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de buscarDniAlumno
        ///</summary>
        [TestMethod()]
        public void buscarDniAlumnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string dni = string.Empty; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.buscarDniAlumno(dni);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de altaAlumno
        ///</summary>
        [TestMethod()]
        public void altaAlumnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno a = null; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.altaAlumno(a);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Una prueba de altaResponsable
        ///</summary>
        [TestMethod()]
        public void altaResponsableTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Responsable r = null; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.altaResponsable(r);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Una prueba de altaProfesor
        ///</summary>
        [TestMethod()]
        public void altaProfesorTest()
        {
            Data_base metodo = new Data_base(); 
            IDictionary<string, object> datos = new Dictionary<string, object>();
            

            datos["nombre"] = "nombre_prueba";
            datos["apellido"] = "apellido_prueba";
            datos["dni"] = "11111111M";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "123456";
            datos["direccion"] = "San martin 314 7º B";
            datos["email"] = "prueba@prueba.com";

            Profesor profe = new Profesor(datos) ;

            metodo.altaProfesor(profe); //cargo el profesor
            
            Profesor actual = metodo.Buscar_Profesor("11111111M"); //busco el profesor si quedo cargado

            if (actual.getDni().Equals("11111111M")) // comparo si lo que se grabo es lo que se especifico
            { 
            
                
            }

           // Assert.AreEqual(expected, actual);

            metodo.consulta("delete from profesor where dni= '11111111M' ");

           

        }

        /// <summary>
        ///Una prueba de Buscar_Profesor
        ///</summary>
        [TestMethod()]
        public void Buscar_ProfesorTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string dni = "12345678"; // TODO: Inicializar en un valor adecuado
            bool igual = false;

            IDictionary<string, object> index = new Dictionary<string, object>();

            
            index["nombre"] = "asd";
            index["apellido"] = "fgh";
            index["dni"] = "12345678";
            index["fecha_nac"] = "25/09/1980";
            index["telefono_carac"] = 789;
            index["telefono_numero"] = 963;
            index["direccion"] = "asdf";
            index["email"] = "";

            Profesor expected = new Profesor(index);

            Profesor actual = target.Buscar_Profesor(dni);

            if(expected.getDni().Equals(actual.getDni()) && expected.getFecha_nac() == actual.getFecha_nac() && expected.getNombre().Equals(actual.getNombre()))
                igual= true;

            Assert.IsTrue(igual);
            
        }
    }
}
