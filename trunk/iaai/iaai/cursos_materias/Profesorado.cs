using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iaai.cursos_materias
{
    class Profesorado
    {

        public int id_profesorado { get; set; }
        public string nombre { get; set; }
        public int niveles  { get; set; }
        public List<Materia> materias = null;

        Data_base.Data_base db = new iaai.Data_base.Data_base();


        public Profesorado() { 
        
            
        }
                       
        public List<Materia> get_materias(int nivel, string turno)
        {

            try
            {
                materias = db.getMaterias(id_profesorado,nivel,turno);
            }
#pragma warning disable
            catch (Exception exc) {

            }
#pragma warning enable

            return materias;
        }

        
        
    }
}
