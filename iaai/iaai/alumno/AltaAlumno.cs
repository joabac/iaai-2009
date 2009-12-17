using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.responsable;
using iaai.metodos_comunes;
using iaai.alumno;
using iaai.cursos_materias;

namespace iaai.alumno
{
    /// <summary>
    /// Clase AltaAlumno
    /// </summary>
    public partial class AltaAlumno : Form
    {
        private string error = "";
        private int responsable = -1;
        
        Utiles metodo = new Utiles();
#pragma warning disable
        bool exito = false;
#pragma warning enable
        Alumno alumno_cargado = null;
        Inscripcion formulario {get; set ;}
        
       

        //objeto diccionario para PRE almacenar los datos y permitir luego la generacion de un objeto Alumno
        IDictionary<string, object> datos = new Dictionary<string, object>();
        
        Data_base.Data_base db = new iaai.Data_base.Data_base();

        List<int> altasResp = new List<int>(); //para guardar los responsables dados de alta

        /// <summary>
        /// Método que guarda los id_responsables de los responsables que hayan sido cargados en base de datos
        /// en la carga de un alumno nuevo.
        /// </summary>
        /// <param name="a">id_responsable que se agrega a la lista altasResp</param>
        public void agregarAltaResp(List<int> a)
        {
            foreach (int f in a)
            {
                altasResp.Add(f);
            }
        }

        /// <summary>
        /// Constructor de clase AltaAlumno
        /// </summary>
        public AltaAlumno()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Redefinición del método Show para deshabilitar las ventanas que esperan el retorno desde AltaAlumno.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void Show(int i) 
        {
            Owner.Enabled = false;
            this.ShowDialog();
        }
        

        /// <summary>
        /// Método para cancelar y salir del formulario de AltaAlumno
        /// Elimina los responsables que fueron dados de alta a partir de esta función y que no fueron referenciados
        /// a ningún alumno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            //se elimina los responsables que hayan sido cargados al sistema como motivo de la carga cancelada de un alumno
            db.deshacerResponsableLista(altasResp);//elimina los responsables ingresados y no asignados
                                                  //a ningún alumno cargado.
            if(altasResp.Count > 0)
                MessageBox.Show("Se eliminó el o los responsables dado de alta para el alta alumno cancelado.");

                       
            if(Owner!= null)
                Owner.Enabled = true;
                
        }

        
        /// <summary>
        /// Método que valida los datos del formulario
        /// </summary>
        /// <returns>
        /// List<string> lista de errores
        /// </returns>
        
