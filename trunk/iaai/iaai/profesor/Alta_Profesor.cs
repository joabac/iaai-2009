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

            //validacion nombre
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(nombre.Text))
                    error = error + "Formato de nombre no válido \r\n";
            }

            //validación apellido
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(apellido.Text))
                    error = error + "Formato de apellido no válido \r\n";
            }

            //validación dni
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            else
            {
                if (metodo.ValidarDni(dni.Text) == true)
                {
                    if (!db.buscarDniProfesor(dni.Text))
                    {
                        error = error + "El profesor ya fue dado de alta en el sistema. \r\n";
                    }
                }
                else
                {
                    error = error + "El DNI ingresado no es válido. \r\n";
                }
            }

           
            //validación caracteristica del telefono
            if (telefono_carac.Text.Length == 0)
                error = error + "Ingrese la característica del teléfono. \r\n";

            else
            {
                if(!metodo.validar_Caracteristica(telefono_carac.Text)
                    error = error + "Formato de característica de teléfono no válido \r\n";
            }


            //validación numero del telefono
            if (telefono_numero.Text.Length == 0)
                error = error + "Ingrese el número de teléfono. \r\n";

            else
            {
                if(!metodo.validar_Telefono(telefono_numero.Text)
                    error = error + "Formato de número de teléfono no válido \r\n";
            }

            //validación de la dirección
            if (direccion.Text.Length == 0)
                error = error + "Ingrese la dirección. \r\n";
           
            


            //validación fehca de nacimiento
            bool validar = fecha_nacimiento.Text.Contains(' ');
            if (!validar)//si la fecha esta ingresada
            {
                //si el profesor es menor de 21 años
                if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                {
                    error = "El profesor no puede ser menor de edad.";
                    
                    fecha_nacimiento.Focus();
                }
            }


            //si se producen errores
            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);

            }

            //si el profesor ya fue dado de alta
            if (metodo.ValidarDni(dni.Text) == true)
            {
                if (!db.buscarDniProfesor(dni.Text))
                {

                    error = "El profesor ya fue dado de alta en el sistema";
                    MessageBox.Show(error);
                }

            }
            else
            {
                error = "El DNI ingresado no es válido";
            }

          
            //si no hubo errores
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
                    MessageBox.Show("El profesor fué dado de alta con éxito.");

                    this.Close();
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void fecha_nacimiento_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dni_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void telefono_carac_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void telefono_numero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
