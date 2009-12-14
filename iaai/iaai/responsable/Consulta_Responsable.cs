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
    /// <summary>
    /// Clase de consulta Responsable
    /// </summary>
    public partial class Consulta_Responsable : Form
    {
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();
        Responsable responsable = new Responsable();
        List<Responsable> responsables_encontrados = new List<Responsable>();

        /// <summary>
        /// Constructor de clase Consulta Profesor
        /// </summary>
        public Consulta_Responsable()
        {
            InitializeComponent();
        }


        private void Consulta_Responsable_Load(object sender, EventArgs e)
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
                        //si el responsable ya fue dado de alta en el sistema
                        if (!db.buscarDniResponsable(textBoxBuscar.Text))
                        {
                            responsable = db.Buscar_Responsable(textBoxBuscar.Text);

                            nombre.Text = responsable.getNombre();
                            apellido.Text = responsable.getApellido();
                            dni.Text = responsable.getDni().ToString();
                            fecha_nacimiento.Text = responsable.getFecha_nac().ToString();
                            if (!responsable.getTelefono_carac().ToString().Equals("0"))
                                telefono_carac.Text = responsable.getTelefono_carac().ToString();
                            telefono_numero.Text = responsable.getTelefono_numero().ToString();
                            direccion.Text = responsable.getDireccion();
                            if (responsable.getEmail() != null)
                                email.Text = responsable.getEmail().ToString(); 
                        }
                        else
                        {
                            MessageBox.Show("El DNI ingresado no corresponde a un Responsable activo");
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
                        //si el responsable ya fue dado de alta en el sistema
                        if (!db.buscarDniResponsable(textBoxBuscar.Text))
                        {
                            responsable = db.Buscar_Responsable(textBoxBuscar.Text);

                            nombre.Text = responsable.getNombre();
                            apellido.Text = responsable.getApellido();
                            dni.Text = responsable.getDni().ToString();
                            fecha_nacimiento.Text = responsable.getFecha_nac().ToString();
                            if (!responsable.getTelefono_carac().ToString().Equals("0"))
                                telefono_carac.Text = responsable.getTelefono_carac().ToString();
                            telefono_numero.Text = responsable.getTelefono_numero().ToString();
                            direccion.Text = responsable.getDireccion();
                            if (responsable.getEmail() != null)
                                email.Text = responsable.getEmail().ToString();

                        }
                        else
                        {
                            MessageBox.Show("El DNI ingresado no corresponde a un Responsable activo");
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

                    if (responsables_encontrados != null)
                        responsables_encontrados.Clear();

                    if (busca_apellido.DroppedDown == true)
                        busca_apellido.DroppedDown = false;
                }



                if (metodo.validar_Nombre_App(caracter.KeyChar.ToString()) && busca_apellido.Text.Length >= 3 && caracter.KeyChar != '\r' && caracter.KeyChar != '\b')
                {
                    //busco los responsables activos que cumplan con la condicion ingresada
                    responsables_encontrados = db.Buscar_Responsable_Por_apellido(busca_apellido.Text + caracter.KeyChar);


                    if (responsables_encontrados != null) //si existe algun responsable con la condicion ingresada
                    {
                        if (busca_apellido.Items.Count > 0) //si existen elementos anteriores
                        {
                            busca_apellido.Items.Clear();   //limpio el listado para cargar los nuevos elementos
                        }

                        foreach (Responsable responsable in responsables_encontrados) //para cada valor ingresado 
                        {
                            //agrego un item en el orden de la lista obtenida presentando solo apellido,nombre
                            busca_apellido.Items.Add(responsable.getApellido() + ", " + responsable.getNombre());
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
#pragma warning disable
            catch (Exception e) //si hay errorres de indice o de carga de listados capturo la excepcion
            {
                //no realizo tarea alguna es solo para protejer la ejecucion
            }
#pragma warning enable

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
        /// carga los datos recuperados para el responsable seleccionado por apellido y nombre
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

                    if (responsables_encontrados != null)
                        responsables_encontrados.Clear();

                    if (busca_apellido.DroppedDown == true)
                        busca_apellido.DroppedDown = false;
                }

                if (responsables_encontrados != null) //si hay responsable en Lista<Responsable>
                {
                    //si presionan Enter
                    if (e.KeyCode == Keys.Enter && responsables_encontrados.Count > 0 &&
                        busca_apellido.SelectedIndex >= 0 && busca_apellido.SelectedIndex >= 0) 
                    {
                        //Busco el responsable por los datos especificos
                        Responsable responsable = db.Buscar_Responsable((responsables_encontrados[busca_apellido.SelectedIndex]).getDni().ToString());

                        if (responsable != null)
                        {
                            //cargo los textboxes
                            nombre.Text = responsable.getNombre();
                            apellido.Text = responsable.getApellido();
                            dni.Text = responsable.getDni().ToString();
                            fecha_nacimiento.Text = responsable.getFecha_nac().ToString();
                            if (!responsable.getTelefono_carac().ToString().Equals("0"))
                              telefono_carac.Text = responsable.getTelefono_carac().ToString();
                            telefono_numero.Text = responsable.getTelefono_numero().ToString();
                            direccion.Text = responsable.getDireccion();
                            if (responsable.getEmail() != null)
                                email.Text = responsable.getEmail();
                        }
                        else
                        {
                            MessageBox.Show("El DNI ingresado no corresponde a un Responsable activo");
                        }

                    }

                }
            }
            #pragma warning disable 
            catch(Exception ex){
                    //capturo excepciones para evitar salidas abruptas
            }
            #pragma warning enable
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
       
    }
}
