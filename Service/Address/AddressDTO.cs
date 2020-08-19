using System;

namespace Service
{
    public class AddressDTO
    {
        public Guid? Identifier { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
