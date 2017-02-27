using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using Beers.services.Mappers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Implementations
{
    public class CountryService : ServiceBase, ICountryService
    {
        public List<CountryDto> GetAll()
        {
            return Context.Country.ToCountryDtoList();
        }
    }
}
