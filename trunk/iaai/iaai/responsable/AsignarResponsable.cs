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
{   ///Clase AsignarResponsable
    public partial class AsignarResponsable : Form
    {

        string consulta;
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<List<string>> resultado;
        List<int> altas = new List<int>();//lista donde se guardan temporalmente los responsables dados de alta


        /// <summary>
        /// Nuevo metodo Show para retornar elementos desde alta
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void Show(int i)
        {
            Owner.Enabled = false;
            this.ShowDialog();
        }

        /// <summary>
        /// Método que recibe de la clase AltaResponsable el id_responsable recientemente cargado en base de datos
        /// se utiliza para eliminar los responsables sin asignación a ningun alumno.
        /// </summary>
        /// <param name="a"></param>
        public void guardaAltasResponsable(int a)
        {
            altas.Add(a);
        }


        /// <summary>
        /// CONSTRUCTORES DE LA CLASE AsignarResponsable
        /// </summary>
 
        public AsignarResponsable()
        {
            InitializeComponent();
        }

       

        
        /// <summary>
        /// Constructor utilizado para cambiar el responsable 
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
                        ((AltaAlumno)this.Owner).agregarAltaResp(altas);//pasa al formulario AltaAlumno la lista de los responsables cargados en base de datos sin asignar a un alumno
                        
                    }
#pragma warning disable
                    catch (Exception exception)
                    {
#pragma warning enable
                        ((ModificarAlumno)this.Owner).asignarResponsable((int)(Convert.ToUInt32(tablaResultado.Rows[fila].Cells[0].Value)));
                        ((ModificarAlumno)this.Owner).agregarAltaResp(altas);//pasa al formulario AltaAlumno la lista de los responsables cargados en base de datos sin asignar a un alumno
                        
                    }
                    break;
                }

            }
            this.Close();
            if (Owner != null)
                Owner.Enabled = true;
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            //se elimina los responsables que hayan sido cargados al sistema como motivo de la carga cancelada de un alumno
            db.deshacerResponsableLista(altas);//elimina los responsables ingresados y no asignados
            //a ningún alumno cargado.
            if (altas.Count > 0)
                MessageBox.Show("Se eliminó el o los responsables dado de alta para el alta alumno cancelado.");

            if (Owner != null)
                Owner.Enabled = true;
        }

        private void nuevo_Click(object sender, EventArgs e)
        {
            AltaResponsable alta_resp = new AltaResponsable();
            //alta_resp.Parent = this.Parent;
            alta_resp.Owner = this;
            alta_resp.Show(1);
        }
        /// <summary>
        /// Método que valida los datos a ingresar para la búsqueda
        /// </summary>
        /// <returns></returns>
        private bool valido()
        {
            if (nombreBusqueda.Text.Length == 0 && apellidoBusqueda.Text.Length == 0 && dniBusqueda.Text.Length == 0)
            {
                MessageBox.Show("Debe ingresar un parametro de búsqueda.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método que se encarga de armar la consulta que se enviará a base de datos para la carga de
        /// los datos de los responsables buscados.
        /// </summary>
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
            consulta = " AND activo = '1'";
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

        /// <summary>
        /// Método que ejecuta el proceso de búsqueda de los datos del responsable.
        /// </summary>
        /// <param name="resp"></param>
        public void seleccionaNuevoResponsable(int resp)
        {
            string dni_responsable;
            dni_responsable = db.obtenerDniResponsable(resp);
            dniBusqueda.Text = dni_responsable;
            if (valido())
            {
                armarConsulta();
                resultado = db.buscarResponsable(consulta);
                llenarTabla();
                tablaResultado.Rows[0].Cells[6].Value = true;
            }
        }

        private void todos_Click(object sender, EventArgs e)
        {
            consulta = "activo = 1";
            resultado = db.buscarResponsable(consulta);
            llenarTabla();
        }

        



    }
}
