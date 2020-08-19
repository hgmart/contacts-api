using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataGenerator_Test
    {

        [TestMethod]
        public void TestGenerateContactName()
        {
            var contactName = "Martin";
            var contact = DataGenerator.Build(contactName);

            Assert.AreEqual(contactName, contact.Name);
        }

        [TestMethod]
        public void TestGenerateContactEmail()
        {
            var contactName = "Martin";
            var contact = DataGenerator.Build(contactName);

            Assert.AreEqual($"{contactName.ToLower()}@email.com", contact.Email);
        }

        [TestMethod]
        public void TestGenerateData()
        {
            var contacts = DataGenerator.Generate();

            Assert.IsFalse(contacts.Count == 0, "Falló la carga de usuarios");
        }
    }
}
