using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Contract;

namespace Todo.Domain.Commands;
public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult() { }
    public GenericCommandResult(bool sucess, string message, object data)
    {
        Sucess = sucess;
        Message = message;
        Data = data;
    }

    public bool Sucess { get; set; }
    public string Message { get; set; } = string.Empty;
    public object Data { get; set; }
}
