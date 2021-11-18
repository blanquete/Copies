using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Prueb_GitHub.Entity;
using Prueb_GitHub.Persistence;

namespace Prueb_GitHub.Service
{
    public class UserService
    {
        public static void Agregar(Tasca tasca)
        {

            string query = "INSERT INTO tasca(nom, descripcio, dataInici, dataFinal, id_prioritat, id_estat, id_responsable) VALUES (?, ?, ?, ?, ?, ?, ?)";
            using (var command = new SQLiteCommand(query, DbContext.conectar))
            {
                //command.Parameters.Add(new SQLiteParameter("id", temp.Id));
                command.Parameters.Add(new SQLiteParameter("nom", tasca.Nom));
                command.Parameters.Add(new SQLiteParameter("descripcio", tasca.Descripcio));
                command.Parameters.Add(new SQLiteParameter("dataInici", tasca.DInici));
                command.Parameters.Add(new SQLiteParameter("dataFinal", tasca.DFinal));
                command.Parameters.Add(new SQLiteParameter("id_prioritat", tasca.Prioritat_id));
                command.Parameters.Add(new SQLiteParameter("id_estat", tasca.Estat_id));
                command.Parameters.Add(new SQLiteParameter("id_responsable", tasca.Responsable_id));

                command.ExecuteNonQuery();
            }

        }
    }
}
