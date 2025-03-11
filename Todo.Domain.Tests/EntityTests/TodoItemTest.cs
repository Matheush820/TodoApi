using Todo.Domain.Entities;

namespace Todo.Domain.Tests;

[TestClass]
public class TodoItemTest
{
    private readonly TodoItem _todo = new TodoItem("Título aqui", "usuario", DateTime.Now);
    [TestMethod]
    public void DadoUmNovoTodoNaoPodeSerConcluido()
    {
        //teste do TodoItem
        //var todo = new TodoItem("Título aqui", "usuario", DateTime.Now);
        //Assert.AreEqual(todo.Done, false);
        Assert.AreEqual(_todo.Done, false);


    }
}
