using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iaai.responsable
{
    public partial class AltaResponsable : Form
    {
        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();

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
                    MessageBox.Show("El responsable fué dado de alta con éxito.");
                else
                    MessageBox.Show("Ocurrió un error en base de datos.");
            }

        }

        private void cancelar_MouseClick(object sender, MouseEventArgs e)
        {

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
    
            bool validar = fecha_nacimiento.Text.Contains(' ');
            if (!validar)//si la fecha esta ingresada
            {   //controlo si es mayor de 21
                if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                {
                    error = error + "El responsable debe ser mayor de 21 años. \n";
                }
            }
            
            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                return false;
            }

            if (db.validarDniResponsable(dni.Text))
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

        }

    }
}
