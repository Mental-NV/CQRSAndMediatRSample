using MediatR;

namespace Todo.Domain.Commands
{
    public class DeleteTodoItemCommand : IRequest<bool>
    {
        public long Id { get; init; }
    }
}