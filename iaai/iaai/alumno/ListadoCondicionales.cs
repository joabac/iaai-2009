using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;
using System.Drawing.Printing;
using iaai.cursos_materias;

namespace iaai.alumno
{
    /// <summary>
    /// Clase ListadoAsistencia
    /// </summary>
    public partial class ListadoCondicionales : Form
    {

        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> listado;
        DataGridViewPrinter MyDataGridViewPrinter;
        List<List<string>> cursos = null;
        List<List<string>> cursosEsp = null;
        List<Materia> materias = null;
        List<Profesorado> profesorados = null;

        /// <summary>
        /// Constructor de ListadoAsistencia Form
        /// </summary>
        public ListadoCondicionales()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Método que carga la tabla según los alumnos dentro de listado
        /// </summary>
        private void cargarTabla()
        {
            string[] row;
            int indice = 0;
            lista.Rows.Clear();

            foreach (List<string> fila in listado)
            {
                row = new string[4];
                row[0] = "false";
                indice++;
                foreach (string dato in fila)
                {
                    row[indice] = dato;
                    indice++;
                }
                lista.Rows.Add(row);
                indice = 0;
            }
        }
        /// <summary>
        /// Botón imprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imprimir_Click(object sender, EventArgs e)
        {
            if (lista.RowCount > 0)
            {
                lista.Columns[3].Visible = true;
                lista.Columns[0].Visible = false;
                if (SetupThePrinting())
                {
                    MyPrintDocument.Print();
                }
            }
            lista.Columns[3].Visible = false;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Método que envía el listado para impresión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }
        /// <summary>
        /// Método que muestra una vista previa del listado de alumnos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previa_Click(object sender, EventArgs e)
        {
            if (lista.RowCount > 0)
            {
                lista.Columns[0].Visible = false;
                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    MyPrintPreviewDialog.Document = MyPrintDocument;
                    MyPrintPreviewDialog.ShowDialog();
                }
            }
            
        }
        /// <summary>
        /// Método que genera el listado y lo configura para la impresión
        /// </summary>
        /// <returns></returns>
        private bool SetupThePrinting()
        {
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

            if (seleccionCurso.Checked)
            {
                MyPrintDocument.DocumentName = "Listado de Condicionales para el curso: " + curso.SelectedItem.ToString() + " Area: " + comboBoxArea.SelectedItem.ToString() + " Nivel: " + curso_nivel.SelectedItem.ToString();
            }
            else if (seleccionCursoE.Checked)
            {
                MyPrintDocument.DocumentName = "Listado de Condicionales para el curso especial: " + cursoE.SelectedItem.ToString() + " Area: " + comboBoxArea_esp.SelectedItem.ToString();
            }
            else if (seleccionMateria.Checked)
            {
                MyPrintDocument.DocumentName = "Listado de Condicionales para la materia: " + comboMaterias.SelectedItem.ToString() + " Carrera: " + combo_profesorados.SelectedItem.ToString() + " Nivel: " + combo_niveles.SelectedItem.ToString() + " Turno: " + comboTurno.SelectedItem.ToString();
            }

            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            
                if (seleccionCurso.Checked)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, true, true, "Listado de Condicionlaes para el curso:\n " + curso.SelectedItem.ToString() + " \nArea: " + comboBoxArea.SelectedItem.ToString() + " \nNivel: " + curso_nivel.SelectedItem.ToString(), new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
                }
                else if (seleccionCursoE.Checked)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, true, true, "Listado de Condicionlaes para el curso especial:\n " + cursoE.SelectedItem.ToString() + " \nArea: " + comboBoxArea_esp.SelectedItem.ToString(), new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
                }
                else if (seleccionMateria.Checked)
                {
                    MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, true, true, "Listado de Condicionlaes para la materia:\n " + comboMaterias.SelectedItem.ToString() + " \nCarrera: " + combo_profesorados.SelectedItem.ToString() + " \nNivel: " + combo_niveles.SelectedItem.ToString() + " \nTurno: " + comboTurno.SelectedItem.ToString(), new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
                }
           
    

            return true;
        }

        /// <summary>
        /// Método que obtiene las Áreas de la base de datos y las carga a los comboBox correspondientes
        /// </summary>
        private void cargarAreas()
        {
            curso.Items.Clear();
            curso_nivel.Items.Clear();
            if (cursos == null)
            {
                cursos = db.getCursos();
            }
            foreach (List<string> c in cursos)
            {
                if (!comboBoxArea.Items.Contains(c[3]))
                {
                    comboBoxArea.Items.Add(c[3]);
                }
            }
            curso_nivel.Text = null;
            curso.Text = null;
        }
        /// <summary>
        /// Método que obtiene los Cursos de la base de datos y los carga a los comboBox correspondientes
        /// </summary>
        private void cargarCursos()
        {
            curso.Items.Clear();
            foreach (List<string> c in cursos)
            {
                if (comboBoxArea.SelectedItem != null && curso_nivel.SelectedItem != null)
                {
                    if (comboBoxArea.SelectedItem.ToString().Equals(c[3]) && curso_nivel.SelectedItem.ToString().Equals(c[2]))
                    {
                        curso.Items.Add(c[1]);
                    }
                }
            }
            curso.Text = null;

        }
        /// <summary>
        /// Método que obtiene los Niveles de la base de datos y los carga a los comboBox correspondientes
        /// </summary>
        private void cargarNiveles()
        {
            curso.Items.Clear();
            curso_nivel.Items.Clear();
            foreach (List<string> c in cursos)
            {
                if (comboBoxArea.SelectedItem != null)
                {
                    if (comboBoxArea.SelectedItem.ToString().Equals(c[3]))
                    {
                        if (!curso_nivel.Items.Contains(c[2]))
                        {
                            curso_nivel.Items.Add(c[2]);
                        }
                    }
                }
            }
            curso_nivel.Text = null;
            curso.Text = null;
        }
        /// <summary>
        /// Método que obtiene las Áreas Especiales de la base de datos y las carga a los comboBox correspondientes
        /// </summary>
        private void cargarAreasEsp()
        {
            
            comboBoxArea_esp.Items.Clear();
            if (cursosEsp == null)
            {
                cursosEsp = db.getCursosEsp();
            }
            foreach (List<string> c in cursosEsp)
            {
                if (!comboBoxArea_esp.Items.Contains(c[2]))
                {
                    comboBoxArea_esp.Items.Add(c[2]);
                }
            }
            comboBoxArea_esp.Text = null;
        }
        /// <summary>
        /// Método que obtiene los Cursos especiales de la base de datos y los carga a los comboBox correspondientes
        /// </summary>
        private void cargarCursosEsp()
        {
            cursoE.Items.Clear();
            foreach (List<string> c in cursosEsp)
            {
                if (comboBoxArea_esp.SelectedItem != null)
                {
                    if (comboBoxArea_esp.SelectedItem.ToString().Equals(c[2]))
                    {
                        cursoE.Items.Add(c[1]);
                    }
                }
            }
            cursoE.Text = null;
        }
        /// <summary>
        /// Método que obtiene los Profesorados de la base de datos y los carga a los comboBox correspondientes
        /// </summary>
        private void cargarProfesorados()
        {
            combo_niveles.Items.Clear();

            profesorados = db.getCarreras();
            if (profesorados != null)
            {
                foreach (Profesorado prof in profesorados)
                {

                    combo_profesorados.Items.Add(prof.nombre);

                }


                combo_profesorados.SelectedIndex = 0;
            }

        }
        /// <summary>
        /// Método que obtiene las Materias de la base de datos y las carga a los comboBox correspondientes
        /// </summary>
        private void cargarMaterias()
        {
            comboMaterias.Items.Clear();
            if (materias != null)
            {
                if (materias.Count > 0)
                    materias.Clear();
            }

                if (combo_profesorados.Text != "" && combo_niveles.Text != "" && comboTurno.Text != "" )
                {
                    materias = db.getMaterias(combo_profesorados.Text, combo_niveles.Text, comboTurno.Text);
                    if (materias != null && materias.Count > 0)
                    {
                        foreach (Materia mat_actual in materias)
                        {

                            comboMaterias.Items.Add(mat_actual.nombre);

                        }
                        comboMaterias.SelectedIndex = 0;
                    }

                    else
                    {
                        comboMaterias.Text = "Sin materias";
                        
                    }
                    
                }
            
            

        }

        private void curso_nivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarCursos();
        }
        /// <summary>
        /// Método que controla el evento que se activa al seleccionar el checkBox Curso,
        /// se encarga de habilitar y deshabilitar los comboBoxs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seleccionCurso_CheckedChanged(object sender, EventArgs e)
        {
            if (seleccionCurso.Checked)
            {
                cargarAreas();
                curso.Enabled = true;
                curso_nivel.Enabled = true;
                comboBoxArea.Enabled = true;
                cursoE.Enabled = false;
                comboBoxArea_esp.Enabled = false;
                cursoE.SelectedItem = null;
                comboBoxArea_esp.SelectedItem = null;
                combo_profesorados.Enabled = false;
                combo_niveles.Enabled = false;
                comboTurno.Enabled = false;
                comboMaterias.Enabled = false;
                combo_profesorados.SelectedItem = null;
                combo_niveles.SelectedItem = null;
                comboTurno.SelectedItem = null;
                comboMaterias.SelectedItem = null;
            }
        }
        /// <summary>
        /// Método que controla el evento que se activa al seleccionar el checkBox Curso especiales,
        /// se encarga de habilitar y deshabilitar los comboBoxs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seleccionCursoE_CheckedChanged(object sender, EventArgs e)
        {
            if (seleccionCursoE.Checked)
            {
                cargarAreasEsp();
                curso.Enabled = false;
                curso_nivel.Enabled = false;
                comboBoxArea.Enabled = false;
                curso.SelectedItem = null;
                curso_nivel.SelectedItem = null;
                comboBoxArea.SelectedItem = null;
                cursoE.Enabled = true;
                comboBoxArea_esp.Enabled = true;
                combo_profesorados.Enabled = false;
                combo_niveles.Enabled = false;
                comboTurno.Enabled = false;
                comboMaterias.Enabled = false;
                combo_profesorados.SelectedItem = null;
                combo_niveles.SelectedItem = null;
                comboTurno.SelectedItem = null;
                comboMaterias.SelectedItem = null;
            }
        }
        /// <summary>
        /// Método que controla el evento que se activa al seleccionar el checkBox Materia,
        /// se encarga de habilitar y deshabilitar los comboBoxs correspondientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seleccionMateria_CheckedChanged(object sender, EventArgs e)
        {
            if (seleccionMateria.Checked)
            {
                cargarProfesorados();
                curso.Enabled = false;
                curso_nivel.Enabled = false;
                comboBoxArea.Enabled = false;
                curso.SelectedItem = null;
                curso_nivel.SelectedItem = null;
                comboBoxArea.SelectedItem = null;
                cursoE.Enabled = false;
                comboBoxArea_esp.Enabled = false;
                cursoE.SelectedItem = null;
                comboBoxArea_esp.SelectedItem = null;
                combo_profesorados.Enabled = true;
                combo_niveles.Enabled = true;
                comboTurno.Enabled = true;
                comboMaterias.Enabled = true;
            }
        }
        /// <summary>
        /// Método que genera el listado de alumnos según el curso, curso especial o profesorado seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generar_Click(object sender, EventArgs e)
        {
            if (comboMaterias.Text != "Sin materias")
            {
                listado = null;
                if (seleccionCurso.Checked)
                {
                    if (comboBoxArea.SelectedItem != null && curso.SelectedItem != null && curso_nivel.SelectedItem != null)
                    {
                        listado = db.getListadoCondicionalesCursos(obtenerIdCurso());
                        if (listado != null)
                            cargarTabla();
                        else
                        {
                            lista.Rows.Clear();
                            MessageBox.Show("No existen alumnos inscriptos para el curso seleccionado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un área, un nivel y un curso para obtener el listado.");
                    }
                }
                else if (seleccionCursoE.Checked)
                {
                    if (comboBoxArea_esp.SelectedItem != null && cursoE.SelectedItem != null)
                    {
                        listado = db.getListadoCondicionalesCursosEspeciales(obtenerIdCursoEsp());
                        if (listado != null)
                            cargarTabla();
                        else
                        {
                            lista.Rows.Clear();
                            MessageBox.Show("No existen alumnos inscriptos para el curso seleccionado.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un área y un curso especial para obtener el listado.");
                    }
                }
                else if (seleccionMateria.Checked)
                {
                    if (combo_profesorados.SelectedItem.ToString() != "" && combo_niveles.SelectedItem.ToString() != "" && comboTurno.SelectedItem.ToString() != "" && comboMaterias.SelectedItem.ToString() != "")
                    {
                        listado = db.getListadoCondicionalesMateria(obtenerIdMateria().ToString(), comboTurno.SelectedItem.ToString());
                        if (listado != null)
                            cargarTabla();
                        else
                        {
                            lista.Rows.Clear();
                            MessageBox.Show("No existen alumnos inscriptos para la materia seleccionada.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un profesorado, un nivel, un turno \ny una materia para obtener el listado.");
                    }
                }
            }
            else {

                MessageBox.Show("Debe seleccionar una materia");
            }
        }
        /// <summary>
        /// Obtiene el id del Curso seleccionado en los comboBoxs
        /// </summary>
        /// <returns></returns>
        private string obtenerIdCurso()
        {
            foreach (List<string> c in cursos)
            {
                if (c[1].Equals(curso.SelectedItem.ToString()) && c[2].Equals(curso_nivel.SelectedItem.ToString()))
                    return c[0];
            }
            return "-1";
        }
        /// <summary>
        /// Obtiene el id del Curso Especial seleccionado en los comboBoxs
        /// </summary>
        /// <returns></returns>
        private string obtenerIdCursoEsp()
        {
            foreach (List<string> c in cursosEsp)
            {
                if (c[1].Equals(cursoE.SelectedItem.ToString()) && c[2].Equals(comboBoxArea_esp.SelectedItem.ToString()))
                    return c[0];
            }
            return "-1";
        }
        /// <summary>
        /// Obtiene el id de la Materia seleccionado en los comboBoxs de  Profesorado
        /// </summary>
        /// <returns></returns>
        private int obtenerIdMateria()
        {

            int id_materia = -1;
            if (comboMaterias != null && comboMaterias.Items.Count > 0) 
            {

                id_materia = materias[comboMaterias.SelectedIndex].id_materia;
            }

            return id_materia;
        }
        /// <summary>
        /// Método que carga el comboBox Niveles según la opción seleccionada el en comboBox Area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarNiveles();
        }
        /// <summary>
        /// Método que carga el comboBox CursosEsp según la opción seleccionada el en comboBox AreaEsp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxArea_esp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarCursosEsp();
        }
        /// <summary>
        /// Método que carga el comboBox Niveles y Materias según la opción seleccionada el en comboBox Profesorado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_profesorados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            combo_niveles.Items.Clear();
            comboMaterias.Items.Clear();

            if (materias != null) 
            {
                if (materias.Count > 0)
                    materias.Clear();
            }
            if (combo_profesorados.SelectedItem != null)
            {
                
                for (int i = 1; i <= profesorados[combo_profesorados.SelectedIndex].niveles; i++)
                {
                            combo_niveles.Items.Add(i);
                }
                combo_niveles.SelectedIndex = 0;
                       
            }

               
       }
    

        /// <summary>
        /// Método que carga el comboBox Materia según la opción seleccionada el en comboBox Turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboTurno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (materias != null)
            {
                if (materias.Count > 0)
                    materias.Clear();
            }
            cargarMaterias();

        }
        /// <summary>
        /// Método que carga el comboBox Niveles según la opción seleccionada el en comboBox en Profesorado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_niveles_SelectionChangeCommitted(object sender, EventArgs e)
        {
                    
            if (materias != null)
            {
                if (materias.Count > 0)
                    materias.Clear();
            }
            comboTurno.SelectedIndex = 0;
            comboMaterias.Items.Clear();
            cargarMaterias();
        }

        private void inscribe_Click(object sender, EventArgs e)
        {

            if (lista.Rows.Count > 0)
            {
                List<string> resultado = new List<string>();
                resultado = Inscribir(); ;

                if (resultado[0].Contains("Los alumnos se inscribieron correctamente"))
                {
                    MessageBox.Show(resultado.ToArray().ToString());
                }
                else
                {
                    string mensaje = "";

                    foreach (string subMensaje in resultado)
                    {
                        mensaje += subMensaje + "\r\n";

                    }
                    MessageBox.Show("Se produjeron errores: \r\n" + mensaje);
                }
            }
            else
                MessageBox.Show("Listado vacio","Atención",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        /// <summary>
        /// Inscribe los alumnos seleccionados
        /// </summary>
        /// <returns>List de sucesos</returns>
        public List<string> Inscribir() 
        {

            List<string> resultado = new List<string>();

            List<Alumno> alumnos = new List<Alumno>();
            Alumno alumn_tmp = new Alumno();
            //recupero los alumnos seleccionados
            foreach (DataGridViewRow fila in lista.Rows) 
            {

                if (Convert.ToBoolean(fila.Cells[0].Value.ToString()) == true) 
                {
                    alumn_tmp.setNombre(fila.Cells[1].Value.ToString());
                    alumn_tmp.setApellido(fila.Cells[2].Value.ToString());
                    alumn_tmp.setDni(fila.Cells[3].Value.ToString());
                    alumnos.Add(alumn_tmp);

                    alumn_tmp = new Alumno();
                }
            
            }
            if (alumnos.Count > 0)
            {
                if (alumnos.Count > 10)
                {

                    resultado.Add("Se debe crear un nuevo curso.");
                }
                else
                {
                    //rutina de inscripcion
                    
                    if(seleccionMateria.Checked == true){
                        Alumno alumnoCompleto;
                        int id_Turno = materias[comboMaterias.SelectedIndex].get_id_turno(comboTurno.Text);

                        foreach (Alumno alumno_actual in alumnos) 
                        {
                            alumnoCompleto = db.Buscar_Alumno(alumno_actual.getDni());
                            db.cambiarEstado(alumnoCompleto, materias[comboMaterias.SelectedIndex].id_materia,id_Turno );
                    
                        }
                    }
                    if (seleccionCurso.Checked == true) 
                    { 
                        
                    
                    }
                    if (seleccionCursoE.Checked == true) 
                    { 
                    
                    }
                }
            }
            else
            {
                resultado.Add("Debe seleccionar al menos un alumno");
            }
            
            return resultado;
        
        }
        
    }
}
