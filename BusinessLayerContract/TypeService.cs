using BusinessLayer;
using DataAccess;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayerContract
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public Entities.Type Add(TypeViewModel typeViewModel)
        {
            var newType = new Entities.Type
            {
                Name = typeViewModel.Name,
                Code = typeViewModel.Code
            };

            _typeRepository.Add(newType);
            return newType;
        }

        public Entities.Type Delete(int id)
        {
            var result = _typeRepository.GetById(id);
            if (result != null)
            {
                _typeRepository.Delete(result.Id);
            }

            return result;
        }

        public List<Entities.Type> GetAll()
        {
            return _typeRepository.GetAll().ToList();
        }

        public Entities.Type GetById(int id)
        {
            return _typeRepository.GetById(id);
        }

        public Entities.Type Update(int id, string name, string code)
        {
            var result = _typeRepository.GetById(id);
            if (result != null)
            {
                result.Name = name;
                result.Code = code;
            }

            _typeRepository.Update(result);
            return result;
        }
    }
}
