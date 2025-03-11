using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests;

[TestClass]
public class CreateTodoHandlerTests
{
    // Pr�-defini��o de comandos e handler para reutiliza��o nos testes
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("T�tulo da tarefa", "Matheus Henrique", DateTime.Now.AddDays(1));
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepositories());

    // Construtor para validar comandos uma �nica vez ao inicializar a classe de teste
    public CreateTodoHandlerTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Dado_um_Comando_invalido_deve_interromper_a_execucao()
    {
        // Executa o handler com o comando inv�lido e obt�m o resultado
        var result = (GenericCommandResult)_handler.Handler(_invalidCommand);

        // Verifica se o resultado reflete a falha esperada
        Assert.AreEqual(false, result.Sucess, "O comando inv�lido deveria interromper a execu��o.");

        // C�digo sem refatora��o para refer�ncia:
        /*
        // Cria��o do comando inv�lido
        var command = new CreateTodoCommand("", "", DateTime.Now);

        // Instancia��o do handler com um reposit�rio fake
        var handler = new TodoHandler(new FakeTodoRepositories());

        // Chama o handler com o comando e obt�m o resultado
        var result = (GenericCommandResult)handler.Handler(command);

        // Verifica se a execu��o foi interrompida
        Assert.AreEqual(false, result.Sucess, "O comando inv�lido deveria interromper a execu��o.");
        */
    }

    [TestMethod]
    public void Dado_um_Comando_valido_deve_criar_a_tarefa()
    {
        // Executa o handler com o comando v�lido e obt�m o resultado
        var result = (GenericCommandResult)_handler.Handler(_validCommand);

        // Verifica se o resultado reflete o sucesso esperado
        Assert.AreEqual(true, result.Sucess, "O comando v�lido deveria criar a tarefa.");

        // C�digo sem refatora��o para refer�ncia:
        /*
        // Cria��o do comando v�lido
        var command = new CreateTodoCommand("T�tulo da tarefa", "Matheus Henrique", DateTime.Now);

        var handler = new TodoHandler(new FakeTodoRepositories());

        var result = (GenericCommandResult)handler.Handler(command);

        Assert.AreEqual(true, result.Sucess, "O comando v�lido deveria criar a tarefa.");
        */
    }
}
