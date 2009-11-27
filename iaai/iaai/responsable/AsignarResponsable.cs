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

        private void llenarTabla()
        {
            string aux = "";
            foreach (List<string> fila in resultado)
            {
                aux = aux + fila[0] + "- " + fila[1];
                    MessageBox.Show(aux);
                //llenar la tabla
            }

        }

        private void aceptar_Click(object sender, EventArgs e)
        {

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
                consulta = "nombre_respon LIKE '" + nombreBusqueda.Text + "'";
            if (apellidoBusqueda.Text.Length > 0)
            {
                if (consulta.Length > 0)
                    consulta = consulta + " AND apellido_respon LIKE '" + apellidoBusqueda.Text + "'";
                else
                    consulta = "apellido_respon LIKE '" + apellidoBusqueda.Text + "'";
            }
            if (dniBusqueda.Text.Length > 0)
            {
                if (consulta.Length > 0)
                    consulta = consulta + " AND dni = '" + dniBusqueda.Text + "'";
                else
                    consulta = "dni = '" + dniBusqueda.Text + "'";
            }
        }

    }
}
