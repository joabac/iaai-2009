using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using iaai.alumno;
using System.Data.SqlClient;



namespace iaai.Data_base
{
    
    
    class Data_base
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;user=iaai;database=iaai;port=3306;password=iaai;");



        public bool open_db(){

            conexion.Open();

           // if (conexion.State == System.Data.ConnectionState.Open)
             //   MessageBox.Show("la base esta abierta");

            return true;
        }

        public bool altaAlumno(Alumno a)
        {
            this.open_db();
            //hay que ver como hacer para que coincida el tipo fecha con el de la base de datos
           // MySqlCommand MyCommand = new MySqlCommand("insert into alumno(nombre, apellido, dni, fecha_nac, telefono_carac, telefono_numero, escuela_nombre, escuela_año, direccion, id_responsable) values('" + a.getNombre() + "', '" + a.getApellido() + "', '" + a.getDni() + "', '" + a.getFecha_nac().ToShortDateString() + "', '" + a.getTelefono_carac() + "', '" + a.getTelefono_numero() + "', '" + a.getEscuela_nombre() + "', '" + a.getEscuela_año() + "', '" + a.getDireccion() + "', '" + a.getId_responsable() + "')", conexion);
           // MyCommand.Connection.Open();
            //MyCommand.ExecuteNonQuery();
            
            
            
            return true;
        }

        public void leer()
        {//esta la dejamos de ejemplo para ver como leer desde la base de datos
            MySqlCommand MyCommand = new MySqlCommand("insert", conexion);
            MySqlDataReader MyDataReader = MyCommand.ExecuteReader();
            MyDataReader.Read();
            MessageBox.Show(MyDataReader.GetValue(2).ToString());
        }

    }
}
