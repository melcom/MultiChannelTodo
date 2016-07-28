using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MultiChannelTodo.Core.Api.Models
{
    public interface ITodoItemRepository
    {
        Task AddTodoItem(TodoItem todoItem);
        Task<IEnumerable<TodoItem>> GetAllTodoItems();
        Task<TodoItem> GetTodoItem(ObjectId id);
        Task<bool> RemoveTodoItem(ObjectId id);
        Task UpdateTodoItem(TodoItem todoItem);
        Task Populate();
    }
}