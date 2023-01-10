using DesignPatterns.Dapper.Models;
using DesignPatterns.EntityFramework.Data;
using DesignPatterns.Repository.UnicOfWork;
using DesignPatternsAPP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsAPP.Controllers
{
    public class PetController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public PetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {

            IEnumerable<PetViewModel> pets = from d in _unitOfWork.Pets.GetAll()
                                             select new PetViewModel
                                             {
                                                 PetId = d.PetId,
                                                 PetName = d.PetName

                                             };
            return View("Index", pets);

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormPetViewModel data)
        {

            if (!ModelState.IsValid)
            {

                return View("Add", data);
            }

            var myPet = new Pet
            {
                PetName = data.PetName
            };

            _unitOfWork.Pets.Add(myPet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? PetId)
        {
            if (PetId.HasValue)
            {
                _unitOfWork.Pets.Delete(PetId.Value);

            };
            return RedirectToAction("Index");
        }
    }
}
