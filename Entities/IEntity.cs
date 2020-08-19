using System;

namespace Entities
{
    public interface IEntity
    {
        Guid? Identifier { get; set; }
    }
}
