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
    public partial class ModificarProfesor : Form
    {
        Profesor profesor_encontrado = new Profesor();
        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        public ModificarProfesor()
        {
            InitializeComponent();
        }

        private void modificarProfesor_Load(object sender, EventArgs e)
        {

        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                guardarDatos();

                Profesor profe = new Profesor(datos);



                if (db.modificarProfesor(profe))
                {
                    MessageBox.Show("El profesor fué modificado con éxito.");
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

        private bool validar()
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
            /*if (dni.Text.Length == 0)
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
                    error = error + "El DNI ingresado no es valido. \r\n";
                }
            }*/
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
                /*if (!db.buscarDniProfesor(dni.Text))
                {

                    error = "El profesor ya fue dado de alta en el sistema";
                    MessageBox.Show(error);
                }*/

            }
            else
            {
                error = "El DNI ingresado no es valido";
            }



            if (error == "")
            {
                return true;

            }

            return false;


        }

        private void button_buscar_Click(object sender, EventArgs e)
        {

            if (metodo.ValidarDni(dni.Text))
            {
                profesor_encontrado = db.Buscar_Profesor(dni.Text);

                if (profesor_encontrado == null)
                    MessageBox.Show("El DNI no es de un profesor del Instituto");
                else
                {
                    nombre.Enabled = true;
                    apellido.Enabled = true;
                    fecha_nacimiento.Enabled = true;
                    telefono_carac.Enabled = true;
                    telefono_numero.Enabled = true;
                    direccion.Enabled = true;
                    email.Enabled = true;

                    nombre.Text = profesor_encontrado.getNombre();
                    apellido.Text = profesor_encontrado.getApellido();
                    fecha_nacimiento.Text = profesor_encontrado.getFecha_nac().ToString();
                    telefono_carac.Text = profesor_encontrado.getTelefono_carac().ToString();
                    telefono_numero.Text = profesor_encontrado.getTelefono_numero().ToString();
                    direccion.Text = profesor_encontrado.getDireccion();
                    email.Text = profesor_encontrado.getEmail();


                }



            }
            else
            {
                MessageBox.Show("El DNI ingresado es incorrecto");
            }
            
        }

       


        



    }
}
