using MediatR;

namespace TodoApi.Application.Commands
{
    public class DeleteTodoItemCommand : IRequest<bool>
    {
        public long Id { get; init; }
    }
}