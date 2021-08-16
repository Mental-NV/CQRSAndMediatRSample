using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Todo.Domain.Models;

namespace Todo.Domain.Commands
{
    public class PostTodoItemCommandHandler : IRequestHandler<PostTodoItemCommand, TodoItem>
    {
        private readonly ITodoItemsRepository todoItemsRepository;
        public PostTodoItemCommandHandler(ITodoItemsRepository todoItemsRepository)
        {
            this.todoItemsRepository = todoItemsRepository ?? throw new ArgumentNullException(nameof(todoItemsRepository));
        }

        public async Task<TodoItem> Handle(PostTodoItemCommand request, CancellationToken cancellationToken)
        {
            return await todoItemsRepository.PostTodoItem(request.TodoItem);
        }
    }
}