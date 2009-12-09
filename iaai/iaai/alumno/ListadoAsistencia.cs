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
    public partial class ListadoAsistencia : Form
    {

        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> listado;
        DataGridViewPrinter MyDataGridViewPrinter;
        List<List<string>> cursos = null;
        List<List<string>> cursosEsp = null;
        List<List<string>> materias = null;

        /// <summary>
        /// Constructor de ListadoAsistencia Form
        /// </summary>
        public ListadoAsistencia()
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
                row = new string[3];
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
                if (SetupThePrinting())
                    MyPrintDocument.Print();
            }
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

        private void previa_Click(object sender, EventArgs e)
        {
            if (lista.RowCount > 0)
            {
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
                MyPrintDocument.DocumentName = "Listado de Asistencia para el curso: " + curso.SelectedItem.ToString() + " Area: " + comboBoxArea.SelectedItem.ToString() + " Nivel: " + curso_nivel.SelectedItem.ToString();
            }
            else if (seleccionCursoE.Checked)
            {
                MyPrintDocument.DocumentName = "Listado de Asistencia para el curso especial: " + cursoE.SelectedItem.ToString() + " del Area: " + comboBoxArea_esp.SelectedItem.ToString();
            }
            else if (seleccionMateria.Checked)
            {
                MyPrintDocument.DocumentName = "Listado de Asistencia para la materia: " + comboMaterias.SelectedItem.ToString() + " Carrera: " + combo_profesorados.SelectedItem.ToString() + " Nivel: " + combo_niveles.SelectedItem.ToString() + " Turno: " + comboTurno.SelectedItem.ToString();
            }

            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("¿Desea que el listado quede centrado en la página?", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, true, true, "Listado de Asistencia para el curso " + curso.SelectedItem.ToString(), new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, false, true, "Listado de Asistencia para el curso " + curso.SelectedItem.ToString(), new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

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
            if (materias == null)
            {
                materias = db.getMaterias();
            }
            foreach (List<string> m in materias)
            {
                if (!combo_profesorados.Items.Contains(m[0]))
                {
                    combo_profesorados.Items.Add(m[0]);
                }
            }
            combo_niveles.Text = null;
            comboTurno.Text = null;
        }
        /// <summary>
        /// Método que obtiene las Materias de la base de datos y las carga a los comboBox correspondientes
        /// </summary>
        private void cargarMaterias()
        {
            comboMaterias.Items.Clear();

            foreach (List<string> m in materias)
            {
                if (combo_profesorados.SelectedItem != null && combo_niveles.SelectedItem != null && comboTurno.SelectedItem != null)
                {
                    if (combo_profesorados.SelectedItem.ToString().Equals(m[0]) && combo_niveles.SelectedItem.ToString().Equals(m[4]))
                    {
                        comboMaterias.Items.Add(m[3]);
                    }
                }
            }
            comboMaterias.Text = null;

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
            listado = null;
            if (seleccionCurso.Checked)
            {
                if (comboBoxArea.SelectedItem != null && curso.SelectedItem != null && curso_nivel.SelectedItem != null)
                {
                    listado = db.getListadoCursos(obtenerIdCurso());
                    if (listado != null)
                        cargarTabla();
                    else
                    {
                        lista.Rows.Clear();
                        MessageBox.Show("No existen alumnos regulares para el curso seleccionado.");
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
                    listado = db.getListadoCursosEspeciales(obtenerIdCursoEsp());
                    if (listado != null)
                        cargarTabla();
                    else
                    {
                        lista.Rows.Clear();
                        MessageBox.Show("No existen alumnos regulares para el curso seleccionado.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un área y un curso especial para obtener el listado.");
                }
            }
            else if (seleccionMateria.Checked)
            {
                if (combo_profesorados.SelectedItem != null && combo_niveles.SelectedItem != null && comboTurno.SelectedItem != null && comboMaterias.SelectedItem != null)
                {
                    listado = db.getListadoMateria(obtenerIdMateria(), comboTurno.SelectedItem.ToString());
                    if (listado != null)
                        cargarTabla();
                    else
                    {
                        lista.Rows.Clear();
                        MessageBox.Show("No existen alumnos regulares para la materia seleccionada.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un profesorado, un nivel, un turno \ny una materia para obtener el listado.");
                }
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
        private string obtenerIdMateria()
        {
            foreach (List<string> m in materias)
            {
                if (m[0].Equals(combo_profesorados.SelectedItem.ToString()) && m[4].Equals(combo_niveles.SelectedItem.ToString()) && m[3].Equals(comboMaterias.SelectedItem.ToString()))
                    return m[2];
            }
            return "-1";
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
            if (combo_profesorados.SelectedItem != null)
            {
                foreach (List<string> m in materias)
                {
                    if (m[0].Equals(combo_profesorados.SelectedItem.ToString()))
                    {
                        for (int i = 1; i <= Convert.ToInt32(m[1]); i++)
                        {
                            combo_niveles.Items.Add(i);
                        }
                        break;
                    }
                }
                

                combo_niveles.SelectedItem = null;
                comboTurno.SelectedItem = null;
                comboMaterias.SelectedItem = null;
            }
        }
        /// <summary>
        /// Método que carga el comboBox Materia según la opción seleccionada el en comboBox Turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboTurno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarMaterias();
        }
        /// <summary>
        /// Método que carga el comboBox Niveles según la opción seleccionada el en comboBox en Profesorado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_niveles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboTurno.SelectedItem = null;
            comboMaterias.Items.Clear();
            comboMaterias.Text = null;
        }

        
    }
}
