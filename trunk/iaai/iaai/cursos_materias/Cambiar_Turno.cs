using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iaai.cursos_materias
{
    public partial class Cambiar_Turno : Form
    {
        /// <summary>
        /// Constructor publico de clase cambia turno
        /// </summary>
        public Cambiar_Turno()
        {

            InitializeComponent();
        }

        /// <summary>
        /// Inicializacion de Form cambia turno
        /// </summary>
        public void inicializar()
        {


        }

        private void Cambiar_Turno_Load(object sender, EventArgs e)
        {




        }

        private void listBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        internal void inicializar(List<string> disponibles)
        {
            listBoxTurno.Items.Clear();



            for (int i = 0; i < disponibles.Count; i++)
            {
               listBoxTurno.Items.Add(disponibles[i]);
            }

            
        }
    }
}
