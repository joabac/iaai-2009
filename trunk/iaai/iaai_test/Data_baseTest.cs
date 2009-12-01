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
            bool expected = true; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.open_db();
            Assert.AreEqual(expected, actual);

            



        }

        

        /// <summary>
        ///Una prueba de buscarResponsable
        ///</summary>
        [TestMethod()]
        public void buscarResponsableTest()
        {
           
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de buscarDniResponsable
        ///</summary>
        [TestMethod()]
        public void buscarDniResponsableTest()
        {
          
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de buscarDniProfesor
        ///</summary>
        [TestMethod()]
        public void buscarDniProfesorTest()
        {
            
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de buscarDniAlumno
        ///</summary>
        [TestMethod()]
        public void buscarDniAlumnoTest()
        {
          
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de altaAlumno
        ///</summary>
        [TestMethod()]
        public void altaAlumnoTest()
        {
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
            
        }

        /// <summary>
        ///Una prueba de altaResponsable
        ///</summary>
        [TestMethod()]
        public void altaResponsableTest()
        {
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
            
        }

        /// <summary>
        ///Una prueba de altaProfesor
        ///</summary>
        [TestMethod()]
        public void altaProfesorTest()
        {
            Data_base metodo = new Data_base(); 
            IDictionary<string, object> datos = new Dictionary<string, object>();
            
            //genero un profesor para poder manipular los datos ingresados
            datos["nombre"] = "nombre_prueba";
            datos["apellido"] = "apellido_prueba";
            datos["dni"] = "22222222M";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "123456";
            datos["direccion"] = "San martin 314 7º B";
            datos["email"] = "prueba@prueba.com";

            Profesor esperado = new Profesor(datos) ;  //cargo el nuevo profesor

            //prueba 1
            //++++++++++++codigo que se prueba 

            metodo.altaProfesor(esperado); //Doy de alta el profesor
            
            //+++++++++++++++++++++++++++++++++++++++++++

            //busco el profesor en la base de datos para ver como quedo cargado

            Profesor recuperado = metodo.Buscar_Profesor("22222222M"); 

            //verifico campo a campo los datos registrados
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); // comparo si lo que se grabo es lo que se especifico
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getEmail().ToString(), recuperado.getEmail().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
 

            //elimino manualmente el profesor de prueba generado
            metodo.consulta("delete from profesor where dni like '22222222M' ");


        }

        /// <summary>
        ///Una prueba de Buscar_Profesor
        ///</summary>
        [TestMethod()]
        public void Buscar_ProfesorTest()
        {
            Data_base metodo = new Data_base(); 
            IDictionary<string, object> datos = new Dictionary<string, object>();
            
            //genero un profesor para poder manipular los datos ingresados
            datos["nombre"] = "nombre_prueba";
            datos["apellido"] = "apellido_prueba";
            datos["dni"] = "33333333M";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "123456";
            datos["direccion"] = "San martin 314 7º B";
            datos["email"] = "prueba@prueba.com";

            Profesor profe = new Profesor(datos) ;  //cargo el nuevo profesor

            metodo.altaProfesor(profe); //Doy de alta el profesor
            
            

            //busco el profesor en la base de datos para ver como quedo cargado
            //++++++++++++codigo que se prueba
            Profesor actual = metodo.Buscar_Profesor("33333333M");
            //+++++++++++++++++++++++++++++++++++++++++++

            //verifico campo a campo los datos registrados
            Assert.AreEqual(actual.getDni().ToString(), profe.getDni().ToString()); // comparo si lo que se grabo es lo que se especifico
            Assert.AreEqual(actual.getNombre().ToString(), profe.getNombre().ToString());
            Assert.AreEqual(actual.getApellido().ToString(), profe.getApellido().ToString());
            Assert.AreEqual(actual.getDireccion().ToString(), profe.getDireccion().ToString());
            Assert.AreEqual(actual.getEmail().ToString(), profe.getEmail().ToString());
            Assert.AreEqual(actual.getFecha_nac().ToString("yyyy-MM-dd"), profe.getFecha_nac().ToString("yyyy-MM-dd"));
 


             //prueba 2
            //+++++++++++++++++++++++++++++
            //buscar profesor marcado como eliminado
            metodo.eliminarProfesor("33333333M");

            //busco el profesor 
            actual = metodo.Buscar_Profesor("33333333M");
            Profesor esperado = null;

            Assert.AreEqual(esperado, actual);


            //elimino manualmente el profesor de prueba generado

            metodo.consulta("delete from profesor where dni like '33333333M' ");
            

            //prueba 3
            //++++++++++++++++++++++++++++++
            //busco profesor que no existe

            actual = metodo.Buscar_Profesor("34563456M");
            esperado = null;

            Assert.AreEqual(esperado, actual);


        }

        /// <summary>
        ///Una prueba de eliminarProfesor
        ///</summary>
        [TestMethod()]
        public void eliminarProfesorTest()
        {
            Data_base metodo = new Data_base();
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //genero un profesor para poder manipular los datos ingresados
            datos["nombre"] = "nombre_prueba";
            datos["apellido"] = "apellido_prueba";
            datos["dni"] = "11111111M";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "123456";
            datos["direccion"] = "San martin 314 7º B";
            datos["email"] = "prueba@prueba.com";

            Profesor profe = new Profesor(datos);  //cargo el nuevo profesor

            metodo.altaProfesor(profe); //Doy de alta el profesor

           
            //elimino el profesor de la base marcandolo como eliminado
            //pasandole como parametro el dni generado
            //++++++++++++codigo que se prueba
            metodo.eliminarProfesor(profe.getDni());

            //busco el profesor para ver si esta en base como activo
            Profesor actual = metodo.Buscar_Profesor("11111111M");
            Profesor esperado = null;

            //prueba
            Assert.AreEqual(esperado, actual);


            //borro manualmente el prfesor de prueba generado
            metodo.consulta("delete from profesor where dni like '11111111M' ");
            
        }

        /// <summary>
        ///Una prueba de modificarProfesor
        ///</summary>
        [TestMethod()]
        public void modificarProfesorTest()
        {

            Data_base metodo = new Data_base();
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //genero un profesor para poder manipular los datos ingresados
            datos["nombre"] = "nombre_prueba";
            datos["apellido"] = "apellido_prueba";
            datos["dni"] = "11111111M";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "123456";
            datos["direccion"] = "San martin 314 7º B";
            datos["email"] = "prueba@prueba.com";

            Profesor profe = new Profesor(datos);  //cargo el nuevo profesor

            metodo.altaProfesor(profe); //Doy de alta el profesor


            //reutilizo el objeto creado para generar modificaciones
            datos["nombre"] = "nombre_modificado";
            datos["dni"] = "11111111M";
            datos["fecha_nac"] = "2000-01-01";
            datos["telefono_numero"] = "123456";

            Profesor profe_modif = new Profesor(datos);
            //cargo las modificaciones 
            //++++++++++++codigo que se prueba
            metodo.modificarProfesor(profe_modif);
            //+++++++++++++++++++++++++++++++++++++++++++

            //recupero de base el profesor modificado
            Profesor recuperado = metodo.Buscar_Profesor(profe_modif.getDni());

            if (recuperado != null)
            {
                //verifico campo a campo los datos registrados
                Assert.AreEqual(profe_modif.getDni(), recuperado.getDni()); // comparo si lo que se grabo es lo que se especifico
                Assert.AreEqual(profe_modif.getNombre(), recuperado.getNombre().ToString());
                Assert.AreEqual(profe_modif.getApellido(), recuperado.getApellido().ToString());
                Assert.AreEqual(profe_modif.getDireccion(), recuperado.getDireccion().ToString());
                Assert.AreEqual(profe_modif.getEmail(), recuperado.getEmail().ToString());
                Assert.AreEqual(profe_modif.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            }
            else {
                Assert.Inconclusive("No se pudo recuperar el profesor con los nuevos datos");
            }
 
            
            //borro manualmente el prfesor de prueba generado
            metodo.consulta("delete from profesor where dni like '12345667F' ");
            
        }
    }
}
