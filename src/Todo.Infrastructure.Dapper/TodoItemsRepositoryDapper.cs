using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Todo.Domain;
using Todo.Domain.Models;

namespace Todo.Infrastructure.Dapper
{
    public class TodoItemsRepositoryDapper : ITodoItemsRepository
    {
        private readonly ISqlConnectionFactory connectionFactory;

        public TodoItemsRepositoryDapper(ISqlConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory ?? throw new System.ArgumentNullException(nameof(connectionFactory));
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            string sql = "SELECT Id, Name, IsComplete FROM TodoList";
            using (SqlConnection connection = await connectionFactory.CreateConnectionAsync())
            {
                IEnumerable<TodoItem> items = await connection.QueryAsync<TodoItem>(sql);
                return items;
            }
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            string sql = "SELECT Id, Name, IsComplete FROM TodoList WHERE Id = @Id";
            using (SqlConnection connection = await connectionFactory.CreateConnectionAsync())
            {
                TodoItem item = await connection.QuerySingleOrDefaultAsync<TodoItem>(sql, new { Id = id });
                return item;
            }
        }

        public async Task<TodoItem> PostTodoItem(TodoItem todoItem)
        {
            string sql = "INSERT INTO TodoList(Name, IsComplete) OUTPUT inserted.Id VALUES(@Name, @IsComplete)";
            using (SqlConnection connection = await connectionFactory.CreateConnectionAsync())
            {
                long id = await connection.ExecuteScalarAsync<long>(sql, new { Name = todoItem.Name, IsComplete = todoItem.IsComplete });
                todoItem.Id = id;
                return todoItem;
            }
        }

        public async Task<bool> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                throw new InvalidOperationException();
            }

            string sql = "UPDATE TodoList SET Name = @Name, IsComplete = @IsComplete WHERE Id = @Id";
            using (SqlConnection connection = await connectionFactory.CreateConnectionAsync())
            {
                int affectedRows = await connection.ExecuteAsync(sql, new { Id = todoItem.Id, Name = todoItem.Name, IsComplete = todoItem.IsComplete });
                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteTodoItem(long id)
        {
            string sql = "DELETE FROM TodoList WHERE Id = @Id";
            using (SqlConnection connection = await connectionFactory.CreateConnectionAsync())
            {
                int affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows > 0;
            }
        }
    }
}