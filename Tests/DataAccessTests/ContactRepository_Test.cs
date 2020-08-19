using DataAccess;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ContactRepository_Test
    {
        private EntityRepository<Contact> ContactRepository { get; set; }

        public ContactRepository_Test()
        {
            ContactRepository = new EntityRepository<Contact>("Contact");
            DataGenerator.Generate().ForEach(contact => ContactRepository.Create(contact));
        }

        [TestMethod]
        public void TestInexistentContact()
        {
            var EmptyContactRepository = new EntityRepository<Contact>("Contact");

            Assert.IsNull(EmptyContactRepository.Get(Guid.NewGuid()));
        }

        [TestMethod]
        public void TestExistentContact()
        {
            var currentTestContactRepository = new EntityRepository<Contact>("Contact");

            var contactGuid = currentTestContactRepository.Create(new Contact());

            Assert.IsNotNull(currentTestContactRepository.Get(contactGuid));
        }

        [TestMethod]
        public void TestFetchAllContacts()
        {
            var currentTestContactRepository = new EntityRepository<Contact>("Contact");
            var contactsSaved = new Random().Next(0, 10);

            for (int i = 0; i < contactsSaved; i++)
            {
                Console.WriteLine(currentTestContactRepository.Create(new Contact()));
            }

            Assert.AreEqual(contactsSaved, currentTestContactRepository.All.Count());
        }

        [TestMethod]
        public void TestDeleteContact()
        {
            var currentTestContactRepository = new EntityRepository<Contact>("Contact");

            var contactGuid = currentTestContactRepository.Create(new Contact());
            currentTestContactRepository.Delete(contactGuid);

            Assert.AreEqual(0, currentTestContactRepository.All.Count());
        }

        [TestMethod]
        public void TestUpdateCompany()
        {
            var currentTestContactRepository = new EntityRepository<Contact>("Contact");

            var contact = DataGenerator.Build("John");
            contact.Identifier = currentTestContactRepository.Create(contact);

            var newCompanyName = "NewCompany";
            contact.Company = newCompanyName;
            currentTestContactRepository.Update(contact);

            Assert.AreEqual(newCompanyName, currentTestContactRepository.Get(contact.Identifier.Value).Company);
        }
    }
}
