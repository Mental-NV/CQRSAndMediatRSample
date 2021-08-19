using Todo.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infrastructure.Dapper
{
    public static class TodoItemsRepositoryDapperConfiguration
    {
        public static void AddTodoItemsRepositoryDapper(this IServiceCollection services, string connectionString)
        {
            services
                .AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>(sp => new SqlConnectionFactory(connectionString))
                .AddScoped<ITodoItemsRepository, TodoItemsRepositoryDapper>();
        }
    }
}