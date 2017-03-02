using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.DTOs
{
    public class BeerDto :BaseDto
    {
        [DataType("decimal(2,2)")]
        public decimal Graduation { get; set; }

        public BeerTypeDto BeerTypeDto { get; set; }

        public CountryDto CountryDto { get; set; }

        public CityDto CityDto { get; set; }

        public Guid BeerTypeId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
    }
}
