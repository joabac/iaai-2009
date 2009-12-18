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


namespace iaai.alumno
{   ///Clase ReactivarAlumnoI
    public partial class ReactivarAlumno : Form
    {

        string consulta;
        List<Alumno> listaAlumno = new List<Alumno>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        List<int> altas = new List<int>();//lista donde se guardan temporalmente los responsables dados de alta
        Utiles util = new Utiles();


        

        /// <summary>
        /// Método que recibe de la clase AltaResponsable el id_responsable recientemente cargado en base de datos
        /// se utiliza para eliminar los responsables sin asignación a ningun alumno.
        /// </summary>
        /// <param name="a"></param>
        public void guardaAltasReactivarAlumno(int a)
        {
            altas.Add(a);
        }


        /// <summary>
        /// CONSTRUCTORES DE LA CLASE ReactivarAlumno
        /// </summary>
 

        public ReactivarAlumno()
        {
            InitializeComponent();
        }

       

        
       

        private void buscar_Click(object sender, EventArgs e)
        {
            if (valido())
            {
                armarConsulta();
                listaAlumno = db.buscarAlumnoInactivo(consulta);
                llenarTabla();
            }
        }

        private void todos_Click(object sender, EventArgs e)
        {
            listaAlumno = db.buscarAlumnoInactivo("activo = '0'");
            llenarTabla();
        }


        //método que controla que no se seleccione más de un alumno para dar de alta, dado a que se debe
        //controlar si es menor y si aún existe en base de datos el responsable asignado a éste.
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
            
            row = new string[6];
            foreach(Alumno a in listaAlumno)
            {
                
                row = new string[6];
                row[1] = a.getApellido().ToString();
                row[2] = a.getNombre().ToString();
                row[3] = a.getDni().ToString();
                row[4] = a.getTelefono_carac().ToString() + "-" + a.getTelefono_numero().ToString();
                row[5] = a.getDireccion().ToString();
                
                tablaResultado.Rows.Add(row);   
            }
                
            

        }

        
        /// <summary>
        /// Método que indica si el alumno a reactivar es menor de edad
        /// </summary>
        /// <param name="dni_alumno">string: contiene el dni del alumno seleccionado en el grid</param>
        /// <returns>
        /// true: si es menor de 21 años
        /// false: si es mayor de edad</returns>
        private List<string> esMenor(string dni_alumno)
        {
            List<string> devuelve = new List<string>();
            string fecha = "";
            int id_resp = -1;
            
            foreach(Alumno alu in listaAlumno)
            {
                if (alu.getDni().Equals(dni_alumno))
                {
                    fecha = Convert.ToDateTime(alu.getFecha_nac()).ToString("dd/MM/yyyy");
                    id_resp = alu.getId_responsable();
                }
            }
            
            //si es menor
            
            if (Convert.ToInt32(util.validar_Fecha_Nacimiento(fecha)) == 0)
            {
                devuelve.Add("true");
                devuelve.Add(id_resp.ToString());
            }
            else
                devuelve.Add("false");
            

            return devuelve;

        }

        private void sacarAlumnoActivadoRecientemente(string dni_alumno_activado)
        {
            
            for (int count = 0; count < listaAlumno.Count; count++)
            {
                if (listaAlumno[count].getDni().ToString().Equals(dni_alumno_activado))
                {
                    listaAlumno.RemoveAt(count);
                    break;
                }
            }
            
        }


        private List<string> restaura()
        {
         
            List<string> accion = new List<string>();
            for (int fila = 0; fila < tablaResultado.RowCount; fila++)
            {   //si hay alguno seleccionado.
                try{
                if (Convert.ToBoolean(tablaResultado.Rows[fila].Cells[6].Value.ToString().Equals("True")))
                {
                    db.activarAlumnoEliminado(tablaResultado.Rows[fila].Cells[3].Value.ToString());
                    List<string> aux = this.esMenor(tablaResultado.Rows[fila].Cells[3].Value.ToString());
                    
                    //si es menor
                    if (aux[0].ToString().Equals("true"))
                    {
                        
                        //si existe el responsable que tenía asignado pero está dado de baja.
                        if (db.responsableEsInactivo(aux[1].ToString()))
                        {
                            db.reactivarResponsable(aux[1].ToString());
                            accion.Add("El alumno fue activado en Base de Datos");
                            accion.Add("El Responsable a cargo del alumno fue reactivado también.\n Si desea asignar otro responsable deberá hacerlo\n mediante la función Modificar Alumno del menú Alumnos.");
                            this.sacarAlumnoActivadoRecientemente(tablaResultado.Rows[fila].Cells[3].Value.ToString());
                            llenarTabla();
                            break;
                            return accion;

                        }
                        else
                        {
                            accion.Add("El alumno fue activado en Base de Datos");
                            this.sacarAlumnoActivadoRecientemente(tablaResultado.Rows[fila].Cells[3].Value.ToString());
                            llenarTabla();
                            break;
                            return accion;
                        }
                    }
                    accion.Add("El alumno fue activado en Base de Datos");
                    this.sacarAlumnoActivadoRecientemente(tablaResultado.Rows[fila].Cells[3].Value.ToString());
                    llenarTabla();
                    break;
                    return accion;
                }

                }
                catch (Exception exception)
                {
                    accion.Add("Debe seleccionar un alumno de la lista");
                    return accion;
                }

            }
            
            accion.Add("Debe seleccionar un alumno de la lista");
            return accion;
            
            
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

        private void aceptar_Click(object sender, EventArgs e)
        {
            List<string> resultado = restaura();
            if (resultado[0].Equals("El alumno fue activado en Base de Datos"))
            {
                if (resultado[1].Equals("El Responsable a cargo del alumno fue reactivado también.\n Si desea asignar otro responsable deberá hacerlo\n mediante la función Modificar Alumno del menú Alumnos."))
                {
                    //si el responsable a cargo estaba inactivo
                    string cadena = resultado[0].ToString() + "\n " + resultado[1].ToString();
                    MessageBox.Show(cadena, "Reactivar Alumno", MessageBoxButtons.OK);
                    
                }
                else
                {
                    //si el responsable a cargo estaba activo
                    string cadena = resultado[0].ToString();
                    MessageBox.Show(cadena, "Reactivar Alumno", MessageBoxButtons.OK);
                    
                }
            }
            else
            {
                //si no selecciono ningun alumno de la lista
                string cadena = resultado[0].ToString();
                MessageBox.Show(cadena, "Reactivar Alumno", MessageBoxButtons.OK);
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            
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
                consulta = "nombre LIKE '" + nombreBusqueda.Text + "%'";
            if (apellidoBusqueda.Text.Length > 0)
            {
                if (consulta.Length > 0)
                    consulta = consulta + " AND apellido LIKE '" + apellidoBusqueda.Text + "%'";
                else
                    consulta = "apellido LIKE '" + apellidoBusqueda.Text + "%'";
            }
            if (dniBusqueda.Text.Length > 0)
            {
                if (consulta.Length > 0)
                    consulta = consulta + " AND dni LIKE '" + dniBusqueda.Text + "%'";
                else
                    consulta = "dni LIKE '" + dniBusqueda.Text + "%'";
            }
            consulta = consulta + " AND activo = '0'";
            
        }

        private void nuevo_Click(object sender, EventArgs e)
        {

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
