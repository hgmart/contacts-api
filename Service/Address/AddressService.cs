using DataAccess;
using System;
using Entities;

namespace Service
{
    public class AddressService : IAddressService
    {
        public IAddressDataAccess AddressDataAccess { get; set; }

        public AddressService(IAddressDataAccess addressDataAccess)
        {
            AddressDataAccess = addressDataAccess;
        }

        public Guid Create(AddressDTO addressDTO)
        {
            if (addressDTO.Identifier.HasValue)
            {
                throw new ParameterException("Address guid should not be declared");
            }

            var Address = new Address()
            {
                Identifier = addressDTO.Identifier,
                Name = addressDTO.Name,
                Number = addressDTO.Number,
                City = addressDTO.City,
                State = addressDTO.State
            };


            return AddressDataAccess.Create(Address);
        }

        public AddressDTO Read(Guid guid)
        {
            var address = AddressDataAccess.Read(guid);

            if (address == null)
            {
                throw new NotFoundException($"Address not found");
            }

            var AddressDTO = new AddressDTO()
            {
                Identifier = address.Identifier,
                Name = address.Name,
                Number = address.Number,
                City = address.City,
                State = address.State
            };

            return AddressDTO;
        }

        public void Update(AddressDTO addressDTO)
        {
            if (!addressDTO.Identifier.HasValue)
            {
                throw new ParameterException("User guid should not be declared");
            }

            var address = AddressDataAccess.Read(addressDTO.Identifier.Value);

            if (address == null)
            {
                throw new NotFoundException($"Address not found");
            }

            address.Identifier = addressDTO.Identifier;
            address.Name = addressDTO.Name;
            address.Number = addressDTO.Number;
            address.City = addressDTO.City;
            address.State = addressDTO.State;

            AddressDataAccess.Update(address);
        }

        public bool Delete(Guid guid)
        {
            return AddressDataAccess.Delete(guid);
        }
    }
}
