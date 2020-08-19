using System;

namespace Service
{
    public interface ICRUDService<EntityDTO> where EntityDTO : class
    {
        Guid Create(EntityDTO entityDTO);

        EntityDTO Read(Guid guid);

        void Update(EntityDTO entityDTO);

        bool Delete(Guid guid);
    }
}
