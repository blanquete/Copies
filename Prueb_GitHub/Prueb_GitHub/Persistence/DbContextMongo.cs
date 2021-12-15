using MongoDB.Driver;
using Prueb_GitHub.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueb_GitHub.Persistence
{
    public class DbContextMongo
    {
        public static IMongoDatabase GetInstance()
        {
            string connectionString = "mongodb + srv:Rblanco:Campalans1234@mongoproject.hxqyz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
            MongoClient mongoClient = new MongoClient(connectionString);
            return mongoClient.GetDatabase("testMongo");
        }

        public static IMongoCollection<Tasca> GetUsers()
        {
            return GetInstance().GetCollection<Tasca>("Tasca");
        }
    }
}
