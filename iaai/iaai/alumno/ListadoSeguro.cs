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

    /// <summary>
    /// Clase para generacion de Listado de Seguro
    /// </summary>
    public partial class ListadoSeguro : Form
    {

        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> listado;
        DataGridViewPrinter MyDataGridViewPrinter;

        /// <summary>
        /// Constructor de clase ListadoSeguro
        /// </summary>
        public ListadoSeguro()
        {
            InitializeComponent();
            listado = db.listadoSeguro();
            cargarTabla();
        }
        /// <summary>
        /// Método que carga el listado de alumnos para enviar al seguro.
        /// </summary>
        private void cargarTabla()
        {
            string[] row;
            int indice = 0;
            lista.Rows.Clear();

            foreach (List<string> fila in listado)
            {
                row = new string[6];
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
        /// Método que envía a impresión el listado de alumno
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
        /// Método que configura y envía para impresión el listado de alumnos.
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
        /// Método que permite ver una vista previa del listado de alumnos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Configuración del listado para la impresión
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

            MyPrintDocument.DocumentName = "Listado de Alumnos";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            if (MessageBox.Show("¿Desea que el listado quede centrado en la página?", "InvoiceManager - Center on Page", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, true, true, "Listado de Alumnos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(lista, MyPrintDocument, false, true, "Listado de Alumnos", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
    }
}
