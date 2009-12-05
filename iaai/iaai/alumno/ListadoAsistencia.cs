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

namespace iaai.alumno
{
    public partial class ListadoAsistencia : Form
    {

        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> listado;
        DataGridViewPrinter MyDataGridViewPrinter;
        List<List<string>> cursos;


        public ListadoAsistencia()
        {
            InitializeComponent();
            cargarCursos();
        }

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

        private void imprimir_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
                MyPrintDocument.Print();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void previa_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

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

            MyPrintDocument.DocumentName = "Listado de Asistencia para el curso " + curso.SelectedItem.ToString();
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("¿Desea que el listado quede centrado en la página?", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, true, true, "Listado de Asistencia para el curso " + curso.SelectedItem.ToString(), new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, false, true, "Listado de Asistencia para el curso " + curso.SelectedItem.ToString(), new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }

        private void curso_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarNiveles();
            
        }

        private void cargarCursos()
        {
            cursos = db.getCursos();

            foreach (List<string> c in cursos)
            {
                if (!curso.Items.Contains(c[1]))
                {
                    curso.Items.Add(c[1]);
                }
            }

        }

        private void cargarNiveles()
        {
            curso_nivel.Items.Clear();
            foreach (List<string> c in cursos)
            {
                if (curso.SelectedItem != null)
                {
                    if (curso.SelectedItem.ToString().Equals(c[1]))
                    {
                        curso_nivel.Items.Add(c[2]);
                    }
                }
            }
            curso_nivel.Text = null;
        }

        private void curso_nivel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            listado = db.listaAsistencia(curso.SelectedIndex);
            cargarTabla();
        }

        private void seleccionCurso_CheckedChanged(object sender, EventArgs e)
        {
            if (seleccionCurso.Checked)
            {
                curso.Enabled = true;
                curso_nivel.Enabled = true;
                cursoE.Enabled = false;
                cursoE.SelectedItem = null;
                combo_profesorados.Enabled = false;
                combo_niveles.Enabled = false;
                comboTurno.Enabled = false;
                combo_profesorados.SelectedItem = null;
                combo_niveles.SelectedItem = null;
                comboTurno.SelectedItem = null;
            }
        }

        private void seleccionCursoE_CheckedChanged(object sender, EventArgs e)
        {
            if (seleccionCursoE.Checked)
            {
                curso.Enabled = false;
                curso_nivel.Enabled = false;
                curso.SelectedItem = null;
                curso_nivel.SelectedItem = null;
                cursoE.Enabled = true;
                combo_profesorados.Enabled = false;
                combo_niveles.Enabled = false;
                comboTurno.Enabled = false;
                combo_profesorados.SelectedItem = null;
                combo_niveles.SelectedItem = null;
                comboTurno.SelectedItem = null;
            }
        }

        private void seleccionMateria_CheckedChanged(object sender, EventArgs e)
        {
            if (seleccionMateria.Checked)
            {
                curso.Enabled = false;
                curso_nivel.Enabled = false;
                curso.SelectedItem = null;
                curso_nivel.SelectedItem = null;
                cursoE.Enabled = false;
                cursoE.SelectedItem = null;
                combo_profesorados.Enabled = true;
                combo_niveles.Enabled = true;
                comboTurno.Enabled = true;
            }
        }

        private void generar_Click(object sender, EventArgs e)
        {
            if (seleccionCurso.Checked)
            {
                if (curso.SelectedItem != null && curso_nivel.SelectedItem != null)
                {
                    listado = db.getListadoCursos(obtenerIdCurso());
                    if (listado != null)
                        cargarTabla();
                    else
                        MessageBox.Show("No existen alumnos regulares para el curso seleccionado.");
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un curso y un nivel para el curso.");
                }
            }
        }

        private string obtenerIdCurso()
        {
            foreach (List<string> c in cursos)
            {
                if (c[1].Equals(curso.SelectedItem.ToString()) && c[2].Equals(curso_nivel.SelectedItem.ToString()))
                    return c[0];
            }
            return "-1";
        }

        
    }
}
