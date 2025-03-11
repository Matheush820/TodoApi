using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contract;

namespace Todo.Domain.Handlers.Contracts;

//Meu Handler é um contrato que recebe um comando
//e retorna um resultado de comando
public interface IHandler<T> where T : ICommand
{
    ICommandResult Handler(T command);
}
