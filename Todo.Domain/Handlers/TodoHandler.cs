using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contract;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;
public class TodoHandler : Notifiable<Notification>, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
{
    private ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }


    public ICommandResult Handler(CreateTodoCommand command)
    {
        // Fail Fast Validation (valida imediatamente)
        command.Validate();
        if (!command.IsValid)
        {
            return new GenericCommandResult(
                false,
                "Ops, parece que sua tarefa está errada. Verifique as validações.",
                command.Notifications);
        }

        // Gera o TodoItem com os dados do comando
        var todo = new TodoItem(command.Title, command.User, command.Date);

        // Salva o TodoItem no banco
        _repository.Create(todo);

        // Retorna o resultado com sucesso
        return new GenericCommandResult(true, "Tarefa salva com sucesso!", todo);
    }


    public ICommandResult Handler(UpdateTodoCommand command)
    {
        // Fail Fast Validation
        command.Validate();
        if (!command.IsValid)
        
            return new GenericCommandResult(
                false,
                "Ops, parece que sua tarefa está errada. Verifique as validações.",
                command.Notifications);

        // Recuperar o todo do banco
        var todo = _repository.GetById(command.Id, command.User);

        todo.UpdateTitle(command.Title);

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);


    }

    public ICommandResult Handler(MarkTodoAsDoneCommand command)
    {
        //Fail fast validation
        command.Validate();
        if (!command.IsValid)

            return new GenericCommandResult(
                false,
                "Ops, parece que sua tarefa está errada. Verifique as validações.",
                command.Notifications);

        // recuperar o todo do banco
        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsDone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
    }

    public ICommandResult Handler(MarkTodoAsUndoneCommand command)
    {
        command.Validate();
        if (!command.IsValid)

            return new GenericCommandResult(
                false,
                "Ops, parece que sua tarefa está errada. Verifique as validações.",
                command.Notifications);


        var todo = _repository.GetById(command.Id, command.User);

        todo.MarkAsUndone();

        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa atualizada com sucesso!", todo);
    }
}
