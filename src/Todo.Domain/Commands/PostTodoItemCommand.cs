using MediatR;

using Todo.Domain.Models;

namespace Todo.Domain.Commands
{
    public class PostTodoItemCommand : IRequest<TodoItem>
    {
        public TodoItem TodoItem { get; init; }
    }
}