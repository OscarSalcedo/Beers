using Beers.services.Implementations;
using Beers.web.Models.BeerType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Controllers
{
    public class BeerTypeController : Controller
    {
        private BeerTypeService _beerTypeService;
        public BeerTypeController()
        {
            _beerTypeService = new BeerTypeService();
        }

        // GET: BeerType
        public ActionResult Index()
        {
            var model = new BeerTypeViewModelIndex();
            model.BeerTypeViewModelList = _beerTypeService.GetAll().ToBeerTypeModelList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Filter(BeerTypeViewModelFilter filter)
        {
            var model = new BeerTypeViewModelIndex(filter);
            if (string.IsNullOrWhiteSpace(filter.StringFilter))
            {
                model.BeerTypeViewModelList = _beerTypeService.GetAll().ToBeerTypeModelList();
            }
            else
            {
                model.BeerTypeViewModelList = _beerTypeService.GetByName(filter.StringFilter).ToBeerTypeModelList();
            }
            return View("Index", model);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BeerTypeViewModelCreate source)
        {
            _beerTypeService.CreateBeerType(source.StringType);

            return View("Index");
        }
        public ActionResult Delete(Guid id)
        {
            var model = new BeerTypeViewModel();

            model = _beerTypeService.GetById(id).ToBeerTypeViewModelDelete();

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteBeerType (Guid id)
        {
            _beerTypeService.DeleteBeerType(id);

            return View("Index");
        }

    }
}