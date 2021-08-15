using MediatR;

using TodoApi.Application.Models;

namespace TodoApi.Application.Commands
{
    public class PostTodoItemCommand : IRequest<TodoItem>
    {
        public TodoItem TodoItem { get; init; }
    }
}