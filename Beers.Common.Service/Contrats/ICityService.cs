using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.Contrats
{
    public interface ICityService
    {
        List<CityDto> GetAll();
        CityDto GetById(Guid id);
        List<CityDto> GetByCountryId(Guid CountryId);
    }
}
