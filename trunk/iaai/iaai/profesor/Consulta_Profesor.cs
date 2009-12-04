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
                            profe = db.Buscar_Profesor(textBoxBuscar.Text);

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
                {       //si el formato del apellido es correcto
                    if (metodo.validar_Nombre_App(textBoxBuscar.Text) == true)
                    {
                        //si el profesor ya fue dado de alta en el sistema
                        if (!db.buscarDniProfesor(textBoxBuscar.Text))
                        {
                            profe = db.Buscar_Profesor(textBoxBuscar.Text);

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

        
        /// <summary>
        /// Procede con la busqueda para los carctaeres parciales ingresados
        /// </summary>
        /// <param name="sender">objeto origen</param>
        /// <param name="caracter">ingresa con cada caracter que se presiona en el combobox</param>
        private void buscar(object sender, KeyPressEventArgs caracter)
        {
            try
            {
                if (caracter.KeyChar == '\b')//si presionan back space
                {
                    if (busca_apellido.Items.Count > 0)
                        busca_apellido.Items.Clear();

                    busca_apellido.Text = "";

                    if (profes_encontrados != null)
                        profes_encontrados.Clear();

                    if (busca_apellido.DroppedDown == true)
                        busca_apellido.DroppedDown = false;
                }



                if (metodo.validar_Nombre_App(caracter.KeyChar.ToString()) && busca_apellido.Text.Length >= 3 && caracter.KeyChar != '\r' && caracter.KeyChar != '\b')
                {
                    //busco los profesores activos que cumplan con la condicion ingresada
                    profes_encontrados = db.Buscar_Profesor_Por_apellido(busca_apellido.Text + caracter.KeyChar);


                    if (profes_encontrados != null) //si existe algun profesor con la condicion ingresada
                    {
                        if (busca_apellido.Items.Count > 0) //si existen elementos anteriores
                        {
                            busca_apellido.Items.Clear();   //limpio el listado para cargar los nuevos elementos
                        }

                        foreach (Profesor profe in profes_encontrados) //para cada valor ingresado 
                        {
                            //agrego un item en el orden de la lista obtenida presentando solo apellido,nombre
                            busca_apellido.Items.Add(profe.getApellido() + ", " + profe.getNombre());
                        }


                        //si la lista no esta desplegada
                        if (busca_apellido.DroppedDown == false)
                        {
                            busca_apellido.SelectedIndex = 0; //selecciono el primer item de la lista
                            busca_apellido.DroppedDown = true; //despliego el listado
                            caracter.KeyChar = '\0';
                        }
                    }
                }
            }
            catch (Exception e) //si hay errorres de indice o de carga de listados capturo la excepcion
            {
                //no realizo tarea alguna es solo para protejer la ejecucion
            }

        }

        private void radioButtonPorApellido_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPorApellido.Enabled == true)
            {
                panel1.Visible = true;
                busca_apellido.Focus();
            }

        }

        private void radioButtonPorDni_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPorApellido.Enabled == true)
            {
                panel1.Visible = false;
            }

        }

        /// <summary>
        /// carga los datos recuperados para el profesor seleccionado por apellido y nombre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cargar(object sender, KeyEventArgs e)
        {
            try
            {   
                //si presiona del | -> | <- | Esc
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Escape)
                {
                    //limpio todos los contenedores
                    if (busca_apellido.Items.Count > 0)
                    {
                        busca_apellido.Items.Clear();
                    }

                    busca_apellido.Text = "";

                    if (profes_encontrados != null)
                        profes_encontrados.Clear();

                    if (busca_apellido.DroppedDown == true)
                        busca_apellido.DroppedDown = false;
                }

                if (profes_encontrados != null) //si hay proefesores en Lista<Profesor>
                {
                    //si presionan Enter
                    if (e.KeyCode == Keys.Enter && profes_encontrados.Count > 0 &&
                        busca_apellido.SelectedIndex >= 0 && busca_apellido.SelectedIndex >= 0) 
                    {
                        //Busco el profesor por los datos especificos
                        Profesor profe = db.Buscar_Profesor((profes_encontrados[busca_apellido.SelectedIndex]).getDni());

                        if (profe != null)
                        {
                            //cargo los textboxes
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

                }
            }
            catch(Exception ex){
                    //capturo excepciones para evitar salidas abruptas
            }
        }

      
       
    }
}
