using System.Collections.Generic;
using MediatR;
using TodoApi.Application.Models;

namespace TodoApi.Application.Queries
{
    public class GetTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {
    }
}