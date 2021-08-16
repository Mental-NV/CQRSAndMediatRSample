using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Models;
using Todo.Domain.Queries;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoItemsController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var result = await mediator.Send(new GetTodoItemsQuery());
            return Ok(result);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await mediator.Send(new GetTodoItemQuery() { Id = id });

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            bool result = await mediator.Send(new PutTodoItemCommand() { Id = id, TodoItem = todoItem });

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            TodoItem result = await mediator.Send(new PostTodoItemCommand() { TodoItem = todoItem });

            return CreatedAtAction(nameof(GetTodoItem), new { id = result.Id }, result);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            bool result = await mediator.Send(new DeleteTodoItemCommand() { Id = id });
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
