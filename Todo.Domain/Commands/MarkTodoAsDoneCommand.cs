using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contract;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Todo.Domain.Commands;
public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsDoneCommand() { }

    public MarkTodoAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
         .Requires()
         .IsNotNull(Id, "Id", "Id não pode ser vazio")
         .IsNotNullOrEmpty(User, "User", "Usuário não pode ser vazio")
         .IsGreaterOrEqualsThan(User, 5, "User", "Usuário deve ter pelo menos 5 caracteres")
        );

    }
}
