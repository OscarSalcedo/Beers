using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.Beer
{
    public class BeerViewModelDetails : BeerViewModel
    {
        public BeerViewModelDetails()
        {
            BeerTypeDtoList = new List<SelectListItem>();
        }
        public IEnumerable<SelectListItem> BeerTypeDtoList { get; set; }
        public Guid BeerTypeId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
    }
}