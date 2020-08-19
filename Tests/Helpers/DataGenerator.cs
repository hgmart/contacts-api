using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class DataGenerator
    {
        public static IList<string> Names()
        {
            return new string[]{ "Harry", "John", "Oliver", "Thomas", "George", "Thomas", "Charlie", "Kyle", "Michael", "Joseph", "James" }.ToList();
        }

        public static List<Contact> Generate()
        {
            return Names().Select(name => Build(name)).ToList();
        }

        public static string Email(string name)
        {
            return $"{name.ToLower()}@email.com";
        }

        public static Contact Build(string name)
        {
            var contact = new Contact()
            {
                Name = name,
                Email = Email(name),
                Address = "address",
                Company = "company",
                BirthDate = DateTime.Now,
                PersonalPhoneNumber = DateTime.Now.Ticks.ToString(),
                WorkPhoneNumber = DateTime.Now.Ticks.ToString(),
            };

            Console.WriteLine(contact.Email);

            return contact;
        }
    }
}
