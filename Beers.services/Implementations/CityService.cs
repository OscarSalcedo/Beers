using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using Beers.services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Implementations
{
    public class CityService :ServiceBase, ICityService
    {
        public List<CityDto> GetAll()
        {
            return Context.City.ToCityDtoList();
        }
        
        public List<CityDto> GetById(Guid id)
        {
            return Context.City.Where(w => w.Id == id).ToCityDtoList();
        }

        public List<CityDto> GetByCountryId(Guid CountryId)
        {
            return Context.City.Where(w => w.Country.Id == CountryId).ToCityDtoList();
        }
    }
}
