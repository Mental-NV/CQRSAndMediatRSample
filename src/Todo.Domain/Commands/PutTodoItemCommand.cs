using MediatR;
using Todo.Domain.Models;

namespace Todo.Domain.Commands
{
    public class PutTodoItemCommand : IRequest<bool>
    {
        public long Id { get; init; }

        public TodoItem TodoItem { get; init; }
    }
}