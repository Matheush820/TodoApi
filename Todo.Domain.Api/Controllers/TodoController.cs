using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAll(user);
    }

    [HttpGet("undone")]
    public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllUndone(user);
    }

    [HttpGet("done/today")]
    public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date, true);
    }

    [HttpGet("undone/today")]
    public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date, false);
    }

    [HttpGet("done/tomorrow")]
    public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
    }

    [HttpGet("undone/tomorrow")]
    public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
    }

    [HttpPost]
    public GenericCommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
    {
        command.User = "matheushenrique";
        return (GenericCommandResult)handler.Handler(command);
    }

    [HttpPut]
    public GenericCommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
    {
        command.User = "matheushenrique";
        return (GenericCommandResult)handler.Handler(command);
    }

    [HttpPut("mark-as-done")]
    public GenericCommandResult MarkAsDone([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
    {
        command.User = "matheushenrique";
        return (GenericCommandResult)handler.Handler(command);
    }

    [HttpPut("mark-as-undone")]
    public GenericCommandResult MarkAsUndone([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
    {
        command.User = "matheushenrique";
        return (GenericCommandResult)handler.Handler(command);
    }
}