        private List<string> validar()
        {
            //Validación nombre
            List<string> error = new List<string>();


            //Validación en Base de datos de alumno existente
            //Validación DNI
            if (dni.Text.Length == 0)
            {
                error .Add("Ingrese el DNI.");
            }
            else
             {
                 if (metodo.ValidarDni(dni.Text) == true) //si el formato del dni es correcto
                 {
                     if (!db.buscarDniAlumno(dni.Text))
                     {
                         if (db.esAlumnoActivo(dni.Text)) //si esta ene l sistema pero como inactivo
                            error.Add("El DNI ingresado ya se encuentra\nregistrado en el sistema.");
                         else    
                            error.Add("El DNI ingresado pertenece a un alumno marcado como inactivo.");
                     }
                     
                 }
                 else
                 {
                     error.Add("El DNI ingresado no es válido.");
                 }
            }

            if (nombre.Text.Length == 0)
                error.Add("Ingrese el Nombre.");
            else
            {
                if (!metodo.validar_Nombre_App(nombre.Text))
                    error.Add("Formato de nombre no válido");
            }
            //Validación apellido
            if (apellido.Text.Length == 0)
                error.Add("Ingrese el Apellido.");
            else
            {
                if (!metodo.validar_Nombre_App(apellido.Text))
                    error.Add("Formato de apellido no válido");
            }
                
            /*
            
                
                    //si el alumno ya fue dado de alta en el sistema
                    if (!db.buscarDniAlumno(dni.Text) && !db.esAlumnoActivo(dni.Text))
                    {
                        string cadena = "El DNI del alumno a ingresar ya existe en Base de Datos, \n " +
                            "en estado 'Inactivo'.\n" +
                            "¿Desea volver a activar este alumno?";
                        string titulo = "Alumno Existente en Base de Datos";
                        if (MessageBox.Show(cadena, titulo, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            //error = error + "El alumno ya fue dado de alta en el sistema. \r\n";
                            MessageBox.Show("El alumno ya fue dado de alta en el sistema.");
                            return false;
                        }
                        else
                        {
                            if (db.activarAlumnoEliminado(dni.Text))
                            {
                                MessageBox.Show("El alumno fue reactivado en el sistema. \r\n" +
                                    "Las inscripciones antiguas pertenecientes a este \n" +
                                    "alumno tendran el estado CONDICIONAL. \r\n" +
                                    "Para modificarlas  deberá ingresar al formulario \n" +
                                    "de Inscripciones.\r\n" +
                                    "A continuación se mostrará, a modo de consulta, \n" +
                                    "los datos del alumno que acaba de activarse");
                                Consulta_Alumno recuperado = new Consulta_Alumno(dni.Text);
                                recuperado.Show();
                                if (Owner != null)
                                    Owner.Enabled = true;
                                this.Close();
                                return true; //se activo con exito

                            }
                            else 
                            { 
                                return error; 
                            }
                        }
                    }
                    else
                    {
                        if (!db.buscarDniAlumno(dni.Text) && db.esAlumnoActivo(dni.Text))
                        {
                            MessageBox.Show("El alumno ya fue dado de alta en el sistema.");
                            return error;
                        }
                    }
                }
                
            }*/


            //Validación fecha de nacimiento
            if (fecha_nacimiento.Text.Contains(' '))
                error.Add("Ingrese la fecha de nacimiento.");
            else
            {
                //Validación fecha de nacimiento
                //retorna si el alumno es mayor o menor de 21 años en caso de ser correcto el formato
                int resultado = metodo.validar_Fecha_Nacimiento(fecha_nacimiento.Text);
                if (resultado == -1)
                    error.Add("Formato de fecha de nacimiento no válido.");
                else
                {
                    bool validar = fecha_nacimiento.Text.Contains(' ');
                    if (!validar)//si la fecha esta ingresada
                    {

                        //si menor de 21 años hay que controlar que se le haya asignado un responsable
                        if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                        {
                            if (responsable == -1)
                            {
                                error.Add("Debe asignar un responsable.");
                            }
                        }

                    }
                }
            }

            //Validación número de teléfono
            if (telefono_numero.Text.Length == 0)
                error.Add("Ingrese el teléfono.");
            else
            {
                if (!metodo.validar_Telefono(telefono_numero.Text))
                    error.Add("Formato de número de teléfono no válido");
            }

            //Validación característica telefónica
            if (telefono_carac.Text.Length != 0)
            {
                if (!metodo.validar_Caracteristica(telefono_carac.Text))
                    error.Add("Formato de la Característica telefónica no válido");
            }
        

            //Validación de la dirección
            if (direccion.Text.Length == 0)
                error.Add("Ingrese la dirección.");
            else
            {
                if (!metodo.validar_Direccion(direccion.Text))
                    error.Add("Formato de dirección no válido");
            }


            
 
            if (escuela_nombre.Text.Length > 0 && escuela_nombre.Text.Length <= 100)
            {
                if (metodo.validar_Direccion(escuela_nombre.Text))
                {
                    //si ingreso la escuela, controlo que ingrese el año de cursado
                    if (escuela_año.Text.Length == 0)
                        error.Add("Ingrese el año de cursado.");
                    else
                    {
                        if (!metodo.validar_Escuela_Año(escuela_año.Text))
                            error.Add("Formato de año de cursado no válido (Debe ingresar sólo un dígito).");
                    }
                }
                else 
                {

                    error.Add("Nombre de escuela no valido.");
                }
            } 
            
            if (escuela_año.Text.Length > 0)
            {
                if (!metodo.validar_Escuela_Año(escuela_año.Text))
                    error.Add("Formato de año de cursado no válido (Debe ingresar sólo un dígito).");
                //Validación nombre escuela
                if (escuela_nombre.Text.Length == 0)
                    error.Add("Ingrese el nombre de la escuela.");
                else if (escuela_nombre.Text.Length > 100)
                    error.Add("Nombre de la escuela demasiado extenso.");
            }

            
            if (email.Text.Length != 0)
                if (!metodo.validar_email(email.Text))
                    error.Add("Formato de email no valido");

            

              
                return error; //retorno el resultado de la validacion
            
            
       }



        /// <summary>
        /// Asigna el id de responsable a un alumno
        /// </summary>
        /// <param name="resp">id_responsable de un objeto responsable en Base de Datos</param>
        public void asignarResponsable(int resp)
        {
            this.responsable = resp;
        }

       



