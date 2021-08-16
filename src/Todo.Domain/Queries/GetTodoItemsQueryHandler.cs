using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Todo.Domain.Models;

namespace Todo.Domain.Queries
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, IEnumerable<TodoItem>>
    {
        private readonly ITodoItemsRepository todoItemsRepository;

        public GetTodoItemsQueryHandler(ITodoItemsRepository todoItemsRepository)
        {
            this.todoItemsRepository = todoItemsRepository ?? throw new System.ArgumentNullException(nameof(todoItemsRepository));

        }

        public async Task<IEnumerable<TodoItem>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return await todoItemsRepository.GetTodoItems();
        }
    }
}