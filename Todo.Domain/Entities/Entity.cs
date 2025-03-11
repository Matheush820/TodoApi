using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities;

// A classe Entity é abstrata, ou seja, não pode ser instanciada diretamente (não é possível usar "new Entity()").
// Serve como base para outras classes, definindo propriedades e comportamentos comuns.
public abstract class Entity : IEquatable<Entity>
{
    // O construtor gera um novo Id exclusivo (Guid) sempre que uma instância da entidade é criada.
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    // Propriedade que armazena o identificador único da entidade.
    public Guid Id { get; private set; }

    // Implementa a interface IEquatable<Entity> para comparar entidades com base no Id.
    //  IEquatable <> Ele compara se as duas Coisas são iguais, retornando verdadeiro ou falso.
    public bool Equals(Entity? other)
    {
        // Retorna verdadeiro se os Ids forem iguais; caso contrário, retorna falso.
        return Id == other.Id;
    }
}
