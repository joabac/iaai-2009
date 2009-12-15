using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.cursos_materias;

namespace iaai.alumno
{

    /// <summary>
    /// Clase Alumno 
    /// Contienen todas las estructuras para soportar los datos de un alumno y sus metodos asociadoss
    /// </summary>
    public class Alumno
    {
        /// <summary>
        /// Obtiene o establece el id del alumno
        /// </summary>
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
        private string email;

        /// <summary>
        /// Obtiene o establece la matricula actual de trabajo del alumno
        /// </summary>
        public int id_matricula { get; set; }
        
        List<Materia> mis_materias {get; set;}
        
        Data_base.Data_base db = null;

        /// <summary>
        /// Constructor de clase Alumno
        /// </summary>
        /// <param name="datos">Lista con los atributos de un alumno</param>
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
            if (datos["email"] != null)
                email = datos["email"].ToString();
        }

        /// <summary>
        /// Constructor estandar de clase Alumno
        /// </summary>
        public Alumno()
        {}

        /// <summary>
        /// Constructor que instancia el alumno con 
        /// sus materias si este tiene materias en algun profesorado
        /// </summary>
        /// <param name="id_profesorado">int que representa el profesorado al que se asocia el alumno</param>
        public Alumno(int id_profesorado) {

            db = new iaai.Data_base.Data_base();

            mis_materias =  db.getMateriasAlumno(id_profesorado, id_alumno);
            
        }
        
        /// <summary>
        /// Retorna el id de un alumno
        /// </summary>
        /// <returns>int que representa su id único</returns>

        public int getId_alumno()
        {
            return id_alumno;
        }

        /// <summary>
        /// Retorna el nombre de un alumno
        /// </summary>
        /// <returns>String</returns>
        public string getNombre()
        {
            return nombre;
        }

        /// <summary>
        /// Retorna el apellido de un alumno
        /// </summary>
        /// <returns>String</returns>
        public string getApellido()
        {
            return apellido;
        }

        /// <summary>
        ///Retorna el DNI del alumno 
        /// </summary>
        /// <returns>String que representa el DNI</returns>
        public string getDni()
        {
            return dni;
        }

        /// <summary>
        /// Retorna la fecha de nacimiento registrada del alumno
        /// </summary>
        /// <returns>Objeto del tipo DateTime con la fecha de nacimiento</returns>
        public DateTime getFecha_nac()
        {
            return fecha_nac;
        }

        /// <summary>
        /// Retorna la característica del telefono del alumno
        /// </summary>
        /// <returns>String que representa la característica telefónica</returns>
        public string getTelefono_carac()
        {
            return telefono_carac;
        }

        /// <summary>
        /// Retorna el n° de teléfono del alumno
        /// </summary>
        /// <returns>String que representa el número de teléfono</returns>
        public string getTelefono_numero()
        {
            return telefono_numero;
        }

        /// <summary>
        /// Retorna el año de cursado del alumno en el establecimiento educativo indicado
        /// </summary>
        /// <returns>int año</returns>
        public int getEscuela_año()
        {
            return escuela_año;
        }

        /// <summary>
        /// Retorna el nombre de la escuela en que cursa el alumno
        /// </summary>
        /// <returns>String: Nombre de la escuela</returns>
        public string getEscuela_nombre()
        {
            return escuela_nombre;
        }

        /// <summary>
        /// Retorna la direccion o domicilio del alumno
        /// </summary>
        /// <returns>String: domicilio</returns>
        public string getDireccion()
        {
            return direccion;
        }

        /// <summary>
        /// Retorna el e-mail del alumno
        /// </summary>
        /// <returns>string</returns>
        public string getEmail()
        {
            return email;
        }
        /// <summary>
        /// Retorna id del responsable
        /// </summary>
        /// <returns>int</returns>
        public int getId_responsable()
        {
            return id_responsable;
        }

        
        /// <summary>
        /// Setea el nombre del alumno
        /// </summary>
        /// <param name="nom">String Nombre válido a guardar</param>
        public void setNombre(string nom)
        {
            nombre = nom;
        }

        /// <summary>
        /// Setea el apellido del alumno
        /// </summary>
        /// <param name="ap">String: apellido váalido a guardar</param>
        public void setApellido(string ap)
        {
            apellido = ap;
        }

        /// <summary>
        /// Setea el dni del alumno
        /// </summary>
        /// <param name="denei">String: dni válido a guardar</param>
        public void setDni(string denei)
        {
            dni = denei;
        }

        /// <summary>
        /// Setea la fecha de nacimiento del alumno
        /// </summary>
        /// <param name="fec">DateTime: válido a guardar</param>
        public void setFecha_nac(DateTime fec)
        {
            fecha_nac = fec;
        }

        /// <summary>
        /// Setea la característica del teléfono del alumno
        /// </summary>
        /// <param name="carac">String: caracteristica válida a  guardar</param>
        public void setTelefono_carac(string carac)
        {
            telefono_carac = carac;
        }

        /// <summary>
        /// Setea el número de teléfono del alumno
        /// </summary>
        /// <param name="num">String: número válido a guardar</param>
        public void setTelefono_numero(string num)
        {
            telefono_numero = num;
        }

        /// <summary>
        /// Setea el año de cursado en la escuela del alumno menor
        /// </summary>
        /// <param name="año">int: año válido de cursado</param>
        public void setEscuela_año(int año)
        {
            escuela_año = año;
        }

        /// <summary>
        /// Setea el nombre de la escuela al que concurre el alumno
        /// </summary>
        /// <param name="esc">String: escuela de cursado</param>
        public void setEscuela_nombre(string esc )
        {
            escuela_nombre = esc;
        }

        /// <summary>
        /// Setea la dirección del alumno
        /// </summary>
        /// <param name="dir">String: dirección válida</param>
        public void setDireccion(string dir)
        {
            direccion = dir;
        }

        /// <summary>
        /// Setea el id del responsable asociado
        /// </summary>
        /// <param name="resp">int:  id válido del responsable</param>
        public void setId_responsable(int resp)
        {
            id_responsable = resp;
        }

        /// <summary>
        /// Setea el email del alumno asociado
        /// </summary>
        /// <param name="em">int:  id válido del alumno</param>
        public void setEmail(string em)
        {
            email = em;
        }
    }
}
