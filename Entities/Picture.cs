using System;

namespace Entities
{
    public class Picture : IEntity
    {
        public Guid? Identifier { get; set; }
        public string ImageBase64 { get; set; }
    }
}
