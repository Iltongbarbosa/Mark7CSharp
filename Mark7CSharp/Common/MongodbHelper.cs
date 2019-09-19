namespace Mark7CSharp.Common
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System.Configuration;

    public class MongodbHelper
    {
        private IMongoDatabase _dataBase; 
           
        public MongodbHelper()
        {
            //*Host => endereco
            //* Port => Porta
            //* Database => Base 
            //* User => usuario
            //* Pass => senha

            //Como => mongodb://User:Pass@Host:Port/Database
            string strConn = "";
            var client = new MongoClient(ConfigurationManager.AppSettings["MongoStrConn"]);
            _dataBase = client.GetDatabase(ConfigurationManager.AppSettings["MonoDataBase"]);
        }

        private IMongoCollection<BsonDocument>  Collection(string collection)
        {
            return _dataBase.GetCollection<BsonDocument>(collection);
        }

        public BsonDocument GetUserByEmail(string email)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("profile.eamil", email);
            return  Collection("users").Find(filter).First();
        }

        public void CreateTask(BsonDocument tarefa)
        {
            Collection("tasks").InsertOne(tarefa);
        }

        public void DeleteByTitle(string titulo)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("title", titulo);
            Collection("tasks").DeleteMany(filter);
        }
    }
}
