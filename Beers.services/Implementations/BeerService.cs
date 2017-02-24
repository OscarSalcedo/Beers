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
    public class BeerService : ServiceBase, IBeerService
    {
        public List<BeerDto> GetBeerByBeerType(Guid id)
        {
            return Context.Beer.Where(w => w.BeerType.Id == id).ToList().ToBeerDtoList();
        }

        public bool BeersAssignedToType(Guid id)
        {
            return GetBeerByBeerType(id).Any() ? true : false;

            //bool result = false;

            //if (GetBeerByBeerType(id).Any())
            //{
            //    result = true;
            //}

            //return result;
        }

    }
}
