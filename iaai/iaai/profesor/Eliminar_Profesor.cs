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
    public partial class Eliminar_Profesor : Form
    {
        Profesor profesor_encontrado = new Profesor();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        public Eliminar_Profesor()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            if (metodo.ValidarDni(textBoxDni.Text))
            {
                profesor_encontrado = db.Buscar_Profesor(textBoxDni.Text);

                if (profesor_encontrado == null)

                    MessageBox.Show("El DNI no es de un profesor del Instituto");
                else
                {
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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {

            db.eliminarProfesor(profesor_encontrado.getDni());

            this.Close();

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        
    }
}
