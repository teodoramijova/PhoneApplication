using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface ITypeRepository
    {
        void Add(Entities.Type type);
        void Update(Entities.Type type);
        void Delete(int id);
        List<Entities.Type> GetAll();
        Entities.Type GetById(int id);
    }
}
