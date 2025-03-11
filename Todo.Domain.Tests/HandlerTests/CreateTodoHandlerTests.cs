using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests;

[TestClass]
public class CreateTodoHandlerTests
{
    // Pré-definição de comandos e handler para reutilização nos testes
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da tarefa", "Matheus Henrique", DateTime.Now.AddDays(1));
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepositories());

    // Construtor para validar comandos uma única vez ao inicializar a classe de teste
    public CreateTodoHandlerTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Dado_um_Comando_invalido_deve_interromper_a_execucao()
    {
        // Executa o handler com o comando inválido e obtém o resultado
        var result = (GenericCommandResult)_handler.Handler(_invalidCommand);

        // Verifica se o resultado reflete a falha esperada
        Assert.AreEqual(false, result.Sucess, "O comando inválido deveria interromper a execução.");

        // Código sem refatoração para referência:
        /*
        // Criação do comando inválido
        var command = new CreateTodoCommand("", "", DateTime.Now);

        // Instanciação do handler com um repositório fake
        var handler = new TodoHandler(new FakeTodoRepositories());

        // Chama o handler com o comando e obtém o resultado
        var result = (GenericCommandResult)handler.Handler(command);

        // Verifica se a execução foi interrompida
        Assert.AreEqual(false, result.Sucess, "O comando inválido deveria interromper a execução.");
        */
    }

    [TestMethod]
    public void Dado_um_Comando_valido_deve_criar_a_tarefa()
    {
        // Executa o handler com o comando válido e obtém o resultado
        var result = (GenericCommandResult)_handler.Handler(_validCommand);

        // Verifica se o resultado reflete o sucesso esperado
        Assert.AreEqual(true, result.Sucess, "O comando válido deveria criar a tarefa.");

        // Código sem refatoração para referência:
        /*
        // Criação do comando válido
        var command = new CreateTodoCommand("Título da tarefa", "Matheus Henrique", DateTime.Now);

        var handler = new TodoHandler(new FakeTodoRepositories());

        var result = (GenericCommandResult)handler.Handler(command);

        Assert.AreEqual(true, result.Sucess, "O comando válido deveria criar a tarefa.");
        */
    }
}
