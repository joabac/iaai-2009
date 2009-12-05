using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.cursos_materias
{
    class Inscripto
    {

        public Materia materia_inscripta { get; set; }

        public string condicion { get; set; } //condicion en que quedo inscripto

        public int id_inscripcion_materia { get; set; } //registro de transaccion

        public string turno { get; set; }

        public Inscripto() 
        { 
        }

    }
}
