using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.alumno;
using iaai.metodos_comunes;
using iaai.Data_base;

namespace iaai.cursos_materias
{
    public partial class Inscripcion : Form
    {
        List<Alumno> alumnos_encontrados = new List<Alumno>();
        Utiles metodo = new Utiles();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<Profesorado> listado_profesorados = new List<Profesorado>();
        List<Materia> listadoMaterias = null;

        public Inscripcion()
        {
            InitializeComponent();
        }

        private void Inscripcion_Load(object sender, EventArgs e)
        {
            radioButtonPorDni.Checked = true;

            try
            {
                listado_profesorados = db.getCarreras();

                if (listado_profesorados != null)
                {
                    foreach (Profesorado prof in listado_profesorados)
                    {
                        combo_profesorados.Items.Add(prof.nombre);
                        combo_profesorados.SelectedIndex = 0;
                    }
                }
            }
            catch(Exception excep){
            
                MessageBox.Show(excep.Message,"Excepción",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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



                if (metodo.validar_Nombre_App(caracter.KeyChar.ToString()) && busca_apellido.Text.Length >= 3 
                    && caracter.KeyChar != '\r' && caracter.KeyChar != '\b')
                {
                    //busco los profesores activos que cumplan con la condicion ingresada
                    alumnos_encontrados = db.Buscar_Alumno_Por_apellido(busca_apellido.Text + caracter.KeyChar);


                    if (alumnos_encontrados != null) //si existe algun profesor con la condicion ingresada
                    {
                        if (busca_apellido.Items.Count > 0) //si existen elementos anteriores
                        {
                            busca_apellido.Items.Clear();   //limpio el listado para cargar los nuevos elementos
                        }

                        foreach (Alumno alum in alumnos_encontrados) //para cada valor ingresado 
                        {
                            //agrego un item en el orden de la lista obtenida presentando solo apellido,nombre
                            busca_apellido.Items.Add(alum.getApellido() + ", " + alum.getNombre());
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

        private void lista_profesorados_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_niveles.Items.Clear();

            for (int i = 1; i <= listado_profesorados[combo_profesorados.SelectedIndex].niveles;i++ )
            {
                combo_niveles.Items.Add(i);
            }

            combo_niveles.SelectedIndex = 0;
        }

        private void cargar(object sender, EventArgs e)
        {

            if (dataGrid_Listado.Rows.Count > 0)
                dataGrid_Listado.Rows.Clear();

            if (combo_profesorados.Items.Count > 0 && combo_niveles.Items.Count > 0)
            {
                //recupero las materias asociadas al profesorado nivel y turno seleccionados
                listadoMaterias = db.getMaterias(listado_profesorados[combo_profesorados.SelectedIndex].id_profesorado
                                ,Convert.ToInt32(combo_niveles.SelectedItem.ToString()), comboTurno.SelectedItem.ToString());

                if (listadoMaterias != null)
                {
                    foreach (Materia materia_actual in listadoMaterias) 
                    {
                        string[] row = {"false",
                                        materia_actual.nombre,
                                        materia_actual.get_adjunto(comboTurno.SelectedItem.ToString()),
                                        materia_actual.id_materia.ToString(),
                                        materia_actual.get_id_turno(comboTurno.SelectedItem.ToString()).ToString()};

                        dataGrid_Listado.Rows.Add(row);
                        
                    }
                    
                }
            }


        }

        private void bt_inscribe_Click(object sender, EventArgs e)
        {


        }

        private void busca_apellido_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cargar(object sender, KeyEventArgs e)
        {
          /*  try
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
                    if (e.KeyCode == Keys.Enter && profes_encontrados.Count > 0 && busca_apellido.SelectedIndex >= 0 && busca_apellido.SelectedIndex >= 0) //si presionan enter
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
            }*/
        }

        

        private void cargar_alumno(Alumno alumno)
        {
            nombre.Text = alumno.getNombre();
            apellido.Text = alumno.getApellido();
            dni.Text = alumno.getDni();
            fecha_nacimiento.Text = alumno.getFecha_nac().ToString();
            telefono_carac.Text = alumno.getTelefono_carac().ToString();
            telefono_numero.Text = alumno.getTelefono_numero().ToString();
            direccion.Text = alumno.getDireccion();
            //email.Text = alumno.getEmail();
        }

        private void alta_Click(object sender, EventArgs e)
        {
            AltaAlumno alumno_nuevo = new AltaAlumno();

            alumno_nuevo.Parent= this.Parent;
            alumno_nuevo.MdiParent = this;
            alumno_nuevo.Show();
            /*Alumno alumnoCargado = alumno_nuevo.alta_inscribe();

            if (alumnoCargado != null)
                cargar_alumno(alumnoCargado);*/
            
        }

        

        
    }
}
