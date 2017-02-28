using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.DTOs
{
    public class CityDto :BaseDto
    {
        public CountryDto CountryDto { get; set; }
    }
}
