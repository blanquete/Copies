using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Prueb_GitHub.Entity;
using Prueb_GitHub.Persistence;

namespace Prueb_GitHub.Service
{
    public class UserService
    {
        //Funció fer un insert de les dades introduïdes desde els textboxs.
        public static void Agregar(Tasca tasca)
        {

            string query = "INSERT INTO tasca(nom, descripcio, dataInici, dataFinal, id_prioritat, id_estat, id_responsable) VALUES (?, ?, ?, ?, ?, ?, ?)";
            using (var command = new MySqlCommand(query, DbContext.conectar))
            {
                //command.Parameters.Add(new SQLiteParameter("id", temp.Id));
                command.Parameters.Add(new MySqlParameter("nom", tasca.Nom));
                command.Parameters.Add(new MySqlParameter("descripcio", tasca.Descripcio));
                command.Parameters.Add(new MySqlParameter("dataInici", tasca.DInici));
                command.Parameters.Add(new MySqlParameter("dataFinal", tasca.DFinal));
                command.Parameters.Add(new MySqlParameter("id_prioritat", tasca.Prioritat_id+1));
                command.Parameters.Add(new MySqlParameter("id_estat", tasca.Estat_id+1));
                command.Parameters.Add(new MySqlParameter("id_responsable", tasca.Responsable_id+1));

                command.ExecuteNonQuery();
            }

        }

        public static void SelecionarTodo()
        {
            
            List<Tasca> todo = new List<Tasca>();
            List<Tasca> doing = new List<Tasca>();
            List<Tasca> done = new List<Tasca>();


            string queryTodo = "SELECT * FROM tasca WHERE estat_id = 1";
            string queryDoing = "SELECT * FROM tasca WHERE estat_id = 2";
            string queryDone = "SELECT * FROM tasca WHERE estat_id = 3";

            using (var commmand = new MySqlCommand(queryTodo, DbContext.conectar))
            {
                using(var reader = commmand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        todo.Add(new Tasca
                        {
                            Id = (int)reader["id"],
                            Nom = reader["nom"].ToString(),
                            Descripcio = reader["descripcio"].ToString(),
                            DInici = Convert.ToDateTime(reader["DInici"]),
                            DFinal = Convert.ToDateTime(reader["DFinal"]),
                            Prioritat_id = (int)reader["id_prioritat"],
                            Responsable_id = (int)reader["id_responsable"],
                            Estat_id = (int)reader["id_estat"]
                        }
                        );  
                    }
                }
            }
            
        }
    }
}
