using MediatR;
using Todo.Domain.Models;

namespace Todo.Domain.Queries
{
    public class GetTodoItemQuery : IRequest<TodoItem>
    {
        public long Id { get; init; }
    }
}