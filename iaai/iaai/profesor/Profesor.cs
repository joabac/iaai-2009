using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.profesor
{
    class Profesor
    {

        private int id_profesor;
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fecha_nac;
        private int telefono_carac;
        private int telefono_numero;
        private string direccion;
        private string email;


        //CONSTRUCTOR DE LA CLASE
        public Profesor(IDictionary<string,object> datos)
        {
            nombre = (string)datos["nombre"];
            apellido = (string)datos["apellido"];
            dni = int.Parse(datos["dni"].ToString());
            fecha_nac = DateTime.Parse(datos["fecha_nac"].ToString());
            
            if (datos["telefono_carac"] != null)
                telefono_carac =int.Parse(datos["telefono_carac"].ToString());
          
            telefono_numero = int.Parse(datos["telefono_numero"].ToString());
            
            direccion = (string)datos["direccion"];

            email = (string)datos["email"];
            
        }


        //ESTOS SON LOS GET

        public int getId_alumno()
        {
            return id_profesor;
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
