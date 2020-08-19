using System;

namespace Entities
{
    public class Contact : IEntity
    {
        public Guid? Identifier { get; set; }

        public string Name { get; set; }
        
        public string Company { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; } 

        public string WorkPhoneNumber { get; set; }

        public string PersonalPhoneNumber { get; set; }

        public Guid? ProfileImage { get; set; }
        public Address Address { get; set; }
    }
}
