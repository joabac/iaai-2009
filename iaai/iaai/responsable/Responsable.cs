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
        private string email;

        //CONSTRUCTOR ESTANDAR DE LA CLASE
        public Responsable()
        {

        }
        /// <summary>
        /// Constructor de la Clase Responsable que setea los atributos del mismo
        /// </summary>
        /// <param name="datos">IDictionary que tiene cargados los datos del objeto Responsable a crear</param>
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
            if (datos["email"] != null)
                email = (string)datos["email"];
                
        }


        //ESTOS SON LOS GET
        /// <summary>
        /// Retorna el id del Responsable
        /// </summary>
        /// <returns>int</returns>
        public int getId_responsable()
        {
            return id_responsable;
        }
        /// <summary>
        /// Retorna el nombre del responsable
        /// </summary>
        /// <returns>string</returns>
        public string getNombre()
        {
            return nombre;
        }
        /// <summary>
        /// Retorna el apellido del responsable
        /// </summary>
        /// <returns>string</returns>
        public string getApellido()
        {
            return apellido;
        }
        /// <summary>
        /// Retorna el DNI del responsable
        /// </summary>
        /// <returns>int</returns>
        public int getDni()
        {
            return dni;
        }
        /// <summary>
        /// Retorna la fecha de nacimiento del responsable
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime getFecha_nac()
        {
            return fecha_nac;
        }
        /// <summary>
        /// Retorna la característica telefónica del responsable
        /// </summary>
        /// <returns>int</returns>
        public int getTelefono_carac()
        {
            return telefono_carac;
        }
        /// <summary>
        /// Retorna el número de teléfono del responsable
        /// </summary>
        /// <returns>int</returns>
        public int getTelefono_numero()
        {
            return telefono_numero;
        }
        /// <summary>
        /// Retorna el domicilio del responsable
        /// </summary>
        /// <returns>string</returns>
        public string getDireccion()
        {
            return direccion;
        }
        /// <summary>
        /// Retorna el e-mail del responsable
        /// </summary>
        /// <returns>string</returns>
        public string getEmail()
        {
            return email;
        }

        //ESTOS SON LOS SET

        /// <summary>
        /// Setea el nombre del responsable
        /// </summary>
        /// <param name="nom">string: nombre válido</param>
        public void setNombre(string nom)
        {
            nombre = nom;
        }
        /// <summary>
        /// Setea el apellido del responsable
        /// </summary>
        /// <param name="ap">string: apellido válido</param>
        public void setApellido(string ap)
        {
            apellido = ap;
        }
        /// <summary>
        /// Setea el DNI del responsable
        /// </summary>
        /// <param name="denei">int: DNI válido</param>
        public void setDni(int denei)
        {
            dni = denei;
        }
        /// <summary>
        /// Setea la fecha de nacimiento del responsable
        /// </summary>
        /// <param name="fec">DateTime: fecha de nacimiento válida</param>
        public void setFecha_nac(DateTime fec)
        {
            fecha_nac = fec;
        }
        /// <summary>
        /// Setea la característica telefónica del responsable
        /// </summary>
        /// <param name="carac">int: característica telefónica válida</param>
        public void setTelefono_carac(int carac)
        {
            telefono_carac = carac;
        }
        /// <summary>
        /// Setea el número telefónico del responsable
        /// </summary>
        /// <param name="num">int: número telefónico válido</param>
        public void setTelefono_numero(int num)
        {
            telefono_numero = num;
        }
        /// <summary>
        /// Setea la domicilio del responsable
        /// </summary>
        /// <param name="dir">string: domicilio válida</param>
        public void setDireccion(string dir)
        {
            direccion = dir;
        }
        /// <summary>
        /// Setea el e-mail del responsable
        /// </summary>
        /// <param name="e">string: e-mail válido</param>
        public void setEmail(string e)
        {
            email = e;
        }
        /// <summary>
        /// Setea el Id del responsable
        /// </summary>
        /// <param name="id">int: id_responsable válido</param>
        public void setIdResponsable(int id)
        {
            id_responsable = id;
        }
    }
}
