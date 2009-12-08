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
    public partial class EliminarResponsable : Form
    {
        Responsable responsable_encontrado = new Responsable();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        /// <summary>
        /// Constructor de EliminarResponsable
        /// </summary>
        public EliminarResponsable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que busca el responsable que se intenta eliminar
        /// </summary>
        /// <param name="sender">
        /// </param>
        /// <param name="e"></param>

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            if (metodo.ValidarDni(textBoxDni.Text))
            {
                //Se busca y retorna el responsable buscado
                responsable_encontrado = db.Buscar_Responsable(textBoxDni.Text);

                if (responsable_encontrado == null)
                {
                    MessageBox.Show("El DNI no es de un responsable del Instituto");
                }
                else
                {
                    //Se cargan los textBox con los datos del responsable(solo lectura)
                    nombre.Text = responsable_encontrado.getNombre();
                    apellido.Text = responsable_encontrado.getApellido();
                    fecha_nacimiento.Text = responsable_encontrado.getFecha_nac().ToString();
                    telefono_carac.Text = responsable_encontrado.getTelefono_carac().ToString();
                    telefono_numero.Text = responsable_encontrado.getTelefono_numero().ToString();
                    direccion.Text = responsable_encontrado.getDireccion();
                }
            }
            else
            {
                MessageBox.Show("El DNI ingresado es incorrecto");
            }

        }

        /// <summary>
        /// Elimina el responsable elegido
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (db.validoEliminarResponsable(responsable_encontrado.getId_responsable()))
            {
                DialogResult resultado = MessageBox.Show("¿Usted está seguro que desea eliminar?", "Atención", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (resultado == DialogResult.OK)
                {
                    //si se pudo eliminar el responsable
                    if (db.eliminarResponsable(responsable_encontrado.getDni().ToString()))
                    {
                        MessageBox.Show("El responsable ha sido eliminado con éxito");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El responsable no ha sido eliminado");
                    }
                }
            }
            else
            {
                MessageBox.Show("El responsable no puede ser eliminado \nporque está asociado a un alumno");
            }

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        
    }
}
