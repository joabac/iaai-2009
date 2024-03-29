﻿using System;
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
using System.Drawing.Printing;

namespace iaai.cursos_materias
{
    /// <summary>
    /// Clase de FOrm para Inscripciones
    /// </summary>
    public partial class Inscripcion : Form
    {
        List<Alumno> alumnos_encontrados = new List<Alumno>();
        Utiles metodo = new Utiles();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<Profesorado> listado_profesorados = new List<Profesorado>();
        List<Materia> listadoMaterias = null;
#pragma warning disable
        List<Curso> listadoCursos = null;
#pragma warning enable
        Menu_inicial menuInicio;


        /// <summary>
        /// El alumno que se maneja dentro del formulario y sobre el cual se realizan 
        /// las operaciones de asgnacion de cursos
        /// </summary>
        public Alumno nuevo = null;
        List<List<string>> lista_areas = null;
        List<string> niveles = null;
        

        List<Inscripto> materias_inscriptas = null;
        List<InscriptoCursoEsp> CursosEsp_inscriptos = null;
        List<Inscripto_curso> Cursos_inscriptos = null;


        /// <summary>
        /// Constructor de clase Inscripcion
        /// </summary>
        public Inscripcion()
        {
            InitializeComponent();
        }

        private void Inscripcion_Load(object sender, EventArgs e)
        {
            
            panel_datos.Enabled = false;

            try
            {
                listado_profesorados = db.getCarreras();
                lista_areas = db.getAreas();
                niveles = db.getNiveles();
                

                if (listado_profesorados != null)
                {
                    foreach (Profesorado prof in listado_profesorados)
                    {
                        combo_profesorados.Items.Add(prof.nombre);

                    }
                }

                if (niveles != null) 
                {
                    foreach(string nivel in niveles)
                    {
                        comboBoxNivel.Items.Add(nivel.ToString());
                    }

                    comboBoxNivel.SelectedIndex = 0;
                    
                }
                if(lista_areas != null){
                    foreach (List<string> area in lista_areas) 
                    {
                        comboBoxArea.Items.Add(area[1]);
                        comboBoxArea_esp.Items.Add(area[1]);
                    }
                    comboBoxArea.SelectedIndex = 0;
                    comboBoxArea_esp.SelectedIndex = 0;

                    
                }
                combo_profesorados.SelectedIndex = 0;
                comboTurno.SelectedIndex = 0;

                radioButtonPorDni.Checked = true;
                radioButtonPorApellido.Checked = false;
                panel1.Visible = false;
                
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

                    nuevo = null;
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
                else 
                {

                    if (caracter.KeyChar == '*' && caracter.KeyChar != '\r' && caracter.KeyChar != '\b') 
                    {
                        //busco los profesores activos que cumplan con la condicion ingresada
                        alumnos_encontrados = db.Buscar_Alumno_Por_apellido("%");


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
            if (radioButtonPorApellido.Checked == true)
            {
                panel1.Visible = true;
                busca_apellido.Focus();
            }

        }

        private void radioButtonPorDni_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonPorDni.Checked == true)
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

            if(comboTurno.SelectedItem != null )
               carga_Materias();
        }

        private void cargar_materias(object sender, EventArgs e)
        {
            if (comboTurno.SelectedItem != null && nuevo != null)
                carga_Materias();

        }

        /// <summary>
        /// Rutina para la carga del Datagridview
        /// </summary>
        private void carga_Materias()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                int id_prof = listado_profesorados[combo_profesorados.SelectedIndex].id_profesorado;
                int nivel = Convert.ToInt32(combo_niveles.SelectedItem.ToString());
                string turno = comboTurno.SelectedItem.ToString();


                //obtengo las materias que ya tiene el alumno
                if (nuevo != null)
                {
                    //Las materias que ya tiene el alumno inscriptas pero que no tienen todavia ninguna condición
                    //solo si estan en categoria inscripto
                    List<Materia> materias_Alumno = db.getMateriasAlumno(id_prof, nuevo.id_alumno);
                    nuevo.id_matricula = db.tieneMatriculaProfesorado(nuevo.id_alumno, id_prof);

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
                                int condicion = db.condicion(materia_actual.id_materia, nuevo.id_matricula);

                                if (db.esta_Inscripto_Materia(id_prof, materia_actual.id_materia, nuevo.id_alumno, "%", "%") && condicion >= 0)
                                {
                                    //si entro por esta linea significa que el alumno ya esta inscripto a la materia ya sea condicional o inscripto definitivo


                                    //si ya esta inscripto pero condicional pinto de amarillo
                                    if (condicion == 0) //inscripto en forma condicional
                                    {
                                        string[] row = {"false",
                                        materia_actual.nombre.ToString(),
                                        materia_actual.get_adjunto(comboTurno.SelectedItem.ToString()),
                                        materia_actual.id_materia.ToString(),
                                        materia_actual.get_id_turno(comboTurno.SelectedItem.ToString()).ToString(),"true"};

                                        dataGrid_Listado.Rows.Add(row);


                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].ReadOnly = true;
                                    }
                                    else //inscripto en estado inscripto
                                    {

                                        string[] row = {"false",
                                        materia_actual.nombre.ToString(),
                                        materia_actual.get_adjunto(comboTurno.SelectedItem.ToString()),
                                        materia_actual.id_materia.ToString(),
                                        materia_actual.get_id_turno(comboTurno.SelectedItem.ToString()).ToString(),"false"};

                                        dataGrid_Listado.Rows.Add(row);

                                        string turno_inscripto = db.obtener_turno(materia_actual.id_materia,nuevo.id_matricula);
                                        if(turno_inscripto.Contains(comboTurno.SelectedItem.ToString()))
                                        {
                                            dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                                        }
                                        else
                                        {
                                            dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGray;
                                            dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.ForeColor = Color.Gray;
                                        }
                                        
                                        dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].ReadOnly = true;

                                    }


                                }
                                else
                                {
                                    //si no esta inscripto pinto de verde

                                    string[] row = {"false",
                                        materia_actual.nombre.ToString(),
                                        materia_actual.get_adjunto(comboTurno.SelectedItem.ToString()),
                                        materia_actual.id_materia.ToString(),
                                        materia_actual.get_id_turno(comboTurno.SelectedItem.ToString()).ToString(),"false"};

                                    dataGrid_Listado.Rows.Add(row);
                                    dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                    dataGrid_Listado.Rows[dataGrid_Listado.RowCount - 1].ReadOnly = false;

                                }

                            }
                        }
                    }
                    else
                    {

                        MessageBox.Show(this, "Debe seleccionar un alumno");
                        radioButtonPorDni.Focus();
                        radioButtonPorDni.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// Carga en los campos de vista de datos 
        /// si encontro algun alumno que cumpla con el criterio de apellido
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

                    nuevo = null;
                }

                if (alumnos_encontrados != null) //si hay alumnos en Lista<Alumno>
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
                            email.Text = alumno.getEmail();
                            panel_datos.Enabled = true; //habilito el panel de datos
                            nuevo = alumno;

                            if (tabControl1.SelectedIndex == 0)
                                carga_Materias();
                            if (tabControl1.SelectedIndex == 1)
                                carga_Cursos();
                            if(tabControl1.SelectedIndex == 2)
                                checkedList_CurEsp();
                            
                            
                        }
                        else
                        {
                            nuevo = null;
                            panel_datos.Enabled = false;
                        }
                    }

                }
            }
