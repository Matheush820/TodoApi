namespace Todo.Domain.Entities;

// A classe Todo herda de Entity,
// obtendo as propriedades e comportamentos
// definidos na classe base. Ja tem o Guid e o
// IEquatable<Entity> implementado.
public class TodoItem : Entity
{
    public TodoItem(string title, string user,DateTime date)
    {
        Title = title;
        Done = false;
        Date = date;
        User = user;
    }

    public string Title { get; private set; } = string.Empty;
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }

    //Vou autenticar com o Google/ uma referencia ao usuario
    //vai trazer as informações do usuario do Google
    public string User { get; private set; } = string.Empty;

    //Marcar como Concluido
    public void MarkAsDone() => Done = true;

    //Marcar como Não Concluido
    public void MarkAsUndone() => Done = false;

    //Atualizar o Titulo
    public void UpdateTitle(string title) => Title = title;


}
