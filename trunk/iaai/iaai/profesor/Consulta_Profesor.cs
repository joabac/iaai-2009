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
        List<Profesor> profes_encontrados = new List<Profesor>();

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

        

        private void buscar(object sender, KeyPressEventArgs caracter)
        {
            if (caracter.KeyChar == 8)
            {
                busca_apellido.Items.Clear();
                caracter.KeyChar = '\0';
            }
            
            if (metodo.validar_Nombre_App(caracter.KeyChar.ToString()) && busca_apellido.Text.Length >= 3)
            {
                profes_encontrados = db.Buscar_Profesor_Por_apellido(busca_apellido.Text+caracter.KeyChar);

                if (profes_encontrados != null)
                {
                    
                    foreach (Profesor profe in profes_encontrados)
                    {
                        busca_apellido.Items.Add(profe.getApellido() + ", " + profe.getNombre());
                    }

                }
                
                
                profes_encontrados = new List<Profesor>();
            }

        }

        private void radioButtonPorApellido_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPorApellido.Enabled == true)
            {
                panel1.Visible = true;
            }

        }

        private void radioButtonPorDni_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPorApellido.Enabled == true)
            {
                panel1.Visible = false;
            }

        }

        
      
       
    }
}
