﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueb_GitHub.BBDD
{
    public class DataBase
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = todolist; Uid = root; pwd =1234;");
            conectar.Open();
            return conectar;
        }
    }
}
