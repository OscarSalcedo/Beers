using System.ComponentModel.DataAnnotations;

namespace Beers.Model
{
    public class Beer : BaseEntity
    {
        [DataType("decimal(2,2)")]
        private decimal Graduation { get; set; }

        public BeerType BeerType { get; set; }
        public Country Country { get; set; }

    }
}
