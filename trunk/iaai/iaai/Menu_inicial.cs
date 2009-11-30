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


        private void modificarProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void altaProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Altaprofesor profesor_form = new Altaprofesor();

            profesor_form.Parent = this.Parent;
            profesor_form.MdiParent = this;

            profesor_form.Show();
        }

        
    }
}
