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
        StateMessageDto CreateBeer(BeerDto beerDto);

        List<BeerDto> GetAllBeers();
        List<BeerDto> GetBeerByName(string source);
        List<BeerDto> GetBeerByType(Guid typeId);
        BeerDto GetBeerById(Guid beerId);
        List<BeerDto> GetBeerByFilter(FilterOptionsDto filterOptions);
        int UpdateBeer(BeerDto source);
        int DeleteBeerById(Guid Id);
        //BeerDto GetSingleBeerByName(string name);

    }
}
