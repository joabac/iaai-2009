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
        private int responsable = -1;

        public AltaResponsable()
        {
            InitializeComponent();
        }

        private void aceptar_MouseClick(object sender, MouseEventArgs e)
        {
            validar();

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
            
            return true;
       }
        public void asignarResponsable(int resp)
        {
            this.responsable = resp;
        }

    }
}
