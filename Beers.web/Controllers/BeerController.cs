using Beers.services.Implementations;
using Beers.web.Models.Beer;
using Beers.web.Models.BeerType;
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
        private BeerService _beerService;
        private BeerTypeService _beerTypeService;
        private CountryService _countryService;

        public BeerController()
        {
            _beerService = new BeerService();
            _beerTypeService = new BeerTypeService();
            _countryService = new CountryService();
        }

        public ActionResult Index()
        {
            var model = new BeerViewModelIndex();
            return View();
        }

        public ActionResult Create()
        {
          
            var model = new BeerViewModelCreate();
            
            model.BeerTypeDtoList = new List<SelectListItem> {
                //Nuevo elemento list, para mostrar como primer valor
                new SelectListItem
                {
                    Text = "Select",
                    Value = "0"
                }
            }.Union( _beerTypeService.GetAll().ToSelectListItemList());

            model.CountryDtoList = new List<SelectListItem> {
                new SelectListItem
                {
                    Text="Select",
                    Value="0"
                }
            }.Union( _countryService.GetAll().ToSelectListItemList());

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BeerViewModelCreate model)
        {

            return RedirectToAction("Index");
        }

    }
}