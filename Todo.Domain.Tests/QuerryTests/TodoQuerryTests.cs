using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests;

[TestClass]
public class TodoQuerryTests
{
    private List<TodoItem> _items;
    public TodoQuerryTests()
    {
        _items=new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1","usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "Matheus", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "Matheus", DateTime.Now));

    }
    [TestMethod]
    public void DeveRetornarTarefasApenasDoUsuarioMatheus()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("Matheus"));
        Assert.AreEqual(2, result.Count());
    }
}
