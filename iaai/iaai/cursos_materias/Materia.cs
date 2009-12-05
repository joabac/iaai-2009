using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iaai.profesor;

namespace iaai.cursos_materias
{


    class Materia
    {

        public int id_materia {get; set;}
        public int id_profesorado {get; set;}
        public int nivel {get; set;}
        public string nombre{get; set;}
        public int id_profesor{get; set;}
        
        

        Data_base.Data_base db = new iaai.Data_base.Data_base();
       
        public List<Turno> turno_materia { get; set; }

        public Materia(){
 
        }

        public Materia(int id_mat, int id_profe){

            turno_materia = db.getTurno(id_mat);
           
        }

        public void cargar()
        {
            turno_materia = db.getTurno(id_materia);
            
        }

       

        public string get_adjunto(string turno) {

            foreach (Turno turno_tem in turno_materia)
            {
                if (turno_tem.turno.Contains(turno))
                    return (turno_tem.adjunto.getApellido()+", "+turno_tem.adjunto.getNombre());
            }
            return "";
        }

        internal int get_id_turno(string turno)
        {
            foreach (Turno turno_tem in turno_materia)
            {
                if (turno_tem.turno.Contains(turno))
                    return turno_tem.id_turno;
            }
            return -1;
        }
    }
}
