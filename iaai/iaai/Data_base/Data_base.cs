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


namespace iaai.Data_base
{
    
    
    class Data_base 
    {
        MySqlConnection conexion = new MySqlConnection("server=192.168.0.100;user=iaai;database=iaai;port=3306;password=iaai;");



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
                return true;
            }

            return true;
            
        }

        //Se valida que no exista el alumno en la base de datos.
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

        //
        //TODO: comentar
        //
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

        //TODO: Agregar comentarios
        public bool altaAlumno(Alumno a)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("insert into alumno(nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, escuela_nombre, escuela_año, direccion, id_responsable) values('" + a.getNombre() + "', '" + a.getApellido() + "', '" + a.getDni() + "', '" + a.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + a.getTelefono_carac() + "', '" + a.getTelefono_numero() + "', '" + a.getEscuela_nombre() + "', '" + a.getEscuela_año() + "', '" + a.getDireccion() + "', '" + a.getId_responsable() + "')", conexion);
                //MyCommand.Connection.Open();
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


        //agregar comentarios
        public bool altaResponsable(Responsable r)
        {
            try
            {
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("insert into responsable(nombre_respon, apellido_respon, dni, fecha_nac, telefono_carac, telefono_numero, direccion) values('" + r.getNombre() + "', '" + r.getApellido() + "', '" + r.getDni() + "', '" + r.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + r.getTelefono_carac() + "', '" + r.getTelefono_numero() + "', '" + r.getDireccion() + "')", conexion);
                //MyCommand.Connection.Open();
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
                this.open_db();
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
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
        /// Busca un profesor activo en base de datos
        /// </summary>
        /// <param name="dni">recibe el dni de profesro a buscar</param>
        /// <returns>Lista de profesores eliminados</returns>
        /// <seealso cref=""/>
        public MySqlDataAdapter Buscar_Profesor_inactivos()
        {
            return null ;
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
                    return null;
                
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
                                                            "',email = '" + profe.getEmail() + "'" + " where dni like " + profe.getDni(), conexion);
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
                //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
                MySqlCommand MyCommand = new MySqlCommand("update profesor set activo = '" + 0 
                                                           + " where dni = " + dni, conexion);
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

    }

}
