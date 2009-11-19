using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;



namespace iaai.Data_base
{
    
    
    class Data_base
    {
        MySqlConnection conexion = new MySqlConnection("server=localhost;user=iaai;database=iaai;port=3306;password=iaai;");



        public bool open_db(){

            conexion.Open();

            if (conexion.State == System.Data.ConnectionState.Open)
                MessageBox.Show("la base esta abierta");

            return true;
        }
    }
}
