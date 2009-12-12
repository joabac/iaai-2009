using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.alumno;

namespace iaai.cursos_materias
{
    public partial class Cambiar_Turno : Form
    {

        Alumno alumno_asociado;
        int id_materia;
        int id_turno_actual;
        Data_base.Data_base db = new iaai.Data_base.Data_base();

        /// <summary>
        /// Constructor publico de clase cambia turno
        /// </summary>
        ///
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


        /// <summary>
        /// Inicializa una instancia de la ventana de cambio de turno
        /// </summary>
        /// <param name="disponibles">listado de turnos disponibles para la materia sin incluir el actual</param>
        /// <param name="nuevo">Alumno asociado a la materia</param>
        /// <param name="id_mat">id de la materia que se queire cambiar de turno</param>
        /// <param name="id_tur">id del turno que tiene actualmente</param>
        internal void inicializar(List<string> disponibles,Alumno nuevo, int id_mat,int id_tur)
        {

            alumno_asociado = nuevo;
            id_materia = id_mat;
            id_turno_actual = id_tur;

            this.Owner.Enabled = false;

            comboBox_turnos.Items.Clear();

            for (int i = 0; i < disponibles.Count; i++)
            {
                comboBox_turnos.Items.Add(disponibles[i]);
            }

            if (comboBox_turnos.Items.Count > 0)
            {
                comboBox_turnos.SelectedIndex = 0;
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("No existen otros turnos disponibles", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Owner.Enabled = true;
                this.Close();

            }
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Owner.Enabled = true;
            this.Close();
        }

        private void acept_Click(object sender, EventArgs e)
        {

            int id_turno_nuevo;


            if (comboBox_turnos.Items.Count > 0)
            {
               //recupero el id de turno nuevo que quiere el alumno
               id_turno_nuevo =  db.obtener_Id_turno(id_materia, comboBox_turnos.SelectedItem.ToString());

                if(id_turno_nuevo != -1){//si no hay errores

                    db.cambiarTurno(id_materia,alumno_asociado.id_matricula,id_turno_actual,id_turno_nuevo);

                    this.Owner.Enabled = true;
                    this.Close();
                    
                }
            }
        }

        private void Cambiar_Turno_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }


    }
}
