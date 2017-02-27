using Beers.services.Implementations;
using Beers.web.Models.Beer;
using Beers.web.Models.BeerType;
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

        public BeerController()
        {
            _beerService = new BeerService();
            _beerTypeService = new BeerTypeService();
        }

        public ActionResult Index()
        {
            var model = new BeerViewModelIndex();
            return View();
        }

        public ActionResult Create()
        {
            var model = new BeerViewModelCreate();
            model.BeerTypeDtoList = _beerTypeService.GetAll().ToSelectListItemList();
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Create(BeerViewModelCreate model)
        //{
            
        //    Guid id = new Guid();
        //}

    }
}