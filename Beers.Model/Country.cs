using System.Collections.Generic;

namespace Beers.Model
{
    public class Country : BaseEntity
    {
        public List<City> Cities { get; set; }
    }
}
