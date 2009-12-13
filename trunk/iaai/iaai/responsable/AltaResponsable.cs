using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;


namespace iaai.responsable
{

    /// <summary>
    /// Clase para AltaResponsable
    /// </summary>
    public partial class AltaResponsable : Form
    {
        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();
        //List<int> altas = new List<int>();

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
        /// Constructor de clase AltaResponsable
        /// </summary>
        public AltaResponsable()
        {
            InitializeComponent();
        }

        private void aceptar_MouseClick(object sender, MouseEventArgs e)
        {
            if (validar())
            {
                guardarDatos();

                Responsable responsable = new Responsable(datos);
                
                if (db.altaResponsable(responsable))
                {
                    int id_respon_aux = db.Buscar_Responsable(responsable.getDni().ToString()).getId_responsable();
                    ((AsignarResponsable)this.Owner).guardaAltasResponsable(id_respon_aux);
                    try
                    {
                        ((AsignarResponsable)this.Owner).seleccionaNuevoResponsable(id_respon_aux);
                    }
                    catch
                    {
                    }
                    MessageBox.Show("El responsable fué dado de alta con éxito.");
                    this.Close();
                    if (Owner != null)
                        Owner.Enabled = true;
                }
                else
                    MessageBox.Show("Ocurrió un error en base de datos.");
                 
            }

        }

        private void cancelar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            if (Owner != null)
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
                if (metodo.validar_email(email.Text) == false) 
                    error = error + ("Formato de email no valido\r\n");
                    
        

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                return false;
            }
            if (db.buscarDniResponsable(dni.Text))
                return true;
            else
            {
                error = "El DNI ingresado ya se encuentra\nregistrado en el sistema.";
                MessageBox.Show(error);
                return false;
            }
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

            datos["direccion"] = direccion.Text;
            datos["email"] = email.Text;

        }

        

    }
}
