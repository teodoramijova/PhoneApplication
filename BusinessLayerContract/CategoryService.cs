using BusinessLayer;
using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayerContract
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Category Add(string name, string description)
        {
            var newCategory = new Category
            {
                Name = name,
                Description = description
            };

            _categoryRepository.Add(newCategory);
            return newCategory;
        }

        public Category Delete(int id)
        {
            var result = _categoryRepository.GetById(id);
            if (result != null)
            {
                _categoryRepository.Delete(result.Id);
            }

            return result;
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category Update(int id, string name, string description)
        {
            var result = _categoryRepository.GetById(id);
            if (result != null)
            {
                result.Name = name;
                result.Description = description;
            }

            _categoryRepository.Update(result);
            return result;
        }
    }
}
