using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MultiChannelTodo.Core.Api.Models;

namespace MultiChannelTodo.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class ToDoItemsController : Controller
    {
        private readonly ITodoItemRepository todoItemRepository;

        public ToDoItemsController(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        [HttpGet("populate", Name = "Populate")]
        public async Task<IEnumerable<TodoItem>> Populate()
        {
            Trace.TraceInformation("Populate all ToDo items");

            await todoItemRepository.Populate();

            return await todoItemRepository.GetAllTodoItems();
        }

        // GET: api/ToDoItems
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetToDoItems()
        {
            Trace.TraceInformation("Returning all ToDo items");

            return await todoItemRepository.GetAllTodoItems();
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id:length(24)}", Name = "GetByIdRoute")]
        public async Task<IActionResult> GetToDoItem(string id)
        {
            var item = await todoItemRepository.GetTodoItem(id);

            return new ObjectResult(item);
        }

        // POST: api/ToDoItems
        [HttpPost]
        public async Task PostToDoItem([FromBody] TodoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                HttpContext.Response.StatusCode = 400;
            }
            else
            {
                await todoItemRepository.AddTodoItem(toDoItem);

                var url = Url.RouteUrl("GetByIdRoute", new {id = toDoItem.Id.ToString()}, Request.Scheme,
                    Request.Host.ToUriComponent());
                HttpContext.Response.StatusCode = 201;
                HttpContext.Response.Headers["Location"] = url;
            }
        }

        // COMPLETE 
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> CompleteDoItem(string id)
        {
            Trace.TraceInformation("Deleting item '{0}'", id);

            var item = await todoItemRepository.GetTodoItem(id);

            if(item != null)
            {
                item.Complete = true;
                await todoItemRepository.UpdateTodoItem(item);
                return new StatusCodeResult(200); // 200 Ok
            }
            return NotFound();
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteToDoItem(string id)
        {
            Trace.TraceInformation("Deleting item '{0}'", id);

            if (await todoItemRepository.RemoveTodoItem(id))
            {
                return new StatusCodeResult(204); // 204 No Content
            }
            return NotFound();
        }
    }
}