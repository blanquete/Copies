﻿using System;
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
        public static List<Prioritat> prioritats = SelectP();
        public static List<Responsable> responsables = SelectR();


        public static void Agregar(Tasca tasca)
        {

            string query = "INSERT INTO tasca(nom, descripcio, dataInici, dataFinal, id_prioritat, id_estat, id_responsable) VALUES (?, ?, ?, ?, ?, ?, ?)";
            using (var command = new MySqlCommand(query, DbContext.conectar))
            {
                //command.Parameters.Add(new MySqlParameter("id", temp.Id));
                command.Parameters.Add(new MySqlParameter("nom", tasca.Nom));
                command.Parameters.Add(new MySqlParameter("descripcio", tasca.Descripcio));
                command.Parameters.Add(new MySqlParameter("dataInici", tasca.DInici));
                command.Parameters.Add(new MySqlParameter("dataFinal", tasca.DFinal));
                int p = -1;
                foreach(Prioritat prioritat in prioritats)
                {
                    if(prioritat.Nom == tasca.Prioritat_name)
                        p = prioritat.Id;
                }
                command.Parameters.Add(new MySqlParameter("id_prioritat", p));

                command.Parameters.Add(new MySqlParameter("id_estat", Estat.ToDo+1));

                int r = -1;

                foreach (Responsable responsable in responsables)
                {
                    if (responsable.Nom == tasca.Responsable_name)
                        r = responsable.Id;
                }
                command.Parameters.Add(new MySqlParameter("id_responsable", r));

                command.ExecuteNonQuery();
            }
        }
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
                            Estat_name = reader["id_estat"].ToString(),
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
