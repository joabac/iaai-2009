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
        bool exito = false;
        Alumno alumno_cargado = null;
        Inscripcion formulario {get; set ;}
       

        //objeto diccionario para PRE almacenar los datos y permitir luego la generacion de un objeto Alumno
        IDictionary<string, object> datos = new Dictionary<string, object>();
        
        Data_base.Data_base db = new iaai.Data_base.Data_base();


        /// <summary>
        /// Constructor de clase AltaAlumno
        /// </summary>
        public AltaAlumno()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Nuevo metodo Show para retornar elementos desde alta
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void Show(int i) 
        {
            Owner.Enabled = false;
            
            this.ShowDialog();
        }
        


        private void cancelar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            Owner.Enabled = true;
                
        }

        

        private Boolean validar()
        {
            error = "";
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(nombre.Text))
                    error = error + "Formato de nombre no válido \r\n";
            }
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(apellido.Text))
                    error = error + "Formato de apellido no válido \r\n";
            }
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            else
            {       //si el formato del dni es correcto
                if (metodo.ValidarDni(dni.Text) == true)
                {
                    //si el alumno ya fue dado de alta en el sistema
                    if (!db.buscarDniAlumno(dni.Text))
                    {
                        error = error + "El alumno ya fue dado de alta en el sistema. \r\n";
                    }
                }
                else
                {
                    error = error + "El DNI ingresado no es válido. \r\n";
                }
            }
            if (fecha_nacimiento.Text.Contains(' '))
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            else
            {
                int resultado = metodo.validar_Fecha_Nacimiento(fecha_nacimiento.Text);
                if (resultado == -1)
                    error = error + "Formato de fecha de nacimiento no válido. \r\n";
            }
            if (telefono_numero.Text.Length == 0)
                error = error + "Ingrese el teléfono. \r\n";
            else
            {
                if (!metodo.validar_Telefono(telefono_numero.Text))
                    error = error + "Formato de número de teléfono no válido \r\n";
            }
            if (direccion.Text.Length == 0)
                error = error + "Ingrese la dirección. \r\n";
            else
            {
                if (!metodo.validar_Direccion(direccion.Text))
                    error = error + "Formato de dirección no válido \r\n";
            }
            
 
 
            if (escuela_nombre.Text.Length > 0)
            {
                //si ingreso la escuela, controlo que ingrese el año de cursado
                if(escuela_año.Text.Length == 0)
                    error = error + "Ingrese el año de cursado. \r\n";
            }
            else if (escuela_año.Text.Length > 0)
            {
                error = error + "Ingrese el nombre de la escuela. \n";
            }

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

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                return false;
            }
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
        /// asigna el id de responsable a un alumno
        /// </summary>
        /// <param name="resp"></param>
        public void asignarResponsable(int resp)
        {
            this.responsable = resp;
        }

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
                datos["telefono_carac"] = null;
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

        }

        

        private void agregarResponsable_Click(object sender, EventArgs e)
        {
            if (fecha_nacimiento.Text.Contains(' '))
            {
                MessageBox.Show("Ingrese la fecha de nacimiento");
            }
            else if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) < DateTime.Today)
            {
                MessageBox.Show("No se puede asignar un responsable \n a un alumno mayor de 21 años.");
            }
            else
            {
                AsignarResponsable asignarResponsable = new AsignarResponsable();
                asignarResponsable.Owner = this;
                this.SetVisibleCore(false);
                asignarResponsable.Show();
            }
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                guardarDatos();

                alumno_cargado = new Alumno(datos);



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


                //---------------------Codigo para pasar parametros

               /* if (exito && Owner.Name.Contains(Inscripcion.ActiveForm.Name))
                {
                    formulario.cargar_alumno(alumno_cargado);
                    Owner.Enabled = true;
                    this.Close();
                }*/
                //--------------------------------------------------
            }
            
        }

        /// <summary>
        /// Retorna el ultimo alumno que se cargo desde este formulario
        /// </summary>
        /// <returns></returns>
        public Alumno get_cargado() {

            return alumno_cargado;
        }


        

    }
}
