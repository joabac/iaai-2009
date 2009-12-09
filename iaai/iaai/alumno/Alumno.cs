using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.cursos_materias;

namespace iaai.alumno
{
    public class Alumno
    {
        public int id_alumno { get; set; }
        private string nombre;
        private string apellido;
        private string dni;
        private DateTime fecha_nac;
        private string telefono_carac;
        private string telefono_numero;
        private string escuela_nombre;
        private int escuela_año;
        private string direccion;
        private int id_responsable;
        public int id_matricula { get; set; }
        
        List<Materia> mis_materias {get; set;}
        
        Data_base.Data_base db = null;

        //CONSTRUCTOR DE LA CLASE
        public Alumno(IDictionary<string,object> datos)
        {
            id_alumno = -1;
            nombre = (string)datos["nombre"];
            apellido = (string)datos["apellido"];
            dni = (string) datos["dni"];
            fecha_nac = DateTime.Parse(datos["fecha_nac"].ToString());
            if (datos["telefono_carac"] != null)
                telefono_carac =datos["telefono_carac"].ToString();
            telefono_numero = datos["telefono_numero"].ToString();
            if (datos["escuela_nombre"] != null)
            {
                escuela_nombre = (string)datos["escuela_nombre"];
                escuela_año = int.Parse(datos["escuela_año"].ToString());
            }
            
            direccion = (string)datos["direccion"];
            if (datos["id_responsable"] != null)
                id_responsable = int.Parse(datos["id_responsable"].ToString());
        }

        public Alumno()
        {}

        /// <summary>
        /// Constructor que instancia el alumno con 
        /// sus materias si este tiene materias en algun profesorado
        /// </summary>
        /// <param name="id_profesorado"></param>
        public Alumno(int id_profesorado) {

            db = new iaai.Data_base.Data_base();

            mis_materias =  db.getMateriasAlumno(id_profesorado, id_alumno);
            
        }
        //ESTOS SON LOS GET

        public int getId_alumno()
        {
            return id_alumno;
        }
        public string getNombre()
        {
            return nombre;
        }
        public string getApellido()
        {
            return apellido;
        }
        public string getDni()
        {
            return dni;
        }
        public DateTime getFecha_nac()
        {
            return fecha_nac;
        }
        public string getTelefono_carac()
        {
            return telefono_carac;
        }
        public string getTelefono_numero()
        {
            return telefono_numero;
        }
        public int getEscuela_año()
        {
            return escuela_año;
        }
        public string getEscuela_nombre()
        {
            return escuela_nombre;
        }
        public string getDireccion()
        {
            return direccion;
        }
        public int getId_responsable()
        {
            return id_responsable;
        }

        //ESTOS SON LOS SET VITEH

        public void setNombre(string nom)
        {
            nombre = nom;
        }
        public void setApellido(string ap)
        {
            apellido = ap;
        }
        public void setDni(string denei)
        {
            dni = denei;
        }
        public void setFecha_nac(DateTime fec)
        {
            fecha_nac = fec;
        }
        public void setTelefono_carac(string carac)
        {
            telefono_carac = carac;
        }
        public void setTelefono_numero(string num)
        {
            telefono_numero = num;
        }
        public void setEscuela_año(int año)
        {
            escuela_año = año;
        }
        public void setEscuela_nombre(string esc )
        {
            escuela_nombre = esc;
        }
        public void setDireccion(string dir)
        {
            direccion = dir;
        }
        public void setId_responsable(int resp)
        {
            id_responsable = resp;
        }

        /*static void Main()
        {
            
            IDictionary<string, object> index = new Dictionary<string, object>();

            index["id"] = 1;
            index["nombre"] = "Matías";
            index["apellido"] = "Milesi";
            index["dni"] = "2222";
            index["fecha_nac"] = "28/06/1984";
            index["telefono_carac"] = 342;
            index["telefono_numero"] = 4550871;
            index["escuela_nombre"] = "comercial";
            index["escuela_año"] = 2001;
            index["direccion"] = "conchabamba 1123";
            index["id_responsable"] = 2;

            Alumno t = new Alumno(index);

            Console.WriteLine(t.getApellido());
            
        }*/

        
    }
}
