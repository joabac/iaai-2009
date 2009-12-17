using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using iaai.alumno;
using System.Data.SqlClient;
using iaai.responsable;
using iaai.profesor;
using iaai.cursos_materias;


namespace iaai.Data_base
{
    
    
    class Data_base 
    {

        string cadena_coneccion = "server=localhost;user=iaai;database=iaai_pruebas;port=3306;password=iaai;";

        //string cadena_coneccion = "server=localhost;user=root;database=iaai;port=3306;password=root;";

        
        MySqlConnection conexion = null;

        public Data_base(){

            conexion = new MySqlConnection(cadena_coneccion);
            
        }


        public Data_base(string cadena) 
        {
            conexion = new MySqlConnection(cadena);
        }

        public void connectionString(string cadena)
        {
            cadena_coneccion = cadena;
            if (conexion != null)
                conexion.ConnectionString = cadena;
        }

        public bool open_db(){

            try
            {
                
                conexion.Open();
                if (conexion.State == System.Data.ConnectionState.Open)
                    return true;
            }
            catch (MySqlException my_ex)
            {
                MessageBox.Show("Error al abrir la base de Datos:\r\n"+my_ex.Message);
                return false;
            }

            return true;
            
        }

        /// <summary>
        /// Se valida que no exista el alumno en la base de datos.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>
        /// true: si no se encuentra
        /// false: si se encuentra
        /// </returns>
        public bool buscarDniAlumno(string dni)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from alumno where dni like '" + dni + "'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                
                if (MyDataReader.Read())
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos al buscar el alumno: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        /// <summary>
        /// Método retorna si el alumno está como inactivo o activo.
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>
        /// true:si el alumno es activo (activo = 1)
        /// flase:si el alumno NO es activo (activo = 0)</returns>
        public bool esAlumnoActivo(string dni)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from alumno where dni like '" + dni + "' and activo = '0'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();

                if (MyDataReader.Read())
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos al buscar el alumno: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        /// <summary>
        /// Método que retorna el DNI del responsable 
        /// </summary>
        /// <param name="id">int: id_responsable</param>
        /// <returns>
        /// string: DNI responsable
        /// </returns>
        public string obtenerDniResponsable(int id)
        {
            string dni_responsable = "";
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from responsable where id_responsable = '" + id + "'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                if (MyDataReader.Read())
                {
                    dni_responsable = MyDataReader[0].ToString();
                    conexion.Close();
                    return dni_responsable;
                }
                else
                {
                    conexion.Close();
                    return null;
                }
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error en base de Datos al buscar el dni del responsable: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dni_responsable;
        }

       /// <summary>
        /// Se valida que no exista el responsable en la base de datos.
       /// </summary>
       /// <param name="dni"></param>
       /// <returns>
        /// true: si no se encuentra
        /// false: si se encuentra
        /// </returns>
        public bool buscarDniResponsable(string dni)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from responsable where dni like '" + dni + "'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                if (MyDataReader.Read())
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error en base de Datos al buscar el dni del responsable: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }


