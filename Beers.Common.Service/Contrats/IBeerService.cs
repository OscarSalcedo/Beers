using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.Contrats
{
    public interface IBeerService
    {
        List<BeerDto> GetBeerByBeerType(Guid id);
        bool BeersAssignedToType(Guid id);
        int CreateBeer(BeerDto beerDto);

    }
}
