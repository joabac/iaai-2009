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
    public partial class Consulta_Profesor : Form
    {
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();
        Profesor profe = new Profesor();

        public Consulta_Profesor()
        {
            InitializeComponent();
        }


        private void Consulta_Profesor_Load(object sender, EventArgs e)
        {
            radioButtonPorDni.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonPorDni.Checked == true)
            {
                if (textBoxBuscar.Text.Length == 0)
                    MessageBox.Show("Ingrese el DNI. \r\n");
                else
                {       //si el formato del dni es correcto
                    if (metodo.ValidarDni(textBoxBuscar.Text) == true)
                    {
                        //si el profesor ya fue dado de alta en el sistema
                        if (!db.buscarDniProfesor(textBoxBuscar.Text))
                        {
                            profe = db.consultarProfesor(textBoxBuscar.Text);

                            nombre.Text = profe.getNombre();
                            apellido.Text = profe.getApellido();
                            dni.Text = profe.getDni();
                            fecha_nacimiento.Text = profe.getFecha_nac().ToString();
                            telefono_carac.Text = profe.getTelefono_carac().ToString();
                            telefono_numero.Text = profe.getTelefono_numero().ToString();
                            direccion.Text = profe.getDireccion();
                            email.Text = profe.getEmail();

                        }
                    }
                    else
                    {
                        MessageBox.Show("El DNI ingresado es incorrecto");
                    }
                }
            }
            else
            {
                if (textBoxBuscar.Text.Length == 0)
                    MessageBox.Show("Ingrese el apellido. \r\n");
                else
                {       //si el formato del dni es correcto
                    if (metodo.ValidarDni(textBoxBuscar.Text) == true)
                    {
                        //si el profesor ya fue dado de alta en el sistema
                        if (!db.buscarDniProfesor(textBoxBuscar.Text))
                        {
                            profe = db.consultarProfesor(textBoxBuscar.Text);

                            nombre.Text = profe.getNombre();
                            apellido.Text = profe.getApellido();
                            dni.Text = profe.getDni();
                            fecha_nacimiento.Text = profe.getFecha_nac().ToString();
                            telefono_carac.Text = profe.getTelefono_carac().ToString();
                            telefono_numero.Text = profe.getTelefono_numero().ToString();
                            direccion.Text = profe.getDireccion();
                            email.Text = profe.getEmail();

                        }
                    }
                    else
                    {
                        MessageBox.Show("El DNI ingresado es incorrecto");
                    }
                }


            }
        }

        
      
       
    }
}
