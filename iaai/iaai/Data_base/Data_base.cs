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
        string cadena_coneccion = "server=localhost;user=iaai;database=iaai;port=3306;password=iaai;";

        MySqlConnection conexion = new MySqlConnection("server=localhost;user=iaai;database=iaai;port=3306;password=iaai;");

        //MySqlConnection conexion = new MySqlConnection("server=localhost;user=root;database=iaai;port=3306;password=root;");




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
        /// true: si no lo encontro
        /// false: si lo encontro
        /// </returns>

        public bool buscarDniAlumno(string dni)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from alumno where dni = '" + dni + "'", conexion);
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
        /// Se valida que no exista el responsable en la base de datos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// true: si no lo encontro
        /// false: si lo encontro
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
       /// true: si no lo encontro
       /// false: si lo encontro
       /// </returns>
        public bool buscarDniResponsable(string dni)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from responsable where dni = '" + dni + "'", conexion);
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
        /// Da de alta un alumno en la base de datos
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        /// true: si se subio a la base de datos
        /// false:si no lo subio a la base de datos
        /// </returns>
        public bool altaAlumno(Alumno a)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("insert into alumno(nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, escuela_nombre, escuela_año, direccion, id_responsable) values('" + a.getNombre() + "', '" + a.getApellido() + "', '" + a.getDni() + "', '" + a.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + a.getTelefono_carac() + "', '" + a.getTelefono_numero() + "', '" + a.getEscuela_nombre() + "', '" + a.getEscuela_año() + "', '" + a.getDireccion() + "', '" + a.getId_responsable() + "')", conexion);
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
        /// Da de alta un responsable en la base de datos
        /// </summary>
        /// <param name="r"></param>
        /// <returns>
        /// true: si se subio a la base de datos
        /// false:si no lo subio a la base de datos
        /// </returns>
        public bool altaResponsable(Responsable r)
        {
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("insert into responsable(nombre_respon, apellido_respon, dni, fecha_nac, telefono_carac, telefono_numero, direccion) values('" + r.getNombre() + "', '" + r.getApellido() + "', '" + r.getDni() + "', '" + r.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + r.getTelefono_carac() + "', '" + r.getTelefono_numero() + "', '" + r.getDireccion() + "')", conexion);
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
        /// Busca un responsable especificando una porcion de consulta SQL
        /// </summary>
        /// <param name="consulta">
        /// consulta: 
        /// </param>
        /// <returns>
        /// ?
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
        /// Modifica un alumno en la base de datos
        /// </summary>
        /// <param name="alumno">
        /// Se debe ingresar un instancia de Alumno
        /// </param>
        /// <returns>
        /// {true= si se dio la modificación del alumno}  
        /// {false= si no se pudo modificar}
        /// </returns>
        public bool modificarAlumno(Alumno alumno)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("update alumno set nombre = '" +
                                                            alumno.getNombre() + "',apellido = '" + alumno.getApellido() + "',dni = '" +
                                                            alumno.getDni() + "', telefono_carac = " + alumno.getTelefono_carac() + ",telefono_numero = " +
                                                            alumno.getTelefono_numero() + ",fecha_nac = '" +
                                                            alumno.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "',direccion = '" + alumno.getDireccion() +
                                                            "',escuela_nombre = '" + alumno.getEscuela_nombre() +
                                                            "', escuela_año = '" + alumno.getEscuela_año() + 
                                                            "', id_responsable = '" + alumno.getId_responsable() + "' where dni like '" + alumno.getDni() + "'", conexion);
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
        /// Modifica un responsable en la base de datos
        /// </summary>
        /// <param name="alumno">
        /// Se debe ingresar un instancia de Responsable
        /// </param>
        /// <returns>
        /// {true= si se dio la modificación del responsable}  
        /// {false= si no se pudo modificar}
        /// </returns>
        public bool modificarResponsable(Responsable responsable)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("update responsable set nombre_respon = '" +
                                                            responsable.getNombre() + "',apellido_respon = '" + responsable.getApellido() + "',dni = '" +
                                                            responsable.getDni() + "', telefono_carac = " + responsable.getTelefono_carac() + ",telefono_numero = " +
                                                            responsable.getTelefono_numero() + ",fecha_nac = '" +
                                                            responsable.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "',direccion = '" + responsable.getDireccion() + "' where dni like '" + responsable.getDni() + "'", conexion);
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
        /// Busca un alumno en base de datos
        /// </summary>
        /// <param name="dni">recibe el dni del alumno a buscar</param>
        /// <returns>Alumno si encontro el alumno buscado
        /// null: si no encontro el dni solicitado</returns>
        public Alumno Buscar_Alumno(string dni)
        {
            Alumno alumno = new Alumno();
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select id_alumno,nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, escuela_nombre, escuela_año, id_responsable " +
                                                          "from alumno " +
                                                          "where dni like '" + dni + "'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    alumno.id_alumno = (Convert.ToInt32(reader[0]));
                    alumno.setNombre(reader[1].ToString());
                    alumno.setApellido(reader[2].ToString());
                    alumno.setDni(reader[3].ToString());
                    alumno.setTelefono_carac(reader[4].ToString());
                    alumno.setTelefono_numero(reader[5].ToString());
                    alumno.setFecha_nac(Convert.ToDateTime(reader[6]));
                    alumno.setDireccion(reader[7].ToString());
                    alumno.setEscuela_nombre(reader[8].ToString());
                    alumno.setEscuela_año(Convert.ToInt32(reader[9].ToString()));
                    alumno.setId_responsable(Convert.ToInt32(reader[10].ToString()));
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
        /// <returns>Responsable si encontro el responsable buscado
        /// null: si no encontro el dni solicitado</returns>
        public Responsable Buscar_Responsable(string dni)
        {
            Responsable responsable = new Responsable();
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select nombre_respon, apellido_respon, dni, telefono_carac, telefono_numero, fecha_nac, direccion, id_responsable " +
                                                          "from responsable " +
                                                          "where dni like '" + dni + "'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    responsable.setNombre(reader[0].ToString());
                    responsable.setApellido(reader[1].ToString());
                    responsable.setDni(Convert.ToInt32(reader[2]));
                    responsable.setTelefono_carac(Convert.ToInt32(reader[3].ToString()));
                    responsable.setTelefono_numero(Convert.ToInt32(reader[4].ToString()));
                    responsable.setFecha_nac(Convert.ToDateTime(reader[5]));
                    responsable.setDireccion(reader[6].ToString());
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
                MySqlCommand MyCommand = new MySqlCommand("select dni from profesor where dni = '" + dni_profesor + "'", conexion);
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
                                                        profe.getNombre() + "', '" + profe.getApellido() + "', '" +
                                                        profe.getDni() + "', '" + profe.getTelefono_carac() + "', '" +
                                                        profe.getTelefono_numero() + "', '" +
                                                        profe.getFecha_nac().ToString("yyyy-MM-dd") +
                                                        "', '" + profe.getDireccion() +
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
        /// <returns>true: pudo completar la consulta 
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
                    MessageBox.Show("Error de escritura en base de Datos al dar de alta un profesor: \r\n" + e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }


            return true;

        }

        /// <summary>
        /// Busca el consjunto de profesores dados de baja del sistema
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
                                                          "where apellido like '"+apellido+"%' and activo = 1", conexion);

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
                                                            profe.getNombre() + "',apellido = '" + profe.getApellido() + "',dni = '" +
                                                            profe.getDni() + "', telefono_carac = " + profe.getTelefono_carac() + ",telefono_numero = " +
                                                            profe.getTelefono_numero() + ",fecha_nac = '" +
                                                            profe.getFecha_nac().ToString("yyyy-MM-dd") +
                                                            "',direccion = '" + profe.getDireccion() +
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
        /// Marca como eliminado un alumno de la base de datos
        /// </summary>
        /// <param name="dni">String del alumno a elimnar</param>
        /// <remarks>este debe ser valido y existir en la base</remarks>
        /// <returns>true: si pudo eliminar false: si no pudo realizar la eliminacion</returns>
        public bool eliminarAlumno(String dni)
        {
            try
            {
                this.open_db();

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
        /// <param name="dni">String del responsable a elimnar</param>
        /// <remarks>este debe ser valido y existir en la base</remarks>
        /// <returns>true: si pudo eliminar false: si no pudo realizar la eliminacion</returns>
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
        /// Arma el listado de alumnos para presentar al seguro
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
                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, direccion from alumno where id_alumno IN(select id_alumno from matricula);", conexion);
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
        /// <param name="curso">int del curso del cual se quiere obtener el listado de alumnos</param>
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
        /// <param name="id">
        /// Se debe ingresar un dni valido en formato String
        /// </param>
        /// <returns>
        ///{true= si no tiene alumnos asociados}  
        ///{false= si tiene alumnos asociados} 
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


        internal List<Alumno> Buscar_Alumno_Por_apellido(string apellido)
        {
            List<Alumno> alum = new List<Alumno>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select id_alumno,nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, escuela_nombre, escuela_año, id_responsable " +
                                                          "from alumno " +
                                                          "where apellido like '" + apellido +"%'", conexion);

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

        internal List<Responsable> Buscar_Responsable_Por_apellido(string apellido)
        {
            List<Responsable> responsables = new List<Responsable>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();

                MySqlCommand MyCommand = new MySqlCommand("select id_responsable,nombre_respon, apellido_respon, dni, telefono_carac, telefono_numero, fecha_nac, direccion " +
                                                          "from responsable " +
                                                          "where apellido_respon like '" + apellido + "%'", conexion);

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
                        int disponible = verificarCupoMateria(materia_actual.id_materia, turno);

                        if (disponible == 0)
                        { //si el disponible es 0 

                            MyCommand.CommandText= ("insert into registro_materia (id_matricula, id_materia, fecha, hora, id_turno, "+
                                                         " condicion) values " +
                                                         "(" + matricula + "," + materia_actual.id_materia+",'"+ DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                         "','" + DateTime.Now.ToShortTimeString() + "'," + materia_actual.get_id_turno(turno)  +
                                                         ",'condicional' )");
            

                            MyCommand.ExecuteNonQuery();
                            //transaccion.Commit();
                        }
                        else{  //si quedara inscripto

                            if (disponible > 0)
                            {
                                MyCommand.CommandText = ("insert into registro_materia (id_matricula, id_materia, fecha, hora, id_turno," +
                                                         " condicion) values " +
                                                         "(" + matricula + "," + materia_actual.id_materia + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                         "','" + DateTime.Now.ToShortTimeString() + "'," + materia_actual.get_id_turno(turno) +
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
                            transaccion.Rollback();
                            matricula = -1;
                            db_inscribe.Close();
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


                MySqlCommand MyCommand = new MySqlCommand("select p.nombre, p.niveles, m.id_materia, m.nombre, m.nivel " +
                                                          "from profesorado p, materia m " +
                                                          "where m.id_profesorado = p.id_profesorado", conexion);

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

        


        public List<List<string>> getListadoCursos(string curso)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno as a, matricula as m " +
                                                          "where m.id_curso = '" + curso + "' AND m.id_alumno = a.id_alumno AND m.condicion = 'regular'", conexion);

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

        public List<List<string>> getListadoCursosEspeciales(string curso)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno as a, matricula as m " +
                                                          "where m.id_curso_especial = '" + curso + "' AND m.id_alumno = a.id_alumno AND m.condicion = 'regular'", conexion);

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

        public List<List<string>> getListadoMateria(string id_materia, string turno)
        {
            List<List<string>> listado = new List<List<string>>();

            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    this.open_db();


                MySqlCommand MyCommand = new MySqlCommand("select a.nombre, a.apellido, a.dni " +
                                                          "from alumno a, inscripcion_materia i, turno t, matricula m " +
                                                          "where i.id_materia = '" + id_materia + "' AND t.turno = '" + turno + "' AND t.id_turno = i.id_turno  AND i.id_matricula = m.id_matricula AND m.condicion = 'regular'", conexion);

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
        /// <param name="id_area">area correspondiente a los cursos</param>
        /// <param name="cursos_select">lista de cursos seleccionados</param>
        /// <returns>Lista de las inscripciones del alunno a los cursos</returns>

        internal List<Inscripto_curso> inscribirCursos(Alumno nuevo, int id_area, List<Curso> cursos_select)
        {

            int matricula = nuevo.id_matricula;
            List<Inscripto_curso> listado_inscripciones = new List<Inscripto_curso>(); //listado donde se registraran las inscripciones y condicion en que quedo
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

                foreach (Curso curso_actual in cursos_select)
                {
                    //int disponible = verificarCupoMateria(materia_actual.id_materia, turno);

                    //if (disponible == 0)
                    { //si el disponible es 0 

                        MyCommand.CommandText = ("insert into registro_materia (id_matricula, id_materia, fecha, hora, id_turno, " +
                                                     " condicion) values " +
                                                     "(" + matricula + "," + curso_actual.id_curso + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                     ",'" + DateTime.Now.ToShortTimeString() + "'," +
                                                     "'condicional' )");


                        MyCommand.ExecuteNonQuery();
                        //transaccion.Commit();
                    }
                    // else
                    {  //si quedara inscripto

                        // if (disponible > 0)
                        {
                            MyCommand.CommandText = ("insert into registro_materia (id_matricula, id_materia, fecha, hora, id_turno," +
                                                     " condicion) values " +
                                                     "(" + matricula + "," + curso_actual.id_curso + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd") +
                                                     "','" + DateTime.Now.ToShortTimeString() + "'," +
                                                     ", 'inscripto' )");

                            MyCommand.ExecuteNonQuery();
                            //transaccion.Commit();

                        }
                        //   else
                        {
                            transaccion.Rollback();
                            MessageBox.Show("Error al intentar inscribir Alumno en la materia\r\n Problemas de cupo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }



                    //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                    MyCommand.CommandText = "select id_inscripcion_materia,condicion " +
                                                 "from registro_materia " +
                                                 "where id_matricula = " + matricula +
                                                 " and  id_materia= " + curso_actual.id_curso;

                    MySqlDataReader reader = MyCommand.ExecuteReader();



                    if (reader.Read())
                    {

                        inscripto_tmp = new Inscripto_curso();
                        //cargo el id de la transaccion
                        inscripto_tmp.id_inscripcion_curso = Convert.ToInt32(reader[0].ToString());

                        //cargo la condicion en que se asigno al curos
                        inscripto_tmp.condicion = reader[1].ToString();

                        //cargo la materia para registro futuro
                        inscripto_tmp.curso_inscripto = curso_actual;


                        listado_inscripciones.Add(inscripto_tmp);
                        reader.Close();
                    }
                    else
                    {
                        transaccion.Rollback();
                        matricula = -1;
                        db_inscribe.Close();
                    }
                }

                transaccion.Commit();
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


            return listado_inscripciones;


        }


        /// <summary>
        /// Retorna el listado de cursosEspeciales para un area en especial 
        /// </summary>
        /// <returns>
        /// Retorna una lista de Cursos existentes asociados al area
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
                                                          "where a.nombre like '" + area+"'", conexion);

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
                                                          "and a.nombre like '" + area + "'" + " and n.nombre like '"+ nivel+"'", conexion);

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
    }

    
}
