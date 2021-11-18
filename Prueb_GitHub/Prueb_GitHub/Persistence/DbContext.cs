using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Prueb_GitHub.Entity;
using System.Data.SQLite;

namespace Prueb_GitHub.BBDD
{
    public class DbContext
    {
        public static SQLiteConnection conectar;
        public static SQLiteConnection ObtenerConexion()
        {
            string DBName = "todolist.sql";
            //server = 127.0.0.1; database = todolist; Uid = root; pwd = 1234;
            conectar = new SQLiteConnection(String.Format("Data source={0};Version=3", DBName));
            conectar.Open();

            return conectar;
        }
    }
}
