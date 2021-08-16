using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodoApi.Application.Models;

namespace TodoApi.Application.Commands
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