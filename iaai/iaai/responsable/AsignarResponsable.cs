using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iaai.responsable
{
    public partial class AsignarResponsable : Form
    {

        string consulta;
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> resultado;


        public AsignarResponsable()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (valido())
            {
                armarConsulta();
                resultado = db.buscarResponsable(consulta);
                llenarTabla();
            }
        }
        //método que controla que no se seleccione más de un responsable para un alumno dado.
        //está pendiente de terminarse ya que nos funcionaba mal.
        private void grid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*   int fila = e.RowIndex;
           
           if (Convert.ToBoolean(tablaResultado.Rows[fila].Cells[5].Value))
            {
                for (int x = 0; x < tablaResultado.RowCount; x++)
                {
                    if (e.ColumnIndex == 5 && x != fila)
                    {
                        tablaResultado.Rows[x].Cells[5].Value = false;
                    }
                }
            }*/
            
        }

        private void llenarTabla()
        {
            string[] row;
            int indice = 0;
            tablaResultado.Rows.Clear();
            
            foreach (List<string> fila in resultado)
            {
                row = new string[5];
                foreach (string dato in fila)
                {
                    row[indice] = dato;
                    indice++;
                }
                tablaResultado.Rows.Add(row);
                indice = 0;
            }

        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tablaResultado.Rows[0].Cells[5].Value.ToString());
        }

        private void cancelar_Click(object sender, EventArgs e)
        {

        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            
        }

        private bool valido()
        {
            if (nombreBusqueda.Text.Length == 0 && apellidoBusqueda.Text.Length == 0 && dniBusqueda.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un parametro de búsqueda.");
                return false;
            }
            return true;
        }

        private void armarConsulta()
        {
            consulta = "";
            if (nombreBusqueda.Text.Length > 0)
                consulta = "nombre_respon LIKE '" + nombreBusqueda.Text + "%'";
            if (apellidoBusqueda.Text.Length > 0)
            {
                if (consulta.Length > 0)
                    consulta = consulta + " AND apellido_respon LIKE '" + apellidoBusqueda.Text + "%'";
                else
                    consulta = "apellido_respon LIKE '" + apellidoBusqueda.Text + "%'";
            }
            if (dniBusqueda.Text.Length > 0)
            {
                if (consulta.Length > 0)
                    consulta = consulta + " AND dni = '" + dniBusqueda.Text + "%'";
                else
                    consulta = "dni = '" + dniBusqueda.Text + "%'";
            }
        }

        private void tablaResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {

         /*   int fila = e.RowIndex;
           
           if (Convert.ToBoolean(tablaResultado.Rows[fila].Cells[5].Value))
            {
                for (int x = 0; x < tablaResultado.RowCount; x++)
                {
                    if (e.ColumnIndex == 5 && x != fila)
                    {
                        tablaResultado.Rows[x].Cells[5].Value = false;
                    }
                }
            }*/
        }





    }
}
