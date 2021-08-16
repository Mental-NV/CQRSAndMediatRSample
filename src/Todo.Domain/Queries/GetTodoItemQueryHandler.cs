using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Models;

namespace Todo.Domain.Queries
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItem>
    {
        private readonly ITodoItemsRepository todoItemsRepository;

        public GetTodoItemQueryHandler(ITodoItemsRepository todoItemsRepository)
        {
            this.todoItemsRepository = todoItemsRepository ?? throw new System.ArgumentNullException(nameof(todoItemsRepository));
        }

        public async Task<TodoItem> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await todoItemsRepository.GetTodoItem(request.Id);
            return todoItem;
        }
    }
}