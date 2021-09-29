using Entities;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface ICategoryService
    {
        Category Add(string name, string description);
        Category Update(int id, string name, string description);
        Category Delete(int id);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