        /// <summary>
        /// Agrega los datos del alumno al IDictionary
        /// </summary>
        private void guardarDatos()
        {
            
            datos["nombre"] = nombre.Text;
            datos["apellido"] = apellido.Text;
            datos["dni"] = dni.Text;
            datos["fecha_nac"] = (object)fecha_nacimiento.Text;
            if (telefono_carac.Text.Length > 0)
            {
                datos["telefono_carac"] = telefono_carac.Text;
            }
            else
            {
                datos["telefono_carac"] = "";
            }
            datos["telefono_numero"] = (object)telefono_numero.Text;

            if (escuela_nombre.Text.Length > 0)
            {
                datos["escuela_nombre"] = escuela_nombre.Text;
                datos["escuela_año"] = escuela_año.Text;
            }
            else
            {
                datos["escuela_nombre"] = null;
                datos["escuela_año"] = null;
            }
            datos["direccion"] = direccion.Text;
            if (responsable != -1)
            {
                datos["id_responsable"] = (object)responsable;
            }
            else
            {
                datos["id_responsable"] = null;
            }
            if (email.Text.Length != 0)
            {
                datos["email"] = email.Text;
            }
            else
            {
                datos["email"] = null;
            }
        }

        
        /// <summary>
        /// Método que deriva al formulario de AlteResponsable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agregarResponsable_Click(object sender, EventArgs e)
        {
            //Validación de la fecha de nacimiento
            //Se valida si fue ingresada, y si el alumno es menor de 21 años.
            if (fecha_nacimiento.Text.Contains(' '))
            {
                MessageBox.Show("Ingrese la fecha de nacimiento");
            }
            else
                if (metodo.validar_Fecha_Nacimiento(fecha_nacimiento.Text) == 0 || metodo.validar_Fecha_Nacimiento(fecha_nacimiento.Text) == 1)
                {
                    if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) < DateTime.Today)
                    {
                        MessageBox.Show("No se puede asignar un responsable \n a un alumno mayor de 21 años.");
                    }
                    else
                    {
                        AsignarResponsable asignarResponsable = new AsignarResponsable();
                        asignarResponsable.Owner = this;
                        //this.SetVisibleCore(false);
                        asignarResponsable.Show(1);

                    }
                }
                else
                {
                    MessageBox.Show("Formato de fecha de nacimiento no válido. \r\n");
                }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            List<string> resultado = new List<string>();

            resultado = cargar();

            if (resultado[0].Contains("El alumno fue dado de alta con éxito."))
            {
                MessageBox.Show(resultado.ToArray().ToString());
            }
            else
            {
                string mensaje = "";

                foreach (string subMensaje in resultado) 
                {
                    mensaje += subMensaje + "\r\n";
                    
                }
                MessageBox.Show("Se produjeron errores: \r\n" + mensaje);
            }
        }




        /// <summary>
        /// Retorna el ultimo alumno que se cargo desde este formulario
        /// </summary>
        /// <returns></returns>
        public Alumno get_cargado() {

            return alumno_cargado;
        }



        /// <summary>
        /// rutina de carga de alumno
        /// </summary>
        /// <returns></returns>
        public List<string> cargar()
        {
            List<string> retorno = validar();

            if (retorno.Count == 0) 
            {
                //si no hay errores--->

                guardarDatos();

                alumno_cargado = new Alumno(datos);
                //se pregunta si se cargó un alumno menor de 21
                if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                {
                    //se elimina de la lista el responsable cargado
                    if (responsable != -1 && altasResp.Contains(responsable))
                        altasResp.RemoveAt(altasResp.IndexOf(responsable));
                    db.deshacerResponsableLista(altasResp);//elimina los responsables ingresados y no asignados
                    //a ningún alumno cargado.

                }
                if (db.altaAlumno(alumno_cargado))
                {
                    retorno.Add("El alumno fue dado de alta con éxito.");
                    exito = true;

                    this.Close(); 
                }
                else
                {
                    alumno_cargado = null;
                    retorno.Add("Ocurrió un error en base de datos.");

                    exito = false;
                }


            }
            
               
            return retorno;
            
        }


        /// <summary>
        /// Utilizar solo para realizacion de pruebas 
        /// </summary>
        /// <param name="datos"></param>
        public AltaAlumno(List<string> datos )
        {

            InitializeComponent();

                
                db.connectionString("server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;");
                

                apellido.Text = datos[0];
                nombre.Text = datos[1];
                dni.Text = datos[2];
                fecha_nacimiento.Text = datos[3];
                telefono_carac.Text = datos[4];
                telefono_numero.Text = datos[5];
                direccion.Text = datos[6];
                email.Text = datos[7];
                escuela_nombre.Text = datos[8];
                escuela_año.Text = datos[9];
            
        }


    }
}
