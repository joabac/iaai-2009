using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.responsable
{
    class Responsable
    {
        private int id_responsable;
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fecha_nac;
        private int telefono_carac;
        private int telefono_numero;
        private string direccion;

        //CONSTRUCTOR DE LA CLASE
        public Responsable(IDictionary<string,object> datos)
        {
            id_responsable = -1;
            nombre = (string)datos["nombre"];
            apellido = (string)datos["apellido"];
            dni = int.Parse(datos["dni"].ToString());
            fecha_nac = DateTime.Parse(datos["fecha_nac"].ToString());
            if (datos["telefono_carac"] != null)
                telefono_carac = int.Parse(datos["telefono_carac"].ToString());
            telefono_numero = int.Parse(datos["telefono_numero"].ToString());
            direccion = (string)datos["direccion"];
        }


        //ESTOS SON LOS GET

        public int getId_responsable()
        {
            return id_responsable;
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
        public string getDireccion()
        {
            return direccion;
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
        public void setDireccion(string dir)
        {
            direccion = dir;
        }
    }
}
