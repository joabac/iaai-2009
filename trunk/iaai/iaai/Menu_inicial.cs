using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.Data_base;
using iaai.alumno;
using iaai.responsable;
using iaai.profesor;

namespace iaai
{
    public partial class Menu_inicial : Form
    {
        

        public Menu_inicial()
        {
            InitializeComponent();
            
        }

        
        private void acercaDeIAAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data_base.Data_base datos = new iaai.Data_base.Data_base();


            datos.open_db();
        }

        private void altaAlumnoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                AltaAlumno alta_alumno_form = new AltaAlumno();
                alta_alumno_form.Parent = this.Parent;
                alta_alumno_form.MdiParent = this;
                alta_alumno_form.Show();
         }

        private void Menu_inicial_Load(object sender, EventArgs e)
        {
            
        }

        private void altaResponsableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AltaResponsable alta_resp = new AltaResponsable();
            alta_resp.Parent = this.Parent;
            alta_resp.MdiParent = this;

            alta_resp.Show();
        }


        private void ModificarProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarProfesor modifica_profesor = new ModificarProfesor();
            modifica_profesor.Parent = this.Parent;
            modifica_profesor.MdiParent = this;

            modifica_profesor.Show();

        }

        private void altaProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Altaprofesor profesor_form = new Altaprofesor();

            profesor_form.Parent = this.Parent;
            profesor_form.MdiParent = this;

            profesor_form.Show();
        }

        private void eliminarProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eliminar_Profesor elimina_profesor_form = new Eliminar_Profesor();

            elimina_profesor_form.Parent = this.Parent;
            elimina_profesor_form.MdiParent = this;

            elimina_profesor_form.Show();
        }


        private void listadoSeguroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoSeguro listado_seguro = new ListadoSeguro();

            listado_seguro.Parent = this.Parent;
            listado_seguro.MdiParent = this;

            listado_seguro.Show();
        }


        private void consultaProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Profesor consulta_profesor_form = new Consulta_Profesor();

            consulta_profesor_form.Parent = this.Parent;
            consulta_profesor_form.MdiParent = this;

            consulta_profesor_form.Show();
        }

        private void modificarAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarAlumno modifica_alumno = new ModificarAlumno();
            modifica_alumno.Parent = this.Parent;
            modifica_alumno.MdiParent = this;

            modifica_alumno.Show();
        }

        private void eliminarAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarAlumno elimina_alumno = new EliminarAlumno();
            elimina_alumno.Parent = this.Parent;
            elimina_alumno.MdiParent = this;

            elimina_alumno.Show();
        }

        private void modificarResponsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarResponsable modifica_responsable = new ModificarResponsable();
            modifica_responsable.Parent = this.Parent;
            modifica_responsable.MdiParent = this;

            modifica_responsable.Show();
        }

        private void eliminarResponsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarResponsable elimina_responsable = new EliminarResponsable();
            elimina_responsable.Parent = this.Parent;
            elimina_responsable.MdiParent = this;

            elimina_responsable.Show();
        }


        
    }
}
