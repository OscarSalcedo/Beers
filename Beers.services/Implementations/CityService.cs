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
        public CityService()
        {

        }
        public List<CityDto> GetAll()
        {
            return Context.City.ToCityDtoList();
        }
    }
}
