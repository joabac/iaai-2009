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

        /// <summary>
        /// Constructor de clase para eliminacion de profesores
        /// </summary>
        public Eliminar_Profesor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que buscar el profesor que se intenta eliminar
        /// </summary>
        /// <param name="sender">
        /// </param>
        /// <param name="e"></param>

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            if (metodo.ValidarDni(textBoxDni.Text))
            {
                //Se busca y retorna el profesor buscado
                profesor_encontrado = db.Buscar_Profesor(textBoxDni.Text);

                if (profesor_encontrado == null)
                {
                    MessageBox.Show("El DNI no es de un profesor del Instituto");
                }
                else
                {
                    //Se cargan los textBox con los datos del profesor(solo lectura)
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

        /// <summary>
        /// Elimina el profesor elegido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            DialogResult resultado =  MessageBox.Show("¿Usted está seguro que desea eliminar?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.OK)
            {
                //si se pudo eliminar el profesor
                if (db.eliminarProfesor(profesor_encontrado.getDni()))
                {
                    MessageBox.Show("El profesor ha sido eliminado con éxito");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El profesor no ha sido eliminado");
                }

                
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        
    }
}
