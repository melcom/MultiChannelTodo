using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MultiChannelTodo.Core.Api.Models
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly IMongoDatabase database;
        private IMongoCollection<TodoItem> collection;

        private readonly string collectionName;
        private ITodoItemRepository _todoItemRepositoryImplementation;

        public TodoItemRepository() : this("", "")
        {
        }

        public TodoItemRepository(string mongoConnection, string databaseName)
        {
            collectionName = "todoitems";

            // Quick fix https://github.com/mongodb/mongo-csharp-driver/pull/243
            var server = mongoConnection.Replace("mongodb://",string.Empty).Split(':');
            string hostname = server[0];
            string port = server.Length == 2 ? server[1] : "27017";
            var ips = System.Net.Dns.GetHostAddressesAsync(hostname).Result;
            mongoConnection = string.Format("mongodb://{0}:{1}", ips[0], port);
            // End - Quick fix

            var client = new MongoClient(mongoConnection);
            this.database = client.GetDatabase(databaseName);
            this.collection = database.GetCollection<TodoItem>(collectionName);
            
        }

        public async Task<TodoItem> GetTodoItem(ObjectId id)
        {
            var query = Builders<TodoItem>.Filter.Eq(e => e.Id, id);
            var cursor = await this.collection.FindAsync(query);
            return cursor.FirstOrDefault();
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodoItems()
        {
            var cursor = await this.collection.FindAsync(f => true);
            return cursor.ToList();
        }

        public async Task AddTodoItem(TodoItem todoItem)
        {
            await this.collection.InsertOneAsync(todoItem);
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            var query = Builders<TodoItem>.Filter.Eq(e => e.Id, todoItem.Id);
            await this.collection.ReplaceOneAsync(query, todoItem);
        }

        public async Task Populate()
        {
            await this.database.CreateCollectionAsync(collectionName);

            this.collection = this.database.GetCollection<TodoItem>(collectionName);

            await this.collection.InsertManyAsync(new []
            {
                new TodoItem { Text = "Build docker file", Complete = false },
                new TodoItem { Text = "Push image to Docker Hub", Complete = false}, 
                new TodoItem { Text = "Compose application", Complete = false}, 
            });
        }


        public async Task<bool> RemoveTodoItem(ObjectId id)
        {
            var query = Builders<TodoItem>.Filter.Eq(e => e.Id, id);
            await this.collection.DeleteOneAsync(query);

            return await GetTodoItem(id) == null;
        }
    }
}