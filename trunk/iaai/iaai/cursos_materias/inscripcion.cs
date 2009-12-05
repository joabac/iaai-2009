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
using System.Collections;

namespace iaai.cursos_materias
{
    public partial class Inscripcion : Form
    {
        List<Alumno> alumnos_encontrados = new List<Alumno>();
        Utiles metodo = new Utiles();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<Profesorado> listado_profesorados = new List<Profesorado>();
        List<Materia> listadoMaterias = null;
        bool abierto_alta = false;
        public Alumno nuevo = null;

        public Inscripcion()
        {
            InitializeComponent();
        }

        private void Inscripcion_Load(object sender, EventArgs e)
        {
            radioButtonPorDni.Checked = true;
            panel_datos.Enabled = false;

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

        private void cargar_materias(object sender, EventArgs e)
        {

            int id_prof =  listado_profesorados[combo_profesorados.SelectedIndex].id_profesorado;
            int nivel = Convert.ToInt32(combo_niveles.SelectedItem.ToString());
            string turno = comboTurno.SelectedItem.ToString();
            DataGridViewRow fila;

            //obtengo las materias que ya tiene el alumno
            if (nuevo != null)
            {
                //Las materias que ya tiene el alumno inscriptas pero que no tienen todavia ninguna condición
                //solo si estan en categoria inscripto
                List<Materia> materias_Alumno = db.getMateriasAlumno(id_prof, nuevo.id_alumno);


                if (dataGrid_Listado.Rows.Count > 0)
                    dataGrid_Listado.Rows.Clear();


                if (combo_profesorados.Items.Count > 0 && combo_niveles.Items.Count > 0)
                {
                    //recupero las materias asociadas al profesorado nivel y turno seleccionados
                    listadoMaterias = db.getMaterias(id_prof, nivel, turno);

                    if (listadoMaterias != null)
                    {
                        foreach (Materia materia_actual in listadoMaterias)
                        {

                            string[] row = {"false",
                                        materia_actual.nombre.ToString(),
                                        materia_actual.get_adjunto(comboTurno.SelectedItem.ToString()),
                                        materia_actual.id_materia.ToString(),
                                        materia_actual.get_id_turno(comboTurno.SelectedItem.ToString()).ToString()};
                     


                            if (materias_Alumno != null)
                            {
                                foreach (Materia mat_Del_Alumno in materias_Alumno)
                                {
                                    if (mat_Del_Alumno.id_materia == materia_actual.id_materia) 
                                    {
                                       
                                        dataGrid_Listado.Rows.Add(row);
                                        //si ya esta inscripto pinto de azul
                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount-1].DefaultCellStyle.BackColor = Color.LightBlue;
                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount-1].ReadOnly = true;
                                        
                                    }
                                    else
                                    {
                                        //si no esta inscripto pinto de verde
                                        
                                        dataGrid_Listado.Rows.Add(row);
                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].ReadOnly = false;
                                        
                                    }

                                }
                            }
                            else { // si no tiene materias el alumno cargo todo en verde

                                //si ya esta inscripto pinto de azul
                                
                                dataGrid_Listado.Rows.Add(row);

                                dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].ReadOnly = false;

                            }

                       }

                    }
                }
            }
            else {

                MessageBox.Show(this,"Debe seleccionar un alumno");
                radioButtonPorDni.Focus();
                radioButtonPorDni.Checked = true;
            }


        }


        /// <summary>
        /// Carga en los campos del vista de datos 
        /// si encontro algun alumno que cumpla con el criterio de apellido
        ///
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

                if (alumnos_encontrados != null) //si hay proefesores en Lista<Profesor>
                {
                    if (e.KeyCode == Keys.Enter && alumnos_encontrados.Count > 0 && busca_apellido.SelectedIndex >= 0 && busca_apellido.SelectedIndex >= 0) //si presionan enter
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
                            telefono_carac.Text = alumno.getTelefono_carac().ToString();
                            telefono_numero.Text = alumno.getTelefono_numero().ToString();
                            direccion.Text = alumno.getDireccion();
                            //email.Text = alumno.getEmail();
                            panel_datos.Enabled = true; //habilito el panel de datos
                            nuevo = alumno;
                        }
                        else
                            panel_datos.Enabled = false;
                    }

                }
            }
            catch(Exception ex){
                    //capturo excepciones para evitar salidas abruptas
            }
        }

        
        /// <summary>
        /// Carga los datos de un objeto alumno encontrado en los campos de vista de datos
        /// </summary>
        /// <param name="alumno"></param>
        public void cargar_alumno(Alumno alumno)
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
                alumno_nuevo.Owner = this;    

                alumno_nuevo.Show(1);

                nuevo = alumno_nuevo.get_cargado();
                if (nuevo != null)
                {
                    cargar_alumno(nuevo);
                    panel_datos.Enabled = true;
                }

                else
                {
                    panel_datos.Enabled = false;
                }
                this.enabled();
                
        }

        public void enabled() { this.Enabled = true; }
        public void disabled() { this.Enabled = false; }


        /// <summary>
        /// Realiza la busqueda por DNI especificado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        
                            Alumno buscado = db.Buscar_Alumno(textBoxBuscar.Text);
                            if (buscado != null)
                            {
                                nombre.Text = buscado.getNombre();
                                apellido.Text = buscado.getApellido();
                                dni.Text = buscado.getDni();
                                fecha_nacimiento.Text = buscado.getFecha_nac().ToString();
                                telefono_carac.Text = buscado.getTelefono_carac().ToString();
                                telefono_numero.Text = buscado.getTelefono_numero().ToString();
                                direccion.Text = buscado.getDireccion();
                                //email.Text = buscado.getEmail();
                                panel_datos.Enabled = true;
                                nuevo = buscado;
                            }
                            else
                                panel_datos.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("El DNI ingresado es incorrecto");
                    }
                }
            
            


            }
        }

        private void bt_inscribe_Click(object sender, EventArgs e)
        {
            //genero un listado de las materias seleccionadas
            List<Materia> mat_select = get_Materias_Seleccionadas();
            List<Inscripto> materias_inscriptas = null;

            //recupero el string turno indicado
            string turno = comboTurno.SelectedItem.ToString();

            //recupero el id del profesorado seleccionado
            int id_profesorado = listado_profesorados[combo_profesorados.SelectedIndex].id_profesorado;

            int matricula;
            int nueva_matricula;


            if (nuevo != null)
            {
                //busco si no tiene ya matriculacion
                matricula = db.tieneMatriculaProfesorado(nuevo.getId_alumno(), id_profesorado);

                if (matricula == -1) // si no tiene matricula en el prof
                {

                    nueva_matricula = db.generarMatriculaProfesorado(nuevo.getId_alumno(), id_profesorado);

                    if (nueva_matricula != -1)
                    { //si tengo nueva matricula
                        nuevo.id_matricula = nueva_matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera
                        materias_inscriptas = db.inscribirMaterias(nuevo, id_profesorado, mat_select, turno);

                        if (materias_inscriptas != null)
                        {
                            DialogResult respuesta = MessageBox.Show("Inscripcion finalizada\r\n ¿Desea generara un reporte?", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //generar reporte de inscripcion
                        }
                        else
                            MessageBox.Show("No se pudo obtener una matricula para el Profesorado", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                    else  //si ya tiene matricula matricula != -1
                    {
                        nuevo.id_matricula = nueva_matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera
                        materias_inscriptas = db.inscribirMaterias(nuevo, id_profesorado, mat_select, turno);

                        if (materias_inscriptas != null)
                        {
                            DialogResult respuesta = MessageBox.Show("Inscripcion finalizada\r\n ¿Desea generara un reporte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            //generar reporte de inscripcion
                        }
                        else
                            MessageBox.Show("No se pudo obtener una matricula para el Profesorado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un alumno \r\n o cargar uno nuevo \r\npara poder realizar una iscripcion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Retorna un List de objetos Materia que fueron seleccionados para la inscripcion
        /// </summary>
        /// <returns></returns>
        private List<Materia> get_Materias_Seleccionadas() 
        {

            List<Materia> listado = new List<Materia>();

            if (dataGrid_Listado.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dataGrid_Listado.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells[0].Value) == true)
                    {
                        //MessageBox.Show("asi se usa-> materia: "+fila.Cells[1].Value.ToString());

                        foreach (Materia mat_temp in listadoMaterias)
                        {
                            if (mat_temp.id_materia == Convert.ToInt32(fila.Cells[3].Value))
                                listado.Add(mat_temp);

                        }
                    }

                }
                return listado;
            }
            else return null;

 
        }


        

        
    }
}
