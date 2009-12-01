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
    public partial class EliminarProfesor : Form
    {
        Profesor profesor_encontrado = new Profesor();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        public EliminarProfesor()
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
                    db.eliminarProfesor(profesor_encontrado.getDni());

                }
            }
            else
            {
                MessageBox.Show("El DNI ingresado es incorrecto");
            }

        }

        
    }
}
