using MediatR;
using TodoApi.Application.Models;

namespace TodoApi.Application.Queries
{
    public class GetTodoItemQuery : IRequest<TodoItem>
    {
        public long Id { get; init; }
    }
}