using Entities;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IPhoneRepository
    {
        void Add(Phone phone);
        void Update(Phone phone);
        void Delete(int id);
        List<Phone> GetAll();
        Phone GetById(int id);
    }
}
