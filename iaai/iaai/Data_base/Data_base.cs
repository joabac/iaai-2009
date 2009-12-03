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

        MySqlConnection conexion = new MySqlConnection("server=localhost;user=iaai;database=iaai;port=3306;password=iaai;");

        //MySqlConnection conexion = new MySqlConnection("server=localhost;user=iaai;database=iaai;port=3306;password=iaai;");




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

                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, escuela_nombre, escuela_año, id_responsable " +
                                                          "from alumno " +
                                                          "where dni like '" + dni + "'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();

                if (reader.Read())
                {
                    alumno.setNombre(reader[0].ToString());
                    alumno.setApellido(reader[1].ToString());
                    alumno.setDni(reader[2].ToString());
                    alumno.setTelefono_carac(reader[3].ToString());
                    alumno.setTelefono_numero(reader[4].ToString());
                    alumno.setFecha_nac(Convert.ToDateTime(reader[5]));
                    alumno.setDireccion(reader[6].ToString());
                    alumno.setEscuela_nombre(reader[7].ToString());
                    alumno.setEscuela_año(Convert.ToInt32(reader[8].ToString()));
                    alumno.setId_responsable(Convert.ToInt32(reader[9].ToString()));
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

                MySqlCommand MyCommand = new MySqlCommand("select nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion, escuela_nombre, escuela_año, id_responsable " +
                                                          "from alumno " +
                                                          "where apellido like '" + apellido +"%'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Alumno alum_tem = new Alumno();

                         

                if (reader.Read())
                {
                    do
                    {

                        alum_tem.setNombre(reader[0].ToString());
                        alum_tem.setApellido(reader[1].ToString());
                        alum_tem.setDni(reader[2].ToString());
                        alum_tem.setTelefono_carac(reader[3].ToString());
                        alum_tem.setTelefono_numero(reader[4].ToString());
                        alum_tem.setFecha_nac(Convert.ToDateTime(reader[5]));
                        alum_tem.setDireccion(reader[6].ToString());
                        alum_tem.setEscuela_nombre(reader[7].ToString());
                        alum_tem.setEscuela_año(Convert.ToInt32(reader[8].ToString()));
                        alum_tem.setId_responsable(Convert.ToInt32(reader[9].ToString()));

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
                MySqlCommand MyCommand = new MySqlCommand("select id_materia, id_profesorado, nivel, nombre " +
                                                          "from materia m join turno t on m.id_turno=t.id_turno "+
                                                          "where id_profesorado = "+id_prof+" and nivel = "+ nivel +" and turno like '"+turno+"'", conexion);

                MySqlDataReader reader = MyCommand.ExecuteReader();
                Materia materia_tem = new Materia();

                if (reader.Read())
                {
                    do
                    {

                        materia_tem.id_materia = Convert.ToInt32(reader[0].ToString());
                        materia_tem.id_profesorado = Convert.ToInt32(reader[1].ToString());
                        materia_tem.nombre = reader[2].ToString();
                        materia_tem.nivel = Convert.ToInt32(reader[3].ToString());

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
    }

}
