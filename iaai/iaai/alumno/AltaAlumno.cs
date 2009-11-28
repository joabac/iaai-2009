using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.responsable;

namespace iaai.alumno
{
    public partial class AltaAlumno : Form
    {
        private string error = "";
        private int responsable = -1;
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();

        public AltaAlumno()
        {
            InitializeComponent();
        }

        private void AltaAlumno_Load(object sender, EventArgs e)
        {

        }

        private void aceptar_MouseClick(object sender, MouseEventArgs e)
        {
            if (validar())
            {
                guardarDatos();

                Alumno alumno = new Alumno(datos);



                if (db.altaAlumno(alumno))
                {
                    MessageBox.Show("El alumno fué dado de alta con éxito.");

                }
                else
                    MessageBox.Show("Ocurrió un error en base de datos.");
            }
            
        }

        private void cancelar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void agregarResponsable_MouseClick(object sender, MouseEventArgs e)
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
                this.SetVisibleCore(false);
                asignarResponsable.Show();
            }
        }

        private Boolean validar()
        {
            error = "";
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            if (fecha_nacimiento.Text.Contains(' '))
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            if (telefono_numero.Text.Length == 0)
                error = error + "Ingrese el teléfono. \r\n";
            if (direccion.Text.Length == 0)
                error = error + "Ingrese la dirección. \r\n";
            
 
 
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
            if (db.validarDniAlumno(dni.Text))
                return true;
            else
            {
                error = "El DNI ingresado ya se encuentra\nregistrado en el sistema.";
                MessageBox.Show(error);
                return false;
            }
       }
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
                datos["escuela_año"] = 2001;
            }
            else
            {
                datos["escuela_nombre"] = null;
                datos["escuela_año"] = null;
            }
            datos["direccion"] = direccion.Text;
            if (responsable != -1)
            {
                datos["id_responsable"] = 2;
            }
            else
            {
                datos["id_responsable"] = null;
            }

        }

        private void aceptar_Click(object sender, EventArgs e)
        {

        }

        

    }
}
