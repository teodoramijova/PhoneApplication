using BusinessLayer;
using DataAccess;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayerContract
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public PhoneViewModel Add(PhoneViewModel phoneViewModel)
        {
            var newPhone = new Phone
            {
                Code = phoneViewModel.Code,
                Price = phoneViewModel.Price,
                CategoryId = phoneViewModel.CategoryId,
                TypeId = phoneViewModel.TypeId
            };

            _phoneRepository.Add(newPhone);

            return phoneViewModel;
        }

        public Phone Delete(int id)
        {
            var result = _phoneRepository.GetById(id);
            if (result != null)
            {
                _phoneRepository.Delete(result.Id);
            }
            return result;
        }

        public List<Phone> GetAll()
        {
            return _phoneRepository.GetAll().ToList();
        }

        public PhoneViewModel GetById(int id)
        {
            var result = _phoneRepository.GetById(id);
            if (result != null)
            {
                return result.MapToViewModel();
            }
            return null;
        }

        public PhoneViewModel Update(PhoneViewModel phoneViewModel)
        {
            var result = _phoneRepository.GetById(phoneViewModel.Id);
            if (result != null)
            {
                result.Code = phoneViewModel.Code;
                result.Price = phoneViewModel.Price;
                result.CategoryId = phoneViewModel.CategoryId;
                result.TypeId = phoneViewModel.TypeId;
            }

            _phoneRepository.Update(result);
            return result.MapToViewModel();
        }
    }
}
