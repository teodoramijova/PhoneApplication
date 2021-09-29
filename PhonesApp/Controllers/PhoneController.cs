using BusinessLayer;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PhonesApp.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public IActionResult Phones()
        {
            return View();
        }

        public IActionResult GetPhones()
        {
            var result = _phoneService.GetAll().ToList();
            return Json(new { data = result });
        }

        [HttpGet]
        public IActionResult AddOrEdit(int id)
        {
            if(id == 0)
            {
                return View(new Entities.Models.PhoneViewModel());
            } else
            {
                return View(_phoneService.GetById(id));
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(PhoneViewModel phoneViewModel)
        {
            if(phoneViewModel.Id == 0)
            {
                _phoneService.Add(phoneViewModel);
                return Redirect("/Phone/Phones");
            }
            else
            {
                _phoneService.Update(phoneViewModel);
                return Redirect("/Phone/Phones");
            }

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _phoneService.GetById(id);
            if(result != null)
            {
                _phoneService.Delete(result.Id);
            }

            return Redirect("/Phone/Phones");
        }   
    }
}
