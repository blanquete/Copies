using System;
using System.Collections.Generic;
using System.Text;
using Prueb_GitHub.Entity;
using MySql.Data.MySqlClient;

namespace Prueb_GitHub.Persistence
{
    //----------------------------------- Password MongoDB ---------------------------------------------------//
    //----------------------------------- User: Iprats, passwd: Campalans1234 --------------------------------//
    //----------------------------------- User: Rblanco, passwd: Campalans1234 -------------------------------//
    //----------------------------------- User: Awaggeh, passwd: Campalans1234 -------------------------------//
    public class DbContext
    {
        //Conexio a la BBDD 
        public static MySqlConnection conectar;
        public static MySqlConnection ObtenerConexion()
        {
            conectar = new MySqlConnection(String.Format("server = 127.0.0.1; database = todolist; Uid = root; pwd = 1234;"));
            conectar.Open();
            return conectar;
        }
    }
}
