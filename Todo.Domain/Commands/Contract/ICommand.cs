using Flunt.Notifications;

namespace Todo.Domain.Commands.Contract
{
    // Interface ICommand para padronizar a validação
    public interface ICommand
    {
        void Validate();
    }
}
