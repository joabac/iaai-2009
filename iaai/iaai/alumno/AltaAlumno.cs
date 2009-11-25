using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iaai.alumno
{
    public partial class AltaAlumno : Form
    {
        private string error = "";

        public AltaAlumno()
        {
            InitializeComponent();
        }

        private void AltaAlumno_Load(object sender, EventArgs e)
        {

        }

        private void aceptar_MouseClick(object sender, MouseEventArgs e)
        {
            validar();
        }

        private void cancelar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void agregarResponsable_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private Boolean validar()
        {
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            if (fecha_nacimiento.Text.Length == 0)
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            
            
            //[fecha_nacimiento.Text.Length-1]!= '_'
            bool validar = fecha_nacimiento.Text.Contains("");
            if (!validar)
            {
                if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) < DateTime.Today)
                {
                    if (telefono_numero.Text.Length == 0)
                        error = error + "Ingrese el teléfono. \r\n";
                    if (direccion.Text.Length == 0)
                        error = error + "Ingrese la dirección. \r\n";
                }
            }
            if (escuela_nombre.Text.Length > 0)
                if(escuela_año.Text.Length == 0)
                    error = error + "Ingrese el año de cursado. \r\n";

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                return false;
            }
            return true;




        }

    }
}
