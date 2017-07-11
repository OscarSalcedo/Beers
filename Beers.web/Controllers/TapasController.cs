using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using Beers.services.Implementations;
using Beers.web.Models.Tapas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Controllers
{
    public class TapasController : Controller
    {
        private ITapasService _tapasService;

        public TapasController()
        {
            _tapasService = new TapasService();
        }

        // GET: Tapas
        public ActionResult Index()
        {
            var model = new List<TapasViewModel>();

            model = _tapasService.GetAllTapas().ToTapasViewModelList();
            return View(model);
        }
    }
}