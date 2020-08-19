using DataAccess;
using Entities;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ContactService :IContactService
    {
        public IContactDataAccess ContactDataAccess { get; set; }

        public ContactService(IContactDataAccess contactDataAccess)
        {
            ContactDataAccess = contactDataAccess;
        }

        public Guid Create(ContactDTO contactDTO)
        {
            if (contactDTO.Identifier.HasValue)
            {
                throw new ParameterException("User guid should not be declared");
            }

            var contact = new Contact()
            {
                Name = contactDTO.Name,
                BirthDate = contactDTO.BirthDate,
                PersonalPhoneNumber = contactDTO.PersonalPhoneNumber,
                WorkPhoneNumber = contactDTO.WorkPhoneNumber,
                Email = contactDTO.Email,
                Company = contactDTO.Company,
                // Address = contactDTO.Address,
            };


            return ContactDataAccess.Create(contact);
        }

        public ContactDTO Read(Guid guid)
        {
            var contact = ContactDataAccess.Read(guid);

            if ( contact == null)
            {
                throw new NotFoundException($"Contact not found");
            }

            var contactDTO = new ContactDTO()
            {
                Identifier = contact.Identifier,
                Name = contact.Name,
                BirthDate = contact.BirthDate,
                PersonalPhoneNumber = contact.PersonalPhoneNumber,
                WorkPhoneNumber = contact.WorkPhoneNumber,
                Email = contact.Email,
                Company = contact.Company,
                ProfileImage = contact.ProfileImage
            };

            return contactDTO;
        }

        public void Update(ContactDTO contactDTO)
        {
            if (!contactDTO.Identifier.HasValue)
            {
                throw new ParameterException("User guid should not be declared");
            }

            var savedContact = ContactDataAccess.Read(contactDTO.Identifier.Value);

            if ( savedContact == null)
            {
                throw new NotFoundException($"Contact not found");
            }

            savedContact.Identifier = savedContact.Identifier;
            savedContact.Name = contactDTO.Name;
            savedContact.BirthDate = contactDTO.BirthDate;
            savedContact.PersonalPhoneNumber = contactDTO.PersonalPhoneNumber;
            savedContact.WorkPhoneNumber = contactDTO.WorkPhoneNumber;
            savedContact.Email = contactDTO.Email;
            savedContact.Company = contactDTO.Company;
            savedContact.ProfileImage = contactDTO.ProfileImage;

            ContactDataAccess.Update(savedContact);
        }

        public bool Delete(Guid guid)
        {
            return ContactDataAccess.Delete(guid);
        }

        public IList<Contact> Search(FilterContactDTO filterContactDTO)
        {
            return ContactDataAccess.Search(filterContactDTO);
        }
    }
}
