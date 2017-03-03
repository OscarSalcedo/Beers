using Beers.Common.Const;
using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using Beers.services.Implementations;
using Beers.web.Models.Beer;
using Beers.web.Models.BeerType;
using Beers.web.Models.City;
using Beers.web.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Controllers
{
    public class BeerController : Controller
    {
        private IBeerService _beerService;
        private IBeerTypeService _beerTypeService;
        private ICountryService _countryService;
        private ICityService _cityService;

        public BeerController()
        {
            _beerService = new BeerService();
            _beerTypeService = new BeerTypeService();
            _countryService = new CountryService();
            _cityService = new CityService();
        }

        public ActionResult Index()
        {
            var model = new BeerViewModelIndex();
            return View(model);
        }

        public ActionResult Create()
        {

            var model = new BeerViewModelCreate();

            FillData(model, false);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BeerViewModelCreate model)
        {
            //if (ModelState.IsValid)
            //{
            //    _beerService.CreateBeer(model.ToBeerDto());
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    ModelState.AddModelError(GeneralConst.GenericError, "Ya existe una cerveza con ese nombre.");
            //    FillData(model);
            //    return View(model);
            //}

            if (ModelState.IsValid)
            {
                var StateCreate = _beerService.CreateBeer(model.ToBeerDto());

                if (StateCreate.State)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(GeneralConst.DuplicateName, "Duplicate Name");
                    FillData(model, true);
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(GeneralConst.GenericError, "Some information is empty");
                FillData(model, true);
                return View(model);
            }
            

        }

        private void FillData(BeerViewModelCreate model, bool reload)
        {
            model.BeerTypeDtoList = new List<SelectListItem> {
                //Nuevo elemento list, para mostrar como primer valor
                new SelectListItem
                {
                    Text = "Select",
                    Value = "0"
                }
            }.Union(_beerTypeService.GetAll().ToSelectListItemList());

            model.CountryDtoList = new List<SelectListItem> {
                new SelectListItem
                {
                    Text="Select",
                    Value="0"
                }
            }.Union(_countryService.GetAll().ToSelectListItemList());

            if (reload && model.CountryId != Guid.Empty)
            {
                model.CityDtoList = _cityService.GetByCountryId(model.CountryId).ToSelectListItemList();
            }
        }

    }
}