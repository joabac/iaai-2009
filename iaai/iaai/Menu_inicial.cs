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

namespace iaai
{
    public partial class Menu_inicial : Form
    {
        AltaAlumno a;

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
                a = new AltaAlumno();
                a.Parent = this.Parent;
                a.MdiParent = this;
                a.Show();
         }

        private void Menu_inicial_Load(object sender, EventArgs e)
        {
            
        }

        private void altaResponsableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AltaResponsable r = new AltaResponsable();
            r.Parent = this.Parent;
            r.MdiParent = this;

            r.Show();
        }

        
    }
}
