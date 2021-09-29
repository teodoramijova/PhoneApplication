
using Entities;
using System.Collections.Generic;

namespace DataAccess
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
