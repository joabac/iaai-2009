﻿using iaai.Data_base;
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
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            bool expected = true; // TODO: Inicializar en un valor adecuado
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
            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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

            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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

            Data_base metodo = new Data_base();
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

            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
            
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
            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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

            Data_base metodo = new Data_base();
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
            Data_base metodo = new Data_base();
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
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            int id_profesorado = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.generarMatriculaProfesorado(id_alumno, id_profesorado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de generarMatriculaCursoEspecial
        ///</summary>
        [TestMethod()]
        public void generarMatriculaCursoEspecialTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            int id_cursoEsp = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.generarMatriculaCursoEspecial(id_alumno, id_cursoEsp);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de generarMatriculaCurso
        ///</summary>
        [TestMethod()]
        public void generarMatriculaCursoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            int id_curso = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.generarMatriculaCurso(id_alumno, id_curso);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de esta_Inscripto_CursoEsp
        ///</summary>
        [TestMethod()]
        public void esta_Inscripto_CursoEspTest()
        {
            
        }

        /// <summary>
        ///Una prueba de esta_Inscripto_Materia
        ///</summary>
        [TestMethod()]
        public void esta_Inscripto_MateriaTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_profesorado = 0; // TODO: Inicializar en un valor adecuado
            int id_materia = 0; // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            string turno = string.Empty; // TODO: Inicializar en un valor adecuado
            string condicion = string.Empty; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.esta_Inscripto_Materia(id_profesorado, id_materia, id_alumno, turno, condicion);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de cambiarEstado
        ///</summary>
        [TestMethod()]
        public void cambiarEstadoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            int id_mat = 0; // TODO: Inicializar en un valor adecuado
            int id_turno = 0; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.cambiarEstado(nuevo, id_mat, id_turno);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de cambiarEstadoCurso
        ///</summary>
        [TestMethod()]
        public void cambiarEstadoCursoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            int id_curso = 0; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.cambiarEstadoCurso(nuevo, id_curso);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de cambiarEstadoCursoEsp
        ///</summary>
        [TestMethod()]
        public void cambiarEstadoCursoEspTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            int id_curso = 0; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.cambiarEstadoCursoEsp(nuevo, id_curso);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de condicion
        ///</summary>
        [TestMethod()]
        public void condicionTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_mat = 0; // TODO: Inicializar en un valor adecuado
            int id_matricula = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.condicion(id_mat, id_matricula);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de cambiarTurno
        ///</summary>
        [TestMethod()]
        public void cambiarTurnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_materia = 0; // TODO: Inicializar en un valor adecuado
            int matricula = 0; // TODO: Inicializar en un valor adecuado
            int id_turno_actual = 0; // TODO: Inicializar en un valor adecuado
            int id_turno_nuevo = 0; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.cambiarTurno(id_materia, matricula, id_turno_actual, id_turno_nuevo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getAreas
        ///</summary>
        [TestMethod()]
        public void getAreasTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            List<List<string>> expected = null; // TODO: Inicializar en un valor adecuado
            List<List<string>> actual;
            actual = target.getAreas();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getCarreras
        ///</summary>
        [TestMethod()]
        public void getCarrerasTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            List<Profesorado> expected = null; // TODO: Inicializar en un valor adecuado
            List<Profesorado> actual;
            actual = target.getCarreras();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getCurso
        ///</summary>
        [TestMethod()]
        public void getCursoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string area = string.Empty; // TODO: Inicializar en un valor adecuado
            string nivel = string.Empty; // TODO: Inicializar en un valor adecuado
            List<Curso> expected = null; // TODO: Inicializar en un valor adecuado
            List<Curso> actual;
            actual = target.getCurso(area, nivel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getCursoEspecial
        ///</summary>
        [TestMethod()]
        public void getCursoEspecialTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            string area = string.Empty; // TODO: Inicializar en un valor adecuado
            List<CursosEsp> expected = null; // TODO: Inicializar en un valor adecuado
            List<CursosEsp> actual;
            actual = target.getCursoEspecial(area);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getCursos
        ///</summary>
        [TestMethod()]
        public void getCursosTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            List<List<string>> expected = null; // TODO: Inicializar en un valor adecuado
            List<List<string>> actual;
            actual = target.getCursos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getCursosEsp
        ///</summary>
        [TestMethod()]
        public void getCursosEspTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            List<List<string>> expected = null; // TODO: Inicializar en un valor adecuado
            List<List<string>> actual;
            actual = target.getCursosEsp();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de verificarCupoMateria
        ///</summary>
        [TestMethod()]
        public void verificarCupoMateriaTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_materia = 0; // TODO: Inicializar en un valor adecuado
            string turno = string.Empty; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.verificarCupoMateria(id_materia, turno);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de verificarCupoCursoEspecial
        ///</summary>
        [TestMethod()]
        [DeploymentItem("iaai.exe")]
        public void verificarCupoCursoEspecialTest()
        {
            Data_base_Accessor target = new Data_base_Accessor(); // TODO: Inicializar en un valor adecuado
            int id_curso = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.verificarCupoCursoEspecial(id_curso);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de verificarCupoCurso
        ///</summary>
        [TestMethod()]
        [DeploymentItem("iaai.exe")]
        public void verificarCupoCursoTest()
        {
            Data_base_Accessor target = new Data_base_Accessor(); // TODO: Inicializar en un valor adecuado
            int id_curso = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.verificarCupoCurso(id_curso);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de tieneMatriculaProfesorado
        ///</summary>
        [TestMethod()]
        public void tieneMatriculaProfesoradoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            int id_profesorado = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.tieneMatriculaProfesorado(id_alumno, id_profesorado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de tieneMatriculaCursoEspecial
        ///</summary>
        [TestMethod()]
        public void tieneMatriculaCursoEspecialTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            int id_cursoEsp = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.tieneMatriculaCursoEspecial(id_alumno, id_cursoEsp);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de tieneMatriculaCurso
        ///</summary>
        [TestMethod()]
        public void tieneMatriculaCursoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            int id_curso = 0; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.tieneMatriculaCurso(id_alumno, id_curso);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de obtener_turno
        ///</summary>
        [TestMethod()]
        public void obtener_turnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int materia = 0; // TODO: Inicializar en un valor adecuado
            int matricula = 0; // TODO: Inicializar en un valor adecuado
            string expected = string.Empty; // TODO: Inicializar en un valor adecuado
            string actual;
            actual = target.obtener_turno(materia, matricula);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de obtener_Id_turno
        ///</summary>
        [TestMethod()]
        public void obtener_Id_turnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_materia = 0; // TODO: Inicializar en un valor adecuado
            string turno = string.Empty; // TODO: Inicializar en un valor adecuado
            int expected = 0; // TODO: Inicializar en un valor adecuado
            int actual;
            actual = target.obtener_Id_turno(id_materia, turno);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de inscriptoACurso
        ///</summary>
        [TestMethod()]
        public void inscriptoACursoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            Curso elemento = null; // TODO: Inicializar en un valor adecuado
            string condicion = string.Empty; // TODO: Inicializar en un valor adecuado
            bool expected = false; // TODO: Inicializar en un valor adecuado
            bool actual;
            actual = target.inscriptoACurso(nuevo, elemento, condicion);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de inscribirMaterias
        ///</summary>
        [TestMethod()]
        public void inscribirMateriasTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            int id_profesorado = 0; // TODO: Inicializar en un valor adecuado
            List<Materia> mat_select = null; // TODO: Inicializar en un valor adecuado
            string turno = string.Empty; // TODO: Inicializar en un valor adecuado
            List<Inscripto> expected = null; // TODO: Inicializar en un valor adecuado
            List<Inscripto> actual;
            actual = target.inscribirMaterias(nuevo, id_profesorado, mat_select, turno);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de inscribirCursosEspeciales
        ///</summary>
        [TestMethod()]
        public void inscribirCursosEspecialesTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            CursosEsp curso_select = null; // TODO: Inicializar en un valor adecuado
            InscriptoCursoEsp expected = null; // TODO: Inicializar en un valor adecuado
            InscriptoCursoEsp actual;
            actual = target.inscribirCursosEspeciales(nuevo, curso_select);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de inscribirCursos
        ///</summary>
        [TestMethod()]
        public void inscribirCursosTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            Alumno nuevo = null; // TODO: Inicializar en un valor adecuado
            Curso curso_select = null; // TODO: Inicializar en un valor adecuado
            Inscripto_curso expected = null; // TODO: Inicializar en un valor adecuado
            Inscripto_curso actual;
            actual = target.inscribirCursos(nuevo, curso_select);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getTurno
        ///</summary>
        [TestMethod()]
        public void getTurnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_materia = 0; // TODO: Inicializar en un valor adecuado
            List<Turno> expected = null; // TODO: Inicializar en un valor adecuado
            List<Turno> actual;
            actual = target.getTurno(id_materia);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getNiveles
        ///</summary>
        [TestMethod()]
        public void getNivelesTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            List<string> expected = null; // TODO: Inicializar en un valor adecuado
            List<string> actual;
            actual = target.getNiveles();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getMateriasAlumno
        ///</summary>
        [TestMethod()]
        public void getMateriasAlumnoTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_profesorado = 0; // TODO: Inicializar en un valor adecuado
            int id_alumno = 0; // TODO: Inicializar en un valor adecuado
            List<Materia> expected = null; // TODO: Inicializar en un valor adecuado
            List<Materia> actual;
            actual = target.getMateriasAlumno(id_profesorado, id_alumno);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getMaterias
        ///</summary>
        [TestMethod()]
        public void getMateriasTest1()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            List<List<string>> expected = null; // TODO: Inicializar en un valor adecuado
            List<List<string>> actual;
            actual = target.getMaterias();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de getMaterias
        ///</summary>
        [TestMethod()]
        public void getMateriasTest()
        {
            Data_base target = new Data_base(); // TODO: Inicializar en un valor adecuado
            int id_prof = 0; // TODO: Inicializar en un valor adecuado
            int nivel = 0; // TODO: Inicializar en un valor adecuado
            string turno = string.Empty; // TODO: Inicializar en un valor adecuado
            List<Materia> expected = null; // TODO: Inicializar en un valor adecuado
            List<Materia> actual;
            actual = target.getMaterias(id_prof, nivel, turno);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
