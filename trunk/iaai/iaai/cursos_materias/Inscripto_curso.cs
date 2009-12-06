using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.cursos_materias
{
    class Inscripto_curso
    {
        public Curso curso_inscripto { get; set; }

        public string condicion { get; set; } //condicion en que quedo inscripto

        public int id_inscripcion_curso { get; set; } //registro de transaccion

        

        public Inscripto_curso() 
        { 
        }
    }
}
