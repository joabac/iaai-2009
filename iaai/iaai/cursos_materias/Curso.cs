using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.cursos_materias
{
    class Curso
    {
        public int id_curso { get; set; }
        public int nivel { get; set; }
        public string nombre { get; set; }
        public int id_profesor { get; set; }
        public int cupo { get; set; }
        public string condicion { get; set; }
        public int id_area { get; set; }
        public int duracion { get; set; }

        public Curso()
        {

        }


    }
}
