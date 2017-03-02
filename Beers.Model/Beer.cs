using System;
using System.ComponentModel.DataAnnotations;

namespace Beers.Model
{
    public class Beer : BaseEntity
    {
        public decimal Graduation { get; set; }
        public BeerType BeerType { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
    }
}
