using DesignPatterns.EntityFramework.Data;
using DesignPatterns.Repository.UnicOfWork;
using DesignPatternsAPP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignPatternsAPP.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ClientViewModel> clients = from d in _unitOfWork.Clients.Get()
                                                   select new ClientViewModel
                                                   {
                                                       ClientId = d.ClientId,
                                                       Name = d.ClientName,
                                                       CountryId = d.CountryId ?? 0,
                                                       Country = d.CountryId.HasValue ? _unitOfWork.Countries.Get(d.CountryId.Value).CountryName : "Nothing here",
                                                       Email = d.ClientEmail
                                                   };
            return View("Index", clients);
        }

        [HttpGet]
        public IActionResult Add()
        {


            GetCountriesData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormClientViewModel data)
        {

            if (!ModelState.IsValid)
            {
                GetCountriesData();
                return View("Add", data);
            }

            var client = new Client
            {
                ClientId = Guid.NewGuid(),
                ClientEmail = data.Email,
                ClientName = data.Name,
                CountryId = data.CountryId ?? CreateNewCountry(data.OtherCountry)
            };

            _unitOfWork.Clients.Add(client);
            _unitOfWork.Clients.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid? ClientId)
        {
            if (ClientId.HasValue)
            {
                _unitOfWork.Clients.DeleteByGuid(ClientId.Value);
                _unitOfWork.Clients.Save();
            };
            return RedirectToAction("Index");
        }
        private int? CreateNewCountry(string otherCountry)
        {
            Country data = _unitOfWork.Countries.Get().Where(o => o.CountryName.ToLower() == otherCountry.ToLower().Trim()).FirstOrDefault();

            if (data == null)
            {
                var country = new Country
                {
                    CountryName = otherCountry.Trim()
                };
                _unitOfWork.Countries.Add(country);
                _unitOfWork.Countries.Save();
                return country.CountryId;
            }
            else
            {
                return data.CountryId;
            }

        }


        #region HELPERS
        private void GetCountriesData()
        {
            var _countries = _unitOfWork.Countries.Get();

            ViewBag.Countries = new SelectList(_countries, "CountryId", "CountryName");

        }
        #endregion
    }
}
