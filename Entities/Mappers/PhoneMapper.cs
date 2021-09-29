using Entities.Models;

namespace Entities
{
    public static class PhoneMapper
    {
        public static PhoneViewModel MapToViewModel(this Phone domainModel)
        {
            var viewModel = new PhoneViewModel
            {
                Id = domainModel.Id,
                Code = domainModel.Code,
                Price = domainModel.Price,
                CategoryId = domainModel.CategoryId,
                TypeId = domainModel.TypeId
            };
            return viewModel;
        }
    }
}
