using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.Beer
{
    public class BeerViewModelCreate :BeerViewModel
    {
        public IEnumerable<SelectListItem> BeerTypeDtoList { get; set; }

        public IEnumerable<SelectListItem> CountryDtoList { get; set; }

        public Guid BeerTypeId { get; set; }

        public Guid CountryId { get; set; }
    }
}