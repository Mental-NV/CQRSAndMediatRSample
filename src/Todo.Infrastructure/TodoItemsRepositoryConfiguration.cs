using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain;

namespace Todo.Infrastructure
{
    public static class TodoItemsRepositoryConfiguration
    {
        public static void AddTodoItemsRepository(this IServiceCollection services)
        {
            services
                .AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"))
                .AddScoped<ITodoItemsRepository, TodoItemsRepository>();
        }
    }
}