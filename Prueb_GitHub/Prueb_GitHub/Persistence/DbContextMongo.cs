using MongoDB.Driver;
using Prueb_GitHub.Entity;
using System;
using System.Collections.Generic;
using System.Text;

//----------------------------------- Password MongoDB ---------------------------------------------------//
//----------------------------------- User: Iprats, passwd: Campalans1234 --------------------------------//
//----------------------------------- User: Rblanco, passwd: Campalans1234 -------------------------------//
//----------------------------------- User: Awaggeh, passwd: Campalans1234 -------------------------------//

namespace Prueb_GitHub.Persistence
{
    public class DbContextMongo
    {
        public static IMongoDatabase GetInstance()
        {
            string connectionString = "mongodb+srv://Iprats:Campalans1234@mongoproject.hxqyz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            MongoClient mongoClient = new MongoClient(connectionString);
            return mongoClient.GetDatabase("todolist");
        }

        public static IMongoCollection<Tasca> GetTasques()
        {
            return GetInstance().GetCollection<Tasca>("tasca");
        }

        public static IMongoCollection<Prioritat> GetPrioritats()
        {
            return GetInstance().GetCollection<Prioritat>("prioritat");
        }

        public static IMongoCollection<Responsable> GetResponsables()
        {
            return GetInstance().GetCollection<Responsable>("responsable");
        }
    }
}
