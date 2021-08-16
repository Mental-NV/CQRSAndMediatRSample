using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Application.Models;

namespace TodoApi.Application
{
    public interface ITodoItemsRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(long id);
        Task<bool> PutTodoItem(long id, TodoItem todoItem);
        Task<TodoItem> PostTodoItem(TodoItem todoItem);
        Task<bool> DeleteTodoItem(long id);
    }
}