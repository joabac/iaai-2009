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
                error = error + "Ingrese el Nombre. /n";
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. /n";
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. /n";
            if (fecha_nacimiento.Text.Length == 0)
                error = error + "Ingrese la fecha de nacimiento. /n";

            if (fecha_nacimiento.Text.ToCharArray[fecha_nacimiento.Text.Length - 1] != "_")
            {
                if (DateTime.Parse(fecha_nacimiento.Text).AddYears(21) < DateTime.Today)
                {
                    if (telefono_numero.Text.Length == 0)
                        error = error + "Ingrese el teléfono. /n";
                    if (direccion.Text.Length == 0)
                        error = error + "Ingrese la dirección. /n";
                }
            }
            if (escuela_nombre.Text.Length > 0)
                if(escuela_año.Text.Length == 0)
                    error = error + "Ingrese el año de cursado. /n";

            if (error.Length > 0)
            {
                error = "Se han producido errores: /n" + error;
                MessageBox.Show(error);
                return false;
            }
            return true;




        }

    }
}