#pragma warning disable
           catch (Exception ex){
                    //capturo excepciones para evitar salidas abruptas
           }
#pragma warning enable
        }

        
        /// <summary>
        /// Carga los datos de un objeto alumno encontrado en los campos de vista de datos
        /// para el alumno encontrado 
        /// </summary>
        /// <param name="alumno">Recibe el Alumno a cargar en el panel de datos</param>
        public void cargar_alumno(Alumno alumno)
        {
            nombre.Text = alumno.getNombre();
            apellido.Text = alumno.getApellido();
            dni.Text = alumno.getDni();
            fecha_nacimiento.Text = alumno.getFecha_nac().ToString();
            telefono_carac.Text = alumno.getTelefono_carac().ToString();
            telefono_numero.Text = alumno.getTelefono_numero().ToString();
            direccion.Text = alumno.getDireccion();
            email.Text = alumno.getEmail();
            
        }

        private void alta_Click(object sender, EventArgs e)
        {
            
                AltaAlumno alumno_nuevo = new AltaAlumno();
                Alumno cargado = null;
                alumno_nuevo.Owner = this;    

                alumno_nuevo.Show(1);

                nuevo = alumno_nuevo.get_cargado();
                if (nuevo != null)
                    cargado  = alumno_nuevo.get_cargado();
                
                if (cargado != null)
                {
                    nuevo = db.Buscar_Alumno(cargado.getDni());
                    cargar_alumno(nuevo);
                    panel_datos.Enabled = true;
                    busca_apellido.Items.Clear();
                    busca_apellido.Text = nuevo.getApellido()+", "+nuevo.getNombre();
                    carga_Materias();
                }

                else
                {
                    panel_datos.Enabled = false;
                }
                this.enabled();
                
        }
        /// <summary>
        /// bloques esta ventana
        /// </summary>
        public void enabled() { this.Enabled = true; }

        /// <summary>
        /// habilita esta ventana
        /// </summary>
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
                                //cargo los text boxes
                                nombre.Text = buscado.getNombre();
                                apellido.Text = buscado.getApellido();
                                dni.Text = buscado.getDni();
                                fecha_nacimiento.Text = buscado.getFecha_nac().ToString();
                                telefono_carac.Text = buscado.getTelefono_carac().ToString();
                                telefono_numero.Text = buscado.getTelefono_numero().ToString();
                                direccion.Text = buscado.getDireccion();
                                email.Text = buscado.getEmail();
                                panel_datos.Enabled = true;
                                nuevo = buscado;

                                if (tabControl1.SelectedIndex == 0)
                                    carga_Materias();
                                if (tabControl1.SelectedIndex == 1)
                                    carga_Cursos();
                                if (tabControl1.SelectedIndex == 2)
                                    checkedList_CurEsp();
                                
                            }
                            else
                            {
                                nuevo = null;
                                panel_datos.Enabled = false;
                            }
                    }
                    else
                    {
                        nuevo = null;
                        MessageBox.Show("El DNI ingresado es incorrecto");
                    }
                }
            
            


            }
        }

        /// <summary>
        /// Metodo de control y gestion de las rutins de inscripcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_inscribe_Click(object sender, EventArgs e)
        {
            //genero un listado de las materias seleccionadas
            List<Materia> mat_select = get_Materias_Seleccionadas();
            
            if (comboTurno.SelectedIndex >= 0)
            {

                //recupero el string turno indicado
                string turno = comboTurno.SelectedItem.ToString();

                //recupero el id del profesorado seleccionado
                int id_profesorado = listado_profesorados[combo_profesorados.SelectedIndex].id_profesorado;

                int matricula;
                int nueva_matricula;


                if (nuevo != null && mat_select != null && mat_select.Count >0) //si se selecciono alumno y se seleccionaron materias
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
                                DialogResult respuesta = MessageBox.Show("Inscripcion finalizada\r\n ¿Desea generara un reporte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (respuesta == DialogResult.Yes)
                                {
                                    imprimir_reporteMaterias();

                                    
                                    
                                }
                                carga_Materias();
                                mat_select.Clear();
                            }

                        }
                        else
                            MessageBox.Show("No se pudo obtener una matricula para el Profesorado", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    }
                    else  //si ya tiene matricula matricula != -1
                    {
                        nuevo.id_matricula = matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera
                        materias_inscriptas = db.inscribirMaterias(nuevo, id_profesorado, mat_select, turno);

                        if (materias_inscriptas != null && materias_inscriptas.Count > 0)
                        {
                            DialogResult respuesta = MessageBox.Show("Inscripcion finalizada\r\n ¿Desea generara un reporte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (respuesta == DialogResult.Yes)
                            {
                                imprimir_reporteMaterias();
                                
                                
                            }
                            carga_Materias();
                            mat_select.Clear();
                        }
                        else
                            MessageBox.Show("No se realizo la inscripción a las Materias seleccionadas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }


                }
                else
                {
                    if (nuevo == null)
                        MessageBox.Show("Debe seleccionar un alumno \r\n o cargar uno nuevo \r\npara poder realizar una iscripcion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        if (mat_select == null || mat_select.Count == 0)
                            MessageBox.Show("Debe seleccionar al menos una materia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else {
                MessageBox.Show("Debe seleccionar un Turno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        /// <summary>
        /// Rutina para configuracion del reporte de Inscripcion 
        /// Prepara la pagina y asgna las configuraciones
        /// </summary>
        /// <returns></returns>
        private bool imprimir_reporteMaterias()
        {
           // DataGridViewPrinter MyDataGridViewPrinter;
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            reporte_inscripcion.DocumentName = "Reporte de Inscripción";
            reporte_inscripcion.PrinterSettings = MyPrintDialog.PrinterSettings;
            reporte_inscripcion.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            reporte_inscripcion.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            
           //genramos el evento imprimir que desencadena la genracion del informe
            reporte_inscripcion.Print();
           
            return true;
        
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
                        
                        foreach (Materia mat_temp in listadoMaterias)
                        {
                            if (mat_temp.id_materia == Convert.ToInt32(fila.Cells[3].Value))
                            {
                                if (Convert.ToBoolean(fila.Cells[5].Value))
                                {
                                    mat_temp.condicion = "condicional";
                                }
                                else {
                                    mat_temp.condicion = "inscripto";
                                }
                                listado.Add(mat_temp);
                            }
                                
                        }
                    }

                }
                return listado;
            }
            else return null;

 
        }

        private void combo_niveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid_Listado.Rows.Clear();
            if(comboTurno.SelectedItem != null && nuevo!=null)
                carga_Materias();
        }

        

        


        /// <summary>
        /// Rutina de generacion de la pagina de reporte de inscripcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reporte_inscripcion_PrintPage(object sender, PrintPageEventArgs e)
        {

            string cadena;
            Font printFont = new Font("Arial", 10);
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            int count = 0;
            float yPos =  10;

//-----------------------Encabezado-----------------------
            e.Graphics.DrawString("REPORTE DE INSCRIPCION", new Font("Arial Black",15), Brushes.Black,( e.MarginBounds.Left), (yPos+10), new StringFormat());
            count+= 5;

//----------------------Datos del Alumno------------------
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics));

            string alumno = nuevo.getApellido() + ", " + nuevo.getNombre()+"\r\nMatricula: "+nuevo.id_matricula;

            e.Graphics.DrawString(alumno, new Font("Arial Black",12), Brushes.Black, leftMargin, yPos, new StringFormat());
            count += 4;

            e.Graphics.DrawLine(new Pen(Brushes.Black), leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
            count++;
//---------------------Registro de inscripciones-----------
            foreach(Inscripto elemento in materias_inscriptas)
            {
                 yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
    
                 cadena = "Numero de Inscripción: "+elemento.id_inscripcion_materia +"\r\nNombre Materia: "+elemento.materia_inscripta.nombre +"\r\nTurno: " + elemento.turno +"\r\nCondición: "+elemento.condicion+"\r\n\r\n";

                 e.Graphics.DrawString(cadena, printFont, Brushes.Black,leftMargin,yPos,new StringFormat());
                 count+= 5;

                 yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawLine(new Pen(Brushes.Black), leftMargin,yPos, e.MarginBounds.Right,yPos);
                count++;
            }
        }

        /// <summary>
        /// metodo para utilizacion en Find
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        private static bool esta_condicional(Materia M) 
        {

            if (M.condicion.Contains("condicional"))
                return true;
            else
                return false;
        }

        private void cargar_al_salir(object sender, EventArgs e)
        {
            try
            {
                
                if (alumnos_encontrados != null) //si hay alumnos en Lista<Alumno>
                {
                    if (alumnos_encontrados.Count > 0 && busca_apellido.SelectedIndex >= 0 && busca_apellido.SelectedIndex >= 0) //si presionan enter
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
                            email.Text = alumno.getEmail();
                            panel_datos.Enabled = true; //habilito el panel de datos
                            nuevo = alumno;

                            if (tabControl1.SelectedIndex == 0)
                                carga_Materias();
                            if (tabControl1.SelectedIndex == 1)
                                carga_Cursos();
                            if (tabControl1.SelectedIndex == 2)
                                checkedList_CurEsp();
                        }
                        else
                        {
                            nuevo = null;
                            panel_datos.Enabled = false;
                        }
                    }

                }
            }
#pragma warning disable
            catch (Exception ex)
            {
                //capturo excepciones para evitar salidas abruptas
            }
#pragma warning enable
        }

        /// <summary>
        /// Rutina para refresco de combo Cursos especiales
        /// </summary>
        private void checkedList_CurEsp() 
        {

            if (tabControl1.SelectedIndex == 2)
            {
                //checkedList_cursosEsp.Items.Clear();
                dataGridView_CurEsp.Rows.Clear();

                string area = comboBoxArea_esp.SelectedItem.ToString();
                if (nuevo != null)
                {
                    List<CursosEsp> lista_cursos = db.getCursoEspecial(area);
                    bool condicional;
                    bool definitivo;

                    if (lista_cursos != null)
                    {

                        foreach (CursosEsp elemento in lista_cursos)
                        {
                            condicional = db.esta_Inscripto_CursoEsp(elemento.id_curso, nuevo.id_alumno, "condicional");
                            definitivo = db.esta_Inscripto_CursoEsp(elemento.id_curso, nuevo.id_alumno, "inscripto");

                            if (condicional == true) //inscripto condicional
                            {
                                string[] row = { "false", elemento.nombre, "true", elemento.id_curso.ToString() };

                                dataGridView_CurEsp.Rows.Add(row);
                                dataGridView_CurEsp.Rows[dataGridView_CurEsp.RowCount - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                                dataGridView_CurEsp.Rows[dataGridView_CurEsp.RowCount - 1].ReadOnly = true;

                            }


                            if (definitivo == true)
                            { //inscripto
                                string[] row = { "false", elemento.nombre, "false", elemento.id_curso.ToString() };

                                dataGridView_CurEsp.Rows.Add(row);
                                dataGridView_CurEsp.Rows[dataGridView_CurEsp.RowCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                                dataGridView_CurEsp.Rows[dataGridView_CurEsp.RowCount - 1].ReadOnly = true;
                            }
                            else
                            {//no inscrito ni condicional ni incscripto
                              if (definitivo == false && condicional == false){
                                string[] row = { "false", elemento.nombre, "false", elemento.id_curso.ToString() };

                                dataGridView_CurEsp.Rows.Add(row);
                                dataGridView_CurEsp.Rows[dataGridView_CurEsp.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                dataGridView_CurEsp.Rows[dataGridView_CurEsp.RowCount - 1].ReadOnly = false;
                                }
                            }


                        }
                    }
                }
            }
        }
        

     
        /// <summary>
        /// RUTINA PARA CARGAR el checked list cursos
        /// </summary>
        void carga_Cursos()
        {
            dataGrid_cursos.Rows.Clear();

            if (tabControl1.SelectedIndex == 1)
            {
                dataGrid_cursos.Rows.Clear();

                string area = comboBoxArea.SelectedItem.ToString();
                string nivel = comboBoxNivel.SelectedItem.ToString();

                List<Curso> lista_cursos = db.getCurso(area, nivel);

                bool condicional;
                bool definitivo;

                if (nuevo != null)
                {


                    if (lista_cursos != null)
                    {
                        foreach (Curso elemento in lista_cursos)
                        {


                            condicional = db.inscriptoACurso(nuevo, elemento, "condicional");
                            definitivo = db.inscriptoACurso(nuevo, elemento, "inscripto");

                            if (condicional == true) //inscripto condicional
                            {
                                string[] row = { "false", elemento.nombre, "true", elemento.id_curso.ToString() };

                                dataGrid_cursos.Rows.Add(row);
                                dataGrid_cursos.Rows[dataGrid_cursos.RowCount - 1].DefaultCellStyle.BackColor = Color.LightYellow;
                                dataGrid_cursos.Rows[dataGrid_cursos.RowCount - 1].ReadOnly = true;

                            }


                            if (definitivo == true)
                            { //inscripto
                                string[] row = { "false", elemento.nombre, "false", elemento.id_curso.ToString() };

                                dataGrid_cursos.Rows.Add(row);
                                dataGrid_cursos.Rows[dataGrid_cursos.RowCount - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                                dataGrid_cursos.Rows[dataGrid_cursos.RowCount - 1].ReadOnly = true;
                            }
                            else
                            {//no inscrito ni condicional ni incscripto

                                if (definitivo == false && condicional == false)
                                {
                                    string[] row = { "false", elemento.nombre, "false", elemento.id_curso.ToString() };

                                    dataGrid_cursos.Rows.Add(row);
                                    dataGrid_cursos.Rows[dataGrid_cursos.RowCount - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                                    dataGrid_cursos.Rows[dataGrid_cursos.RowCount - 1].ReadOnly = false;
                                }
                            }




                        }
                    }
                }
            }
        }
        

        private void cambio_area(object sender, EventArgs e)
        {
            dataGrid_cursos.Rows.Clear();

            if (comboBoxNivel != null && comboBoxArea != null)
            {
                
                carga_Cursos();
            }
        }

        private void cambia_nivel(object sender, EventArgs e)
        {
            dataGrid_cursos.Rows.Clear();

            if (comboBoxNivel != null && comboBoxArea != null)
                carga_Cursos();
        }

        

        /// <summary>
        /// Inscribe al alumno a los cursos que selecciono
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInscribir_Click(object sender, EventArgs e)
        {
            //genero un listado de los cursos seleccionados
            List<Curso> cur_select = get_Cursos_Seleccionados();

                   
            Inscripto_curso Curso_inscripto;

            Cursos_inscriptos = new List<Inscripto_curso>();

            if (cur_select != null && cur_select.Count > 0)
            {
                if (dataGrid_cursos.Rows.Count >= 0)
                {

                    int matricula;
                    int nueva_matricula;

                    foreach (Curso curso_actual in cur_select) //itero para cada curso seleccionado 
                    {
                        if (nuevo != null && cur_select != null && cur_select.Count > 0) //si se selecciono alumno y se seleccionaron materias
                        {
                            //busco si no tiene ya matriculacion
                            matricula = db.tieneMatriculaCurso(nuevo.getId_alumno(), curso_actual.id_curso);

                            if (matricula == -1) // si no tiene matricula en el curso
                            {

                                nueva_matricula = db.generarMatriculaCurso(nuevo.getId_alumno(), curso_actual.id_curso);

                                if (nueva_matricula != -1)
                                { //si tengo nueva matricula
                                    nuevo.id_matricula = nueva_matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera
                                    Curso_inscripto = db.inscribirCursos(nuevo, curso_actual);

                                    if (Curso_inscripto != null)
                                    {

                                        Cursos_inscriptos.Add(Curso_inscripto);

                                        carga_Cursos();
                                                                             
                                    }

                                }
                                else
                                    MessageBox.Show("No se pudo obtener una matricula para el Curso", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            }
                            else  //si ya tiene matricula matricula != -1
                            {
                                nuevo.id_matricula = matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera

                                MessageBox.Show("El alumno ya esta matriculado en el Curso: " + curso_actual.nombre + "\r\n Matricula Nº: " + matricula, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }


                        }
                        else
                        {
                            if (nuevo == null)
                                MessageBox.Show("Debe seleccionar un alumno \r\n o cargar uno nuevo \r\npara poder realizar una iscripcion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                                if (cur_select == null || cur_select.Count == 0)
                                    MessageBox.Show("Debe seleccionar al menos un Curso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }//termina el foreach
                    if (Cursos_inscriptos != null && Cursos_inscriptos.Count > 0)
                    {
                        DialogResult respuesta = MessageBox.Show("Inscripcion finalizada\r\n¿Desea generara un reporte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (respuesta == DialogResult.Yes)
                        {
                            imprimir_reporteCurso();

                            

                        }
                        cur_select.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Area", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (nuevo == null)
                    MessageBox.Show("Debe seleccionar un alumno \r\n o cargar uno nuevo \r\npara poder realizar una iscripcion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    if (cur_select == null || cur_select.Count == 0)
                        MessageBox.Show("Debe seleccionar al menos un Curso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        

        /// <summary>
        /// Retorna un List de objetos Curso que fueron seleccionados para la inscripcion
        /// </summary>
        /// <returns>Lista de Cursos que selecciono</returns>
        private List<Curso> get_Cursos_Seleccionados()
        {

            List<Curso> listado = new List<Curso>();
            List<Curso> listadoCursos = db.getCurso(comboBoxArea.SelectedItem.ToString(), comboBoxNivel.SelectedItem.ToString());

            if(listadoCursos != null && listadoCursos.Count>0)           
            {
                foreach (DataGridViewRow itemChecked in dataGrid_cursos.Rows)
                {
                     
                    if (Convert.ToBoolean(itemChecked.Cells[0].Value))                   
                    {
                        
                        foreach(Curso curso_temp in listadoCursos)
                        {
                            //busco el curso hasta encontrarlo
                            if(curso_temp.id_curso == Convert.ToInt32(itemChecked.Cells[3].Value))
                            {
                                if (Convert.ToBoolean(itemChecked.Cells[2].Value))
                                    curso_temp.condicion = "condicional";
                                else
                                    curso_temp.condicion = "inscripto";

                                listado.Add(curso_temp);
                              
                            }
                        
                        }
                     }
                  }
                return listado;
                }   
            
            else return null;
        }


        /// <summary>
        /// rutina sobre el boton inscribe para Cursos Especiales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //genero un listado de las materias seleccionadas
            List<CursosEsp> cur_select = get_Cursos_Esp_Seleccionados();
            InscriptoCursoEsp Curso_inscripto;

            CursosEsp_inscriptos = new List<InscriptoCursoEsp>();

            if (cur_select != null && cur_select.Count > 0)
            {
                if (comboBoxArea_esp.SelectedIndex >= 0)
                {


                    int matricula;
                    int nueva_matricula;

                    foreach (CursosEsp curso_actual in cur_select) //itero para cada curso seleccionado 
                    {
                        if (nuevo != null && cur_select != null && cur_select.Count > 0) //si se selecciono alumno y se seleccionaron materias
                        {
                            //busco si no tiene ya matriculacion
                            matricula = db.tieneMatriculaCursoEspecial(nuevo.getId_alumno(), curso_actual.id_curso);

                            if (matricula == -1) // si no tiene matricula en el cursoEsp
                            {

                                nueva_matricula = db.generarMatriculaCursoEspecial(nuevo.getId_alumno(), curso_actual.id_curso);

                                if (nueva_matricula != -1)
                                { //si tengo nueva matricula
                                    nuevo.id_matricula = nueva_matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera
                                    Curso_inscripto = db.inscribirCursosEspeciales(nuevo, curso_actual);

                                    if (Curso_inscripto != null)
                                    {

                                        CursosEsp_inscriptos.Add(Curso_inscripto);
                                        checkedList_CurEsp();//refresco los checked list                           
                                    }

                                }
                                else
                                    MessageBox.Show("No se pudo obtener una matricula para el Curso", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            }
                            else  //si ya tiene matricula matricula != -1
                            {
                                nuevo.id_matricula = matricula; //encapsulo la nueva amtricula asignada al alumno para esta carrera

                                MessageBox.Show("El alumno ya esta matriculado en el Curso: " + curso_actual.nombre + "\r\n Matricula Nº: " + matricula, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }


                        }
                        else
                        {
                            if (nuevo == null)
                                MessageBox.Show("Debe seleccionar un alumno \r\n o cargar uno nuevo \r\npara poder realizar una iscripcion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                                if (cur_select == null || cur_select.Count == 0)
                                    MessageBox.Show("Debe seleccionar al menos un Curso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }//termina el foreach
                    if (CursosEsp_inscriptos != null && CursosEsp_inscriptos.Count > 0)
                    {
                        DialogResult respuesta = MessageBox.Show("Inscripcion finalizada\r\n¿Desea generara un reporte?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (respuesta == DialogResult.Yes)
                        {
                            imprimir_reporteCursoEspecial();

                            cur_select.Clear();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Area", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (nuevo == null)
                    MessageBox.Show("Debe seleccionar un alumno \r\n o cargar uno nuevo \r\npara poder realizar una iscripcion", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    if (cur_select == null || cur_select.Count == 0)
                        MessageBox.Show("Debe seleccionar al menos un Curso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
        /// <summary>
        /// COnfigurar pagina para reporte de Cursos de especializacion
        /// </summary>
        /// <returns></returns>
        private bool imprimir_reporteCursoEspecial()
        {
            // DataGridViewPrinter MyDataGridViewPrinter;
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            reporte_curso_especial.DocumentName = "Inscripción Curso Especialización";
            reporte_curso_especial.PrinterSettings = MyPrintDialog.PrinterSettings;
            reporte_curso_especial.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            reporte_curso_especial.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //genramos el evento imprimir que desencadena la genracion del informe
            reporte_curso_especial.Print();

            return true;
        }


         /// <summary>
         /// Rutina para la configuracion de la pagina para los reportes de inscripcion a cursos
         /// </summary>
         /// <returns></returns>
        private bool imprimir_reporteCurso()
        {
            // DataGridViewPrinter MyDataGridViewPrinter;
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            reporte_curso.DocumentName = "Inscripción a Curso";
            reporte_curso.PrinterSettings = MyPrintDialog.PrinterSettings;
            reporte_curso.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            reporte_curso.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //genramos el evento imprimir que desencadena la genracion del informe
            reporte_curso.Print();

            return true;
        }

        /// <summary>
        /// Rutina para la recuperacion de los items seleccionados en el checked list box de cursos de especializacion
        /// </summary>
        /// <returns></returns>
        private List<CursosEsp> get_Cursos_Esp_Seleccionados()
        {


            List<CursosEsp> listado = new List<CursosEsp>();
            CursosEsp curso = new CursosEsp();
            bool estado;



            //protejo de seleccion sin area
            if (comboBoxArea_esp.Items != null && comboBoxArea_esp.SelectedIndex >= 0 && comboBoxArea_esp.SelectedItem != null)
            {
                List<CursosEsp> cursosActuales = db.getCursoEspecial(comboBoxArea_esp.SelectedItem.ToString());

                if (dataGridView_CurEsp.Rows.Count > 0 && cursosActuales != null)
                {
                    foreach (DataGridViewRow itemChecked in dataGridView_CurEsp.Rows)
                    {
                        estado = Convert.ToBoolean(itemChecked.Cells[0].Value);

                        if (estado == true)
                        {

                            //recupero el curso especifico 
                            foreach(CursosEsp elemento in cursosActuales)
                            {
                                if (elemento.id_curso == Convert.ToInt32(itemChecked.Cells[3].Value))
                                {
                                    if (Convert.ToBoolean(itemChecked.Cells[2].Value))
                                    {
                                        elemento.condicion = "condicional";
                                        listado.Add(elemento);
                                    }
                                    else 
                                    {
                                        elemento.condicion = "inscripto";
                                        listado.Add(elemento);
                                    }
                                }
                            }

                        }
                    }

                    return listado; // si se selcceionaron cursos
                }
                else
                {
                    return null; // si la seleccion es vacia
                }
            }
            return null;
        }


        /// <summary>
        /// Rutina para la generacion de la pagina de reporte para cursos especiales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_reporte_curso_especial(object sender, PrintPageEventArgs e)
        {
            string cadena;
            Font printFont = new Font("Arial", 10);
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            int count = 0;
            float yPos = 10;

            //-----------------------Encabezado-----------------------
            e.Graphics.DrawString("REPORTE DE INSCRIPCION \r\nCURSO DE ESPECIALIZACIÓN", new Font("Arial Black", 15), Brushes.Black, (e.MarginBounds.Left), (yPos + 10), new StringFormat());
            count += 5;

            //----------------------Datos del Alumno------------------
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics));

            string alumno = nuevo.getApellido() + ", " + nuevo.getNombre() ;

            e.Graphics.DrawString(alumno, new Font("Arial Black", 12), Brushes.Black, leftMargin, yPos, new StringFormat());
            count += 4;

            e.Graphics.DrawLine(new Pen(Brushes.Black), leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
            count++;
            //---------------------Registro de inscripciones-----------
            foreach (InscriptoCursoEsp elemento in CursosEsp_inscriptos)
            {
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));

                cadena = "Numero de Inscripción: " + elemento.id_inscripcion_curso + "\r\nMatricula: " + db.tieneMatriculaCursoEspecial(nuevo.id_alumno,elemento.curso_inscripto.id_curso) + "\r\nNombre Curso Especializacion: " + elemento.curso_inscripto.nombre + "\r\nHoras Totales: " + elemento.curso_inscripto.horas + "\r\nCondición: " + elemento.condicion + "\r\n\r\n";

                e.Graphics.DrawString(cadena, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count += 6;

                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawLine(new Pen(Brushes.Black), leftMargin, yPos, e.MarginBounds.Right, yPos);
                count++;
            }
        }

        //metodo interno
        private void limpiar_Matricula(object sender, EventArgs e)
        {
            if (nuevo != null)
                nuevo.id_matricula = -1;

            if (tabControl1.SelectedIndex == 0)
                carga_Materias();
            if (tabControl1.SelectedIndex == 1)
                carga_Cursos();
            if (tabControl1.SelectedIndex == 2)
                checkedList_CurEsp();
        }



        /// <summary>
        /// Rutina para la generacion de pagina de reporte para cursos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_reporte_curso(object sender, PrintPageEventArgs e)
        {
            string cadena;
            Font printFont = new Font("Arial", 10);
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            int count = 0;
            float yPos = 10;

            //-----------------------Encabezado-----------------------
            e.Graphics.DrawString("REPORTE DE INSCRIPCION A CURSOS", new Font("Arial Black", 15), Brushes.Black, (e.MarginBounds.Left), (yPos + 10), new StringFormat());
            count += 5;

            //----------------------Datos del Alumno------------------
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics));

            string alumno = nuevo.getApellido() + ", " + nuevo.getNombre();

            e.Graphics.DrawString(alumno, new Font("Arial Black", 12), Brushes.Black, leftMargin, yPos, new StringFormat());
            count += 4;

            e.Graphics.DrawLine(new Pen(Brushes.Black), leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
            count++;
            //---------------------Registro de inscripciones-----------
            foreach (Inscripto_curso elemento in Cursos_inscriptos)
            {
                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));

                cadena = "Numero de Inscripción: " + elemento.id_inscripcion_curso + "\r\nMatricula: " + db.tieneMatriculaCurso(nuevo.id_alumno,elemento.curso_inscripto.id_curso) + "\r\nNombre Curso: " + elemento.curso_inscripto.nombre + "\r\nDuracion: " + elemento.curso_inscripto.duracion + " [años]\r\nCondición: " + elemento.condicion + "\r\n\r\n";

                e.Graphics.DrawString(cadena, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count += 6;

                yPos = topMargin + (count * printFont.GetHeight(e.Graphics));
                e.Graphics.DrawLine(new Pen(Brushes.Black), leftMargin, yPos, e.MarginBounds.Right, yPos);
                count++;
            }
        }


        /// <summary>
        /// Rutina para el cambio de estado de condicional a inscripto de forma forzosa "y"
        /// Para el control de cambio de turnos si hay cupo en los turnos disponibles
        /// </summary>
        /// <param name="sender">objeto llamador</param>
        /// <param name="e">parametros del evento KeyDown</param>
        private void cambiar_condicion(object sender, KeyEventArgs e)
        {
            Cambiar_Turno ventanaturno = new Cambiar_Turno();
            ventanaturno.Owner = this;

            List<string> disponibles = new List<string>();
            string turno_actual;
            int materia;

            if(e.KeyCode == Keys.F10)
            {
                if (dataGrid_Listado.CurrentRow.DefaultCellStyle.BackColor != Color.LightYellow &&
                    dataGrid_Listado.CurrentRow.DefaultCellStyle.BackColor != Color.LightGreen)
                {
                    materia= Convert.ToInt32(dataGrid_Listado.CurrentRow.Cells[3].Value);
                    turno_actual = db.obtener_turno(materia, nuevo.id_matricula);


                    if (turno_actual != "")
                    {
                        disponibles = cargarTurnosDisponibles(nuevo, materia, turno_actual);

                        int id_mat = Convert.ToInt32(dataGrid_Listado.CurrentRow.Cells[3].Value);
                        int id_turno = db.obtener_Id_turno(materia, turno_actual);

                        ventanaturno.inicializar(disponibles, nuevo, id_mat, id_turno);
                        carga_Materias();
                    }
                }
            }



            if (e.KeyCode == Keys.F9)
            {
                if (dataGrid_Listado.CurrentRow.DefaultCellStyle.BackColor == Color.LightYellow)
                {
                    if (Convert.ToBoolean(dataGrid_Listado.CurrentRow.Cells[5].Value) == true)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar la condición del alumno a \"inscripto\" ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                           if(respuesta == DialogResult.Yes)
                           {
                              
                              db.cambiarEstado(nuevo,Convert.ToInt32(dataGrid_Listado.CurrentRow.Cells[3].Value),
                                                        Convert.ToInt32(dataGrid_Listado.CurrentRow.Cells[4].Value));

                              
                              carga_Materias();
                           }
                    }
                }
            }
            
        
        }

        private List<string> cargarTurnosDisponibles(Alumno nuevo, int id_mat, string tur)
        {
            List<string> disponibles = new List<string>();

            int disp = 0;


            switch(tur)
            {
                case "mañana":
                    
                        disp = db.verificarCupoMateria(id_mat, "tarde");
                        if(disp > 0)
                            disponibles.Add("tarde");
                        disp = db.verificarCupoMateria(id_mat, "noche");
                        if(disp > 0)
                            disponibles.Add("noche");
                        break;
                case "tarde":
                    
                        disp = db.verificarCupoMateria(id_mat, "mañana");
                        if(disp > 0)
                            disponibles.Add("mañana");
                        disp = db.verificarCupoMateria(id_mat, "noche");
                        if(disp > 0)
                            disponibles.Add("noche");
                    break;
                case "noche":
                    
                        disp = db.verificarCupoMateria(id_mat, "mañana");
                        if(disp > 0)
                            disponibles.Add("mañana");
                        disp = db.verificarCupoMateria(id_mat, "tarde");
                        if(disp > 0)
                            disponibles.Add("tarde");
                    break;
                default:
                    MessageBox.Show("Error en el nombre del turno");
                    break;
            }


            return disponibles;
            

          

            
        }

        private void refrescar_checked_CurEsp(object sender, EventArgs e)
        {
            checkedList_CurEsp();
        }

        private void cambia_Condicion_Curso(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (dataGrid_cursos.CurrentRow.DefaultCellStyle.BackColor == Color.LightYellow)
                {
                    if (Convert.ToBoolean(dataGrid_cursos.CurrentRow.Cells[2].Value) == true)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar la condición del alumno a \"inscripto\" ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                        if (respuesta == DialogResult.Yes)
                        {

                            db.cambiarEstadoCurso(nuevo, Convert.ToInt32(dataGrid_cursos.CurrentRow.Cells[3].Value));


                            carga_Cursos();
                        }
                    }
                }
            }
        }

        private void cambia_Condicion_CurExp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (dataGridView_CurEsp.CurrentRow.DefaultCellStyle.BackColor == Color.LightYellow)
                {
                    if (Convert.ToBoolean(dataGridView_CurEsp.CurrentRow.Cells[2].Value) == true)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro que desea cambiar la condición del alumno a \"inscripto\" ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                        if (respuesta == DialogResult.Yes)
                        {

                            db.cambiarEstadoCursoEsp(nuevo, Convert.ToInt32(dataGridView_CurEsp.CurrentRow.Cells[3].Value));


                            checkedList_CurEsp();
                        }
                    }
                }
            }     
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            menuInicio.enable_inscripcion();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            menuInicio.enable_inscripcion();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            menuInicio.enable_inscripcion();
        }

        public void Show(Menu_inicial menu) 
        {
            menuInicio = menu;
            this.Show();
        }

        private void Inscripcion_FormClosing(object sender, FormClosingEventArgs e)
        {
            menuInicio.enable_inscripcion();
        }
        
       

        
    }
}
