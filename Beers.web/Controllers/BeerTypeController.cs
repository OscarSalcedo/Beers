using Beers.Common.Service.Contrats;
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
        private IBeerTypeService _beerTypeService;
        private IBeerService _beerService;
        public BeerTypeController()
        {
            _beerTypeService = new BeerTypeService();
            _beerService = new BeerService();
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
            if (ModelState.IsValid)
            {
                _beerTypeService.CreateBeerType(source.StringType);

                return RedirectToAction("Index");
            }
            else
            {
                return View(source);
            }


        }
        //[HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (!_beerService.BeersAssignedToType(id))
            {
                _beerTypeService.DeleteBeerType(id);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Edit(Guid id)
        {
            var model = new BeerTypeViewModel();

            model = _beerTypeService.GetById(id).ToBeerTypeViewModel();

            return View("Details",model);
        }

        [HttpPost]
        public ActionResult Update(BeerTypeViewModel details)
        {

            _beerTypeService.UpdateBeerType(details.ToBeerTypeDto());

            return RedirectToAction("Index");
        }


    }
}