        /// <summary>
        /// Método que da de alta un alumno en la base de datos
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        /// true: si se subio correctamente a la base de datos
        /// false:si no fue subido a la base de datos
        /// </returns>
        public bool altaAlumno(Alumno a)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("insert into alumno(nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, escuela_nombre, escuela_año, direccion, id_responsable, email) values('" + 
                                                            apostrofos(a.getNombre()) + "', '" + apostrofos(a.getApellido()) + "', '" + a.getDni() + "', '" + a.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "', '" + a.getTelefono_carac() + "', '" + a.getTelefono_numero() + "', '" + apostrofos(a.getEscuela_nombre()) +
                                                            "', '" + a.getEscuela_año()+ "', '" + apostrofos(a.getDireccion()) + "', '" + a.getId_responsable() + "', '" + a.getEmail() + "')", conexion);
                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de escritura en base de Datos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                return true;
            
            
        }


        /// <summary>
        /// Método que da de alta un responsable en la base de datos
        /// </summary>
        /// <param name="r"></param>
        /// <returns>
        /// true: si fue subido correctamente a la base de datos
        /// false:si no fue subido a la base de datos
        /// </returns>
        public bool altaResponsable(Responsable r)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("insert into responsable(nombre_respon, apellido_respon, dni, fecha_nac, telefono_carac, telefono_numero, direccion, email) values('" + 
                                                        apostrofos(r.getNombre()) + "', '" + apostrofos(r.getApellido()) + "', '" + r.getDni() + "', '" + r.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + 
                                                        r.getTelefono_carac() + "', '" + r.getTelefono_numero() + "', '" + apostrofos(r.getDireccion()) + "','" + r.getEmail() + "')", conexion);
                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de escritura en base de Datos al dar de alta un responsable: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }


        /// <summary>
        /// Busca un responsable en base de datos
        /// </summary>
        /// <param name="consulta">
        /// consulta: string con la condición de búsqueda en la base de datos para recuperar los datos de los responsables
        /// </param>
        /// <returns>
        /// List: lista con datos de los responsables que son recuperados según 
        /// las condiciones dadas en el parámetro "consulta".
        /// </returns>
        public List<List<string>> buscarResponsable(string consulta)
        {
            List<List<string>> datos = new List<List<string>>();
            List<string> d = new List<string>();

            try
            {
            this.open_db();
            MySqlCommand MyCommand = new MySqlCommand("select * from responsable where " + consulta, conexion);
            MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
            while (MyDataReader.Read())
            {
                d = new List<string>();
                d.Add(MyDataReader.GetValue(0).ToString());//id_responsable
                d.Add(MyDataReader.GetValue(1).ToString());//nombre
                d.Add(MyDataReader.GetValue(2).ToString());//apellido
                d.Add(MyDataReader.GetValue(7).ToString());//dni
                d.Add(MyDataReader.GetValue(5).ToString() + " " + MyDataReader.GetValue(6).ToString());//telefono
                d.Add(MyDataReader.GetValue(4).ToString());//direccion
                datos.Add(d);
            }
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos al buscar el responsable: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return datos;
        }


        /// <summary>
        /// Método que modifica un alumno en la base de datos
        /// </summary>
        /// <param name="alumno">
        /// Objeto Alumno con los datos modificados.
        /// </param>
        /// <param name="dni_viejo">
        /// Se espera el dni registrado en base para indexar la modificación en base de datos
        /// </param>
        /// <returns>
        /// true: si fue modificado el alumno
        /// false: si no fue modificado el alumno.
        /// </returns>
        public bool modificarAlumno(Alumno alumno, string dni_viejo)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("update alumno set nombre = '" +
                                                            apostrofos(alumno.getNombre()) + "',apellido = '" + apostrofos(alumno.getApellido()) + "',dni = '" +
                                                            alumno.getDni() + "', telefono_carac = '" + alumno.getTelefono_carac() + "',telefono_numero = '" +
                                                            alumno.getTelefono_numero() + "',fecha_nac = '" +
                                                            alumno.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "',direccion = '" + apostrofos(alumno.getDireccion()) +
                                                            "',escuela_nombre = '" + apostrofos(alumno.getEscuela_nombre()) +
                                                            "', escuela_año = '" + alumno.getEscuela_año() + 
                                                            "', id_responsable = '" + alumno.getId_responsable() + "', email = '" + alumno.getEmail() + "' where dni like '" + dni_viejo + "'", conexion);
                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
        }

        /// <summary>
        /// Método que modifica un responsable en la base de datos
        /// </summary>
        /// <param name="responsable">
        /// Obejto Responsable con los datos modificados
        /// </param>
        /// <param name="dni_viejo">
        /// Se espera el dni registrado en base para indexar la modificación en base de datos
        /// </param>
        /// <returns>
        /// true: si fue modificado el responsable
        /// false: si no fue modificado el responsable
        /// </returns>
        public bool modificarResponsable(Responsable responsable, string dni_viejo)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("update responsable set nombre_respon = '" +
                                                            apostrofos(responsable.getNombre()) + "',apellido_respon = '" + apostrofos(responsable.getApellido()) + "',dni = '" +
                                                            responsable.getDni() + "', telefono_carac = " + responsable.getTelefono_carac() + ",telefono_numero = " +
                                                            responsable.getTelefono_numero() + ",fecha_nac = '" +
                                                            responsable.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "',direccion = '" + apostrofos(responsable.getDireccion()) + "', email = '" + responsable.getEmail() + "' where dni like '" + dni_viejo + "'", conexion);
                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
        }

        //objeto diccionario para PRE almacenar los datos y permitir luego la generacion de un objeto Alumno
        IDictionary<string, object> datos = new Dictionary<string, object>();

        /// <summary>
        /// Busca un alumno en base de datos
        /// </summary>
        /// <param name="dni">recibe el dni del alumno a buscar</param>
        /// <returns>
        /// Alumno: si encontro el alumno buscado
        /// null: si no encontro el alumno según el dni solicitado</returns>
        public Alumno Buscar_Alumno(string dni)
        {
            Alumno alumno = new Alumno();
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select id_alumno,nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, escuela_nombre, escuela_año, id_responsable, email " +
                                                          "from alumno " +
                                                          "where dni like '" + dni + "' AND activo = '1'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    datos["nombre"] = (reader[1].ToString());
                    datos["apellido"] = (reader[2].ToString()); ;
                    datos["dni"] = (reader[3].ToString()); ;
                    datos["fecha_nac"] = (Convert.ToDateTime(reader[6]));
                    if ((reader[4].ToString()) != "0")
                    {
                        datos["telefono_carac"] = (reader[4].ToString());
                    }
                    else
                    {
                        datos["telefono_carac"] = "";
                    }
                    datos["telefono_numero"] = (reader[5].ToString());

                    if ((reader[8].ToString()).Length > 0)
                    {
                        datos["escuela_nombre"] = (reader[8].ToString());
                        datos["escuela_año"] = (Convert.ToInt32(reader[9].ToString()));
                    }
                    else
                    {
                        datos["escuela_nombre"] = null;
                        datos["escuela_año"] = null;
                    }
                    datos["direccion"] = (reader[7].ToString());
                    if (reader[10].ToString().Length > 0)
                        datos["id_responsable"] = (Convert.ToInt32(reader[10].ToString()));
                    else
                        datos["id_responsable"] = null;
                    if (reader[11].ToString().Length > 0)
                        datos["email"] = reader[11].ToString();
                    else
                        datos["email"] = null;
                    
                    alumno = new Alumno(datos);
                    alumno.id_alumno = (Convert.ToInt32(reader[0]));
                    
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Alumnos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }
            return alumno;

        }
            

        /// <summary>
        /// Busca un responsable en base de datos
        /// </summary>
        /// <param name="dni">recibe el dni del responsable a buscar</param>
        /// <returns>
        /// Responsable: si encontro el responsable buscado
        /// null: si no encontro el responsable según el dni solicitado</returns>
        public Responsable Buscar_Responsable(string dni)
        {
            Responsable responsable = new Responsable();
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select nombre_respon, apellido_respon, dni, telefono_carac, telefono_numero, fecha_nac, direccion, id_responsable, email " +
                                                          "from responsable " +
                                                          "where dni like '" + dni + "' AND activo = '1'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    IDictionary<string, object> datos = new Dictionary<string, object>();

                    //se generan los dato del Responsable a dar de alta
                    datos["nombre"] = (reader[0].ToString());
                    datos["apellido"] = (reader[1].ToString());
                    datos["dni"] = reader[2].ToString();
                    datos["fecha_nac"] = (Convert.ToDateTime(reader[5]));
                    datos["telefono_carac"] = reader[3].ToString();
                    datos["telefono_numero"] = reader[4].ToString();
                    //datos["id_responsable"] = reader[7].ToString();
                    datos["direccion"] = reader[6].ToString();
                    if (reader[8].ToString().Length > 0)
                        datos["email"] = reader[8].ToString();
                    else
                        datos["email"] = null;
                    responsable = new Responsable(datos);
                    responsable.setIdResponsable(Convert.ToInt32(reader[7].ToString()));
                   
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return responsable;

        }


        public void leer()
        {//esta la dejamos de ejemplo para ver como leer desde la base de datos
            MySqlCommand MyCommand = new MySqlCommand("insert", conexion);
            MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
            MyDataReader.Read();
            MessageBox.Show(MyDataReader.GetValue(2).ToString());
        }

        /// <summary>
        /// Busca el DNI del profesor solicitado en base de datos,
        /// </summary>
        /// <param name="dni_profesor">
        /// Se debe ingresar un dni valido en formato String
        /// </param>
        /// <returns>
        ///{true= si existe el docente}  
        ///{false= si no existen registros del mismo} 
        /// </returns>
        internal bool buscarDniProfesor(string dni_profesor)
        {
            
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from profesor where dni like '" + dni_profesor + "'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                
                if (MyDataReader.Read())
                {
                    conexion.Close();
                    return false;
                }
                else
                {  
                    conexion.Close();
                    return true;
                }
                
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos al buscar dni profesor: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        /// <summary>
        /// Da de alta un profesor
        /// </summary>
        /// <param name="profe">
        /// Se debe ingresar un instancia de Profesor
        /// </param>
        /// <returns>
        /// {true= si se dio de alta el profesor}  
        /// {false= si no se pudo dar de alta}
        /// </returns>
        public bool altaProfesor(Profesor profe)
        {
            try
            {
            this.open_db();
            //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
            MySqlCommand MyCommand = new MySqlCommand("insert into profesor(nombre, apellido, dni, telefono_carac,"+
                                                      "  telefono_numero, fecha_nac, direccion,email) values('" + 
                                                        apostrofos(profe.getNombre()) + "', '" + apostrofos(profe.getApellido()) + "', '" +
                                                        profe.getDni() + "', '" + profe.getTelefono_carac() + "', '" +
                                                        profe.getTelefono_numero() + "', '" +
                                                        profe.getFecha_nac().ToString("yyyy-MM-dd") +
                                                        "', '" + apostrofos(profe.getDireccion()) +
                                                        "', '" + profe.getEmail() + "')", conexion);
            MyCommand.ExecuteNonQuery();
            conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
        }


        /// <summary>
        /// Ejecuta comando del tipo del especificando consulta completa
        /// </summary>
        /// <param name="consulta">recibe cualquier tipod e consulta en formato string</param>
        /// <returns>
        /// true: pudo completar la consulta 
        /// false: no pudo completar consulta</returns>
        /// <remarks>Solo se utiliza para ejecutar consultas genericas o simples</remarks>
        public bool consulta(string consulta)
        {

            try
            {
               if(conexion.State == System.Data.ConnectionState.Closed)
                   this.open_db();

                
                MySqlCommand MyCommand = new MySqlCommand(consulta, conexion);
                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos al realizar consulta: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;

        }

        /// <summary>
        /// Busca el conjunto de profesores dados de baja del sistema
        /// </summary>
        /// <returns>Lista de profesores inactivos</returns>
        public List<Profesor> Buscar_Profesor_inactivos()
        {

            List<Profesor> profe = new List<Profesor>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, email " +
                                                          "from profesor " +
                                                          "where activo = 0", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Profesor profesor_tem = new Profesor();

                if (reader.Read())
                {
                    do
                    {


                        profesor_tem.setNombre(reader[0].ToString());
                        profesor_tem.setApellido(reader[1].ToString());
                        profesor_tem.setDni(reader[2].ToString());
                        profesor_tem.setTelefono_carac(Convert.ToInt32(reader[3].ToString()));
                        profesor_tem.setTelefono_numero(Convert.ToInt32(reader[4].ToString()));
                        profesor_tem.setFecha_nac(Convert.ToDateTime(reader[5]));
                        profesor_tem.setDireccion(reader[6].ToString());
                        profesor_tem.setMail(reader[7].ToString());

                        profe.Add(profesor_tem); //agrega a la lista de retorno

                        profesor_tem = new Profesor();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Profesores: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return profe;
        }

        /// <summary>
        /// Busca un profesor activo en base de datos
        /// </summary>
        /// <param name="dni">recibe el dni de profesro a buscar</param>
        /// <returns>Profesor si encontro el profesor buscado
        /// null: si no encontro el dni solicitado</returns>
        /// <seealso cref="Buscar_Profesor_inactivos()"/>
        public Profesor Buscar_Profesor(string dni)
        {
            Profesor profe = new Profesor();
            try
            {
                if(conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, email "+
                                                          "from profesor "+
                                                          "where dni like '" + dni +"' and activo = 1", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    profe.setNombre(reader[0].ToString());
                    profe.setApellido(reader[1].ToString());
                    profe.setDni(reader[2].ToString());
                    profe.setTelefono_carac(Convert.ToInt32(reader[3].ToString()));
                    profe.setTelefono_numero(Convert.ToInt32(reader[4].ToString()));
                    profe.setFecha_nac(Convert.ToDateTime(reader[5]));
                    profe.setDireccion(reader[6].ToString());
                    profe.setMail(reader[7].ToString());
                }
                else
                {
                    conexion.Close();
                    return null;
                }
                
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Profesores: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }

            
            return profe;

        }


        /// <summary>
        /// Busca un profesor activo en base de datos por apellido completo o parcial
        /// </summary>
        /// <param name="apellido">recibe una procion de apellido</param>
        /// <returns>Profesor si encontro el profesor buscado
        /// null: si no encontro el dni solicitado</returns>
        /// <seealso cref="Buscar_Profesor_inactivos()"/>
        public List<Profesor> Buscar_Profesor_Por_apellido(string apellido)
        {
            List<Profesor> profe = new List<Profesor>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, email " +
                                                          "from profesor " +
                                                          "where apellido like '"+apostrofos(apellido)+"%' and activo = 1", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Profesor profesor_tem = new Profesor();

                if (reader.Read())
                {
                    do
                    {


                        profesor_tem.setNombre(reader[0].ToString());
                        profesor_tem.setApellido(reader[1].ToString());
                        profesor_tem.setDni(reader[2].ToString());
                        profesor_tem.setTelefono_carac(Convert.ToInt32(reader[3].ToString()));
                        profesor_tem.setTelefono_numero(Convert.ToInt32(reader[4].ToString()));
                        profesor_tem.setFecha_nac(Convert.ToDateTime(reader[5]));
                        profesor_tem.setDireccion(reader[6].ToString());
                        profesor_tem.setMail(reader[7].ToString());

                        profe.Add(profesor_tem); //agrega a la lista de retorno

                        profesor_tem = new Profesor();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if(conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Profesores: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return profe;
        }

        /// <summary>
        /// Modifica un profesor en la base de datos
        /// </summary>
        /// <param name="profe">
        /// Se debe ingresar un instancia de Profesor
        /// </param>
        /// <returns>
        /// {true= si se dio la modificación del profesor}  
        /// {false= si no se pudo modificar}
        /// </returns>
        public bool modificarProfesor(Profesor profe)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("update profesor set nombre = '" +
                                                            apostrofos(profe.getNombre()) + "',apellido = '" + apostrofos(profe.getApellido()) + "',dni = '" +
                                                            profe.getDni() + "', telefono_carac = " + profe.getTelefono_carac() + ",telefono_numero = " +
                                                            profe.getTelefono_numero() + ",fecha_nac = '" +
                                                            profe.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "',direccion = '" + apostrofos(profe.getDireccion()) +
                                                            "',email = '" + profe.getEmail() + "'" + " where dni like '" + profe.getDni()+"'", conexion);
                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
        }


        /// <summary>
        /// Marca como eliminado un profesor de la base de datos
        /// </summary>
        /// <param name="dni">String del profesor a elimnar</param>
        /// <remarks>este debe ser valido y existir en la base</remarks>
        /// <returns>true: si pudo eliminar false: si no pudo realizar la eliminacion</returns>
        public bool eliminarProfesor(String dni)
        {
            try
            {
                this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("update profesor set activo = 0 "+
                                                           "where dni like '"+dni+"'", conexion);

                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
            
        }
        /// <summary>
        /// Método que reactiva un alumno dado de baja en el sistema, ya que sus datos perduran en dicha Base de datos.
        /// Éste método setea las materias a las que el alumno se había inscripto pero con el estado "condicional"
        /// </summary>
        /// <param name="dni">string: dni válido de un alumno en base de datos (inactivo)</param>
        public Boolean activarAlumnoEliminado(string dni)
        {
            List<string> matriculas = new List<string>();
            try
            {
                this.open_db();

                //extraigo los id_matricula del alumno a reactivar
                MySqlCommand MyReadCommand = new MySqlCommand("select m.id_matricula from matricula as m, alumno as a where a.dni = '" + dni + "' and a.id_alumno = m.id_alumno and a.activo = 0", conexion);
                MySqlDataReader reader = MyReadCommand.ExecuteReader();
                // cargo la lista de matrículas que tiene el alumno a reactivar.
                while (reader.Read())
                {
                    matriculas.Add(reader[0].ToString());
                }
                reader.Close();
                MySqlCommand MyCommand2;
                MySqlCommand MyCommand3;
                MySqlCommand MyCommand4;
                //seteo como condicional al alumno en todas las materias, cursos y demás donde haya estado inscripto.
                foreach (string mat in matriculas)
                {
                    MyCommand2 = new MySqlCommand("update registro_curso set condicion = 'condicional' " +
                                                             "where id_matricula like '" + mat + "'", conexion);
                    MyCommand2.ExecuteNonQuery();

                    MyCommand3 = new MySqlCommand("update registro_curso_especial set condicion ='condicional' " +
                                                             "where id_matricula like '" + mat + "'", conexion);
                    MyCommand3.ExecuteNonQuery();

                    MyCommand4 = new MySqlCommand("update registro_materia set condicion = 'condicional' " +
                                                             "where id_matricula like '" + mat + "'", conexion);
                    MyCommand4.ExecuteNonQuery();

                }

                MySqlCommand MyCommand = new MySqlCommand("update alumno set activo = 1 " +
                                                           "where dni like '" + dni + "'", conexion);
                MyCommand.ExecuteNonQuery();

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;

        }


        /// <summary>
        /// Marca como eliminado un alumno de la base de datos
        /// </summary>
        /// <param name="dni">String: DNI del alumno a elimnar</param>
        /// <remarks>este debe ser valido y existir en la base</remarks>
        /// <returns>
        /// true: si pudo eliminar 
        /// false: si no pudo realizar la eliminación</returns>
        public bool eliminarAlumno(String dni)
        {
            List<string> matriculas = new List<string>();
            try
            {
                this.open_db();

                //extraigo los id_matricula del alumno a eliminar
                MySqlCommand MyReadCommand = new MySqlCommand("select m.id_matricula from matricula as m, alumno as a where a.dni = '" + dni + "' and a.id_alumno = m.id_alumno", conexion);
                MySqlDataReader reader = MyReadCommand.ExecuteReader();
                //seteo como inactivo al alumno en todas las materias, cursos y demás donde esté inscripto el alumno
                while (reader.Read())
                {
                    matriculas.Add(reader[0].ToString());
                }
                reader.Close();
                MySqlCommand MyCommand2;
                MySqlCommand MyCommand3;
                MySqlCommand MyCommand4;
                foreach(string mat in matriculas)
                {
                    MyCommand2 = new MySqlCommand("update registro_curso set condicion = 'inactivo' " +
                                                             "where id_matricula like '" + mat + "'", conexion);
                    MyCommand2.ExecuteNonQuery();

                    MyCommand3 = new MySqlCommand("update registro_curso_especial set condicion ='inactivo' " +
                                                             "where id_matricula like '" + mat + "'", conexion);
                    MyCommand3.ExecuteNonQuery();

                    MyCommand4 = new MySqlCommand("update registro_materia set condicion = 'inactivo' " +
                                                             "where id_matricula like '" + mat + "'", conexion);
                    MyCommand4.ExecuteNonQuery();

                }

                MySqlCommand MyCommand = new MySqlCommand("update alumno set activo = 0 " +
                                                           "where dni like '" + dni + "'", conexion);
                MyCommand.ExecuteNonQuery();
                
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;

        }

        /// <summary>
        /// Marca como eliminado un responsable de la base de datos
        /// </summary>
        /// <param name="dni">String: DNI del responsable a elimnar</param>
        /// <remarks>este debe ser valido y existir en la base</remarks>
        /// <returns>
        /// true: si pudo eliminar 
        /// false: si no pudo realizar la eliminacion</returns>
        public bool eliminarResponsable(String dni)
        {
            try
            {
                this.open_db();
                

                MySqlCommand MyCommand = new MySqlCommand("update responsable set activo = 0 " +
                                                           "where dni like '" + dni + "'", conexion);

                MyCommand.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;

        }

        /// <summary>
        /// Método que borra de la base de datos un responsable que fue dado de alta pero que luego
        /// no fue asignado a ningún alumno, producto de cancelar el alta de un alumno o por haber dado de alta
        /// más de un responsable en la carga de un alumno.
        /// </summary>
        /// <param name="id">String: id del responsable a elimnar</param>
        /// <returns>
        /// true: si se pudo eliminar 
        /// false: si no se pudo realizar la eliminacion</returns>
        public bool deshacerResponsable(int id)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand1 = new MySqlCommand("select id_alumno from alumno where id_responsable = '" + id + "'", conexion);
                MySqlDataReader re = MyCommand1.ExecuteReader();
                if (!(re.Read()))
                {
                    conexion.Close();
                    this.open_db();
                    MySqlCommand MyCommand = new MySqlCommand("delete from responsable where id_responsable like '" + id + "'", conexion);
                    MyCommand.ExecuteNonQuery();
                }
                else
                {
                    conexion.Close();
                    return false;
                }
                conexion.Close();

            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;

        }

        public void deshacerResponsableLista(List<int> ids)
        {
            try
            {
                this.open_db();
                foreach(int id_res in ids)
                {
                MySqlCommand MyCommand1 = new MySqlCommand("select id_alumno from alumno where id_responsable = '" + id_res + "'", conexion);
                MySqlDataReader re = MyCommand1.ExecuteReader();
                if (!(re.Read()))
                {
                    conexion.Close();
                    this.open_db();
                    MySqlCommand MyCommand = new MySqlCommand("delete from responsable where id_responsable like '" + id_res + "'", conexion);
                    MyCommand.ExecuteNonQuery();
                }
                }
                
                conexion.Close();

            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de escritura en base de Datos\r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

            }
            

        }



        /// <summary>
        /// Arma el listado de alumnos matriculados para presentar al seguro 
        /// </summary>
        /// <returns>
        /// List de Strings
        /// </returns>
        public List<List<string>> listadoSeguro()
        {
            List<List<string>> datos = new List<List<string>>();
            List<string> d = new List<string>();

            try
            {
                this.open_db();
//                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, direccion from alumno where id_alumno IN(select id_alumno from matricula) order by apellido asc;", conexion);
                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, direccion from alumno where activo = '1' order by apellido asc;", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    d = new List<string>();
                    d.Add(MyDataReader.GetValue(0).ToString());//nombre
                    d.Add(MyDataReader.GetValue(1).ToString());//apellido
                    d.Add(MyDataReader.GetValue(2).ToString());//dni
                    d.Add(Convert.ToDateTime(MyDataReader.GetValue(3)).ToString("dd-MM-yyyy"));//fecha nacimiento
                    d.Add(MyDataReader.GetValue(4).ToString() + " " + MyDataReader.GetValue(5).ToString());//telefono
                    d.Add(MyDataReader.GetValue(6).ToString());//direccion
                    datos.Add(d);
                }
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos al recuperar el listado: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datos;
        }

        /// <summary>
        /// Arma el listado de alumnos del curso pasado como parametro para la toma de asistencia
        /// </summary>
        /// <param name="curso">int: id del curso del cual se quiere obtener el listado de alumnos</param>
        /// <returns>
        /// List de Strings
        /// </returns>
        public List<List<string>> listaAsistencia(int curso)
        {
            List<List<string>> datos = new List<List<string>>();
            List<string> d = new List<string>();

            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni from alumno where id_alumno IN(select id_alumno from matricula);", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                while (MyDataReader.Read())
                {
                    d = new List<string>();
                    d.Add(MyDataReader.GetValue(0).ToString());//nombre
                    d.Add(MyDataReader.GetValue(1).ToString());//apellido
                    d.Add(MyDataReader.GetValue(2).ToString());//dni
                    datos.Add(d);
                }
                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos al recuperar el listado: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return datos;
        }

        /// <summary>
        /// Valida que el responsable no tenga asociado un alumno
        /// </summary>
        /// <remarks> Utilizado para deshacer la carga de un responsable que no fue asignado.
        /// Se valida por seguridad, para no eliminar una referencia activa en la base de datos, quedando ésta inconsistente.</remarks>
        /// <param name="id">
        /// int: dni valido.
        /// </param>
        /// <returns>
        ///true= si no tiene alumnos asociados
        ///false= si tiene alumnos asociados
        /// </returns>
        internal bool validoEliminarResponsable(int id)
        {

            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select id_responsable from responsable where id_responsable IN (select id_responsable from alumno) AND id_responsable = '" + id + "'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();

                if (MyDataReader.Read())
                {
                    conexion.Close();
                    return false;
                }
                else
                {
                    conexion.Close();
                    return true;
                }

            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
                MessageBox.Show("Error de lectura en base de Datos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        /// <summary>
        /// Busca alumnos por una porcion de su apellido
        /// </summary>
        /// <param name="apellido">String: porcion de apellido</param>
        /// <returns>List Alumnos: listado de alumnos que coinciden con el criterio de busqueda</returns>
        internal List<Alumno> Buscar_Alumno_Por_apellido(string apellido)
        {
            List<Alumno> alum = new List<Alumno>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select id_alumno,nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, escuela_nombre, escuela_año, id_responsable, email " +
                                                          "from alumno " +
                                                          "where apellido like '" + apostrofos(apellido) +"%' and activo = true", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Alumno alum_tem = new Alumno();

                         

                if (reader.Read())
                {
                    do
                    {
                        alum_tem.id_alumno = (Convert.ToInt32(reader[0]));
                        alum_tem.setNombre(reader[1].ToString());
                        alum_tem.setApellido(reader[2].ToString());
                        alum_tem.setDni(reader[3].ToString());
                        alum_tem.setTelefono_carac(reader[4].ToString());
                        alum_tem.setTelefono_numero(reader[5].ToString());
                        alum_tem.setFecha_nac(Convert.ToDateTime(reader[6]));
                        alum_tem.setDireccion(reader[7].ToString());
                        alum_tem.setEscuela_nombre(reader[8].ToString());
                        alum_tem.setEscuela_año(Convert.ToInt32(reader[9].ToString()));
                        alum_tem.setId_responsable(Convert.ToInt32(reader[10].ToString()));
                        alum_tem.setEmail(reader[11].ToString());

                        alum.Add(alum_tem); //agrega a la lista de retorno

                        alum_tem = new Alumno();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Alumnos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return alum;
        }

        /// <summary>
        /// Busca un responsable por su apellido o parte de el
        /// </summary>
        /// <param name="apellido">String: porcion de apellido</param>
        /// <returns>List de Responsabl: Responsables que cumplieron con el criterio</returns>
        internal List<Responsable> Buscar_Responsable_Por_apellido(string apellido)
        {
            List<Responsable> responsables = new List<Responsable>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select id_responsable,nombre_respon, apellido_respon, dni, telefono_carac, telefono_numero, fecha_nac, direccion, email " +
                                                          "from responsable " +
                                                          "where apellido_respon like '" + apostrofos(apellido) + "%'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Responsable respon_tem = new Responsable();



                if (reader.Read())
                {
                    do
                    {
                        respon_tem.setIdResponsable(Convert.ToInt32(reader[0]));
                        respon_tem.setNombre(reader[1].ToString());
                        respon_tem.setApellido(reader[2].ToString());
                        respon_tem.setDni(Convert.ToInt32(reader[3]));
                        respon_tem.setTelefono_carac(Convert.ToInt32(reader[4]));
                        respon_tem.setTelefono_numero(Convert.ToInt32(reader[5]));
                        respon_tem.setFecha_nac(Convert.ToDateTime(reader[6]));
                        respon_tem.setDireccion(reader[7].ToString());
                        respon_tem.setEmail(reader[8].ToString());

                        responsables.Add(respon_tem); //agrega a la lista de retorno

                        respon_tem = new Responsable();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Responsables: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return responsables;
        }



        /// <summary>
        /// Retorna todas las carreras que existen actualmente en el sistema
        /// </summary>
        /// <returns>List Profesorado</returns>
        internal List<Profesorado> getCarreras()
        {
            List<Profesorado> profesorado = new List<Profesorado>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select id_profesorado, nombre, niveles " +
                                                          "from profesorado " , conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Profesorado profesorado_tem = new Profesorado();

                if (reader.Read())
                {
                    do
                    {

                        profesorado_tem.id_profesorado = Convert.ToInt32(reader[0]);
                        profesorado_tem.nombre = reader[1].ToString();
                        profesorado_tem.niveles = Convert.ToInt32(reader[2].ToString());
                        
                        profesorado.Add(profesorado_tem); //agrega a la lista de retorno

                        profesorado_tem = new Profesorado();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Profesores: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return profesorado;
        }

        /// <summary>
        /// Retorna el listado de materias asociadas a un profeesorado
        /// </summary>
        /// <param name="id_prof">id del profesorado a buscar</param>
        /// <param name="nivel">nivel para el cual se buscan materias</param>
        /// <param name="turno">String turno para el cual se buscan materias</param>
        /// <returns></returns>
        internal List<Materia> getMaterias(int id_prof,int nivel, string turno)
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select m.id_materia, m.id_profesorado, nivel, nombre " +
                                                          "from materia m join turno t on m.id_materia=t.id_materia " +
                                                          "where id_profesorado = " + id_prof + " and nivel = " + nivel + 
                                                          " and t.turno like '" + turno + "'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Materia materia_tem = new Materia();

                if (reader.Read())
                {
                    do
                    {

                        materia_tem.id_materia = Convert.ToInt32(reader[0].ToString());
                        materia_tem.id_profesorado = Convert.ToInt32(reader[1].ToString());
                        materia_tem.nivel = Convert.ToInt32(reader[2].ToString());
                        materia_tem.nombre = reader[3].ToString();
                        materia_tem.cargar();

                        materias.Add(materia_tem); //agrega a la lista de retorno

                        materia_tem = new Materia();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return materias;
        }


        /// <summary>
        /// Busca un profesor por su id de profesor
        /// </summary>
        /// <param name="id_profesor">id del profesor a buscar</param>
        /// <returns></returns>
        internal Profesor Buscar_Profesor(int id_profesor)
        {
            Profesor profe = new Profesor();
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select id_profesor,nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, email " +
                                                          "from profesor " +
                                                          "where id_profesor = " + id_profesor + " and activo = 1", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    profe.id_profesor = Convert.ToInt32(reader[0].ToString());
                    profe.setNombre(reader[1].ToString());
                    profe.setApellido(reader[2].ToString());
                    profe.setDni(reader[3].ToString());
                    profe.setTelefono_carac(Convert.ToInt32(reader[4].ToString()));
                    profe.setTelefono_numero(Convert.ToInt32(reader[5].ToString()));
                    profe.setFecha_nac(Convert.ToDateTime(reader[6]));
                    profe.setDireccion(reader[7].ToString());
                    profe.setMail(reader[8].ToString());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Profesores: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return profe;
        }

        /// <summary>
        /// Recupera los turnos disponibles para una materia especifica
        /// </summary>
        /// <param name="id_materia">materia para la que se buscan los turnos</param>
        /// <returns>List Turno: turnos asociados a la materia</returns>
        internal List<Turno> getTurno(int id_materia)
        {
            List<Turno> listado_turno = new List<Turno>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select id_turno, id_profesor, turno, cupo, id_materia " +
                                                          "from turno " +
                                                          "where id_materia = " + id_materia , conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Turno turno_tem = new Turno();

                if (reader.Read())
                {
                    do
                    {
                        turno_tem.id_turno = Convert.ToInt32(reader[0].ToString());
                        turno_tem.id_profesor = Convert.ToInt32(reader[1].ToString());
                        turno_tem.turno = reader[2].ToString();
                        turno_tem.cupo = Convert.ToInt32(reader[3].ToString());
                        turno_tem.materia = Convert.ToInt32(reader[4].ToString());
                        turno_tem.cargar();

                        listado_turno.Add(turno_tem);

                        turno_tem = new Turno();

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Turnos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado_turno;
        }


        /// <summary>
        /// Verifica si un alumno tiene matricula en un profesorado especificado
        /// </summary>
        /// <param name="id_alumno">id del alumno a buscar</param>
        /// <param name="id_profesorado">id del profesorado a verificar</param>
        /// <returns>-1 : si no tiene matricula que cumpla las condiciones
        /// matricula: si existe registro para lo solicitado</returns>
        public int tieneMatriculaProfesorado(int id_alumno, int id_profesorado) 
        {

            int matricula = -1;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select id_matricula " +
                                                          "from matricula " +
                                                          "where id_alumno = " + id_alumno + " and id_profesorado = "+ id_profesorado, conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0]);
                }
                else
                {
                    conexion.Close();
                    
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return matricula;
                }

            }


            return matricula;
        }


        /// <summary>
        /// genera una matricula nueva para un alumno que no esta ya inscripto
        /// </summary>
        /// <param name="id_alumno">id del alumno a inscribir</param>
        /// <param name="id_profesorado">id del profesorado seleccionado</param>
        /// <returns>-1: si no pudo generar la matricula 
        /// nuevo numero matricula: si pudo obtener una nueva matricula</returns>
        internal int generarMatriculaProfesorado(int id_alumno, int id_profesorado)
        {
            int matricula = -1;

            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand ;
            
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                

                MyCommand = new MySqlCommand("insert into matricula (id_profesorado, id_alumno) values (" + id_profesorado + "," + id_alumno +")", conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;
                
                
                MyCommand.ExecuteNonQuery();

                



                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MyCommand = new MySqlCommand("select id_matricula " +
                                             "from matricula " +
                                             "where id_alumno = " + id_alumno + 
                                             " and id_profesorado = " + id_profesorado, conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0]);
                    reader.Close();
                    transaccion.Commit();
                }
                else
                {
                    transaccion.Rollback();
                    matricula = -1;
                    conexion.Close();
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Profesores: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return matricula;
                }

            }


            return matricula;
        }


        /// <summary>
        /// Recupera las materias del alumno para un profesorado especificado
        /// </summary>
        /// <param name="id_profesorado"></param>
        /// <param name="id_alumno"></param>
        /// <returns>Listado de Materias que tiene asociadas el alumno</returns>
        internal List<Materia> getMateriasAlumno(int id_profesorado, int id_alumno )
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                
                //selecciono solo las materias del nivel y profesorado especificados
                MySqlCommand MyCommand = new MySqlCommand("select mat.id_materia,t.turno, m.id_profesorado, nivel, nombre ,condicion " +
                                                          "from registro_materia rm, matricula m,materia mat,turno t " +
                                                          "where rm.id_matricula=m.id_matricula and t.id_turno = rm.id_turno and t.id_materia = rm.id_materia " +
                                                          "and mat.id_materia = rm.id_materia " +
                                                          "and m.id_profesorado = " + id_profesorado + " and m.id_alumno = " + id_alumno +
                                                          " and rm.condicion like 'inscripto' and rm.regular = 0 and rm.libre = 0 and rm.aprobada = 0", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Materia materia_tem = new Materia();

                if (reader.Read())
                {
                    do
                    {

                        materia_tem.id_materia = Convert.ToInt32(reader[0].ToString());
                        materia_tem.turno = reader[1].ToString();
                        materia_tem.id_profesorado = Convert.ToInt32(reader[2].ToString());
                        materia_tem.nivel = Convert.ToInt32(reader[3].ToString());
                        materia_tem.nombre = reader[4].ToString();
                        materia_tem.condicion = reader[5].ToString();
                        //materia_tem.cargar(); //no hace falta cargar los turno es solo la materia del alumno recuperada
                        

                        materias.Add(materia_tem); //agrega a la lista de retorno

                        materia_tem = new Materia();

                    } while (reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return materias;
        }


        /// <summary>
        /// Verifica si un alumno esta inscripto en una materia de un profesorado
        /// </summary>
        /// <param name="id_profesorado">id del profesorado a filtrar</param>
        /// <param name="id_materia">id de la materia a checkear</param>
        /// <param name="id_alumno">id del alumno asociado a la materia</param>
        /// <param name="turno">String del turno a verificar</param>
        /// <param name="condicion">String condicion que se quiere verificar</param>
        /// <returns></returns>
        public bool esta_Inscripto_Materia(int id_profesorado,int id_materia,int id_alumno, string turno, string condicion) {

            bool esta_Inscripto = false;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                //selecciono solo las materias del nivel y profesorado especificados
                MySqlCommand MyCommand = new MySqlCommand("select rm.id_materia " +
                                                          "from registro_materia rm, matricula m,materia mat,turno t " +
                                                          "where rm.id_matricula=m.id_matricula and t.id_turno = rm.id_turno and t.id_materia = rm.id_materia " +
                                                          "and mat.id_materia = rm.id_materia and rm.id_materia = "+id_materia+ " and turno like '"+ turno +"' " +
                                                          "and m.id_profesorado = " + id_profesorado + " and m.id_alumno = " + id_alumno +
                                                          " and rm.condicion like '"+condicion+"' and rm.regular = 0 and rm.libre = 0 and rm.aprobada = 0", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Materia materia_tem = new Materia();

                if (reader.Read())
                {
                    esta_Inscripto = true;
                }
                else
                {
                    conexion.Close();
                    esta_Inscripto = false;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    esta_Inscripto = false;
                }

            }


            return esta_Inscripto;
        }

        /// <summary>
        /// Verifica el cupo i ocupacion de una materia y turno dados
        /// </summary>
        /// <param name="id_materia">la materia a verificar</param>
        /// <param name="turno">el turno de la materia a verificar</param>
        /// <returns>disponible = 0: si no quedan lugares 
        /// disponible > 0 si quedan "disponible" lugares
        /// disponible = -1  si error</returns>
        public int verificarCupoMateria(int id_materia,string turno) 
        {


            int disponible = -1;
            int cupo = 0;
            int ocupacion = 0;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand cupo_comand = new MySqlCommand("select t.cupo Cupo " +
                                                          "from turno t "+
                                                          "where t.id_materia = "+id_materia+" and t.turno like '"+ turno + "' ", conexion);

                MySqlDataReader cupo_reader = cupo_comand.ExecuteReader();

                if (cupo_reader.Read())
                {
                    cupo = Convert.ToInt32(cupo_reader[0].ToString());
                    
                    cupo_reader.Close(); //cierro el datareader

                MySqlCommand ocupacion_comand = new MySqlCommand("select count(rm.id_matricula) Ocupacion " +
                                                          "from turno t join registro_materia rm on t.id_materia = rm.id_materia and t.id_turno = rm.id_turno " +
                                                          "where t.id_materia = " + id_materia + " and t.turno like '" + turno + "' " +
                                                          "and condicion like 'inscripto' " +
                                                          "group by rm.id_materia", conexion);

                MySqlDataReader ocupacion_reader = ocupacion_comand.ExecuteReader();
                
                    if (ocupacion_reader.Read())
                    {

                        ocupacion = Convert.ToInt32(ocupacion_reader[0].ToString());
                        disponible = cupo - ocupacion;
                        ocupacion_reader.Close();
                    }
                     else
                    { //significa que no hay inscriptos al la materia

                            disponible = cupo;

                    }
                
                }
                else
                {
                    conexion.Close();
                    disponible = -1;
                }           

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    disponible = -1;
                }

            }


            return disponible;

        
        }

        /// <summary>
        /// Registra la inscripcion de un alumno a una lista de materias
        /// </summary>
        /// <param name="nuevo">alumno que se inscribe</param>
        /// <param name="id_profesorado">profesorado al que se inscribe</param>
        /// <param name="mat_select">listado de materias a la que se inscribe el alumno</param>
        /// <param name="turno">turno en el cual se inscribe</param>
        /// <returns></returns>

        internal List<Inscripto> inscribirMaterias(Alumno nuevo, int id_profesorado, List<Materia> mat_select, string turno)
        {

            int matricula = nuevo.id_matricula; 
            List<Inscripto> listado_inscripciones = new List<Inscripto>(); //listado donde se registraran las inscripciones y condicion en que quedo
            Inscripto inscripto_tmp = null;
            MySqlTransaction transaccion;
            MySqlCommand MyCommand;


            //creo coneccion dedicada
            MySqlConnection db_inscribe = new MySqlConnection(cadena_coneccion);
            try
            {
                db_inscribe.Open();
                //genero transaccion y comando para ejecucion
                transaccion = db_inscribe.BeginTransaction(); 
                MyCommand = new MySqlCommand();
                MyCommand.Connection = db_inscribe;
                MyCommand.Transaction = transaccion;
                
            }
            catch(MySqlException excep) {
                MessageBox.Show("Error de lectura en base de Datos: \r\n" + excep, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
            try
            {

                    foreach (Materia materia_actual in mat_select)
                    {
                        int disponible;
                        if (materia_actual.condicion.Contains("inscripto"))
                        {
                            disponible = verificarCupoMateria(materia_actual.id_materia, turno);
                        }
                        else {
                            disponible = 0;

                        }

                        if (disponible <= 0)
                        { //si el disponible es 0 
                            DialogResult resultado;
                            if (materia_actual.condicion.Contains("condicional"))
                            {
                                resultado = MessageBox.Show("El alumno se inscribira en forma condicional\r\na la Materia: " + materia_actual.nombre + "\r\n\r\n ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            }
                            else
                                resultado = MessageBox.Show("El alumno se inscribira en forma condicional\r\na la Materia: " + materia_actual.nombre + "\r\n\r\nPor falta de cupo\r\n\r\n ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                            if (resultado == DialogResult.Yes)
                            {
                                MyCommand.CommandText = ("insert into registro_materia (id_matricula, id_materia, fecha, hora, id_turno, " +
                                                             " condicion) values " +
                                                             "(" + matricula + "," + materia_actual.id_materia + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                             "','" + DateTime.Now.ToString("HH:mm:ss") + "'," + materia_actual.get_id_turno(turno) +
                                                             ",'condicional' )");


                                MyCommand.ExecuteNonQuery();
                            }
                            
                        
                        }
                        else{  //si quedara inscripto

                            if (disponible > 0)
                            {
                                MyCommand.CommandText = ("insert into registro_materia (id_matricula, id_materia, fecha, hora, id_turno,condicion) values " +
                                                         "(" + matricula + "," + materia_actual.id_materia + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                         "','" + DateTime.Now.ToString("HH:mm:ss") + "'," + materia_actual.get_id_turno(turno) +
                                                         ", 'inscripto' )");

                                MyCommand.ExecuteNonQuery();
                                //transaccion.Commit();

                            }
                            else {
                                transaccion.Rollback();
                                MessageBox.Show("Error al intentar inscribir Alumno en la materia\r\n Problemas de cupo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }



                        //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                        MyCommand.CommandText = "select id_inscripcion_materia,condicion " +
                                                     "from registro_materia " +
                                                     "where id_matricula = " + matricula +
                                                     " and  id_materia= " + materia_actual.id_materia ;

                        MySqlDataReader reader = MyCommand.ExecuteReader();

                        

                        if (reader.Read())
                        {

                            inscripto_tmp = new Inscripto();
                            //cargo el id de la transaccion
                            inscripto_tmp.id_inscripcion_materia = Convert.ToInt32(reader[0].ToString());
                            
                            //cargo la condicion en que se asigno al curos
                            inscripto_tmp.condicion = reader[1].ToString();

                            //cargo la materia para registro futuro
                            inscripto_tmp.materia_inscripta = materia_actual;
                            inscripto_tmp.turno = turno;

                            listado_inscripciones.Add(inscripto_tmp);
                            reader.Close();
                            
                        }
                        else
                        {
                            reader.Close();
                                                        
                        }
                    }

                    transaccion.Commit();
                    if (db_inscribe.State == System.Data.ConnectionState.Open)
                        db_inscribe.Close();
            }
            catch (MySqlException e)
            {
                if ( db_inscribe.State == System.Data.ConnectionState.Open)
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                    db_inscribe.Close();
                    MessageBox.Show("Error de lectura en base de Datos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado_inscripciones;


        }

        /// <summary>
        /// Devuelve una lista con los cursos que se dictan en el instituto
        /// </summary>
        /// <returns>Lista de string con los nombres de los cursos</returns>
        public List<List<string>> getCursos()
        {
            List<List<string>> cursos = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select c.id_curso, c.nombre, n.nombre, a.nombre " +
                                                          "from curso c, nivel n, area a " +
                                                          "where c.nivel = n.nivel AND c.id_area = a.id_area", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> curso;

                if (reader.Read())
                {
                    do
                    {
                        curso = new List<string>();
                        curso.Add(reader[0].ToString());
                        curso.Add(reader[1].ToString());
                        curso.Add(reader[2].ToString());
                        curso.Add(reader[3].ToString());

                        cursos.Add(curso);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return cursos;
        }

        /// <summary>
        /// Devuelve una lista con los cursos especiales que se dictan en el instituto
        /// </summary>
        /// <returns>Lista de string con los nombres de los cursos especiales</returns>
        public List<List<string>> getCursosEsp()
        {
            List<List<string>> cursos = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select c.id_curso_especial, c.nombre, a.nombre " +
                                                          "from curso_especial c, area a " +
                                                          "where c.id_area = a.id_area", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> curso;

                if (reader.Read())
                {
                    do
                    {
                        curso = new List<string>();
                        curso.Add(reader[0].ToString());
                        curso.Add(reader[1].ToString());
                        curso.Add(reader[2].ToString());

                        cursos.Add(curso);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return cursos;
        }

        /// <summary>
        /// Devuelve una lista con las materias que se dictan en el instituto
        /// </summary>
        /// <returns>Lista de string con los nombres de las materias</returns>
        public List<List<string>> getMaterias()
        {
            List<List<string>> materias = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select p.nombre, p.niveles, m.id_materia, m.nombre, m.nivel, t.turno " +
                                                          "from profesorado p, materia m, turno t " +
                                                          "where m.id_profesorado = p.id_profesorado AND t.id_materia = m.id_materia", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> materia;

                if (reader.Read())
                {
                    do
                    {
                        materia = new List<string>();
                        materia.Add(reader[0].ToString());//nombre profesorado
                        materia.Add(reader[1].ToString());//niveles del profesorado
                        materia.Add(reader[2].ToString());//id materia
                        materia.Add(reader[3].ToString());//nombre materia
                        materia.Add(reader[4].ToString());//nivel de la materia
                        materia.Add(reader[5].ToString());//turnos de la materia

                        materias.Add(materia);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return materias;
        }

        

        /// <summary>
        /// Recupera cursos del sistema
        /// </summary>
        /// <param name="curso">String: id de curso</param>
        /// <returns>List de String de cursos</returns>
        public List<List<string>> getListadoCursos(string curso)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno as a, matricula as m, registro_curso r " +
                                                          "where r.id_curso = '" + curso + "' AND r.condicion = 'inscripto' AND r.id_matricula = m.id_matricula AND m.id_alumno = a.id_alumno", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> alumno;

                if (reader.Read())
                {
                    do
                    {
                        alumno = new List<string>();
                        alumno.Add(reader[0].ToString());
                        alumno.Add(reader[1].ToString());
                        alumno.Add(reader[2].ToString());

                        listado.Add(alumno);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }


        /// <summary>
        /// Método que recupera cursos especiales
        /// </summary>
        /// <param name="curso">id del curso especial a buscar</param>
        /// <returns>List de string de cursos especiales</returns>
        public List<List<string>> getListadoCursosEspeciales(string curso)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno as a, matricula as m, registro_curso_especial r " +
                                                          "where r.id_curso_especial = '" + curso + "' AND r.condicion = 'inscripto' AND r.id_matricula = m.id_matricula AND m.id_alumno = a.id_alumno", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> alumno;

                if (reader.Read())
                {
                    do
                    {
                        alumno = new List<string>();
                        alumno.Add(reader[0].ToString());
                        alumno.Add(reader[1].ToString());
                        alumno.Add(reader[2].ToString());

                        listado.Add(alumno);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }


        /// <summary>
        /// Método que retorna un Listado de materias
        /// </summary>
        /// <param name="id_materia">string: id de la materia especificada</param>
        /// <param name="turno">string: id del turno seleccionado</param>
        /// <returns>Lsta de Materias</returns>
        public List<List<string>> getListadoMateria(string id_materia, string turno)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno a, registro_materia r, turno t, matricula m " +
                                                          "where r.id_materia = '" + id_materia + "' AND t.turno = '" + turno + "' AND t.id_materia = '" + id_materia + "' AND t.id_turno = r.id_turno  AND r.condicion = 'inscripto' AND r.id_matricula = m.id_matricula AND m.id_alumno = a.id_alumno", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> alumno;

                if (reader.Read())
                {
                    do
                    {
                        alumno = new List<string>();
                        alumno.Add(reader[0].ToString());
                        alumno.Add(reader[1].ToString());
                        alumno.Add(reader[2].ToString());

                        listado.Add(alumno);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }


        /// <summary>
        /// Verifica si un alumno esta condicional en una materia
        /// Condicional respecto a su estado de inscripcion
        /// </summary>
        /// <param name="id_mat">id de la materia a verificar</param>
        /// <param name="id_matricula">id matricula del alumno</param>
        /// <returns>-1: si no hay registro
        /// 0: si condicional
        /// 1: si inscripto</returns>
        internal int condicion(int id_mat, int id_matricula)
        {

            int condicion = -1;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand condicion_command = new MySqlCommand("select condicion " +
                                                          "from registro_materia " +
                                                          "where  id_materia = " + id_mat + " and id_matricula = " + id_matricula, conexion);

                MySqlDataReader condicion_reader = condicion_command.ExecuteReader();

                if (condicion_reader.Read())
                {
                    string cond = condicion_reader[0].ToString();

                    if (cond.Contains("condicional"))
                        condicion = 0;
                    else
                    {
                        if (cond.Contains("inscripto"))
                            condicion = 1;
                    }
                }
                else
                {
                    conexion.Close();
                    condicion = -1;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos registro materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    condicion = -1;
                }

            }


            return condicion;
        }


        

        /// <summary>Inscribir un alumno a una lista de cursos</summary>
        /// <param name="nuevo">alumno que se va a inscribir a cursos</param>
        /// <param name="curso_select">Curso al que se va a inscribir el alumno</param>
        /// <returns>Inscripto_curso: registro del curso y condicion en que quedo el alumno</returns>

        internal Inscripto_curso inscribirCursos(Alumno nuevo,Curso curso_select)
        {

            int matricula = nuevo.id_matricula;
            Inscripto_curso inscripcion_curso = new Inscripto_curso(); //listado donde se registraran las inscripciones y condicion en que quedo
            Inscripto_curso inscripto_tmp = null;
            MySqlTransaction transaccion;
            MySqlCommand MyCommand;


            //creo coneccion dedicada
            MySqlConnection db_inscribe = new MySqlConnection(cadena_coneccion);
            try
            {
                db_inscribe.Open();
                //genero transaccion y comando para ejecucion
                transaccion = db_inscribe.BeginTransaction();
                MyCommand = new MySqlCommand();
                MyCommand.Connection = db_inscribe;
                MyCommand.Transaction = transaccion;

            }
            catch (MySqlException excep)
            {
                MessageBox.Show("Error de lectura en base de Datos: \r\n" + excep, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {

               
                int disponible;

                if (curso_select.condicion.Contains("condicional"))
                {
                    disponible = 0;
                }
                else
                {
                    disponible = verificarCupoCurso(curso_select.id_curso);
                }

                if (disponible <= 0)
                { //si el disponible es 0 
                    DialogResult resultado;
                    if (curso_select.condicion.Contains("condicional"))
                    {
                        resultado = MessageBox.Show("El alumno se inscribira en forma condicional\r\nal Curso: " + curso_select.nombre + "\r\n\r\n ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                        resultado = MessageBox.Show("El alumno se inscribira en forma condicional\r\nal Curso: " + curso_select.nombre + "\r\n\r\nPor falta de cupo\r\n\r\n ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {

                        MyCommand.CommandText = ("insert into registro_curso (id_matricula, id_curso, fecha, hora, condicion) values " +
                                                     "(" + matricula + "," + curso_select.id_curso + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +"', "+
                                                     "' "+ DateTime.Now.ToString("HH:mm:ss") + "','condicional' )");


                        MyCommand.ExecuteNonQuery();
                        //transaccion.Commit();
                    }

                    else
                    {
                        MyCommand.CommandText = ("delete from matricula where id_matricula = " + matricula + " and id_curso = " + curso_select.id_curso);
                        MyCommand.ExecuteNonQuery();
                        transaccion.Commit();
                        transaccion = null;

                    }
                }
                else
                {  //si quedara inscripto

                    if (disponible > 0)
                    {
                        MyCommand.CommandText = ("insert into registro_curso (id_matricula, id_curso, fecha, hora, condicion) values " +
                                                 "(" + matricula + "," + curso_select.id_curso + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                 "','" + DateTime.Now.ToString("HH:mm:ss") + "'," +
                                                 " 'inscripto' )");

                        MyCommand.ExecuteNonQuery();
                        //transaccion.Commit();

                    }
                    else
                    {
                        transaccion.Rollback();
                        MessageBox.Show("Error al intentar inscribir Alumno en el curso\r\n Problemas de cupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



                    //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                    MyCommand.CommandText = "select id_registro_curso,condicion " +
                                                 "from registro_curso " +
                                                 "where id_matricula = " + matricula +
                                                 " and  id_curso= " + curso_select.id_curso;

                    MySqlDataReader reader = MyCommand.ExecuteReader();



                    if (reader.Read())
                    {

                        inscripto_tmp = new Inscripto_curso();
                        //cargo el id de la transaccion
                        inscripto_tmp.id_inscripcion_curso = Convert.ToInt32(reader[0].ToString());

                        //cargo la condicion en que se asigno al curos
                        inscripto_tmp.condicion = reader[1].ToString();

                        //cargo la materia para registro futuro
                        inscripto_tmp.curso_inscripto = curso_select;


                        inscripcion_curso =inscripto_tmp;
                        reader.Close();
                        transaccion.Commit();
                        
                    }
                    else
                    {
                        reader.Close();
                        if (transaccion != null)
                            transaccion.Rollback();

                        matricula = -1;
                        db_inscribe.Close();
                    }
                

                
                if (db_inscribe.State == System.Data.ConnectionState.Open)
                    db_inscribe.Close();
            }
            catch (MySqlException e)
            {
                if (db_inscribe.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    db_inscribe.Close();
                    MessageBox.Show("Error de lectura en base de Datos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return inscripcion_curso;


        }


        /// <summary>
        /// Mpetodo que retorna el listado de cursosEspeciales para un area en especial 
        /// </summary>
        /// <returns>
        /// Lista de Cursos
        /// </returns>
        public List<CursosEsp> getCursoEspecial(string area)
        {
            List<CursosEsp> cursos = new List<CursosEsp>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select id_curso_especial, c.nombre, horas_curso, id_profesor, cupo, c.id_area " +
                                                          "from curso_especial c join area a on c.id_area=a.id_area " +
                                                          "where a.nombre like '" + apostrofos(area)+"'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                CursosEsp curso = new CursosEsp();

                if (reader.Read())
                {
                    do
                    {
                        curso.id_curso = Convert.ToInt32(reader[0].ToString());
                        curso.nombre = reader[1].ToString();
                        curso.horas = Convert.ToInt32(reader[2].ToString());
                        curso.id_profesor = Convert.ToInt32(reader[3].ToString());
                        curso.cupo = Convert.ToInt32(reader[4].ToString());
                        curso.area = Convert.ToInt32(reader[5].ToString());

                        cursos.Add(curso);
                        curso = new CursosEsp();

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return cursos;
        }


        /// <summary>
        /// Retorna el listado de cursos para un area en especial 
        /// </summary>
        /// <returns>
        /// Retorna una lista de Cursos existentes asociados al area
        /// </returns>
        public List<Curso> getCurso(string area,string nivel)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select id_curso, c.nombre, c.nivel, duracion, id_profesor, cupo, c.id_area " +
                                                          "from curso c, area a , nivel n  " +
                                                          "where c.id_area=a.id_area and c.nivel = n.nivel "+ 
                                                          "and a.nombre like '" + apostrofos(area) + "'" + " and n.nombre like '"+ nivel+"'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Curso curso = new Curso();

                if (reader.Read())
                {
                    do
                    {
                        curso.id_curso = Convert.ToInt32(reader[0].ToString());
                        curso.nombre = reader[1].ToString();
                        curso.nivel = Convert.ToInt32(reader[2].ToString());
                        curso.duracion = Convert.ToInt32(reader[2].ToString());
                        curso.id_profesor = Convert.ToInt32(reader[3].ToString());
                        curso.cupo = Convert.ToInt32(reader[4].ToString());
                        curso.id_area = Convert.ToInt32(reader[5].ToString());


                        cursos.Add(curso);
                        curso = new Curso();

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return cursos;
        }



/// <summary>
/// retorna las areas registradas en el sistema
/// </summary>
/// <returns></returns>
        internal List<List<string>> getAreas()
        {

            List<List<string>> listado_retorno = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select id_area, nombre " +
                                                          "from area", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> area = new List<string>();

                
                if (reader.Read())
                {
                    do
                    {
                        area.Add(reader[0].ToString());
                        area.Add(reader[1].ToString());


                        listado_retorno.Add(area);

                        area = new List<string>();

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado_retorno;
        }

        /// <summary>
        /// Recupera los niveles disponibles en el sistema
        /// </summary>
        /// <returns>List string de niveles disponibles</returns>
        internal List<string> getNiveles()
        {
            List<string> listado = new List<string>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select nombre " +
                                                          "from nivel ", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                

                if (reader.Read())
                {
                    do
                    {
                        
                        listado.Add(reader[0].ToString());

                       

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }


        /// <summary>
        /// Rutina para la inscripcion en base de datos de los cursos que selecciono el alumno por pantalla
        /// para esto se debe contar ya con matricula y se deben haber seleccionado almenos 1 curso
        /// </summary>
        /// <param name="nuevo">El objeto Alumno de interes</param>
        /// <param name="curso_select">Curso en que se inscribe</param>
        internal InscriptoCursoEsp inscribirCursosEspeciales(Alumno nuevo, CursosEsp curso_select)
        {

            int matricula = nuevo.id_matricula; //recupero la matricula que utilizare mas adelante
            InscriptoCursoEsp inscripto_tmp = null;
            MySqlTransaction transaccion;
            MySqlCommand MyCommand;


            //creo coneccion dedicada
            MySqlConnection db_inscribe = new MySqlConnection(cadena_coneccion);
            try
            {
                db_inscribe.Open();
                //genero transaccion y comando para ejecucion
                transaccion = db_inscribe.BeginTransaction();
                MyCommand = new MySqlCommand();
                MyCommand.Connection = db_inscribe;
                MyCommand.Transaction = transaccion;

            }
            catch (MySqlException excep)
            {
                MessageBox.Show("Error de lectura en base de Datos: \r\n" + excep, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                int disponible;

                if (curso_select.condicion.Contains("condicional"))
                {
                    disponible = 0;
                }
                else
                {
                    disponible = verificarCupoCursoEspecial(curso_select.id_curso);
                }

                if (disponible <= 0)
                { //si el disponible es 0 
                    DialogResult resultado;
                    if (curso_select.condicion.Contains("condicional"))
                    {
                        resultado = MessageBox.Show("El alumno se inscribira en forma condicional\r\nal Curso: " + curso_select.nombre + "\r\n\r\n ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                    else
                        resultado = MessageBox.Show("El alumno se inscribira en forma condicional\r\nal Curso: " + curso_select.nombre + "\r\n\r\nPor falta de cupo\r\n\r\n ¿Desea continuar?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {

                        MyCommand.CommandText = ("insert into registro_curso_especial (id_matricula, id_curso_especial, fecha, hora, condicion) values " +
                                                     "(" + matricula + "," + curso_select.id_curso + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                     "','" + DateTime.Now.ToString("HH:mm:ss") + "','condicional' )");


                        MyCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        MyCommand.CommandText = ("delete from matricula where id_matricula = " + matricula + " and id_curso_especial = " + curso_select.id_curso);
                        MyCommand.ExecuteNonQuery();
                        transaccion.Commit();
                        transaccion = null;

                    }
                    //transaccion.Commit();
                }
                else
                {  //si quedara inscripto

                    if (disponible > 0)
                    {
                        MyCommand.CommandText = ("insert into registro_curso_especial (id_matricula, id_curso_especial, fecha, hora, condicion) values " +
                                                 "(" + matricula + "," + curso_select.id_curso + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                 "','" + DateTime.Now.ToString("HH:mm:ss") + "','inscripto' )");

                        MyCommand.ExecuteNonQuery();
                        //transaccion.Commit();

                    }
                    else
                    {
                        transaccion.Rollback();
                        MessageBox.Show("Error al intentar inscribir Alumno al Curso\r\n Problemas de cupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }



                
                MyCommand.CommandText = "select id_registro_curso_especial,condicion " +
                                             "from registro_curso_especial " +
                                             "where id_matricula = " + matricula +
                                             " and  id_curso_especial = " + curso_select.id_curso;

                MySqlDataReader reader = MyCommand.ExecuteReader();



                if (reader.Read())
                {

                    inscripto_tmp = new InscriptoCursoEsp();
                    //cargo el id de la transaccion
                    inscripto_tmp.id_inscripcion_curso = Convert.ToInt32(reader[0].ToString());

                    //cargo la condicion en que se asigno al curos
                    inscripto_tmp.condicion = reader[1].ToString();

                    //cargo la materia para registro futuro
                    inscripto_tmp.curso_inscripto = curso_select;


                    reader.Close();
                    transaccion.Commit();
                }
                else
                {
                    reader.Close();
                    if (transaccion != null)
                        transaccion.Rollback();

                    matricula = -1;
                    db_inscribe.Close();
                }




                if (db_inscribe.State == System.Data.ConnectionState.Open)
                    db_inscribe.Close();
            }
            catch (MySqlException e)
            {
                if (db_inscribe.State == System.Data.ConnectionState.Open)
                {
                    if (transaccion != null)
                        transaccion.Rollback();
                    db_inscribe.Close();
                    MessageBox.Show("Error de lectura en base de Datos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return inscripto_tmp;
        }

        /// <summary>
        /// Verifica el cupo de cursos especiales
        /// </summary>
        /// <param name="id_curso">id de curso a verificar</param>
        /// <returns>{-1: si error}
        /// {cupo: si hay cupo}
        /// {0: si no hay cupo}</returns>
        private int verificarCupoCursoEspecial(int id_curso)
        {
            int disponible = -1;
            int cupo = 0;
            int ocupacion = 0;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                
                MySqlCommand cupo_comand = new MySqlCommand("select ce.cupo cupo " +
                                                          "from curso_especial ce " +
                                                          "where ce.id_curso_especial = " + id_curso, conexion);

                MySqlDataReader cupo_reader = cupo_comand.ExecuteReader();

                if (cupo_reader.Read())
                {
                    cupo = Convert.ToInt32(cupo_reader[0].ToString());

                    cupo_reader.Close(); //cierro el datareader

                    MySqlCommand ocupacion_comand = new MySqlCommand("select count(rm.id_matricula) Ocupacion " +
                                                              "from registro_curso_especial rm " +
                                                              "where rm.id_curso_especial = " + id_curso +
                                                              " and condicion like 'inscripto' " +
                                                              "group by rm.id_registro_curso_especial", conexion);

                    MySqlDataReader ocupacion_reader = ocupacion_comand.ExecuteReader();

                    if (ocupacion_reader.Read())
                    {

                        ocupacion = Convert.ToInt32(ocupacion_reader[0].ToString());
                        disponible = cupo - ocupacion;
                        ocupacion_reader.Close();
                    }
                    else
                    { //significa que no hay inscriptos al la materia

                        disponible = cupo;

                    }

                }
                else
                {
                    conexion.Close();
                    disponible = -1;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    disponible = -1;
                }

            }


            return disponible;

        }

        
        /// <summary>
        /// verifica si un alumno tiene matricula en un curso especial
        /// </summary>
        /// <param name="id_alumno">id del alumno</param>
        /// <param name="id_cursoEsp">id del curso a verificar</param>
        /// <returns>numero de matricula: si esta matriculado
        /// -1 si no existe matricula para el curso</returns>
        internal int tieneMatriculaCursoEspecial(int id_alumno, int id_cursoEsp)
        {
            int matricula = -1;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select id_matricula " +
                                                          "from matricula " +
                                                          "where id_alumno = " + id_alumno + " and id_curso_especial = " + id_cursoEsp, conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0]);
                }
                else
                {
                    conexion.Close();

                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return matricula;
                }

            }


            return matricula;

        }


        /// <summary>
        /// Genera un nuevo numero de matricula para el cusrso especial que se solicito
        /// </summary>
        /// <param name="id_alumno">el id del alumno a matricular</param>
        /// <param name="id_cursoEsp">el id del curso a matricular</param>
        /// <returns>retorna el nuevo numero de matricula o -1 en caso de error</returns>
        internal int generarMatriculaCursoEspecial(int id_alumno, int id_cursoEsp)
        {
            int matricula = -1;

            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();



                MyCommand = new MySqlCommand("insert into matricula (id_curso_especial, id_alumno) values (" + id_cursoEsp + "," + id_alumno + ")", conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;


                MyCommand.ExecuteNonQuery();





                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MyCommand = new MySqlCommand("select id_matricula " +
                                             "from matricula " +
                                             "where id_alumno = " + id_alumno +
                                             " and id_curso_especial = " + id_cursoEsp, conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0]);
                    reader.Close();
                    transaccion.Commit();
                }
                else
                {
                    transaccion.Rollback();
                    matricula = -1;
                    conexion.Close();
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return matricula;
                }

            }


            return matricula;
        }


        /// <summary>
        /// Retorna si el alumno esta inscripto en alguna condicion
        /// </summary>
        /// <param name="id_curso">el curso a consultar</param>
        /// <param name="id_alumno">al alumno en cuestion</param>
        /// <param name="condicion">la condicion inscripto o condicional</param>
        /// <returns></returns>
        public bool esta_Inscripto_CursoEsp(int id_curso, int id_alumno, string condicion)
        {

            bool esta_Inscripto = false;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                //selecciono solo las materias del nivel y profesorado especificados
                MySqlCommand MyCommand = new MySqlCommand("SELECT id_registro_curso_especial "+ 
                                                          "FROM registro_curso_especial r, matricula m " +
                                                          "where r.id_matricula = m.id_matricula "+
                                                          "and m.id_alumno = "+id_alumno+" and r.id_curso_especial = "+id_curso+" and condicion like '"+condicion+"'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Materia materia_tem = new Materia();

                if (reader.Read())
                {
                    esta_Inscripto = true;
                }
                else
                {
                    conexion.Close();
                    esta_Inscripto = false;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    esta_Inscripto = false;
                }

            }


            return esta_Inscripto;
        }



        /// <summary>
        /// Verifica si el alumno está matriculado en un curso
        /// </summary>
        /// <param name="id_alumno"></param>
        /// <param name="id_curso"></param>
        /// <returns>retorna la matricula del alumno o -1 en su defecto</returns>
        internal int tieneMatriculaCurso(int id_alumno, int id_curso)
        {
            int matricula = -1;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select id_matricula " +
                                                          "from matricula " +
                                                          "where id_alumno = " + id_alumno + " and id_curso = " + id_curso, conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0]);
                }
                else
                {
                    conexion.Close();

                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return matricula;
                }

            }


            return matricula;

        }


        /// <summary>
        /// Genera un nuevo numero de matricula para el cusrso que se solicito
        /// </summary>
        /// <param name="id_alumno">el id del alumno a matricular</param>
        /// <param name="id_curso">el id del curso a matricular</param>
        /// <returns>retorna el nuevo numero de matricula o -1 en caso de error</returns>
        internal int generarMatriculaCurso(int id_alumno, int id_curso)
        {
            int matricula = -1;

            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();



                MyCommand = new MySqlCommand("insert into matricula (id_curso, id_alumno) values (" + id_curso + "," + id_alumno + ")", conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;


                MyCommand.ExecuteNonQuery();





                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MyCommand = new MySqlCommand("select id_matricula " +
                                             "from matricula " +
                                             "where id_alumno = " + id_alumno +
                                             " and id_curso = " + id_curso, conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    matricula = Convert.ToInt32(reader[0]);
                    reader.Close();
                    transaccion.Commit();
                }
                else
                {
                    transaccion.Rollback();
                    matricula = -1;
                    conexion.Close();
                }

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return matricula;
                }

            }


            return matricula;
        }


        /// <summary>
        /// Verifica el cupo del curso
        /// </summary>
        /// <param name="id_curso"></param>
        /// <returns>retorna el cupo disponible del curso, 0 si no hay o -1 si error</returns>
        private int verificarCupoCurso(int id_curso)
        {            
            int disponible = -1;
            int cupo = 0;
            int ocupacion = 0;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                
                MySqlCommand cupo_comand = new MySqlCommand("select ce.cupo cupo " +
                                                          "from curso ce " +
                                                          "where ce.id_curso = " + id_curso, conexion);

                MySqlDataReader cupo_reader = cupo_comand.ExecuteReader();

                if (cupo_reader.Read())
                {
                    cupo = Convert.ToInt32(cupo_reader[0].ToString());

                    cupo_reader.Close(); //cierro el datareader

                    MySqlCommand ocupacion_comand = new MySqlCommand("select count(rm.id_matricula) Ocupacion " +
                                                              "from registro_curso rm " +
                                                              "where rm.id_curso = " + id_curso +
                                                              " and condicion like 'inscripto' " +
                                                              "group by rm.id_curso", conexion);

                    MySqlDataReader ocupacion_reader = ocupacion_comand.ExecuteReader();

                    if (ocupacion_reader.Read())
                    {

                        ocupacion = Convert.ToInt32(ocupacion_reader[0].ToString());
                        disponible = cupo - ocupacion;
                        ocupacion_reader.Close();
                    }
                    else
                    { //significa que no hay inscriptos al la materia

                        disponible = cupo;

                    }

                }
                else
                {
                    conexion.Close();
                    disponible = -1;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    disponible = -1;
                }

            }


            return disponible;

        }



        /// <summary>
        /// Convierte una cadena con apostrofos a su equivalene soportada por Mysql
        /// </summary>
        /// <param name="cadena">Cadena a ser transformada</param>
        /// <returns>Cadena con correccion de apostrofos</returns>
        private string apostrofos(string cadena) 
        {
            if (cadena != null)
            {
                string retorno = "";
                string cadena_tmp = "";

                cadena_tmp = cadena.Replace("\'", "#");

                retorno = cadena_tmp.Replace("#", "\\'");
                return retorno;
            }
            else
            {
                return cadena;
            }
          
        }



        /// <summary>
        /// Rutina para el cambio de estado manual de estado condicional a inscripto
        /// </summary>
        /// <param name="nuevo">Alumno que se asocia a la materia a cambiar de estado</param>
        /// <param name="id_mat">id de la materia a ser cambiada</param>
        /// <param name="id_turno">id de turno de la materia a ser cambiada</param>
        /// <returns></returns>
        internal bool cambiarEstado(Alumno nuevo, int id_mat, int id_turno)
        {
            

            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();



                MyCommand = new MySqlCommand("update registro_materia "+
                                              "set condicion = 'inscripto' "+
                                              "where id_materia = "+id_mat+" and id_turno = "+id_turno+" and id_matricula = "+nuevo.id_matricula, conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;


                MyCommand.ExecuteNonQuery();

                transaccion.Commit();

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
 
        }


        /// <summary>
        /// Determina si un alumno está inscripto a un curso
        /// </summary>
        /// <param name="nuevo">alumno al que se hace referencia</param>
        /// <param name="elemento">curso al que se hace referencia</param>
        /// <param name="condicion">Condicion que se quiere verificar</param>
        /// <returns>{true: si esta inscripto el alumno a ese curso y en esa condicion}
        /// {false: si el alumno NO esta inscripto al curso o NO esta en esa condicion}</returns>
        internal bool inscriptoACurso(Alumno nuevo, Curso elemento, string condicion)
        {

            bool esta_Inscripto = false;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                //selecciono solo las materias del nivel y profesorado especificados
                MySqlCommand MyCommand = new MySqlCommand("SELECT r.id_matricula, r.id_curso " +
                                                          "FROM registro_curso r, matricula m " +
                                                          " WHERE m.id_matricula = r.id_matricula and m.id_alumno = " + nuevo.id_alumno + " and r.id_curso = " + elemento.id_curso +" and r.condicion like '"+condicion+"' " , conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                

                if (reader.Read())
                {
                    esta_Inscripto = true;
                }
                else
                {
                    conexion.Close();
                    esta_Inscripto = false;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos con los cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    esta_Inscripto = false;
                }

            }


            return esta_Inscripto;
        }

        /// <summary>
        /// Cambia un curso de condicional a inscripto
        /// </summary>
        /// <param name="nuevo">Alumno asociado al curso</param>
        /// <param name="id_curso">id del curso a cambiar de estado</param>
        /// <returns>true: si exito
        /// false: si fallo</returns>
        internal bool cambiarEstadoCurso(Alumno nuevo, int id_curso)
        {


            int matricula = tieneMatriculaCurso(nuevo.id_alumno, id_curso);

            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();



                MyCommand = new MySqlCommand("update registro_curso " +
                                              "set condicion = 'inscripto' " +
                                              "where id_curso = " + id_curso + " and id_matricula = " + matricula, conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;


                MyCommand.ExecuteNonQuery();

                transaccion.Commit();

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
 
        }

        /// <summary>
        /// cambia el estado de un curso especial de condicional a inscripto
        /// </summary>
        /// <param name="nuevo">Alumno asociado al curso</param>
        /// <param name="id_curso">id del curso especial</param>
        /// <returns>true: si exito false: si fallo</returns>
        internal bool cambiarEstadoCursoEsp(Alumno nuevo, int id_curso)
        {
            int matricula = tieneMatriculaCursoEspecial(nuevo.id_alumno, id_curso);

            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();



                MyCommand = new MySqlCommand("update registro_curso_especial " +
                                              "set condicion = 'inscripto' " +
                                              "where id_curso_especial = " + id_curso + " and id_matricula = " + matricula, conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;


                MyCommand.ExecuteNonQuery();

                transaccion.Commit();

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
        }


        /// <summary>
        /// Obtiene el id de turno para una materia y turno especificado
        /// </summary>
        /// <param name="id_materia">id de la materia a buscar</param>
        /// <param name="turno">String: turno a consultar</param>
        /// <returns>-1: si error o turno inexistente
        /// id_turno: si turno existe y materia valida
        /// </returns>
        internal int obtener_Id_turno(int id_materia, string turno)
        {

            int turno_trabajo = -1;
            

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                
                    MySqlCommand id_turno = new MySqlCommand("SELECT id_turno "+
                                                             "from turno "+
                                                             "where id_materia = "+id_materia+" and turno like '"+turno+"'", conexion);

                    MySqlDataReader idTurno_reader = id_turno.ExecuteReader();

                    if (idTurno_reader.Read())
                    {

                        turno_trabajo = Convert.ToInt32(idTurno_reader[0].ToString());
                        
                        idTurno_reader.Close();
                    }
                    else
                    { //significa que no hay turno asociado

                        turno_trabajo = -1;

                    }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    turno_trabajo = -1;
                }

            }


            return turno_trabajo;
        }


        /// <summary>
        /// Rutina para el cambio de turno en una materia de un alumno
        /// </summary>
        /// <param name="id_materia">id de la materia a cambiar de turno</param>
        /// <param name="matricula">matricula del alumno para el profesorado asociado a las materias</param>
        /// <param name="id_turno_actual">el turno actual de la materia</param>
        /// <param name="id_turno_nuevo">el turno nuevo de la materia</param>
        /// <returns>true: si exito  false: si fallo o error</returns> 
        internal bool cambiarTurno(int id_materia,int matricula, int id_turno_actual, int id_turno_nuevo)
        {


            if (conexion.State == System.Data.ConnectionState.Closed)
                open_db();

            MySqlTransaction transaccion = conexion.BeginTransaction(); ;
            MySqlCommand MyCommand;

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();



                MyCommand = new MySqlCommand("update registro_materia " +
                                              "set id_turno =" + id_turno_nuevo + 
                                              " where id_materia = " + id_materia + " and id_turno = " + id_turno_actual + " and id_matricula = " + matricula, conexion);

                MyCommand.Connection = conexion;
                MyCommand.Transaction = transaccion;


                MyCommand.ExecuteNonQuery();

                transaccion.Commit();

                conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    transaccion.Rollback();
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Matricula para Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;
        }


        /// <summary>
        /// Rutina para el retorno del string turno actual para una materia y matricula especificados
        /// </summary>
        /// <param name="materia">materia a buscar</param>
        /// <param name="matricula">matricula del alumno</param>
        /// <returns>String: turno actual de la materia para la matricula especificada
        /// String: "" si no encuentra materia o matricula asociadas</returns>
        internal string obtener_turno(int materia, int matricula)
        {
            string turno_trabajo = "";


            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand id_turno = new MySqlCommand("SELECT t.turno "+
                                                         "FROM registro_materia r , turno t "+
                                                         "where r.id_turno = t.id_turno "+
                                                         "and r.id_materia = "+materia+" and r.id_matricula = "+matricula, conexion);

                MySqlDataReader idTurno_reader = id_turno.ExecuteReader();

                if (idTurno_reader.Read())
                {

                    turno_trabajo = idTurno_reader[0].ToString();

                    idTurno_reader.Close();
                }
                else
                { //significa que no hay turno asociado

                    turno_trabajo = "";

                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    turno_trabajo = "";
                }

            }


            return turno_trabajo;            
        }

        internal List<Materia> getMaterias(string prof, string nivel, string turno)
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("select m.id_materia, m.id_profesorado, nivel, m.nombre " +
                                                          "from materia m , turno t,profesorado p " +
                                                          "where m.id_materia = t.id_materia and m.id_profesorado = p.id_profesorado and "+
                                                          "p.nombre like '" + prof + "' and m.nivel = " + nivel +
                                                          " and t.turno like '"+ turno +"'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Materia materia_tem = new Materia();

                if (reader.Read())
                {
                    do
                    {
                        materia_tem.id_materia = Convert.ToInt32(reader[0].ToString());
                        materia_tem.id_profesorado = Convert.ToInt32(reader[1].ToString());
                        materia_tem.nivel = Convert.ToInt32(reader[2].ToString());
                        materia_tem.nombre = reader[3].ToString();
                        materia_tem.cargar();

                        materias.Add(materia_tem); //agrega a la lista de retorno

                        materia_tem = new Materia();

                    }while(reader.Read());
                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Materias: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return materias;
        }

        internal List<List<string>> getListadoCondicionalesCursos(string p)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno as a, matricula as m, registro_curso r " +
                                                          "where r.id_curso = '" + curso + "' AND r.condicion = 'condicional' AND r.id_matricula = m.id_matricula AND m.id_alumno = a.id_alumno", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> alumno;

                if (reader.Read())
                {
                    do
                    {
                        alumno = new List<string>();
                        alumno.Add(reader[0].ToString());
                        alumno.Add(reader[1].ToString());
                        alumno.Add(reader[2].ToString());

                        listado.Add(alumno);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }

        internal List<List<string>> getListadoCondicionalesCursosEspeciales(string p)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno as a, matricula as m, registro_curso_especial r " +
                                                          "where r.id_curso_especial = '" + curso + "' AND r.condicion = 'condicional' AND r.id_matricula = m.id_matricula AND m.id_alumno = a.id_alumno", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> alumno;

                if (reader.Read())
                {
                    do
                    {
                        alumno = new List<string>();
                        alumno.Add(reader[0].ToString());
                        alumno.Add(reader[1].ToString());
                        alumno.Add(reader[2].ToString());

                        listado.Add(alumno);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos Especiales: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }

        internal List<List<string>> getListadoCondicionalesMateria(string p, string p_2)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno a, registro_materia r, turno t, matricula m " +
                                                          "where r.id_materia = '" + id_materia + "' AND t.turno = '" + turno + "' AND t.id_materia = '" + id_materia + "' AND t.id_turno = r.id_turno  AND r.condicion = 'condicional' AND r.id_matricula = m.id_matricula AND m.id_alumno = a.id_alumno", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                List<string> alumno;

                if (reader.Read())
                {
                    do
                    {
                        alumno = new List<string>();
                        alumno.Add(reader[0].ToString());
                        alumno.Add(reader[1].ToString());
                        alumno.Add(reader[2].ToString());

                        listado.Add(alumno);

                    } while (reader.Read());

                }
                else
                {
                    conexion.Close();
                    return null;
                }

                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (MySqlException e)
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Error de lectura en base de Datos Cursos: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }


            return listado;
        }
    }

    
}
