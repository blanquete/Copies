using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Prueb_GitHub.Entity;
using Prueb_GitHub.Persistence;
using Prueb_GitHub.Views;

namespace Prueb_GitHub.Service
{
    public class UserService
    {


        //public Tasca temp;
        public static MainWindow w1;




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
                command.Parameters.Add(new MySqlParameter("id_prioritat", tasca.Prioritat_id + 1));
                command.Parameters.Add(new MySqlParameter("id_estat", tasca.Estat_id + 1));
                command.Parameters.Add(new MySqlParameter("id_responsable", tasca.Responsable_id + 1));

                command.ExecuteNonQuery();
            }
            //w1.todo = Select(1);

        }
        ///
        public static List<Tasca> Select(int estat)
        {
            List<Tasca> todo = new List<Tasca>();
            string query = $"SELECT * FROM tasca WHERE id_estat = {estat} ";

            using (var commmand = new MySqlCommand(query, DbContext.conectar))
            {
                using (var reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        todo.Add(new Tasca
                        {
                            Id = (int)reader["id"],
                            Nom = reader["nom"].ToString(),
                            Descripcio = reader["descripcio"].ToString(),
                            DInici = Convert.ToDateTime(reader["dataInici"]),
                            DFinal = Convert.ToDateTime(reader["dataFinal"]),
                            Prioritat_id = (int)reader["id_prioritat"],
                            Estat_id = (int)reader["id_estat"],
                            Responsable_id = (int)reader["id_responsable"]
                        });
                    }
                }
            }
            return todo;
        }





        public static List<Prioritat> SelectP()
        {
            List<Prioritat> prioritats = new List<Prioritat>();
            string query = $"SELECT * FROM prioritat";

            using (var commmand = new MySqlCommand(query, DbContext.conectar))
            {
                using (var reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        prioritats.Add(new Prioritat
                        {
                            Id = (int)reader["id"],
                            Nom = reader["nom"].ToString()
                        });
                    }
                }
            }
            return prioritats;
        }







        public static List<Responsable> SelectR()
        {
            List<Responsable> responsables = new List<Responsable>();
            string query = $"SELECT * FROM responsable";

            using (var commmand = new MySqlCommand(query, DbContext.conectar))
            {
                using (var reader = commmand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        responsables.Add(new Responsable
                        {
                            Id = (int)reader["id"],
                            Nom = reader["nom"].ToString()
                        });
                    }
                }
            }
            return responsables;
        }
    }
}
