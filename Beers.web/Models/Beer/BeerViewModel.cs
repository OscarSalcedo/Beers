using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Beers.web.Models.Beer
{
    public class BeerViewModel
    {
        public string Name { get; set; }

        [DataType("decimal(2,2)")]
        public decimal Graduation { get; set; }

        public BeerTypeDto BeerTypeDto { get; set; }

        public CountryDto CountryDto { get; set; }
    }
}