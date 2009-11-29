﻿using System;
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
        MySqlConnection conexion = new MySqlConnection("server=localhost;user=iaai;database=iaai;port=3306;password=iaai;");



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

        //TODO: cambiar nombre del metodo resulta ambiguo seria mejor buscar...
        //TODO: agregar tray y catch
        //Se valida que no exista el alumno en la base de datos.
        public bool validarDniAlumno(string dni)
        {
            this.open_db();
            MySqlCommand MyCommand = new MySqlCommand("select dni from alumno where dni = '"+ dni +"'", conexion);
            MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
            bool aux = !(MyDataReader.Read());
            conexion.Dispose();
            return aux;
        }

        //
        //TODO: cambiar nombre del metodo validarDniResponsable resulta ambiguo seria mejor buscar...
        //TODO: agregar tray y catch
        //
        public bool validarDniResponsable(string dni)
        {
            this.open_db();
            MySqlCommand MyCommand = new MySqlCommand("select dni from responsable where dni = '" + dni + "'", conexion);
            MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
            bool aux = !(MyDataReader.Read());
            conexion.Dispose();
            return aux;
        }

        //TODO: Agregar comentarios y bloques try catch
        public bool altaAlumno(Alumno a)
        {
           
            this.open_db();
            //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
            MySqlCommand MyCommand = new MySqlCommand("insert into alumno(nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, escuela_nombre, escuela_año, direccion, id_responsable) values('" + a.getNombre() + "', '" + a.getApellido() + "', '" + a.getDni() + "', '" + a.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + a.getTelefono_carac() + "', '" + a.getTelefono_numero() + "', '" + a.getEscuela_nombre() + "', '" + a.getEscuela_año() + "', '" + a.getDireccion() + "', '" + a.getId_responsable() + "')", conexion);
            //MyCommand.Connection.Open();
            MyCommand.ExecuteNonQuery();
            conexion.Dispose();
            
            
            return true;
        }


        //TODO: Agregar comentarios y bloques try catch
        public bool altaResponsable(Responsable r)
        {
            this.open_db();
            //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
            MySqlCommand MyCommand = new MySqlCommand("insert into responsable(nombre_respon, apellido_respon, dni, fecha_nac, telefono_carac, telefono_numero, direccion) values('" + r.getNombre() + "', '" + r.getApellido() + "', '" + r.getDni() + "', '" + r.getFecha_nac().ToString("yyyy-MM-dd") + "', '" + r.getTelefono_carac() + "', '" + r.getTelefono_numero() + "', '" + r.getDireccion() + "')", conexion);
            //MyCommand.Connection.Open();
            MyCommand.ExecuteNonQuery();
            conexion.Dispose();


            return true;
        }


        //TODO: Agregar comentarios y bloques try catch
        public List<List<string>> buscarResponsable(string consulta)
        {
            this.open_db();
            List<List<string>> datos = new List<List<string>>();
            List<string> d = new List<string>();
            MySqlCommand MyCommand = new MySqlCommand("select * from responsable where " + consulta, conexion);
            MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
            while (MyDataReader.Read())
            {
                d.Add(MyDataReader.GetValue(1).ToString());
                d.Add(MyDataReader.GetValue(2).ToString());
                d.Add(MyDataReader.GetValue(7).ToString());
                d.Add(MyDataReader.GetValue(5).ToString() + " " + MyDataReader.GetValue(6).ToString());
                d.Add(MyDataReader.GetValue(4).ToString());
                datos.Add(d);
            }
            conexion.Dispose();
           
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
        internal bool BuscarDniProfesor(string dni_profesor)
        {
            bool aux= false;
            try
            {
                this.open_db();
                MySqlCommand MyCommand = new MySqlCommand("select dni from profesor where dni = '" + dni_profesor + "'", conexion);
                MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
                aux =  !(MyDataReader.Read());
                conexion.Close();
            }
            catch (MySqlException e) {

                MessageBox.Show("Error de lectura en base de Datos: \r\n"+e, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aux;
        }

        //TODO: Agregar comentarios y bloques try catch
        public bool altaProfesor(Profesor profe)
        {

            this.open_db();
            //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
            MySqlCommand MyCommand = new MySqlCommand("insert into profesor(nombre, apellido, dni, telefono_carac, telefono_numero, fecha_nac, direccion,email) values('" +
                                                        profe.getNombre() + "', '" + profe.getApellido() + "', '" +
                                                        profe.getDni() + "', '" +
                                                        "', '" + profe.getTelefono_carac() + "', '" +
                                                        profe.getTelefono_numero() + "', '" + profe.getFecha_nac().ToString("yyyy-MM-dd") +
                                                        "', '" + profe.getDireccion() +
                                                        "', '" + profe.getEmail() + "')", conexion);
            //MyCommand.Connection.Open();
            MyCommand.ExecuteNonQuery();
            conexion.Dispose();


            return true;
        }
    }
}
