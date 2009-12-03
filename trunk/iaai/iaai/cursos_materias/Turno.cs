using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iaai.profesor;

namespace iaai.cursos_materias
{
 
    class Turno
    {
        public int id_turno { get; set; }
        public int id_profesor { get; set; }
        public string turno { get; set; }
        public int cupo { get; set; }
        public int materia { get; set; }
        public Profesor adjunto { get; set; }

        Data_base.Data_base db = new iaai.Data_base.Data_base();

        public Turno() {

       
        }

        public void cargar() 
        {
            adjunto = db.Buscar_Profesor(id_profesor);
        }

       
    }

}
