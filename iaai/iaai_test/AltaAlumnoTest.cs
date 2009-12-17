using iaai.alumno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Forms;
using iaai.Data_base;
using System.Threading;
using System;
using iaai.responsable;




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
            
            
            string esperado;
            List<string> datos_A_Cargar = new List<string>();
            Data_base db = new Data_base("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
            List<string> resultado;

            //************************* Prueba de cada ruta de control de formatos y contenido ***************
            //************************************************************************************************
            //un dni no valido 6 numeros
            string[] errores_formato = {"Perez","Jose","388593","25/09/1981","0342","4856321","Pazo 325","correo@correo.com","",""};          
            datos_A_Cargar.AddRange(errores_formato);
            AltaAlumno formulario = new AltaAlumno(datos_A_Cargar);
            
            esperado = "El DNI ingresado no es válido.";
            

            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

            //*****************************************************************
            //sin dni
            string[] errores_formato1 = { "Perez", "Jose", "", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato1);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el DNI.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

            //*****************************************************************
            //sin nombre  "Formato de nombre no válido"
            string[] errores_formato2 = { "Perez", "", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato2);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el Nombre.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //Formato de nombre no valido  
            string[] errores_formato3 = { "Perez", "J05e", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato3);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de nombre no válido";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //Sin apellido
            string[] errores_formato4 = { "", "Jose", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato4);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el Apellido.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //apellido no valido
            string[] errores_formato5 = { "P€re$", "Jose", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato5);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de apellido no válido";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

            

            //*****************************************************************
            //sin fecha de naciemiento
            string[] errores_formato6 = { "Peres", "Jose", "28859353", "", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato6);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese la fecha de nacimiento.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //fecha de naciemiento no valida
            string[] errores_formato7 = { "Peres", "Jose", "28859353", "31/02/1980", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato7);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de fecha de nacimiento no válido.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //menor de edad
            string[] errores_formato8 = { "Peres", "Jose", "28859353", DateTime.Now.Subtract(TimeSpan.FromDays(3600)).ToString("dd/MM/yyyy"), "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato8);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Debe asignar un responsable.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //sin telefono
            string[] errores_formato9 = { "Peres", "Jose", "28859353", "25/12/1980" , "0342", "", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato9);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el teléfono.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();
            
            //*****************************************************************
            //telefono no valido
            string[] errores_formato10 = { "Peres", "Jose", "28859353", "25/12/1980" , "0342", "asfg54", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato10);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de número de teléfono no válido";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //caracteristica no valida
            string[] errores_formato11 = { "Peres", "Jose", "28859353", "25/12/1980", "22s2", "123456", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato11);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de la Característica telefónica no válido";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

            //*****************************************************************
            //sin direccion
            string[] errores_formato12 = { "Peres", "Jose", "28859353", "25/12/1980", "1234", "123456", "", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato12);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese la dirección.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();



            //*****************************************************************
            //direccion no valida
            string[] errores_formato13 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "€chague 345 7* B", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(errores_formato13);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de dirección no válido";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //sin año de cursado
            string[] errores_formato14 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "Paso 345", "correo@correo.com", "Carbo 3", ""};
            datos_A_Cargar.AddRange(errores_formato14);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el año de cursado.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

            //*****************************************************************
            //año de cursado no valido
            string[] errores_formato15 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "Paso 345", "correo@correo.com", "Carbo 3", "2000" };
            datos_A_Cargar.AddRange(errores_formato15);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de año de cursado no válido (Debe ingresar sólo un dígito).";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //sin el nombre de la escuela
            string[] errores_formato16 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "Paso 345", "correo@correo.com", "", "2" };
            datos_A_Cargar.AddRange(errores_formato16);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el nombre de la escuela.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //nombre de la escuela extenso
            string[] errores_formato17 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "Paso 345", "correo@correo.com", generarCadenaLarga(101), "2" };
            datos_A_Cargar.AddRange(errores_formato17);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Nombre de la escuela demasiado extenso.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();
            
            //*****************************************************************
            //nombre de la escuela no valido
            string[] errores_formato22 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "Paso 345", "correo@correo.com", "A$trada", "2" };
            datos_A_Cargar.AddRange(errores_formato22);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Nombre de escuela no valido.";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();
            
            


            //*****************************************************************
            //e-mail no valido
            string[] errores_formato18 = { "Peres", "Jose", "28859353", "25/12/1980", "0342", "123456", "Paso 345", "cor&reo@co..rreo.com", "carbo 3", "2" };
            datos_A_Cargar.AddRange(errores_formato18);
            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Formato de email no valido";


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();



            //*****************************************************************
            //todos los campos vacios
            string[] errores_formato19 = { "", "", "", "", "", "", "", "", "", "" };
            datos_A_Cargar.AddRange(errores_formato19);
            formulario = new AltaAlumno(datos_A_Cargar);

            
            resultado = formulario.cargar();

            Assert.AreEqual("Ingrese el DNI.", resultado[0].ToString());
            Assert.AreEqual("Ingrese el Nombre.", resultado[1].ToString());
            Assert.AreEqual("Ingrese el Apellido.", resultado[2].ToString());
            Assert.AreEqual("Ingrese la fecha de nacimiento.", resultado[3].ToString());
            Assert.AreEqual("Ingrese el teléfono.", resultado[4].ToString());
            Assert.AreEqual("Ingrese la dirección.", resultado[5].ToString());
                     
           
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //*****************************************************************
            //todos los campos no validos
            string[] errores_formato20 = { "234", "235", "234f", "2344", "sdf", "sdf", "ç`p4%", "345&/3º1*", "·$%/&fs4", "333" };
            datos_A_Cargar.AddRange(errores_formato20);
            formulario = new AltaAlumno(datos_A_Cargar);


            resultado = formulario.cargar();

            Assert.AreEqual("El DNI ingresado no es válido.", resultado[0].ToString());
            Assert.AreEqual("Formato de nombre no válido", resultado[1].ToString());
            Assert.AreEqual("Formato de apellido no válido", resultado[2].ToString());
            Assert.AreEqual("Formato de fecha de nacimiento no válido.", resultado[3].ToString());
            Assert.AreEqual("Formato de número de teléfono no válido", resultado[4].ToString());
            Assert.AreEqual("Formato de la Característica telefónica no válido", resultado[5].ToString());
            Assert.AreEqual("Formato de dirección no válido", resultado[6].ToString());
            Assert.AreEqual("Nombre de escuela no valido.", resultado[7].ToString());
            Assert.AreEqual("Formato de año de cursado no válido (Debe ingresar sólo un dígito).", resultado[8].ToString());
            Assert.AreEqual("Formato de email no valido", resultado[9].ToString());


            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();



 //**************************** Validaciones de logica de alta responsable ***********
            //-------------------------------------------------------------------------------------------------

            //intento cargar responsable a alumno sin fecha de nacimiento
            string[] respo_test = { "Perez", "Matias", "28859355", "", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(respo_test);


            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese la fecha de nacimiento";

            resultado = formulario.cargaResponsable();  //verifico las rutas de alta responsable
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

            //--------------------------------------------------------------------------------------------------
            //intento cargar responsable a alumno mayor de edad
            string[] respo_test1 = { "Perez", "Matias", "28859355", DateTime.Now.Subtract(TimeSpan.FromDays(10000)).ToString("dd/MM/yyyy"), "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(respo_test1);


            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "No se puede asignar un responsable \n a un alumno mayor de 21 años.";

            resultado = formulario.cargaResponsable();  //verifico las rutas de alta responsable
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //--------------------------------------------------------------------------------------------------
            //un alumno valido menor de edad sin datos de escuela
            string[] respo_test2 = { "Perez", "Matias", "28859355", DateTime.Now.Subtract(TimeSpan.FromDays(4000)).ToString("dd/MM/yyyy"), "0342", "4856321", "Pazo 325", "correo@correo.com", "", "", "2" };
            datos_A_Cargar.AddRange(respo_test2);


            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "El alumno es menor debe ingresar la escuela a la que concurre";

            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


            //--------------------------------------------------------------------------------------------------
            //un alumno valido menor de edad sin datos de escuela
            string[] respo_test4 = { "Perez", "Matias", "28859355", DateTime.Now.Subtract(TimeSpan.FromDays(4000)).ToString("dd/MM/yyyy"), "0342", "4856321", "Pazo 325", "correo@correo.com", "Carbo 3", "","2" };
            datos_A_Cargar.AddRange(respo_test4);


            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "Ingrese el año de cursado.";

            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();



            //****************************** Pruebas de consistencia de logica ****************///
//-------------------------------------------------------------------------------------------------
            //un alumno valido
            string [] cadena2 = {"Perez","Jose","28859353","25/09/1981","0342","4856321","Pazo 325","correo@correo.com","",""};
            datos_A_Cargar.AddRange(cadena2);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = "El alumno fue dado de alta con éxito.";    

            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

//-------------------------------------------------------------------------------------------------
            //alumno con otro nombre pero igual dni que el anterior ingresado
            string[] cadena3 = { "D'luca", "Carlos", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena3);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = "El DNI ingresado ya se encuentra\nregistrado en el sistema."; 
            
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

//-------------------------------------------------------------------------------------------------
            //ejecuto el procedimiento para marcar como eliminado el alumno
            //para chequear luego si me permite cargar nuevamente el alumno repetido
            db.eliminarAlumno("28859353");

//-------------------------------------------------------------------------------------------------
            //intento volver a cargar el alumno que fue eliminado en la sentencia anterior
            string[] cadena4 = { "Perez", "Jose", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena4);

            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = "El DNI ingresado pertenece a un alumno marcado como inactivo.";                             
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

//-------------------------------------------------------------------------------------------------
            //reactivo el alumno manualmente
            db.activarAlumnoEliminado("28859353");

//-------------------------------------------------------------------------------------------------
            //intento volver a cargar el alumno que fue reactivado anteriormente con identicos datos filiatorios
            string[] cadena5 = { "Perez", "Jose", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena5);

            formulario = new AltaAlumno(datos_A_Cargar);

            esperado = "El DNI ingresado ya se encuentra\nregistrado en el sistema."; 
            resultado=formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

//--------------------------------------------------------------------------------------------------
            //intento volver a cargar el alumno que fue reactivado anteriormente con diferentes datos filiatorios
            string[] cadena7 = { "D'luca", "Carlos", "28859353", "25/09/1981", "0342", "4856321", "Pazo 325", "correo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena7);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = "El DNI ingresado ya se encuentra\nregistrado en el sistema.";

            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());
            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();

//-------------------------------------------------------------------------------------------------
            //eliminio nuevamente para volver a intentar cargar con otros datos filiatorios
            db.eliminarAlumno("28859353");


//-------------------------------------------------------------------------------------------------
            //intento volver a cargar el dni con otros datos filiatorios
            string[] cadena6 = { "L'hospital", "Carlitos", "28859353", "23/12/1981", "0343", "4456321", "Pazo 286", "cor_reo@correo.com", "", "" };
            datos_A_Cargar.AddRange(cadena6);


            formulario = new AltaAlumno(datos_A_Cargar);
            esperado = "El DNI ingresado pertenece a un alumno marcado como inactivo.";                              


            resultado = formulario.cargar();
            Assert.AreEqual(esperado, resultado[0].ToString());

            formulario.Dispose();
            datos_A_Cargar.Clear();
            resultado.Clear();


          
            
            //********************  prueba de logica de carga de alumno menor de edad ****************
//----------------------------------------------------------------------------------------------------
            //Genero un responsable para poder cargar el alumno menor de edad
            
            IDictionary<string, object> datos = new Dictionary<string, object>();

            //se generan los dato del Responsable a dar de alta
            datos["nombre"] = "Roberto";
            datos["apellido"] = "Perez";
            datos["dni"] = "20856325";
            datos["fecha_nac"] = "1970-12-01";
            datos["telefono_carac"] = "0342";
            datos["telefono_numero"] = "4856321";
            datos["direccion"] = "Pazo 325";
            datos["email"] = "correo@correo.com";

            Responsable respo = new Responsable(datos);  //se crea el objeto Responsable

            db.altaResponsable(respo); //Alta del Responsable
            Responsable padre = db.Buscar_Responsable("20856325");  //recupero el responable

            if (padre != null)
            {
                //un alumno valido menor de edad
                string[] respo_test3 = { "Perez", "Matias", "28859355", "25/09/2000", "0342", "4856321", "Pazo 325", "correo@correo.com", "Carbo 3", "4", padre.getId_responsable().ToString() };
                datos_A_Cargar.AddRange(respo_test3);


                formulario = new AltaAlumno(datos_A_Cargar);

                esperado = "El alumno fue dado de alta con éxito.";

                resultado = formulario.cargar();  
                Assert.AreEqual(esperado, resultado[0].ToString());
                formulario.Dispose();
                datos_A_Cargar.Clear();
                resultado.Clear();
            }
            else
                Assert.Fail("Error en Preparación de Prueba: No se pudo cargar el responable");

//----------------------------------------------------------------------------------------------------



            db.consulta("delete from alumno where dni like '28859353'"); //borro alumno mayor
            db.consulta("delete from alumno where dni like '28859355'"); //borro laumno menor
            db.consulta("delete from responsable where dni like '20856325' "); //borro responsable generado


        }


        /// <summary>
        /// metodo auxiliar para generar cadenas largas
        /// </summary>
        /// <param name="longitud">la longitud a generar</param>
        /// <returns>cadena tipo string de longitud requerida</returns>
        string generarCadenaLarga(int longitud) 
        {
            List<char> cadena = new List<char>();

            for (int i = 1; i <= longitud; i++) 
            {
                cadena.Add('a');
            }
            String salida = new String(cadena.ToArray());
            
            return salida;
        }
    }
}
