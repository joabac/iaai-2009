using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.profesor
{
    class Profesor
    {

        public int id_profesor {get; set;}
        private string nombre;
        private string apellido;
        private string dni;
        private DateTime fecha_nac;
        private int telefono_carac;
        private int telefono_numero;
        private string direccion;
        private string email;


        //CONSTRUCTOR DE LA CLASE
        public Profesor(IDictionary<string,object> datos)
        {
            id_profesor = -1;
            nombre = (string)datos["nombre"];
            apellido = (string)datos["apellido"];
            dni = (string) datos["dni"];
            fecha_nac = DateTime.Parse(datos["fecha_nac"].ToString());
            
            if (datos["telefono_carac"] != null)
                telefono_carac =int.Parse(datos["telefono_carac"].ToString());
          
            telefono_numero = int.Parse(datos["telefono_numero"].ToString());
            
            direccion = (string)datos["direccion"];

            email = (string)datos["email"];
            
        }

        public Profesor() { 
        
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
        public string getDni()
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
        
        public string getDireccion()
        {
            return direccion;
        }

        public string getEmail()
        {
            return email;
        }


        //ESTOS SON LOS SET

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
        public void setTelefono_carac(int carac)
        {
            telefono_carac = carac;
        }
        public void setTelefono_numero(int num)
        {
            telefono_numero = num;
        }
        
        public void setDireccion(string dir)
        {
            direccion = dir;
        }
        public void setMail(string mail)
        {
            email = mail;
        }


    }
}
