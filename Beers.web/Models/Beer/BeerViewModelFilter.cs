using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.Beer
{
    public class BeerViewModelFilter :BeerViewModel
    {
        public string StringFilter { get; set; }
        public IEnumerable<SelectListItem> BeerTypeDtoList { get; set; }
        public Guid BeerTypeId { get; set; }

    }
}