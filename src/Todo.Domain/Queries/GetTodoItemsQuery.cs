using System.Collections.Generic;
using MediatR;
using Todo.Domain.Models;

namespace Todo.Domain.Queries
{
    public class GetTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {
    }
}