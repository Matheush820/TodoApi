using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    // Pré-definição de comandos válidos e inválidos para reutilização nos testes
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now); //Dados inválidos
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da tarefa", "Matheus", DateTime.Now.AddDays(1)); //Dados válidos

    // Construtor da classe de teste, validando os comandos uma vez ao inicializar
    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Deve_Retornar_Invalido_Quando_Dados_Forem_Invalidos()
    {
        // Verifica se o comando inválido foi corretamente marcado como inválido
        Assert.AreEqual(false, _invalidCommand.IsValid, "O comando inválido deveria retornar false.");

        // Código sem refatoração para referência:
        /*
        // Cria uma instância de comando inválido para este teste
        var command = new CreateTodoCommand("", "", DateTime.Now);

        // Valida o comando
        command.Validate();

        // Verifica se o comando foi marcado como inválido
        Assert.AreEqual(false, command.IsValid, "O comando inválido deveria retornar false.");
        */
    }

    [TestMethod]
    public void Deve_Retornar_Valido_Quando_Dados_Forem_Validos()
    {
        // Verifica se o comando válido foi corretamente marcado como válido
        Assert.AreEqual(true, _validCommand.IsValid, "O comando válido deveria retornar true.");

        // Código sem refatoração para referência:
        /*
        // Cria uma instância de comando válido para este teste
        var command = new CreateTodoCommand("Título da tarefa", "Matheus", DateTime.Now.AddDays(1));

        // Valida o comando
        command.Validate();

        // Verifica se o comando foi marcado como válido
        Assert.AreEqual(true, command.IsValid, "O comando válido deveria retornar true.");
        */
    }
}
