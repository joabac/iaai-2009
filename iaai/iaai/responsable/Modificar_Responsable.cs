using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;
using iaai.responsable;

namespace iaai.responsable

{
    /// <summary>
    /// Form para la modificacion de datos de responsabes
    /// </summary>
    public partial class ModificarResponsable : Form
    {
        Responsable responsable_encontrado = new Responsable();
        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();
        string dni_viejo;


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


        /// <summary>
        /// Constructor de ModificarResponsable Form
        /// </summary>
        public ModificarResponsable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se modifican los datos personales de un responsable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aceptar_Click(object sender, EventArgs e)
        {
            //valida que los datos ingresados no contengan errores
            if (validar())
            {
                //carga los datos ingresados en la variable "datos (IDictionary)"
                guardarDatos();


                Responsable responsable = new Responsable(datos);

                //si se pudieron modificar los datos del Responsable
                if (db.modificarResponsable(responsable,dni_viejo))
                {
                    MessageBox.Show("El responsable fué modificado con éxito.");
                    this.Close();

                }
                else
                    MessageBox.Show("Ocurrió un error en base de datos.");
            }
        }

        /// <summary>
        /// Carga los datos ingresados en la interfaz, en una variable IDictionary
        /// </summary>
        private void guardarDatos()
        {

            //cargo datos basicos del profesor
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


            datos["direccion"] = direccion.Text;
            if (email.Text.Length != 0)
                datos["email"] = email.Text;
            else
                datos["email"] = null;

        }

        /// <summary>
        /// Se validan los datos personales del alumno y se muestran los errores si existen
        /// </summary>
        /// <returns>true: si no tiene errores
        ///          false: si tiene errores
        /// </returns>
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
            if (dni_busqueda.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            else
            {
                if (!dni.Text.Equals(dni_viejo))
                {
                    //si el formato del dni es correcto
                    if (metodo.ValidarDni(dni.Text) == true)
                    {
                        //si el responsable ya fue dado de alta en el sistema
                        if (!db.buscarDniResponsable(dni.Text))
                        {
                            error = error + "El responsable ya fue dado de alta en el sistema. \r\n";
                        }
                    }
                    else
                    {
                        error = error + "El DNI ingresado no es válido. \r\n";
                    }
                }
            }
            if (fecha_nacimiento.Text.Contains(' '))
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            else
            {
                int resultado = metodo.validar_Fecha_Nacimiento(fecha_nacimiento.Text);
                if (resultado == -1)
                    error = error + "Formato de fecha de nacimiento no válido. \r\n";
                else
                {
                    if (resultado == 0)
                    {
                        error = error + "El responsable es menor a 21 años. \r\n";
                    }
                }
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
            if(email.Text.Length != 0)
                if (!metodo.validar_email(email.Text) == false)
                    error = error + ("Formato de email no valido\r\n");

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Busca el responsable, dado su DNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //si el dni es correcto
            if (metodo.ValidarDni(dni_busqueda.Text))
            {
                //Busca el responsable en la base de datos
                responsable_encontrado = db.Buscar_Responsable(dni_busqueda.Text);

                if (responsable_encontrado == null)
                    MessageBox.Show("El DNI no es de un responsable registrado en el Instituto");
                else
                {
                    //se habilitan los textBox
                    nombre.Enabled = true;
                    apellido.Enabled = true;
                    dni.Enabled = true;
                    fecha_nacimiento.Enabled = true;
                    telefono_carac.Enabled = true;
                    telefono_numero.Enabled = true;
                    direccion.Enabled = true;
                    email.Enabled = true;

                    //se cargan los datos del responsable, en los textBox
                    nombre.Text = responsable_encontrado.getNombre();
                    apellido.Text = responsable_encontrado.getApellido();
                    dni.Text = responsable_encontrado.getDni().ToString();
                    dni_viejo = responsable_encontrado.getDni().ToString();
                    fecha_nacimiento.Text = responsable_encontrado.getFecha_nac().ToString();
                    if (responsable_encontrado.getTelefono_carac() != 0)
                    {
                        telefono_carac.Text = responsable_encontrado.getTelefono_carac().ToString();
                    }
                    else
                    {
                        telefono_carac.Text = "";
                    }
                    telefono_numero.Text = responsable_encontrado.getTelefono_numero().ToString();
                    direccion.Text = responsable_encontrado.getDireccion();
                    if (responsable_encontrado.getEmail() != null)
                        email.Text = responsable_encontrado.getEmail().ToString();

                }

            }
            else
            {
                MessageBox.Show("El DNI ingresado es incorrecto");
            }
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Owner != null)
                Owner.Enabled = true;
        }

              
    }
}
