using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessContract
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBaseContext _context;

        public CategoryRepository(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();

        }
    }
}
