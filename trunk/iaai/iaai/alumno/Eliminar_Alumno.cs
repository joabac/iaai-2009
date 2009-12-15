using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;

namespace iaai.alumno

{

    /// <summary>
    /// clase EliminarAlumno
    /// </summary>
    public partial class EliminarAlumno : Form
    {
        Alumno alumno_encontrado = new Alumno();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();


        /// <summary>
        /// Constructor de clase EliminarAlumno
        /// </summary>
        public EliminarAlumno()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que busca el alumno que se intenta eliminar
        /// </summary>
        /// <param name="sender">
        /// </param>
        /// <param name="e"></param>

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            if (metodo.ValidarDni(textBoxDni.Text))
            {
                //Se busca y retorna el alumno buscado
                alumno_encontrado = db.Buscar_Alumno(textBoxDni.Text);

                if (alumno_encontrado == null)
                {
                    MessageBox.Show("El DNI no es de un alumno del Instituto");
                }
                else
                {
                    //Se cargan los textBox con los datos del alumno(solo lectura)
                    nombre.Text = alumno_encontrado.getNombre();
                    apellido.Text = alumno_encontrado.getApellido();
                    fecha_nacimiento.Text = alumno_encontrado.getFecha_nac().ToString();
                    telefono_carac.Text = alumno_encontrado.getTelefono_carac().ToString();
                    telefono_numero.Text = alumno_encontrado.getTelefono_numero().ToString();
                    direccion.Text = alumno_encontrado.getDireccion();
                    if (alumno_encontrado.getEscuela_nombre() != null)
                    {
                        escuela_año.Text = alumno_encontrado.getEscuela_año().ToString();
                        escuela_nombre.Text = alumno_encontrado.getEscuela_nombre().ToString();
                    }
                    if (alumno_encontrado.getEmail() != null)
                        email.Text = alumno_encontrado.getEmail().ToString();
                }
            }
            else
            {
                MessageBox.Show("El DNI ingresado es incorrecto");
            }

        }

        /// <summary>
        /// Elimina el alumno elegido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            DialogResult resultado =  MessageBox.Show("¿Usted está seguro que desea eliminar?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (resultado == DialogResult.OK)
            {
                //si se pudo eliminar el alumno
                if (db.eliminarAlumno(alumno_encontrado.getDni()))
                {
                    MessageBox.Show("El alumno ha sido eliminado con éxito");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El alumno no ha sido eliminado");
                }
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        
    }
}
