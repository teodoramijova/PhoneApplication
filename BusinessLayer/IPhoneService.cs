using Entities;
using Entities.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IPhoneService
    {
        PhoneViewModel Add(PhoneViewModel phoneViewModel);
        PhoneViewModel Update(PhoneViewModel phoneViewModel);
        Phone Delete(int id);
        List<Phone> GetAll();
        PhoneViewModel GetById(int id);
    }
}
