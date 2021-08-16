using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Todo.Domain.Commands
{
    public class PutTodoitemCommandHandler : IRequestHandler<PutTodoItemCommand, bool>
    {
        private readonly ITodoItemsRepository todoItemsRepository;
        public PutTodoitemCommandHandler(ITodoItemsRepository todoItemsRepository)
        {
            this.todoItemsRepository = todoItemsRepository ?? throw new System.ArgumentNullException(nameof(todoItemsRepository));
        }

        public async Task<bool> Handle(PutTodoItemCommand request, CancellationToken cancellationToken)
        {
            return await todoItemsRepository.PutTodoItem(request.Id, request.TodoItem);
        }
    }
}