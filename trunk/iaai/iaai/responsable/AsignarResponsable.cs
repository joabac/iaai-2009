using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.alumno;

namespace iaai.responsable
{
    public partial class AsignarResponsable : Form
    {

        string consulta;
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> resultado;

        /// <summary>
        /// CONSTRUCTORES DE LA CLASE AsignarResponsable
        /// </summary>
 
        public AsignarResponsable()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// Este constructor es utilizado cuando para modificar el responsable 
        /// de un alumno menor de 21(para cambiar el resp. asignado)
        /// </summary>
        /// <param name="responsable"></param>
        public AsignarResponsable(int responsable)
        {
            string dni_responsable;
            InitializeComponent();
            dni_responsable = db.obtenerDniResponsable(responsable);
            dniBusqueda.Text = dni_responsable;
            if (valido())
            {
                armarConsulta();
                resultado = db.buscarResponsable(consulta);
                llenarTabla();
                tablaResultado.Rows[0].Cells[6].Value = true;
            }
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
           int fila = e.RowIndex;
          
           if (fila >= 0)
           {
               if (Convert.ToBoolean(tablaResultado.Rows[fila].Cells[6].Value))
               {
                   for (int x = 0; x < tablaResultado.RowCount; x++)
                   {
                       if (e.ColumnIndex == 6 && x != fila)
                       {
                           tablaResultado.Rows[x].Cells[6].Value = false;
                       }
                   }
               }
           }
            
        }

        private void llenarTabla()
        {
            string[] row;
            int indice = 0;
            tablaResultado.Rows.Clear();
            
            foreach (List<string> fila in resultado)
            {
                row = new string[6];
                string aux = "";
                foreach (string dato in fila)
                {
                    aux = aux + dato;
                    row[indice] = dato;
                    indice++;
                }
                tablaResultado.Rows.Add(row);
                indice = 0;
            }

        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            for (int fila = 0; fila < tablaResultado.RowCount; fila++)
            {
                if (Convert.ToBoolean(tablaResultado.Rows[fila].Cells[6].Value))
                {
                    try
                    {
                        ((AltaAlumno)this.Owner).asignarResponsable((int)(Convert.ToUInt32(tablaResultado.Rows[fila].Cells[0].Value)));
                    }
#pragma warning disable
                    catch (Exception exception)
                    {
#pragma warning enable
                        ((ModificarAlumno)this.Owner).asignarResponsable((int)(Convert.ToUInt32(tablaResultado.Rows[fila].Cells[0].Value)));
                    }
                    break;
                }

            }
            this.Close();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            AltaResponsable alta_resp = new AltaResponsable();
            alta_resp.Parent = this.Parent;
            alta_resp.Show();
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

        private void tablaResultado_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tablaResultado.IsCurrentCellDirty)
            {
                tablaResultado.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }





    }
}
