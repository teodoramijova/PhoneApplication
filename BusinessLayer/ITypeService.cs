using Entities;
using Entities.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface ITypeService
    {
        Entities.Type Add(TypeViewModel typeViewModel);
        Entities.Type Update(int id, string name, string code);
        Entities.Type Delete(int id);
        List<Entities.Type> GetAll();
        Entities.Type GetById(int id);
    }
}
