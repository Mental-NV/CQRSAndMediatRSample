using MediatR;
using TodoApi.Application.Models;

namespace TodoApi.Application.Commands
{
    public class PutTodoItemCommand : IRequest<bool>
    {
        public long Id { get; init; }

        public TodoItem TodoItem { get; init; }
    }
}