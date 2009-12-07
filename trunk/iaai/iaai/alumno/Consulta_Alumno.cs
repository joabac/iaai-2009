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
    public partial class Consulta_Alumno : Form
    {
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();
        Alumno alumno = new Alumno();
        List<Alumno> alumnos_encontrados = new List<Alumno>();

        public Consulta_Alumno()
        {
            InitializeComponent();
        }


        private void Consulta_Alumno_Load(object sender, EventArgs e)
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
                        //si el alumno ya fue dado de alta en el sistema
                        if (!db.buscarDniAlumno(textBoxBuscar.Text))
                        {
                            alumno = db.Buscar_Alumno(textBoxBuscar.Text);

                            nombre.Text = alumno.getNombre();
                            apellido.Text = alumno.getApellido();
                            dni.Text = alumno.getDni();
                            fecha_nacimiento.Text = alumno.getFecha_nac().ToString();
                            if (!alumno.getTelefono_carac().ToString().Equals("0"))
                                telefono_carac.Text = alumno.getTelefono_carac().ToString();
                            telefono_numero.Text = alumno.getTelefono_numero().ToString();
                            direccion.Text = alumno.getDireccion();
                            escuela_nombre.Text = alumno.getEscuela_nombre();
                            if(!alumno.getEscuela_año().ToString().Equals("0"))
                                escuela_año.Text = alumno.getEscuela_año().ToString();

                        }
                        else
                        {
                            MessageBox.Show("El DNI ingresado no corresponde a un Alumno activo");
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
                        //si el alumno ya fue dado de alta en el sistema
                        if (!db.buscarDniAlumno(textBoxBuscar.Text))
                        {
                            alumno = db.Buscar_Alumno(textBoxBuscar.Text);

                            nombre.Text = alumno.getNombre();
                            apellido.Text = alumno.getApellido();
                            dni.Text = alumno.getDni();
                            fecha_nacimiento.Text = alumno.getFecha_nac().ToString();
                            if (!alumno.getTelefono_carac().ToString().Equals("0"))
                                telefono_carac.Text = alumno.getTelefono_carac().ToString();
                            telefono_numero.Text = alumno.getTelefono_numero().ToString();
                            direccion.Text = alumno.getDireccion();
                            escuela_nombre.Text = alumno.getEscuela_nombre();
                            if (!alumno.getEscuela_año().ToString().Equals("0"))
                                escuela_año.Text = alumno.getEscuela_año().ToString();
                        }
                        else
                        {
                            MessageBox.Show("El DNI ingresado no corresponde a un Alumno activo");
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

                    if (alumnos_encontrados != null)
                        alumnos_encontrados.Clear();

                    if (busca_apellido.DroppedDown == true)
                        busca_apellido.DroppedDown = false;
                }



                if (metodo.validar_Nombre_App(caracter.KeyChar.ToString()) && busca_apellido.Text.Length >= 3 && caracter.KeyChar != '\r' && caracter.KeyChar != '\b')
                {
                    //busco los alumnos activos que cumplan con la condicion ingresada
                    alumnos_encontrados = db.Buscar_Alumno_Por_apellido(busca_apellido.Text + caracter.KeyChar);


                    if (alumnos_encontrados != null) //si existe algun alumno con la condicion ingresada
                    {
                        if (busca_apellido.Items.Count > 0) //si existen elementos anteriores
                        {
                            busca_apellido.Items.Clear();   //limpio el listado para cargar los nuevos elementos
                        }

                        foreach (Alumno alumno in alumnos_encontrados) //para cada valor ingresado 
                        {
                            //agrego un item en el orden de la lista obtenida presentando solo apellido,nombre
                            busca_apellido.Items.Add(alumno.getApellido() + ", " + alumno.getNombre());
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
        /// carga los datos recuperados para el alumno seleccionado por apellido y nombre
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

                    if (alumnos_encontrados != null)
                        alumnos_encontrados.Clear();

                    if (busca_apellido.DroppedDown == true)
                        busca_apellido.DroppedDown = false;
                }

                if (alumnos_encontrados != null) //si hay alumnos en Lista<Alumno>
                {
                    //si presionan Enter
                    if (e.KeyCode == Keys.Enter && alumnos_encontrados.Count > 0 &&
                        busca_apellido.SelectedIndex >= 0 && busca_apellido.SelectedIndex >= 0) 
                    {
                        //Busco el alumno por los datos especificos
                        Alumno alumno = db.Buscar_Alumno((alumnos_encontrados[busca_apellido.SelectedIndex]).getDni());

                        if (alumno != null)
                        {
                            //cargo los textboxes
                            nombre.Text = alumno.getNombre();
                            apellido.Text = alumno.getApellido();
                            dni.Text = alumno.getDni();
                            fecha_nacimiento.Text = alumno.getFecha_nac().ToString();
                            if (!alumno.getTelefono_carac().ToString().Equals("0"))
                                telefono_carac.Text = alumno.getTelefono_carac().ToString();
                            telefono_numero.Text = alumno.getTelefono_numero().ToString();
                            direccion.Text = alumno.getDireccion();
                            escuela_nombre.Text = alumno.getEscuela_nombre();
                            if (!alumno.getEscuela_año().ToString().Equals("0"))
                                escuela_año.Text = alumno.getEscuela_año().ToString();
                        }
                        else
                        {
                            MessageBox.Show("El DNI ingresado no corresponde a un Alumno activo");
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
