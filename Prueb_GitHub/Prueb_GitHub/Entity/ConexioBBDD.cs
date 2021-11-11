using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Prueb_GitHub.Entity
{
    public class ConexioBBDD
    {
        public static MySqlConnection ObtenerConexion()
        {

            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = prueba; Uid = root; pwd =1234;");

            conectar.Open();

            return conectar;
        }
    }
}

