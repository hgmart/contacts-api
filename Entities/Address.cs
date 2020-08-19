using System;

namespace Entities
{
    public class Address : IEntity
    {
        public Guid? Identifier { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
