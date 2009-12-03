using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.cursos_materias
{


    class Materia
    {

        public int id_materia {get; set;}
        public int id_profesorado {get; set;}
        public int nivel {get; set;}
        public string nombre{get; set;}
        public int id_profesor{get; set;}
        public int cupo{get; set;}
        public int turno{get; set;}

        public Materia(){}

        public Materia(int id_materia){
        
        
        }

        

    }
}
