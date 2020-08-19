using DataAccess;
using Entities;
using System.Collections.Generic;

namespace Service
{
    public interface IContactService : ICRUDService<ContactDTO>
    {
        IList<Contact> Search(FilterContactDTO filterContactDTO);
    }
}
