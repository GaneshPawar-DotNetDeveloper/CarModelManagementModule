using System.Collections.Generic;
using System.Web.Mvc;
using CarModels.DataAccess;
using CarModels.Models;
using System.Linq;

namespace CarModels.Controllers
{
    public class CarModelController : Controller
    {
        private readonly CarModelRepository _repository = new CarModelRepository();

        public ActionResult Index()
        {
            List<CarModel> carModels = _repository.GetCarModels();

            return View(carModels);
        }

        public ActionResult Create()
        {
            return View(new CarModel());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _repository.AddCarModel(carModel);
                return RedirectToAction("Index");
            }
            return View(carModel);
        }

        // Additional actions for Edit, Delete, etc.
    }
}
