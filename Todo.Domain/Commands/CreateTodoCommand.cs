using Flunt.Notifications;
using Flunt.Validations;
using System;
using Todo.Domain.Commands.Contract;

namespace Todo.Domain.Commands
{
    // Comando para criar um Todo
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {
        public CreateTodoCommand() { }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        // Método para adicionar notificações de validação
        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
             .Requires()
             .IsNotNullOrEmpty(Title, "Title", "Título não pode ser vazio")
             .IsGreaterOrEqualsThan(Title, 3, "Title", "Título deve ter pelo menos 3 caracteres")
             .IsNotNullOrEmpty(User, "User", "Usuário não pode ser vazio")
             .IsGreaterOrEqualsThan(User, 5, "User", "Usuário deve ter pelo menos 5 caracteres")
             .IsGreaterThan(Date, DateTime.Now, "Date", "Data deve ser futura")
);

        }
    }
}
