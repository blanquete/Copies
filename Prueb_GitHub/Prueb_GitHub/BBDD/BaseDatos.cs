using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Prueb_GitHub.Entity;

namespace Prueb_GitHub.BBDD
{
    public class BaseDatos
    {
        public static MySqlConnection ObtenerConexion()
        {
            //dades d'acces al heidiSQL
            MySqlConnection conectar = new MySqlConnection("server = 127.0.0.1; database = todolist; Uid = root; pwd = 1234;");
            conectar.Open();
            return conectar;
        }

        public static int Agregar(Tasca temp)
        {
            int retorno = 0;
            string Query = string.Format("Insert into tasca(id, nom, descripcio, dataInici, dataFinal, id_prioritat, id_estat, id_responsable) values('" + temp.Id + "', '" + temp.Nom + "','" + temp.Descripcio + "','" + temp.DInici + "','" + temp.DFinal + "','" + int.Parse(temp.Prioritat_id) + "','" + int.Parse(temp.Estat_id) + "','" + int.Parse(temp.Responsable_id) +"');");
            //temp.Id, temp.Nom, temp.Descripcio, temp.DInici, temp.DFinal, int.Parse(temp.Prioritat_id), int.Parse(temp.Estat_id), int.Parse(temp.Responsable_id)

            MySqlConnection mySqlConnection = ObtenerConexion();
            MySqlCommand comando = new MySqlCommand(Query, mySqlConnection);
            
            
            retorno = comando.ExecuteNonQuery();

            return retorno;

        }
        //'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'
    }
}
