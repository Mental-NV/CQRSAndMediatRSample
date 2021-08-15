using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Application;
using TodoApi.Application.Models;

namespace TodoApi.Infrastructure
{
    public class TodoItemsRepository : ITodoItemsRepository
    {
        private readonly TodoContext todoContext;
        public TodoItemsRepository(TodoContext todoContext)
        {
            this.todoContext = todoContext;
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            return await todoContext.TodoItems.FindAsync(id);
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return await todoContext.TodoItems.ToListAsync();
        }

        public async Task<bool> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                throw new InvalidOperationException();
            }

            todoContext.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await todoContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            todoContext.TodoItems.Add(todoItem);
            await todoContext.SaveChangesAsync();

            return todoItem;
        }

        public async Task<bool> DeleteTodoItem(long id)
        {
            var todoItem = await todoContext.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return false;
            }

            todoContext.TodoItems.Remove(todoItem);
            await todoContext.SaveChangesAsync();

            return true;
        }

        private bool TodoItemExists(long id)
        {
            return todoContext.TodoItems.Any(e => e.Id == id);
        }
    }
}