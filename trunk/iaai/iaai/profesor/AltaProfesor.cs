using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;

namespace iaai.profesor
{
    public partial class Altaprofesor : Form
    {

        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        public Altaprofesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suma: "+ sumar(2, 2));
        }

        public int sumar(int a, int b) {

            return a + b;
        }

        

        private void validar_mail(object sender, EventArgs e)
        {
            if (email.Text != "")
            {
                if (metodo.validar_email(email.Text) == false)
                {
                    MessageBox.Show("Formato de email no valido");
                    email.Focus();
                }
            }
            
        }


        private bool validar() {

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
           
            



            bool validar = fecha_nacimiento.Text.Contains(' ');
            if (!validar)//si la fecha esta ingresada
            {
                //si el profesor es menor de 21 años
                if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                {
                    MessageBox.Show("El profesor debe ser mayor de Edad");
                    fecha_nacimiento.Focus();
                }
            }

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);

            }
            if (metodo.ValidarDni(dni.Text) == true)
            {
                if (!db.BuscarDniProfesor(dni.Text))
                {

                    error = "El profesor ya fue dado de alta en el sistema";
                    MessageBox.Show(error);
                }

            }
            else
            {
                error = "El DNI ingresado no es valido";
                MessageBox.Show(error);
            }

          

            if (error == "")
            {
                return true;

            }

            return false;
        
        
        }

        
        private void aceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                guardarDatos();

                Profesor profe = new Profesor(datos);



                if (db.altaProfesor(profe))
                {
                    MessageBox.Show("El alumno fué dado de alta con éxito.");

                }
                else
                    MessageBox.Show("Ocurrió un error en base de datos.");
            }
        }
        
        //TODO: comentar y especificar que guarda?
        private void guardarDatos()
        {

            //cargo datos basicos del profesor
            datos["nombre"] = nombre.Text;
            datos["apellido"] = apellido.Text;
            datos["dni"] = dni.Text;
            datos["fecha_nac"] = (object)fecha_nacimiento.Text;

            //argo los 
            if (telefono_carac.Text.Length > 0)
            {
                datos["telefono_carac"] = telefono_carac.Text;
            }
            else
            {
                datos["telefono_carac"] = null;
            }

            datos["telefono_numero"] = (object)telefono_numero.Text;

            
            datos["direccion"] = direccion.Text;

            datos["email"] = email.Text;
            
        }
    }

}
