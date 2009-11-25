using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.alumno
{
    class Alumno
    {
        private int id_alumno;
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fecha_nac;
        private int telefono_carac;
        private int telefono_numero;
        private string escuela_nombre;
        private int escuela_año;
        private string direccion;
        private int id_responsable;

        //CONSTRUCTOR DE LA CLASE
        public Alumno(IDictionary<string,object> datos)
        {
            id_alumno = (int)datos["id"];
            nombre = (string)datos["nombre"];
            apellido = (string)datos["apellido"];
            dni = (int)datos["dni"];
            fecha_nac = (DateTime)datos["fecha_nac"];
            telefono_carac =(int)datos["telefono_carac"];
            telefono_numero = (int)datos["telefono_numero"];
            escuela_nombre = (string)datos["escuela_nombre"];
            escuela_año = (int)datos["escuela_año"];
            direccion = (string)datos["direccion"];
            id_responsable = (int)datos["id_responsable"];
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
        public int getDni()
        {
            return dni;
        }
        public DateTime getFecha_nac()
        {
            return fecha_nac;
        }
        public int getTelefono_carac()
        {
            return telefono_carac;
        }
        public int getTelefono_numero()
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


        public void setId_alumno(int id)
        {
            id_alumno = id;
        }
        public void setNombre(string nom)
        {
            nombre = nom;
        }
        public void setApellido(string ap)
        {
            apellido = ap;
        }
        public void setDni(int denei)
        {
            dni = denei;
        }
        public void setFecha_nac(DateTime fec)
        {
            fecha_nac = fec;
        }
        public void setTelefono_carac(int carac)
        {
            telefono_carac = carac;
        }
        public void setTelefono_numero(int num)
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

        static void Main()
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
            
        }

        
    }
}
