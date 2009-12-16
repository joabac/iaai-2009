using iaai.Data_base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iaai.profesor;
using iaai.responsable;
using iaai.alumno;
using System.Collections.Generic;
using System.Windows.Forms;
using iaai.cursos_materias;

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
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            bool expected = true; 
            bool actual;
            actual = target.open_db();
            Assert.AreEqual(expected, actual);

            



        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //               PRUEBAS ALUMNO (MAYOR DE EDAD)               //
        //                                                            //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        /// <summary>
        ///Una prueba de altaAlumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void altaAlumnoTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (sin datos de la escuela ni del año de cursado)
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = null;
            datos["escuela_año"] = null;
            datos["id_responsable"] = null;
            datos["email"] = null;
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1
            
            metodo.altaAlumno(esperado); //Alta del Alumno

            //Busqueda del alumno

            Alumno recuperado = metodo.Buscar_Alumno("22222222");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEscuela_nombre(), recuperado.getEscuela_nombre());
            Assert.AreEqual(esperado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
            Assert.AreEqual(esperado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '22222222' ");


            //prueba 2
            //se agregan los datos de la escuela y el año de curdado.

            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "1";
            datos["email"] = "micorreo@hotmail.com";
            esperado = new Alumno(datos);  //se crea el objeto Alumno

            metodo.altaAlumno(esperado); //Alta del Alumno

            //Busqueda del alumno

            recuperado = metodo.Buscar_Alumno("22222222");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEscuela_nombre(), recuperado.getEscuela_nombre());
            Assert.AreEqual(esperado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
            Assert.AreEqual(esperado.getEmail().ToString(), recuperado.getEmail().ToString());

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '22222222' ");
            

        }

        /// <summary>
        ///Una prueba buscar alumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void buscarAlumnoTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "14141414";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial";
            datos["escuela_año"] = 3;
            datos["id_responsable"] = null;
            datos["email"] = "mimail@hotmail.com";
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno
            
            //Busqueda del alumno

            Alumno recuperado = metodo.Buscar_Alumno("14141414");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEscuela_nombre(), recuperado.getEscuela_nombre());
            Assert.AreEqual(esperado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
            Assert.AreEqual(esperado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '14141414' ");

        }

        /// <summary>
        ///Una prueba modificar alumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void modificarAlumnoTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            string dni_viejo = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = null;
            datos["email"] = null;
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno

            //se generan modificaciones
            datos["nombre"] = "Diego";
            datos["dni"] = "11111111";
            datos["fecha_nac"] = "1984-04-01";
            datos["telefono_numero"] = "123456";
            datos["email"] = "micorreo@gmail.com";

            Alumno modificado = new Alumno(datos);
            
            //se modifica al alumno
            metodo.modificarAlumno(modificado,dni_viejo);
            
            //recupero el alumno modificado de la base datos
            Alumno recuperado = metodo.Buscar_Alumno(modificado.getDni());
            
            if (recuperado != null)
            {
                //verificación de los datos
                Assert.AreEqual(modificado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
                Assert.AreEqual(modificado.getNombre().ToString(), recuperado.getNombre().ToString());
                Assert.AreEqual(modificado.getApellido().ToString(), recuperado.getApellido().ToString());
                Assert.AreEqual(modificado.getDireccion().ToString(), recuperado.getDireccion().ToString());
                Assert.AreEqual(modificado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
                Assert.AreEqual(modificado.getEscuela_nombre(), recuperado.getEscuela_nombre());
                Assert.AreEqual(modificado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
                Assert.AreEqual(modificado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
                Assert.AreEqual(modificado.getEmail(), recuperado.getEmail());
                
            }
            else
            {
                Assert.Inconclusive("No se recuperó el alumno");
            }

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '11111111' ");

        }


        /// <summary>
        ///Una prueba de buscarDniAlumno
        ///</summary>
        [TestMethod()]
        public void buscarDniAlumnoTest()
        {

            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = null;
            datos["email"] = null;
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno

            //verificación de los datos (el método retorna false si encuentra el dni en la base de datos
            //ya que valida en la instancia de alta alumno, para no ingresar un dni duplicado.
            Assert.AreEqual(false, metodo.buscarDniAlumno("44444444")); //se compara lo recibido de BD con lo ingresado
            
            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '44444444' ");


        }



        /// <summary>
        ///Una prueba eliminar alumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void eliminarAlumnoTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = null;
            datos["email"] = null;
            Alumno alumn = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(alumn); //Alta del Alumno

            //el alumno es marcado como eliminado en la base de datos
            
            metodo.eliminarAlumno(alumn.getDni());

            //se comprueba que el alumno figure como eliminado en la base de datos
            Alumno actual = metodo.Buscar_Alumno("44444444");
            Alumno esperado = null;

            //prueba
            Assert.AreEqual(esperado, actual);
            
            //elimino manualmente el alumno
            metodo.consulta("delete from alumno where dni like '44444444' ");

        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //           FIN PRUEBAS ALUMNO (MAYOR DE EDAD)               //
        //                                                            //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//


        
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //           INICIO PRUEBAS RESPONSABLE                       //
        //                                                            //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//


        /// <summary>
        ///Una prueba de altaResponsable 
        ///</summary>
        [TestMethod()]
        public void altaResponsableTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["email"] = null;
            
            Responsable esperado = new Responsable(datos);  //se crea el objeto Responsable

            //prueba 1

            metodo.altaResponsable(esperado); //Alta del Responsable

            //Busqueda del Responsable

            Responsable recuperado = metodo.Buscar_Responsable("22222222");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());
            
            //elimino manualmente el Responsable de prueba generado
            metodo.consulta("delete from responsable where dni like '22222222' ");


            
        }

        /// <summary>
        ///Una prueba buscar responsable
        ///</summary>
        [TestMethod()]
        public void buscarResponsableTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["email"] = null;
            
            Responsable esperado = new Responsable(datos);  //se crea el objeto Responsable

            //prueba 1

            metodo.altaResponsable(esperado); //Alta del Responsable
            //Busqueda del Responsable

            Responsable recuperado = metodo.Buscar_Responsable("22222222");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());

            //elimino manualmente el Responsable de prueba generado
            metodo.consulta("delete from responsable where dni like '44444444' ");

        }

        /// <summary>
        ///Una prueba modificar Responsable
        ///</summary>
        [TestMethod()]
        public void modificarResponsableTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            string dni_viejo = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["email"] = "guardado@mail.com";
            
            Responsable esperado = new Responsable(datos);  //se crea el objeto Responsable

            //prueba 1

            metodo.altaResponsable(esperado); //Alta del Responsable
            
            //se generan modificaciones
            datos["nombre"] = "Diego";
            datos["dni"] = "11111111";
            datos["fecha_nac"] = "1984-04-01";
            datos["telefono_numero"] = "123456";

            Responsable modificado = new Responsable(datos);

            //se modifica al Responsable
            metodo.modificarResponsable(modificado, dni_viejo);
            
            //recupero el Responsable modificado de la base datos
            Responsable recuperado = metodo.Buscar_Responsable(modificado.getDni().ToString());
            
            if (recuperado != null)
            {
                //verificación de los datos
                Assert.AreEqual(modificado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
                Assert.AreEqual(modificado.getNombre().ToString(), recuperado.getNombre().ToString());
                Assert.AreEqual(modificado.getApellido().ToString(), recuperado.getApellido().ToString());
                Assert.AreEqual(modificado.getDireccion().ToString(), recuperado.getDireccion().ToString());
                Assert.AreEqual(modificado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
                Assert.AreEqual(modificado.getEmail(), recuperado.getEmail());
            }
            else
            {
                Assert.Inconclusive("No se recuperó el Responsable");
            }

            //elimino manualmente el Responsable de prueba generado
            metodo.consulta("delete from responsable where dni like '11111111' ");

        }


        /// <summary>
        ///Una prueba de buscarDniResponsable
        ///</summary>
        [TestMethod()]
        public void buscarDniResponsableTest()
        {

            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["email"] = "mimail@hotmail.com";
            Responsable esperado = new Responsable(datos);  //se crea el objeto Responsable

            //prueba 1

            metodo.altaResponsable(esperado); //Alta del Responsable

            //verificación de los datos (el método retorna false si encuentra el dni en la base de datos
            //ya que valida en la instancia de alta responsable, para no ingresar un dni duplicado.
            Assert.AreEqual(false, metodo.buscarDniResponsable("22222222")); //se compara lo recibido de BD con lo ingresado

            //elimino manualmente el responsable de prueba generado
            metodo.consulta("delete from responsable where dni like '22222222' ");


        }



        /// <summary>
        ///Una prueba eliminar Responsable
        ///</summary>
        [TestMethod()]
        public void eliminarResponsableTest()
        {

            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["email"] = "mimail@hotmail.com";
            Responsable resp = new Responsable(datos);  //se crea el objeto Responsable

            //prueba 1

            metodo.altaResponsable(resp); //Alta del Responsable

            //el Responsable es marcado como eliminado en la base de datos

            metodo.eliminarResponsable(resp.getDni().ToString());

            //se comprueba que el Responsable figure como eliminado en la base de datos
            Responsable actual = metodo.Buscar_Responsable("22222222");
            Responsable esperado = null;

            //prueba
            Assert.AreEqual(esperado, actual);

            //elimino manualmente el Responsable
            metodo.consulta("delete from responsable where dni like '22222222' ");

        }



        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //              FIN PRUEBAS RESPONSABLE                       //
        //                                                            //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //               PRUEBAS ALUMNO (MENOR DE EDAD)               //
        //                                                            //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        /// <summary>
        ///Una prueba de altaAlumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void altaAlumnoMenorTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos2 = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos2["nombre"] = "Martin";
            datos2["apellido"] = "Gonzalez";
            datos2["dni"] = "11111111";
            datos2["fecha_nac"] = "1981-12-01";
            datos2["telefono_carac"] = "0342";
            datos2["telefono_numero"] = "1111111";
            datos2["direccion"] = "Av. Freyre 3333";
            datos2["email"] = "mimail@hotmail.com";
            Responsable resp = new Responsable(datos2);  //se crea el objeto Responsable

            metodo.altaResponsable(resp); //Alta del Responsable
           
            resp.setIdResponsable(metodo.Buscar_Responsable("11111111").getId_responsable());
            


            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (sin datos de la escuela ni del año de cursado)
            datos["nombre"] = "Juan";
            datos["apellido"] = "Perez";
            datos["dni"] = "22222222";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = null;
            datos["escuela_año"] = null;
            datos["id_responsable"] = resp.getId_responsable().ToString();
            datos["email"] = "mimail@hotmail.com";
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno

            //Busqueda del alumno

            Alumno recuperado = metodo.Buscar_Alumno("22222222");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEscuela_nombre(), recuperado.getEscuela_nombre());
            Assert.AreEqual(esperado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
            Assert.AreEqual(esperado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '22222222' ");


            //prueba 2
            //se agregan los datos de la escuela y el año de curdado.

            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "1";
            datos["email"] = null;
            esperado = new Alumno(datos);  //se crea el objeto Alumno

            metodo.altaAlumno(esperado); //Alta del Alumno

            //Busqueda del alumno

            recuperado = metodo.Buscar_Alumno("22222222");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEscuela_nombre(), recuperado.getEscuela_nombre());
            Assert.AreEqual(esperado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
            Assert.AreEqual(esperado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '22222222' ");
            //elimino manualmente el responsable
            metodo.consulta("delete from responsable where dni like '11111111' ");


        }

        /// <summary>
        ///Una prueba buscar alumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void buscarAlumnoMenorTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            IDictionary<string, object> datos2 = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos2["nombre"] = "Martin";
            datos2["apellido"] = "Gonzalez";
            datos2["dni"] = "11111111";
            datos2["fecha_nac"] = "1981-12-01";
            datos2["telefono_carac"] = "0342";
            datos2["telefono_numero"] = "11111111";
            datos2["direccion"] = "Av. Freyre 3333";
            datos2["email"] = "mimail@hotmail.com";
            Responsable resp = new Responsable(datos2);  //se crea el objeto Responsable

            metodo.altaResponsable(resp); //Alta del Responsable
            resp.setIdResponsable(metodo.Buscar_Responsable("11111111").getId_responsable());

            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = resp.getId_responsable();
            datos["email"] = "mimail@hotmail.com";
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno

            //Busqueda del alumno

            Alumno recuperado = metodo.Buscar_Alumno("44444444");

            //verificación de los datos
            Assert.AreEqual(esperado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
            Assert.AreEqual(esperado.getNombre().ToString(), recuperado.getNombre().ToString());
            Assert.AreEqual(esperado.getApellido().ToString(), recuperado.getApellido().ToString());
            Assert.AreEqual(esperado.getDireccion().ToString(), recuperado.getDireccion().ToString());
            Assert.AreEqual(esperado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
            Assert.AreEqual(esperado.getEscuela_nombre(), recuperado.getEscuela_nombre());
            Assert.AreEqual(esperado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
            Assert.AreEqual(esperado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
            Assert.AreEqual(esperado.getEmail(), recuperado.getEmail());

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '44444444' ");
            //elimino manualmente el responsable
            metodo.consulta("delete from responsable where dni like '11111111' ");

        }

        /// <summary>
        ///Una prueba modificar alumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void modificarAlumnoMenorTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos2 = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos2["nombre"] = "Martin";
            datos2["apellido"] = "Gonzalez";
            datos2["dni"] = "11111111";
            datos2["fecha_nac"] = "1981-12-01";
            datos2["telefono_carac"] = "0342";
            datos2["telefono_numero"] = "1111111";
            datos2["direccion"] = "Av. Freyre 3333";
            datos2["email"] = "mimail@hotmail.com";
            Responsable resp = new Responsable(datos2);  //se crea el objeto Responsable

            metodo.altaResponsable(resp); //Alta del Responsable
            resp.setIdResponsable(metodo.Buscar_Responsable("11111111").getId_responsable());

            //se generan los dato del 2° Responsable a dar de alta 
            datos2["nombre"] = "Jose";
            datos2["apellido"] = "Tibursio";
            datos2["dni"] = "33333333";
            datos2["fecha_nac"] = "1983-12-01";
            datos2["telefono_carac"] = "0342";
            datos2["telefono_numero"] = "1111111";
            datos2["direccion"] = "Av. Freyre 3333";
            datos2["email"] = "mimail@hotmail.com";
            Responsable resp2 = new Responsable(datos2);  //se crea el objeto Responsable

            metodo.altaResponsable(resp2); //Alta del Responsable
            resp2.setIdResponsable(metodo.Buscar_Responsable("33333333").getId_responsable());

            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            string dni_viejo = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = resp.getId_responsable();
            datos["email"] = "mimail@hotmail.com";
            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno

            //se generan modificaciones
            datos["nombre"] = "Diego";
            datos["dni"] = "11111111";
            datos["fecha_nac"] = "1984-04-01";
            datos["telefono_numero"] = "123456";
            datos["id_responsable"] = resp2.getId_responsable();
            datos["email"] = null;

            Alumno modificado = new Alumno(datos);

            //se modifica al alumno
            metodo.modificarAlumno(modificado,dni_viejo);

            //recupero el alumno modificado de la base datos
            Alumno recuperado = metodo.Buscar_Alumno(modificado.getDni());

            if (recuperado != null)
            {
                //verificación de los datos
                Assert.AreEqual(modificado.getDni().ToString(), recuperado.getDni().ToString()); //se compara lo recibido de BD con lo ingresado
                Assert.AreEqual(modificado.getNombre().ToString(), recuperado.getNombre().ToString());
                Assert.AreEqual(modificado.getApellido().ToString(), recuperado.getApellido().ToString());
                Assert.AreEqual(modificado.getDireccion().ToString(), recuperado.getDireccion().ToString());
                Assert.AreEqual(modificado.getFecha_nac().ToString("yyyy-MM-dd"), recuperado.getFecha_nac().ToString("yyyy-MM-dd"));
                Assert.AreEqual(modificado.getEscuela_nombre(), recuperado.getEscuela_nombre());
                Assert.AreEqual(modificado.getEscuela_año().ToString(), recuperado.getEscuela_año().ToString());
                Assert.AreEqual(modificado.getId_responsable().ToString(), recuperado.getId_responsable().ToString());
                Assert.AreEqual(modificado.getEmail(), recuperado.getEmail());
            }
            else
            {
                Assert.Inconclusive("No se recuperó el alumno");
            }

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '11111111' ");
            //elimino manualmente el responsable
            metodo.consulta("delete from responsable where dni like '11111111' ");
            //elimino manualmente el responsable
            metodo.consulta("delete from responsable where dni like '33333333' ");


        }


        /// <summary>
        ///Una prueba de buscarDniAlumno
        ///</summary>
        [TestMethod()]
        public void buscarDniAlumnoMenorTest()
        {

            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos2 = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos2["nombre"] = "Martin";
            datos2["apellido"] = "Gonzalez";
            datos2["dni"] = "11111111";
            datos2["fecha_nac"] = "1981-12-01";
            datos2["telefono_carac"] = "0342";
            datos2["telefono_numero"] = "1111111";
            datos2["direccion"] = "Av. Freyre 3333";
            datos2["email"] = "mimail@hotmail.com";
            Responsable resp = new Responsable(datos2);  //se crea el objeto Responsable

            metodo.altaResponsable(resp); //Alta del Responsable
            resp.setIdResponsable(metodo.Buscar_Responsable("11111111").getId_responsable());

            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = resp.getId_responsable();
            datos["email"] = "mimail@hotmail.com";

            Alumno esperado = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(esperado); //Alta del Alumno

            //verificación de los datos
            Assert.AreEqual(false, metodo.buscarDniAlumno("44444444")); //se compara lo recibido de BD con lo ingresado

            //elimino manualmente el alumno de prueba generado
            metodo.consulta("delete from alumno where dni like '44444444' ");
            //elimino manualmente el responsable
            metodo.consulta("delete from responsable where dni like '11111111' ");


        }



        /// <summary>
        ///Una prueba eliminar alumno (mayor de edad)
        ///</summary>
        [TestMethod()]
        public void eliminarAlumnoMenorTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
            IDictionary<string, object> datos2 = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta 
            datos2["nombre"] = "Martin";
            datos2["apellido"] = "Gonzalez";
            datos2["dni"] = "11111111";
            datos2["fecha_nac"] = "1981-12-01";
            datos2["telefono_carac"] = "0342";
            datos2["telefono_numero"] = "1111111";
            datos2["direccion"] = "Av. Freyre 3333";
            datos2["email"] = "mimail@hotmail.com";
            Responsable resp = new Responsable(datos2);  //se crea el objeto Responsable

            metodo.altaResponsable(resp); //Alta del Responsable
            resp.setIdResponsable(metodo.Buscar_Responsable("11111111").getId_responsable());

            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del alumno a dar de alta (mayor de edad)
            datos["nombre"] = "Jose";
            datos["apellido"] = "Gomez";
            datos["dni"] = "44444444";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "1111111";
            datos["direccion"] = "Av. Freyre 1234";
            datos["escuela_nombre"] = "Comercial Domingo. G Silva";
            datos["escuela_año"] = "4";
            datos["id_responsable"] = resp.getId_responsable();
            datos["email"] = "mimail@hotmail.com";
            Alumno alumn = new Alumno(datos);  //se crea el objeto Alumno

            //prueba 1

            metodo.altaAlumno(alumn); //Alta del Alumno

            //el alumno es marcado como eliminado en la base de datos

            metodo.eliminarAlumno(alumn.getDni());

            //se comprueba que el alumno figure como eliminado en la base de datos
            Alumno actual = metodo.Buscar_Alumno("44444444");
            Alumno esperado = null;

            //prueba
            Assert.AreEqual(esperado, actual);

            //elimino manualmente el alumno
            metodo.consulta("delete from alumno where dni like '44444444' ");
            //elimino manualmente el responsable
            metodo.consulta("delete from responsable where dni like '11111111' ");

        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //           FIN PRUEBAS ALUMNO (MENOR DE EDAD)               //
        //                                                            //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//


        /// <summary>
        ///Una prueba de altaProfesor
        ///</summary>
        [TestMethod()]
        public void altaProfesorTest()
        {
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
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



            //++++++++++++++++++ prueba 2 ++++++++++++++++++++++++++++++++++

            //genero un profesor para poder manipular los datos ingresados
            datos["nombre"] = "con_ap'ostrofos";
            datos["apellido"] = "apellido'apostrofo";
            datos["dni"] = "22222222M";
            datos["fecha_nac"] = "1981-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "123456";
            datos["direccion"] = "L'Hospital 56 7º B";
            datos["email"] = "prueba@prueba.com";

            esperado = null;
            esperado = new Profesor(datos);  //cargo el nuevo profesor

            
            //++++++++++++codigo que se prueba 

            metodo.altaProfesor(esperado); //Doy de alta el profesor

            //+++++

            //busco el profesor en la base de datos para ver como quedo cargado

            recuperado = metodo.Buscar_Profesor("22222222M");

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
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
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
            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
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

            Data_base metodo = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
           
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

        /// <summary>
        ///Una prueba de apostrofos
        ///</summary>
        [TestMethod()]
        [DeploymentItem("iaai.exe")]
        public void apostrofosTest()
        {
            Data_base_Accessor target = new Data_base_Accessor();
            

            //chequeo de cambio de apostrofos por \\'
            string cadena = "cadena con apo'stro'fos"; 
            string expected = "cadena con apo\\'stro\\'fos"; 
            string actual;

            actual = target.apostrofos(cadena);

            Assert.AreEqual(expected, actual);


            
            //prueba para chequear que no desarma las cadenas originales sin apostrofos
            cadena = "cadena sin apostrofos"; 
            expected = "cadena sin apostrofos"; 

            actual = target.apostrofos(cadena);

            Assert.AreEqual(expected, actual);


            //prueba para chequear uso con null
            cadena = null;
            expected = null;

            actual = target.apostrofos(cadena);

            Assert.AreEqual(expected, actual);



            //prueba para chequear string vacio
            cadena = "";
            expected = "";

            actual = target.apostrofos(cadena);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de generarMatriculaProfesorado
        ///</summary>
        [TestMethod()]
        public void generarMatriculaProfesoradoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;"); 
            
            int id_alumno = 18; 
            int id_profesorado = 2; 
            int not_expected = -1; 

            int actual;
            actual = target.generarMatriculaProfesorado(id_alumno, id_profesorado);
            Assert.AreNotEqual(not_expected, actual);

            //+++++++++++++ chequeo que se genero la matricula

            int resultado = target.tieneMatriculaProfesorado(18, 2);

            Assert.AreEqual(actual, resultado);

            target.consulta("delete from matricula where id_alumno = 18 and id_profesorado = 2");
           
        }

        /// <summary>
        ///Una prueba de generarMatriculaCursoEspecial
        ///</summary>
        [TestMethod()]
        public void generarMatriculaCursoEspecialTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;"); 
            
            int id_alumno = 18; 
            int id_cursoEsp = 3; 
            int not_expected = -1; 
            int actual;

            actual = target.generarMatriculaCursoEspecial(id_alumno, id_cursoEsp);
            Assert.AreNotEqual(not_expected, actual);

            //+++++++++++++++  verifico que se genero la matricula 

            int resultado = target.tieneMatriculaCursoEspecial(18,3);

            Assert.AreEqual(actual, resultado);

            //restauro el estado anterior
            target.consulta("delete from matricula where id_alumno = 18 and id_curso_especial = 3");

        }

        /// <summary>
        ///Una prueba de generarMatriculaCurso
        ///</summary>
        [TestMethod()]
        public void generarMatriculaCursoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;"); 

            int id_alumno = 18;
            int id_curso = 11;
            int not_expected = -1;
            int actual;

            actual = target.generarMatriculaCurso(id_alumno, id_curso);
            Assert.AreNotEqual(not_expected, actual);

            //+++++++++++++++  verifico que se genero la matricula 

            int resultado = target.tieneMatriculaCurso(18, 11);

            Assert.AreEqual(actual, resultado);

            target.consulta("delete from matricula where id_alumno = 18 and id_curso = 11");
        }

        

        /// <summary>
        ///Una prueba de esta_Inscripto_Materia
        ///</summary>
        [TestMethod()]
        public void esta_Inscripto_MateriaTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            //++++++++++++++++++++++++ prueba 1
            int id_profesorado = 1; 
            int id_materia = 1; 
            int id_alumno = 18; 
            string turno = "mañana"; 
            string condicion = "inscripto"; 
            bool expected = true; 
            bool actual;
            
            actual = target.esta_Inscripto_Materia(id_profesorado, id_materia, id_alumno, turno, condicion);

            Assert.AreEqual(expected, actual);

            //++++++++++++++++++++++++ prueba 2
            id_profesorado = 1;
            id_materia = 1;
             id_alumno = 18;
             turno = "mañana";
             condicion = "condicional";
             expected = false;
             

            actual = target.esta_Inscripto_Materia(id_profesorado, id_materia, id_alumno, turno, condicion);

            Assert.AreEqual(expected, actual);


            //++++++++++++++++++++++++ prueba 3
            id_profesorado = 1;
            id_materia = 5;
            id_alumno = 18;
            turno = "mañana";
            condicion = "condicional";
            expected = true;
            

            actual = target.esta_Inscripto_Materia(id_profesorado, id_materia, id_alumno, turno, condicion);

            Assert.AreEqual(expected, actual);



            //++++++++++++++++++++++++ prueba 2
            id_profesorado = 1;
            id_materia = 4;
            id_alumno = 18;
            turno = "%";     //permito que sean de cualquier turno o condicion para validar 
            condicion = "%"; // que chequee correctamente lpara todos los turnos y condiciones
            expected = false;
            

            actual = target.esta_Inscripto_Materia(id_profesorado, id_materia, id_alumno, turno, condicion);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de cambiarEstado
        ///</summary>
        [TestMethod()]
        public void cambiarEstadoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;"); 

            int id_profesorado = 1;

            Alumno nuevo = new Alumno();

            nuevo.id_alumno = 18;
            nuevo.id_matricula = 42;

            
            Materia mat = new Materia();
            mat.id_materia = 5;
            mat.turno = "mañana";


            bool expected = true;
            bool actual;
            actual = target.esta_Inscripto_Materia(id_profesorado,mat.id_materia,nuevo.id_alumno,mat.turno, "condicional");
            Assert.AreEqual(expected, actual);


            
            expected = true;

            actual = target.cambiarEstado(nuevo,mat.id_materia,5);
            Assert.AreEqual(expected, actual);



            expected = true;  //verifico este inscripto como inscripto

            actual = target.esta_Inscripto_Materia(id_profesorado, mat.id_materia, nuevo.id_alumno, mat.turno, "inscripto");
            Assert.AreEqual(expected, actual);

            target.consulta("update registro_materia set condicion = 'condicional' where id_materia = 5 and id_turno = 5 and id_matricula = 42");
        }

        /// <summary>
        ///Una prueba de cambiarEstadoCurso
        ///</summary>
        [TestMethod()]
        public void cambiarEstadoCursoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;"); 
            
            Alumno nuevo = new Alumno();

            nuevo.id_alumno = 18;
            nuevo.id_matricula = 44;

            int id_curso = 4;
            Curso curs = new Curso();
            curs.id_curso = 4;
            

            bool expected = true;
            bool actual;
            actual = target.inscriptoACurso(nuevo, curs, "condicional");
            Assert.AreEqual(expected, actual);


             id_curso = 4; 
             expected = true; 
            
            actual = target.cambiarEstadoCurso(nuevo, id_curso);
            Assert.AreEqual(expected, actual);


            
             expected = true;  //verifico este inscripto como inscripto
             
            actual = target.inscriptoACurso(nuevo,curs,"inscripto");
            Assert.AreEqual(expected, actual);

            target.consulta("update registro_curso set condicion = 'condicional' where id_curso = 4 and id_matricula = 44");
        }

        /// <summary>
        ///Una prueba de cambiarEstadoCursoEsp
        ///</summary>
        [TestMethod()]
        public void cambiarEstadoCursoEspTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");

            Alumno nuevo = new Alumno();

            nuevo.id_alumno = 18;
            nuevo.id_matricula = 47;

            int id_curso = 2;
            

            //chequeo que esta condicional
            bool expected = true;
            bool actual;
            actual = target.esta_Inscripto_CursoEsp(id_curso,nuevo.id_alumno,"condicional");
            Assert.AreEqual(expected, actual);


            //cambio su condicion
            expected = true;

            actual = target.cambiarEstadoCursoEsp(nuevo, id_curso);
            Assert.AreEqual(expected, actual);



            expected = true;  //verifico este inscripto como inscripto

            actual = target.esta_Inscripto_CursoEsp(id_curso,nuevo.id_alumno, "inscripto");
            Assert.AreEqual(expected, actual);

            target.consulta("update registro_curso_especial set condicion = 'condicional' where id_curso_especial = 2 and id_matricula = 47");
        }

        /// <summary>
        ///Una prueba de condicion
        ///</summary>
        [TestMethod()]
        public void condicionTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            int id_mat = 1; 
            int id_matricula = 42; 
            int expected = 1; 
            int actual;
            actual = target.condicion(id_mat, id_matricula);
            Assert.AreEqual(expected, actual);


             id_mat = 5;
             id_matricula = 42;
             expected = 0;
             
            actual = target.condicion(id_mat, id_matricula);
            Assert.AreEqual(expected, actual);


            id_mat = 2;
            id_matricula = 42;
            expected = -1;
            
            actual = target.condicion(id_mat, id_matricula);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///Una prueba de cambiarTurno
        ///</summary>
        [TestMethod()]
        public void cambiarTurnoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            int id_materia = 3; //una materia que tiene  dos turnos disponibles
            int matricula = 42; //el alumno de prueba
            int id_turno_actual = 3; 
            int id_turno_nuevo = 6; 

            string turno = target.obtener_turno(id_materia,42);

            Assert.AreEqual("mañana",turno); //verificamos que esta en turno mañana

            bool expected = true; 
            bool actual;
            

            //cambiamos el turno
            actual = target.cambiarTurno(id_materia, matricula, id_turno_actual, id_turno_nuevo);
            
            Assert.AreEqual(expected, actual);


            turno = target.obtener_turno(id_materia, 42); //verificamos que se cambio el turno

            Assert.AreEqual("noche",turno);


            target.consulta("update registro_materia set id_turno = 3 where id_matricula = 42 and id_materia = 3 and id_turno = 6");

        }

        /// <summary>
        ///Una prueba de getAreas
        ///</summary>
        [TestMethod()]
        public void getAreasTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            List<List<string>> expected = new List<List<string>>();

            List<string> area1 = new List<string>();
            List<string> area2 = new List<string>() ;
            List<string> area3 = new List<string>();

            area1.Add("1");
            area1.Add("Idioma");

            area2.Add("2");
            area2.Add("Arte");

            area3.Add("3");
            area3.Add("Danza");

            expected.Add(area1);
            expected.Add(area2);
            expected.Add(area3);

            List<List<string>> actual;
            
            actual = target.getAreas();
            int indice = 0;

            foreach (List<string> area in actual)
            {
                Assert.AreEqual(expected[indice][1].ToString(), area[1]);
                indice++;
            }
           

            
            
        }

        /// <summary>
        ///Una prueba de getCarreras
        ///</summary>
        [TestMethod()]
        public void getCarrerasTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            List<Profesorado> expected = new List<Profesorado>(); 
            List<Profesorado> actual;


            Profesorado prof1 = new Profesorado();
            prof1.id_profesorado = 2;
            prof1.nombre = "Profesorado Ingles";
            prof1.niveles = 4;

            Profesorado prof2 = new Profesorado();
            prof2.id_profesorado = 1;
            prof2.nombre = "Traductorado";
            prof2.niveles = 5;


            expected.Add(prof2);
            expected.Add(prof1);

            actual = target.getCarreras();
            int indice = 0;

            foreach (Profesorado elemento in actual)
            {
                Assert.AreEqual(expected[indice].id_profesorado, elemento.id_profesorado);
                Assert.AreEqual(expected[indice].nombre, elemento.nombre);
                Assert.AreEqual(expected[indice].niveles, elemento.niveles);
                indice++;
            }
            
        }

        /// <summary>
        ///Una prueba de getCurso
        ///</summary>
        [TestMethod()]
        public void getCursoTest()
        {

//busco curso con niveles que si existe y tiene varios niveles
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            string area = "Idioma";
            string nivel = "inicial";

            int esperado = 3;
            List<Curso> actual;

            actual = target.getCurso(area, nivel);

            Assert.AreEqual(esperado, actual.Count);

//busco un curso en nivel que no existe
            area = "Arte";
            nivel = "intermedio";

            actual = target.getCurso(area, nivel);

            Assert.AreEqual(null, actual);
           
        }

        /// <summary>
        ///Una prueba de getCursoEspecial
        ///</summary>
        [TestMethod()]
        public void getCursoEspecialTest()
        {
            //busco area con elementos
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            string area = "Idioma";

            int esperado = 2;
            List<CursosEsp> actual;

            actual = target.getCursoEspecial(area);

            Assert.AreEqual(esperado, actual.Count);

            //busco un area que no tiene elementos
            area = "Danza";
           
            actual = target.getCursoEspecial(area);

            Assert.AreEqual(null, actual);
        }

        /// <summary>
        ///Una prueba de getCursos
        ///</summary>
        [TestMethod()]
        public void getCursosTest()
        {
            //busco curso con niveles que si existe y tiene varios niveles
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            
            List<List<string>> actual;

            actual = target.getCursos();

            Assert.AreNotEqual(null, actual);

            
        }

        /// <summary>
        ///Una prueba de getCursosEsp
        ///</summary>
        [TestMethod()]
        public void getCursosEspTest()
        {
            //busco area con elementos
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            List<List<string>> actual;

            actual = target.getCursosEsp();

            Assert.AreNotEqual(null, actual);
        }

        /// <summary>
        ///Una prueba de verificarCupoMateria
        ///</summary>
        [TestMethod()]
        public void verificarCupoMateriaTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            int id_materia = 3; //lengua inglesa II
            string turno = "mañana"; 
            int expected = 0;   // deberia ser cero
            
            int actual;
            actual = target.verificarCupoMateria(id_materia, turno);

            Assert.AreEqual(expected, actual);


             id_materia = 1; //lengua inglesa I
             turno = "mañana";
             int not_expected = 0; //esperamos mayor a cero
             int not_expected2 = -1;

            
            actual = target.verificarCupoMateria(id_materia, turno);

            Assert.AreNotEqual(not_expected, actual);
            Assert.AreNotEqual(not_expected2, actual);

            id_materia = 9999; //una materia no existente
            turno = "mañana";
            expected = -1; //esperamos mayor a cero
            


            actual = target.verificarCupoMateria(id_materia, turno);

            Assert.AreEqual(expected, actual);
            
            
        }

        /// <summary>
        ///Una prueba de verificarCupoCursoEspecial
        ///</summary>
        [TestMethod()]
        [DeploymentItem("iaai.exe")]
        public void verificarCupoCursoEspecialTest()
        {
            Data_base_Accessor target = new Data_base_Accessor("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            
            int id_curso = 1; //artes visuales inicial
            int expected = 0;  //deberia ser cero el cupo
            int actual;
            actual = target.verificarCupoCursoEspecial(id_curso);
            Assert.AreEqual(expected, actual);


            id_curso = 2; //grabado en madera
            int not_expected = 0;  //deberia ser mayor a cero
            int not_expected2 = -1;

            actual = target.verificarCupoCursoEspecial(id_curso);
            Assert.AreNotEqual(not_expected, actual);
            Assert.AreNotEqual(not_expected2, actual);


            id_curso = 99; //curso inexistente
            expected = -1;  //deberia ser -1 no hay curso
            
            actual = target.verificarCupoCursoEspecial(id_curso);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///Una prueba de verificarCupoCurso
        ///</summary>
        [TestMethod()]
        [DeploymentItem("iaai.exe")]
        public void verificarCupoCursoTest()
        {
            Data_base_Accessor target = new Data_base_Accessor("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            
            int id_curso = 1; //artes visuales inicial
            int expected = 0;  //deberia ser cero el cupo
            int actual;
            actual = target.verificarCupoCurso(id_curso);
            Assert.AreEqual(expected, actual);


            id_curso = 11; //grabado en madera
            int not_expected = 0;  //no deberia ser 0 ni -1
            int not_expected2 = -1;

            actual = target.verificarCupoCurso(id_curso);
            Assert.AreNotEqual(not_expected, actual);
            Assert.AreNotEqual(not_expected2, actual);

            id_curso = 99; //curso inexistente
            expected = -1;  //deberia ser -1 no hay curso

            actual = target.verificarCupoCurso(id_curso);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de tieneMatriculaProfesorado
        ///</summary>
        [TestMethod()]
        public void tieneMatriculaProfesoradoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int id_alumno = 18; //alumno de prueba
            int id_profesorado = 1;  //traductorado
            int expected = 42;  //matricula esperada
            int actual;

            actual = target.tieneMatriculaProfesorado(id_alumno, id_profesorado);
            Assert.AreEqual(expected, actual);


             id_alumno = 18; 
             id_profesorado = 2; //profesorado de ingles
             expected = -1;   //se espera que no este registrado
            

            actual = target.tieneMatriculaProfesorado(id_alumno, id_profesorado);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de tieneMatriculaCursoEspecial
        ///</summary>
        [TestMethod()]
        public void tieneMatriculaCursoEspecialTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            
            int id_alumno = 18;
            int id_cursoEsp = 1;  //Ingles Tecnico (Medicina)
            int expected = 45;   //matricula esperada
            int actual;
            actual = target.tieneMatriculaCursoEspecial(id_alumno, id_cursoEsp);
            Assert.AreEqual(expected, actual);


             id_alumno = 18;
             id_cursoEsp = 4;  //Grabado en Madera
             expected = -1;   //no esta matriculado
           
            actual = target.tieneMatriculaCursoEspecial(id_alumno, id_cursoEsp);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de tieneMatriculaCurso
        ///</summary>
        [TestMethod()]
        public void tieneMatriculaCursoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int id_alumno = 18;
            int id_curso = 1;   //Inglés Inicial
            int expected = 43; //matricula del curso
            int actual;
            actual = target.tieneMatriculaCurso(id_alumno, id_curso);
            Assert.AreEqual(expected, actual);


             id_alumno = 18;
             id_curso = 17;   //Danzas Folkloricas Especialización 
             expected = -1;   //no esta matriculado  
            
            actual = target.tieneMatriculaCurso(id_alumno, id_curso);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///Una prueba de obtener_turno
        ///</summary>
        [TestMethod()]
        public void obtener_turnoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int materia = 1;  //LENGUA INGLESA I
            int matricula = 42; //alumno de prueba
            string expected = "mañana"; 
            string actual;
            actual = target.obtener_turno(materia, matricula);
            Assert.AreEqual(expected, actual);


             materia = 5;  //FONOLOGÍA II PRÁCTICA DE LABORATORIO 
             matricula = 42; //alumno de prueba
             expected = "mañana";  //esta inscripto condicional
           
            actual = target.obtener_turno(materia, matricula);
            Assert.AreEqual(expected, actual);


            materia = 4;  //LENGUA INGLESA II
            matricula = 42; //alumno de prueba
            expected = "";  //no esta inscrito
            actual = target.obtener_turno(materia, matricula);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de obtener_Id_turno
        ///</summary>
        [TestMethod()]
        public void obtener_Id_turnoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int materia = 1;  //LENGUA INGLESA I
            string turno = "mañana"; //turno a chequear
            int expected = 1;
            int actual;
            actual = target.obtener_Id_turno(materia, turno);
            Assert.AreEqual(expected, actual);


            materia = 5;  //FONOLOGÍA II PRÁCTICA DE LABORATORIO 
            turno = "mañana"; //turno a chequear
            expected = 5;  //esta inscripto condicional

            actual = target.obtener_Id_turno(materia, turno);
            Assert.AreEqual(expected, actual);


            materia = 99;  //no existente
            turno = "mañana"; //turno a chequear
            expected = -1;  //no esta inscrito
            actual = target.obtener_Id_turno(materia, turno);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de inscriptoACurso
        ///</summary>
        [TestMethod()]
        public void inscriptoACursoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            Alumno nuevo = new Alumno();
            Curso elemento = new Curso();

            nuevo.id_alumno = 18;
            elemento.id_curso = 1;  //Inglés Inicial

            string condicion = "inscripto"; 
            bool expected = true; 
            bool actual;
            actual = target.inscriptoACurso(nuevo, elemento, condicion);
            Assert.AreEqual(expected, actual);

            //----------------------------------
            nuevo.id_alumno = 18;
            elemento.id_curso = 4; //Francés Inicial

             condicion = "inscripto";  //esta en forma condicional
             expected = false;
             
            actual = target.inscriptoACurso(nuevo, elemento, condicion);
            Assert.AreEqual(expected, actual);


            //----------------------------------
            nuevo.id_alumno = 18;
            elemento.id_curso = 99; //no existe el curso

            condicion = "%";  //furzo que sea cualquier condicion
            expected = false;

            actual = target.inscriptoACurso(nuevo, elemento, condicion);
            Assert.AreEqual(expected, actual);



            //-------------------------------
            nuevo.id_alumno = 18;
            elemento.id_curso = 4; //Francés Inicial

            condicion = "condicional";  //esta en forma condicional
            expected = true;

            actual = target.inscriptoACurso(nuevo, elemento, condicion);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de inscribirMaterias
        ///</summary>
        [TestMethod()]
        public void inscribirMateriasTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            target.connectionString("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");

            Alumno nuevo = new Alumno();
            nuevo.id_alumno = 18;
            nuevo.id_matricula = 42;
            string turno = string.Empty;
            int id_profesorado = 1; 

            //armo materias para pasar como parametro
            List<Materia> mat_select = new List<Materia>();
            Materia materia1 = new Materia();
            materia1.turno_materia = target.getTurno(4);
            materia1.id_materia = 4;
            materia1.turno = "tarde";
            materia1.id_profesorado = 1;
            materia1.nivel = 2;
            materia1.nombre = "TEORÍA Y PRÁCTICA DE LA TRADUCCIÓN";
            materia1.condicion = "inscripto";

            Materia materia2 = new Materia();
            materia2.turno_materia = target.getTurno(6);
            materia2.id_materia = 6;
            materia2.turno = "tarde";
            materia2.id_profesorado = 1;
            materia2.nivel = 2;
            materia2.nombre = "GRAMÁTICA INGLESA III";
            materia2.condicion = "inscripto";

            mat_select.Add(materia1);
            mat_select.Add(materia2);


            //armo el resultado esperado
            Inscripto resultado = new Inscripto();
            resultado.condicion = "inscripto";
            resultado.materia_inscripta = mat_select[0];
            resultado.turno = "tarde";

            Inscripto resultado2 = new Inscripto();
            resultado2.condicion = "condicional";
            resultado2.materia_inscripta = mat_select[1];
            resultado2.turno = "tarde";

             
            List<Inscripto> expected = new List<Inscripto>();
            expected.Add(resultado);
            expected.Add(resultado2);


            List<Inscripto> actual;
            
            //inscribo las materias
            actual = target.inscribirMaterias(nuevo, id_profesorado, mat_select, "tarde");
              
            int indice = 0;

            //chequeo las materias
            foreach(Inscripto elemento in actual)
            {
                Assert.AreEqual(expected[indice].condicion, elemento.condicion);
                Assert.AreEqual(expected[indice].materia_inscripta.id_materia, elemento.materia_inscripta.id_materia);
                Assert.AreEqual(expected[indice].turno, elemento.turno);
                
                indice++;
            }
            

            //vuelvo la base de datos a su estado original
            foreach(Inscripto elemento in actual)
            {
                
                target.consulta("delete from registro_materia where id_inscripcion_materia = " + elemento.id_inscripcion_materia);
            
            }
        }

        /// <summary>
        ///Una prueba de inscribirCursosEspeciales
        ///</summary>
        [TestMethod()]
        public void inscribirCursosEspecialesTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            target.connectionString("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");


            Alumno nuevo = new Alumno();
            nuevo.id_alumno = 18;
            
            
            //++++++++++++++++++++ Genero cursos para inscribir ++++++++++++++
            CursosEsp curso_select = new CursosEsp();
            curso_select.id_curso = 3;
            curso_select.area = 2;
            curso_select.condicion = "inscripto";
            curso_select.nombre = "Pintura al oleo";
            

            CursosEsp curso_select2 = new CursosEsp();
            curso_select2.id_curso = 5;
            curso_select2.area = 2;
            curso_select2.condicion = "inscripto";
            curso_select2.nombre = "Pintura paisajes";



            //+++++++++++++++++++ Genero el resultado esperado ++++++++++++++++
            InscriptoCursoEsp expected = new InscriptoCursoEsp();
            expected.curso_inscripto = curso_select;
            expected.condicion = "inscripto";      //deberia quedar inscripto

            InscriptoCursoEsp expected2 = new InscriptoCursoEsp();
            expected2.curso_inscripto = curso_select2;
            expected2.condicion = "condicional";   //deberia quedar condicional

            InscriptoCursoEsp actual;
            InscriptoCursoEsp actual2;

            //ejecuto el metodo
            nuevo.id_matricula = target.generarMatriculaCursoEspecial(nuevo.id_alumno, 3); //genero la matricula para el curso
            int matricula1 = nuevo.id_matricula;

            actual = target.inscribirCursosEspeciales(nuevo, curso_select);

            //ejecuto la inscripcion del segundo curso
            nuevo.id_matricula = target.generarMatriculaCursoEspecial(nuevo.id_alumno, 5); //genero la matricula para este curso
            int matricula2 = nuevo.id_matricula;

            actual2 = target.inscribirCursosEspeciales(nuevo, curso_select2);


            //+++++++++++++++++++++++++++++++  testeo los resultados +++++
            Assert.AreNotEqual(null, actual);
            Assert.AreEqual(expected.condicion, actual.condicion);
            Assert.AreEqual(expected.curso_inscripto.id_curso, actual.curso_inscripto.id_curso);

            Assert.AreNotEqual(null, actual2);
            Assert.AreEqual(expected2.condicion, actual2.condicion);
            Assert.AreEqual(expected2.curso_inscripto.id_curso, actual2.curso_inscripto.id_curso);



            //restauro la base a su estado anterior
            target.consulta("delete from registro_curso_especial where id_registro_curso_especial = "+actual.id_inscripcion_curso+
                                " and id_curso_especial = " + actual.curso_inscripto.id_curso);
            target.consulta("delete from matricula where id_matricula = " + matricula1);

            target.consulta("delete from registro_curso_especial where id_registro_curso_especial = " + actual2.id_inscripcion_curso +
                                " and id_curso_especial = " + actual2.curso_inscripto.id_curso);
            target.consulta("delete from matricula where id_matricula = " + matricula2);
        }

        /// <summary>
        ///Una prueba de inscribirCursos
        ///</summary>
        [TestMethod()]
        public void inscribirCursosTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            target.connectionString("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");


            Alumno nuevo = new Alumno();
            nuevo.id_alumno = 18;


            //++++++++++++++++++++ Genero cursos para inscribir ++++++++++++++
            Curso curso_select = new Curso();
            curso_select.id_curso = 14;
            curso_select.id_area = 3;
            curso_select.condicion = "inscripto";
            curso_select.nombre = "Danzas Españolas Inicial";

            Curso curso_select2 = new Curso();
            curso_select2.id_curso = 16;
            curso_select2.id_area = 3;
            curso_select2.condicion = "inscripto";
            curso_select2.nombre = "Danzas Folkloricas Inicial";


            //+++++++++++++++++++ Genero el resultado esperado ++++++++++++++++
            Inscripto_curso expected = new Inscripto_curso();
            expected.curso_inscripto = curso_select;
            expected.condicion = "inscripto";      //deberia quedar inscripto

            Inscripto_curso expected2 = new Inscripto_curso();
            expected2.curso_inscripto = curso_select2;
            expected2.condicion = "condicional";   //deberia quedar condicional

            Inscripto_curso actual;
            Inscripto_curso actual2;

            //ejecuto el metodo
            nuevo.id_matricula = target.generarMatriculaCurso(nuevo.id_alumno, 14); //genero la matricula para el curso
            int matricula1 = nuevo.id_matricula;

            actual = target.inscribirCursos(nuevo, curso_select);

            //ejecuto la inscripcion del segundo curso
            nuevo.id_matricula = target.generarMatriculaCurso(nuevo.id_alumno, 16); //genero la matricula para este curso
            int matricula2 = nuevo.id_matricula;

            actual2 = target.inscribirCursos(nuevo, curso_select2);


            //+++++++++++++++++++++++++++++++  testeo los resultados +++++
            Assert.AreNotEqual(null, actual);
            Assert.AreEqual(expected.condicion, actual.condicion);
            Assert.AreEqual(expected.curso_inscripto.id_curso, actual.curso_inscripto.id_curso);

            Assert.AreNotEqual(null, actual2);
            Assert.AreEqual(expected2.condicion, actual2.condicion);
            Assert.AreEqual(expected2.curso_inscripto.id_curso, actual2.curso_inscripto.id_curso);



            //restauro la base a su estado anterior
            target.consulta("delete from registro_curso where id_registro_curso = " + actual.id_inscripcion_curso +
                                " and id_curso = " + actual.curso_inscripto.id_curso);
            target.consulta("delete from matricula where id_matricula = " + matricula1);

            target.consulta("delete from registro_curso where id_registro_curso = " + actual2.id_inscripcion_curso +
                                " and id_curso = " + actual2.curso_inscripto.id_curso);
            target.consulta("delete from matricula where id_matricula = " + matricula2);
        }

        /// <summary>
        ///Una prueba de getTurno
        ///</summary>
        [TestMethod()]
        public void getTurnoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int id_materia = 3;  //LENGUA INGLESA II
            int expected = 2;  //Tiene 2 turnos mañana y noche
            
            List<Turno> actual;

            actual = target.getTurno(id_materia);
            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual("mañana", actual[0].turno);
            Assert.AreEqual("noche", actual[1].turno);

            
        }

        /// <summary>
        ///Una prueba de getNiveles
        ///</summary>
        [TestMethod()]
        public void getNivelesTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            string[] lista = { "inicial", "intermedio", "especialización" };

            List<string> expected = new List<string>(lista); 
            List<string> actual;
            actual = target.getNiveles();
            
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
        }

        /// <summary>
        ///Una prueba de getMateriasAlumno
        ///</summary>
        [TestMethod()]
        public void getMateriasAlumnoTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            target.connectionString("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");

            int id_profesorado = 1; 
            int id_alumno = 18; 
            int expected = 2;  

            List<Materia> actual;
            actual = target.getMateriasAlumno(id_profesorado, id_alumno);
            Assert.AreEqual(expected, actual.Count);
            Assert.AreEqual("LENGUA INGLESA I", actual[0].nombre);
            Assert.AreEqual("LENGUA INGLESA II", actual[1].nombre);



            
             id_profesorado = 2; 
             id_alumno = 18;
             List<Materia> esperado = null; //no esta inscripto a ninguna materia de este profesorado

            
            actual = target.getMateriasAlumno(id_profesorado, id_alumno);
            Assert.AreEqual(esperado, actual);
            
            
        }

        /// <summary>
        ///Una prueba de getMaterias recupera todas las materias del instituto
        ///</summary>
        [TestMethod()]
        public void getMateriasTest1()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int not_expected = 0;
            List<List<string>> actual;
            actual = target.getMaterias();
            Assert.AreNotEqual(not_expected, actual.Count);
            Assert.AreNotEqual(null, actual);



        }

        /// <summary>
        ///Una prueba de getMaterias
        ///</summary>
        [TestMethod()]
        public void getMateriasTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int id_prof = 1;  //traductorado
            int nivel = 2;   //nivel 2
            string turno = "mañana";  //turno mañana
            int expected = 2;  //tiene cargadas solo 2 materias
            
            List<Materia> actual;
            actual = target.getMaterias(id_prof, nivel, turno);

            Assert.AreEqual(expected, actual.Count);


             id_prof = 1;  
             nivel = 1;      //nivel 1
             turno = "tarde";  //turno tarde
             expected = 1;  //tiene cargadas solo 1 materia

            
            actual = target.getMaterias(id_prof, nivel, turno);

            Assert.AreEqual(expected, actual.Count);


            id_prof = 2;
            nivel = 1;      //nivel 1
            turno = "%";  //cualquier turno
            List<Materia> expect = null;  //no existn materias


            actual = target.getMaterias(id_prof, nivel, turno);

            Assert.AreEqual(expect, actual);
        }

        /// <summary>
        ///Una prueba de getListadoCursos
        ///</summary>
        [TestMethod()]
        public void getListadoCursosTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int not_expected = 0;
            string id_curso = "1";//tiene un inscripto
            List<List<string>> actual;
            actual = target.getListadoCursos(id_curso);
            Assert.AreNotEqual(not_expected, actual.Count);

            
            id_curso = "4"; //tiene un inscripto como condicional
            actual = target.getListadoCursos(id_curso);
            Assert.AreEqual(null, actual);

            
            id_curso = "2"; //no tiene incriptos
            actual = target.getListadoCursos(id_curso);
            Assert.AreEqual(null, actual);


        }

        /// <summary>
        ///Una prueba de getListadoCursosEspeciales
        ///</summary>
        [TestMethod()]
        public void getListadoCursosEspTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int not_expected = 0;
            string id_curso_esp = "1";//tiene un inscripto
            List<List<string>> actual;
            actual = target.getListadoCursosEspeciales(id_curso_esp);
            Assert.AreNotEqual(not_expected, actual.Count);


            id_curso_esp = "2"; //tiene un inscripto como condicional
            actual = target.getListadoCursosEspeciales(id_curso_esp);
            Assert.AreEqual(null, actual);


            id_curso_esp = "3"; //no tiene incriptos
            actual = target.getListadoCursosEspeciales(id_curso_esp);
            Assert.AreEqual(null, actual);


        }

        /// <summary>
        ///Una prueba de getListadoMateria
        ///</summary>
        [TestMethod()]
        public void getListadoMateriaTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            

            int not_expected = 0;
            string id_materia = "3";
            string turno = "mañana";//tiene un inscripto
            List<List<string>> actual;
            actual = target.getListadoMateria(id_materia, turno);
            Assert.AreNotEqual(not_expected, actual.Count);


            id_materia = "5"; //tiene un inscripto como condicional
            turno = "mañana";
            actual = target.getListadoMateria(id_materia, turno);
            Assert.AreEqual(null, actual);


            id_materia = "6"; //no tiene incriptos
            turno = "mañana";
            actual = target.getListadoMateria(id_materia, turno);
            Assert.AreEqual(null, actual);


        }

        /// <summary>
        ///Una prueba de listadoSeguro
        ///</summary>
        [TestMethod()]
        public void getListadoSeguroTest()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            
            int not_expected = 0;
            List<List<string>> actual;
            actual = target.listadoSeguro();//hay alumno activos en la base de datos
            Assert.AreNotEqual(not_expected, actual.Count);

            int expected = 2;
            actual = target.listadoSeguro();//hay 2 alumno activos en la base de datos
            Assert.AreEqual(expected, actual.Count);

        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //                                                            //
        //               PRUEBAS ALUMNO (MAYOR DE EDAD)               //
        //               ELIMINAR Y REACTIVAR                         //
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        /// <summary>
        ///Una prueba de inscribirCursos
        ///</summary>
        [TestMethod()]
        public void eliminarReactivarAlumnoInscripto()
        {
            Data_base target = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            target.connectionString("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");

            //alumno existente cargado para probar
            Alumno nuevo = new Alumno();
            nuevo.id_alumno = 149;
            nuevo.setDni("98765432");
            

            //++++++++++++++++++++ Genero cursos donde está inscripto ++++++++++++++
            Curso curso_select = new Curso();
            curso_select.id_curso = 10;
            curso_select.id_area = 2;
            curso_select.condicion = "inscripto";
            curso_select.nombre = "Artes Visuales Inicial";

            Curso curso_select2 = new Curso();
            curso_select2.id_curso = 11;
            curso_select2.id_area = 2;
            curso_select2.condicion = "condicional";
            curso_select2.nombre = "Artes Visuales Especialización";

            //++++++++++++++++++++ Genero cursos especiales donde está inscripto ++++++++++++++
            CursosEsp curso_esp_select = new CursosEsp();
            curso_esp_select.id_curso = 4;
            curso_esp_select.area = 2;
            curso_esp_select.condicion = "inscripto";
            curso_esp_select.nombre = "Grabado en Madera";

            CursosEsp curso_esp_select2 = new CursosEsp();
            curso_esp_select2.id_curso = 5;
            curso_esp_select2.area = 2;
            curso_esp_select2.condicion = "condicional";
            curso_esp_select2.nombre = "Pintura paisajes";

            //++++++++++++++++++++ Genero materias donde está inscripto ++++++++++++++
            Materia mat = new Materia();
            mat.id_materia = 1;
            mat.condicion = "inscripto";
            mat.nombre = "LENGUA INGLESA I";
            mat.id_profesorado = 1;
            mat.turno = "mañana";

            Materia mat2 = new Materia();
            mat2.id_materia = 3;
            mat2.condicion = "condicional";
            mat2.nombre = "LENGUA INGLESA II";
            mat2.id_profesorado = 1;
            mat2.turno = "mañana";

            Materia mat3 = new Materia();
            mat3.id_materia = 5;
            mat3.condicion = "condicional";
            mat3.nombre = "FONOLOGÍA II PRÁCTICA DE LABORATORIO ";
            mat3.id_profesorado = 1;
            mat3.turno = "mañana";

            //+++++++++++++++++++ Genero el resultado esperado ++++++++++++++++
            //retorna un alumno si quien tiene el dni especificado se encuentra activo en base de datos
            Alumno recupera_alumno = target.Buscar_Alumno(nuevo.getDni());

            //si está inscripto al curso Artes Visuales inicial
            bool recuperado_curso = target.inscriptoACurso(nuevo, curso_select, "inscripto");
            //si está inscripto al curso Artes Visuales especialización
            bool recuperado_curso2 = target.inscriptoACurso(nuevo, curso_select2, "condicional");

            //si está inscripo al curso especial Grabado en madera
            bool recuperado_curso_esp = target.esta_Inscripto_CursoEsp(curso_esp_select.id_curso, nuevo.id_alumno, "inscripto");
            //si está inscripo al curso especial Pintura Paisajes
            bool recuperado_curso_esp2 = target.esta_Inscripto_CursoEsp(curso_esp_select2.id_curso, nuevo.id_alumno, "condicional");

            //si está inscripo a la materia LENGUA INGLESA I
            bool recuperado_mat = target.esta_Inscripto_Materia(mat.id_profesorado, mat.id_materia, nuevo.id_alumno, mat.turno, "inscripto");
            //si está inscripo a la materia LENGUA INGLESA II
            bool recuperado_mat2 = target.esta_Inscripto_Materia(mat2.id_profesorado, mat2.id_materia, nuevo.id_alumno, mat2.turno, "condicional");
            //si está inscripo a la materia FONOLOGÍA II PRÁCTICA DE LABORATORIO 
            bool recuperado_mat3 = target.esta_Inscripto_Materia(mat3.id_profesorado, mat3.id_materia, nuevo.id_alumno, mat3.turno, "condicional");


            //+++++++++++++++++++++++++++++++  testeo los resultados +++++
            Assert.AreEqual(nuevo.getId_alumno(),recupera_alumno.getId_alumno());
            Assert.AreEqual(true, recuperado_curso);
            Assert.AreEqual(true, recuperado_curso2);
            Assert.AreEqual(true, recuperado_curso_esp);
            Assert.AreEqual(true, recuperado_curso_esp2);
            Assert.AreEqual(true, recuperado_mat);
            Assert.AreEqual(true, recuperado_mat2);
            Assert.AreEqual(true, recuperado_mat3);

            //Elimino el alumno de la base de datos
            target.eliminarAlumno(nuevo.getDni());

            recupera_alumno = target.Buscar_Alumno(nuevo.getDni());

            //Compruebo que los estados de las materias y cursos donde estaba inscripto tengan la condición = "inactivo"
            //si está inscripto al curso Artes Visuales inicial
            recuperado_curso = target.inscriptoACurso(nuevo, curso_select, "inactivo");
            //si está inscripto al curso Artes Visuales especialización
            recuperado_curso2 = target.inscriptoACurso(nuevo, curso_select2, "inactivo");

            //si está inscripo al curso especial Grabado en madera
            recuperado_curso_esp = target.esta_Inscripto_CursoEsp(curso_esp_select.id_curso, nuevo.id_alumno, "inactivo");
            //si está inscripo al curso especial Pintura Paisajes
            recuperado_curso_esp2 = target.esta_Inscripto_CursoEsp(curso_esp_select2.id_curso, nuevo.id_alumno, "inactivo");

            //si está inscripo a la materia LENGUA INGLESA I
            recuperado_mat = target.esta_Inscripto_Materia(mat.id_profesorado, mat.id_materia, nuevo.id_alumno, mat.turno, "inactivo");
            //si está inscripo a la materia LENGUA INGLESA II
            recuperado_mat2 = target.esta_Inscripto_Materia(mat2.id_profesorado, mat2.id_materia, nuevo.id_alumno, mat2.turno, "inactivo");
            //si está inscripo a la materia FONOLOGÍA II PRÁCTICA DE LABORATORIO 
            recuperado_mat3 = target.esta_Inscripto_Materia(mat3.id_profesorado, mat3.id_materia, nuevo.id_alumno, mat3.turno, "inactivo");

            //+++++++++++++++++++++++++++++++  testeo los resultados +++++
            Assert.AreEqual(null, recupera_alumno);
            Assert.AreEqual(true, recuperado_curso);
            Assert.AreEqual(true, recuperado_curso2);
            Assert.AreEqual(true, recuperado_curso_esp);
            Assert.AreEqual(true, recuperado_curso_esp2);
            Assert.AreEqual(true, recuperado_mat);
            Assert.AreEqual(true, recuperado_mat2);
            Assert.AreEqual(true, recuperado_mat3);


            //Se reactiva el alumno eliminado, cambiando la condición de materias y cursos a "condicional"
            target.activarAlumnoEliminado(nuevo.getDni());

            recupera_alumno = target.Buscar_Alumno(nuevo.getDni());

            //Compruebo que los estados de las materias y cursos donde estaba inscripto tengan la condición = "condicional"
            //si está inscripto al curso Artes Visuales inicial
            recuperado_curso = target.inscriptoACurso(nuevo, curso_select, "condicional");
            //si está inscripto al curso Artes Visuales especialización
            recuperado_curso2 = target.inscriptoACurso(nuevo, curso_select2, "condicional");

            //si está inscripo al curso especial Grabado en madera
            recuperado_curso_esp = target.esta_Inscripto_CursoEsp(curso_esp_select.id_curso, nuevo.id_alumno, "condicional");
            //si está inscripo al curso especial Pintura Paisajes
            recuperado_curso_esp2 = target.esta_Inscripto_CursoEsp(curso_esp_select2.id_curso, nuevo.id_alumno, "condicional");

            //si está inscripo a la materia LENGUA INGLESA I
            recuperado_mat = target.esta_Inscripto_Materia(mat.id_profesorado, mat.id_materia, nuevo.id_alumno, mat.turno, "condicional");
            //si está inscripo a la materia LENGUA INGLESA II
            recuperado_mat2 = target.esta_Inscripto_Materia(mat2.id_profesorado, mat2.id_materia, nuevo.id_alumno, mat2.turno, "condicional");
            //si está inscripo a la materia FONOLOGÍA II PRÁCTICA DE LABORATORIO 
            recuperado_mat3 = target.esta_Inscripto_Materia(mat3.id_profesorado, mat3.id_materia, nuevo.id_alumno, mat3.turno, "condicional");

            //+++++++++++++++++++++++++++++++  testeo los resultados +++++
            Assert.AreEqual(nuevo.getId_alumno(), recupera_alumno.getId_alumno());
            Assert.AreEqual(true, recuperado_curso);
            Assert.AreEqual(true, recuperado_curso2);
            Assert.AreEqual(true, recuperado_curso_esp);
            Assert.AreEqual(true, recuperado_curso_esp2);
            Assert.AreEqual(true, recuperado_mat);
            Assert.AreEqual(true, recuperado_mat2);
            Assert.AreEqual(true, recuperado_mat3);





            //restauro la base a su estado anterior
            target.consulta("update registro_curso set condicion = 'condicional' where id_registro_curso = '30'" +
                                " and id_curso = '11'");
            target.consulta("update registro_curso set condicion = 'inscripto' where id_registro_curso = '31'" +
                                " and id_curso = '10'");
            target.consulta("update registro_curso_especial set condicion = 'inscripto' where id_registro_curso_especial = '38'" +
                                 " and id_curso_especial = '4'");
            target.consulta("update registro_curso_especial set condicion = 'condicional' where id_registro_curso_especial = '39'" +
                                 " and id_curso_especial = '5'");
            target.consulta("update registro_materia set condicion = 'inscripto' where id_inscripcion_materia = '75'" +
                                             " and id_materia = '1'");
            target.consulta("update registro_materia set condicion = 'condicional' where id_inscripcion_materia = '76'" +
                                             " and id_materia = '3'");
            target.consulta("update registro_materia set condicion = 'condicional' where id_inscripcion_materia = '77'" +
                                             " and id_materia = '5'");
        }

    }
}
