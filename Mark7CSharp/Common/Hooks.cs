namespace Mark7CSharp.Common
{
    using MongoDB.Bson;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Hooks
    {
       
        [BeforeScenario]
        [Scope(Tag = "add_task")]
        public void BeforeScenario()
        {
            var mongo = new MongodbHelper();
            var user = mongo.GetUserByEmail("ilton.io@ninja.com.br");
            var id = user["_id"];

            var tarefa = new BsonDocument
            {
                { "title", "Tarefa indesejada"},
                {"dueDate", "31/12/2019" },
                {"done", false }
            };

            mongo.CreateTask(tarefa);
        }
    }
}
