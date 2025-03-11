using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contract;

namespace Todo.Domain.Commands;
public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
         .Requires()
         .IsNotNull(Id, "Id", "Id não pode ser vazio")
         .IsNotNullOrEmpty(Title, "Title", "Título não pode ser vazio")
         .IsGreaterOrEqualsThan(Title, 3, "Title", "Título deve ter pelo menos 3 caracteres")
         .IsNotNullOrEmpty(User, "User", "Usuário não pode ser vazio")
         .IsGreaterOrEqualsThan(User, 5, "User", "Usuário deve ter pelo menos 5 caracteres")
        );
    }
}
