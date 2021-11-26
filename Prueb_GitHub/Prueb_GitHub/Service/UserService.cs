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
        public static MainWindow w1;
        public static List<Prioritat> prioritats = SelectP();
        public static List<Responsable> responsables = SelectR();


        public static void Agregar(Tasca tasca)
        {

            string query = "INSERT INTO tasca(nom, descripcio, dataInici, dataFinal, id_prioritat, id_estat, id_responsable) VALUES (?, ?, ?, ?, ?, ?, ?)";
            using (MySqlConnection conection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, conection))
                {
                    //command.Parameters.Add(new MySqlParameter("id", temp.Id));
                    command.Parameters.Add(new MySqlParameter("nom", tasca.Nom));
                    command.Parameters.Add(new MySqlParameter("descripcio", tasca.Descripcio));
                    command.Parameters.Add(new MySqlParameter("dataInici", tasca.DInici));
                    command.Parameters.Add(new MySqlParameter("dataFinal", tasca.DFinal));

                    int p = -1;
                    foreach (Prioritat prioritat in prioritats)
                    {
                        if (prioritat.Nom == tasca.Prioritat_name)
                            p = prioritat.Id;
                    }
                    command.Parameters.Add(new MySqlParameter("id_prioritat", p));

                    command.Parameters.Add(new MySqlParameter("id_estat", Estat.ToDo + 1));

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
        }

        public static void eliminarTasca(int id)
        {
            string query = $"DELETE FROM tasca WHERE id = {id}";

            using (MySqlConnection conection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, conection))
                {
                    id = (int)command.ExecuteNonQuery();
                }
            }
        }
        public static List<Tasca> Select(int estat)
        {
            List<Tasca> todo = new List<Tasca>();
            string query = $"SELECT t.id as ID, t.nom as nom, descripcio, dataInici, dataFinal, r.nom as nomResponsable, e.nom as nomEstat, p.nom as nomPrioritat FROM tasca t, responsable r, estat e, prioritat p WHERE t.id_estat = e.id  and t.id_responsable = r.id and t.id_prioritat = p.id  and t.id_estat = {estat}";

            using (MySqlConnection conection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, conection))
                {
                    using (var reader = command.ExecuteReader())
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
                                Estat_name = reader["nomEstat"].ToString(),
                                Prioritat_name = reader["nomPrioritat"].ToString(),
                                Responsable_name = reader["nomResponsable"].ToString(),
                            });

                        }
                    }
                }
                return todo;
            }
        }

        public static List<Prioritat> SelectP()
        {
            List<Prioritat> prioritats = new List<Prioritat>();
            string query = "SELECT * FROM prioritat";


            using (MySqlConnection conection = DbContext.ObtenerConexion())
            { 
                using (var command = new MySqlCommand(query, conection))
                {
                    using (var reader = command.ExecuteReader())
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
            }
            return prioritats;
        }

        public static List<Responsable> SelectR()
        {
            List<Responsable> responsables = new List<Responsable>();
            string query = "SELECT * FROM responsable";

            using (MySqlConnection conection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, conection))
                {
                    using (var reader = command.ExecuteReader())
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
            }
            return responsables;
        }

        public static void updateEstat(Tasca tasca)
        {
            string query = $"UPDATE TASCA SET id_estat = {tasca.Estat + 1} WHERE id = {tasca.Id}";

            using (var connection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void updateTasca(Tasca tasca)
        {
            string query = $"UPDATE TASCA SET nom = {tasca.Nom}, descripcio = {tasca.Descripcio}, dataFinal = {tasca.DFinal}, id_prioritat = {tasca.Prioritat_id}, id_responsable = {tasca.Responsable_id} WHERE id = {tasca.Id}";

            using (var connection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static int maxId()
        {
            string query = $"SELECT MAX(id) FROM tasca";

            int max = 0;

            using (MySqlConnection conection = DbContext.ObtenerConexion())
            {
                using (var command = new MySqlCommand(query, conection))
                {
                    max = (int)command.ExecuteScalar();
                }
            }
            return max;
        }
    }
}

