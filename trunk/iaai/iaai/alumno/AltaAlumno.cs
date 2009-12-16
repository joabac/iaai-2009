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
        /// true: si se ingresaron todos los datos obligatorios y éstos son válidos (formato y valores) 
        /// false: si falta algún dato obligatorio o si alguno no respeta el formato o tiene valores no permitidos.
        /// </returns>
        private Boolean validar()
        {
            //Validación nombre
            error = "";
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(nombre.Text))
                    error = error + "Formato de nombre no válido \r\n";
            }
            //Validación apellido
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(apellido.Text))
                    error = error + "Formato de apellido no válido \r\n";
            }
            //Validación DNI
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            else
            {       //si el formato del dni es correcto
                if (metodo.ValidarDni(dni.Text) == true)
                {
                    //si el alumno ya fue dado de alta en el sistema
                    if (!db.buscarDniAlumno(dni.Text))
                    {
                        string cadena = "El DNI del alumno a ingresar ya existe en Base de Datos, \n "+
                            "en estado 'Inactivo'.\n"+
                            "¿Desea volver a activar este alumno?";
                        string titulo = "Alumno Existente en Base de Datos";
                        if (MessageBox.Show(cadena,titulo, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            error = error + "El alumno ya fue dado de alta en el sistema. \r\n";
                        }
                        else
                        {
                            if (db.activarAlumnoEliminado(dni.Text))
                            {
                                MessageBox.Show("El alumno fue reactivado en el sistema. \n" +
                                    "Las inscripciones antiguas pertenecientes a este \n" +
                                    "alumno tendran el estado CONDICIONAL. \n" +
                                    "Para modificarlas  deberá ingresar al formulario \n" +
                                    "de Inscripciones.\n"+
                                    "A continuación se mostrará, a modo de consulta, \n"+
                                    "los datos del alumno que acaba de activarse");
                                Consulta_Alumno recuperado = new Consulta_Alumno(dni.Text);
                                recuperado.Show();
                                if (Owner != null)
                                    Owner.Enabled = true;
                                this.Close();
                                return false;

                            }
                       }
                    }
                }
                else
                {
                    error = error + "El DNI ingresado no es válido. \r\n";
                }
            }
            //Validación fecha de nacimiento
            if (fecha_nacimiento.Text.Contains(' '))
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            else
            {
                //Validación fecha de nacimiento
                //retorna si el alumno es mayor o menor de 21 años en caso de ser correcto el formato
                int resultado = metodo.validar_Fecha_Nacimiento(fecha_nacimiento.Text);
                if (resultado == -1)
                    error = error + "Formato de fecha de nacimiento no válido. \r\n";
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
                                error = error + "Debe asignar un responsable. \n";
                            }
                        }

                    }
                }
            }

            //Validación número de teléfono
            if (telefono_numero.Text.Length == 0)
                error = error + "Ingrese el teléfono. \r\n";
            else
            {
                if (!metodo.validar_Telefono(telefono_numero.Text))
                    error = error + "Formato de número de teléfono no válido \r\n";
            }

            //Validación característica telefónica
            if (telefono_carac.Text.Length != 0)
            {
                if (!metodo.validar_Caracteristica(telefono_carac.Text))
                    error = error + "Formato de la Característica telefónica no válido \r\n";
            }
        

            //Validación de la dirección
            if (direccion.Text.Length == 0)
                error = error + "Ingrese la dirección. \r\n";
            else
            {
                if (!metodo.validar_Direccion(direccion.Text))
                    error = error + "Formato de dirección no válido \r\n";
            }
            
 
            //Validación nombre escuela
            if (escuela_nombre.Text.Length > 0 && escuela_nombre.Text.Length <= 100)
            {
                //si ingreso la escuela, controlo que ingrese el año de cursado
                if(escuela_año.Text.Length == 0)
                    error = error + "Ingrese el año de cursado. \r\n";
                else
                    if(!metodo.validar_Escuela_Año(escuela_año.Text))
                        error = error + "Formato del año de cursado no válido\n              (Debe ingresar sólo un dígito). \r\n";
            } 
            else if (escuela_año.Text.Length > 0)
            {
                if (!metodo.validar_Escuela_Año(escuela_año.Text))
                    error = error + "Formato incorrecto para el año de cursado. \r\n";
                if (escuela_nombre.Text.Length <= 100) 
                    error = error + "Ingrese el nombre de la escuela. \n";
                else
                    error = error + "Nombre de la escuela demasiado extenso. \n";
            }

            
            if (email.Text.Length != 0)
                if (!metodo.validar_email(email.Text))
                    error = error + "Formato de email no valido\r\n";

            //Si existe algún error se arma el mensaje para mostrar al usuario
            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                return false;
            }
            //Validación en Base de datos de alumno existente
            if (db.buscarDniAlumno(dni.Text))
                return true;
            else
            {
                error = "El DNI ingresado ya se encuentra\nregistrado en el sistema.";
                MessageBox.Show(error);
                return false;
            }
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

            cargar();
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
        public bool cargar()
        {

            if (validar())
            {
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
                    MessageBox.Show("El alumno fué dado de alta con éxito.");
                    exito = true;

                    this.Close(); ;
                }
                else
                {
                    alumno_cargado = null;
                    MessageBox.Show("Ocurrió un error en base de datos.");

                    exito = false;
                }


            }
            return exito;
        }

        

    }
}
