using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Domain.Models;

namespace Todo.Domain
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