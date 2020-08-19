using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ContactDataAccess_Tests
    {
        private IContactDataAccess ContactDataAccess;

        public ContactDataAccess_Tests()
        {
            ContactDataAccess = new ContactDataAccess();
            
            DataGenerator.Generate().ForEach(contact => ContactDataAccess.Create(contact));
        }

        [TestMethod]
        public void TestSearchFiveContacts()
        {
            var results = 5;

            var filterDTO = new FilterContactDTO()
            {
                Results = results,
            };

            Assert.AreEqual(results, ContactDataAccess.Search(filterDTO).Count);
        }


        [TestMethod]
        public void TestFetchContactByEmail()
        {
            var email = DataGenerator.Email(DataGenerator.Names().First());

            var filterDTO = new FilterContactDTO()
            {
                Results = 5,
                Email = email,
            };

            Assert.AreEqual(email, ContactDataAccess.Search(filterDTO).Single().Email);
        }

        [TestMethod]
        public void TestFetchContactByPhoneNumber()
        {
            var contact = DataGenerator.Build("Martin");

            contact.Identifier = ContactDataAccess.Create(contact);

            var filterDTO = new FilterContactDTO()
            {
                Results = 5,
                PersonalPhoneNumber = contact.PersonalPhoneNumber,
            };

            Assert.AreEqual(contact.Identifier, ContactDataAccess.Search(filterDTO).Single().Identifier);
        }


    }
}
