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
        // GET: Tapas
        public ActionResult Index()
        {
            var model = new TapasViewModel();

            return View();
        }
    }
}