using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TodoApi.Application.Commands
{
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, bool>
    {
        private readonly ITodoItemsRepository todoItemsRepository;

        public DeleteTodoItemCommandHandler(ITodoItemsRepository todoItemsRepository)
        {
            this.todoItemsRepository = todoItemsRepository ?? throw new System.ArgumentNullException(nameof(todoItemsRepository));
        }

        public async Task<bool> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            return await todoItemsRepository.DeleteTodoItem(request.Id);
        }
    }
}