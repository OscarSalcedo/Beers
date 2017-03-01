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
        private BeerTypeService _beerTypeService;
        private CountryService _countryService;
        public BeerService()
        {
            _beerTypeService = new BeerTypeService();
            _countryService = new CountryService();
        }
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

        public int CreateBeer(BeerDto beerDto)
        {
            Guid id;
            id = Guid.NewGuid();
            beerDto.Code = id;

            var Beer = new BeerDto
            {
                Code = id,
                Description = beerDto.Description,
                BeerTypeDto = _beerTypeService.GetById(beerDto.BeerTypeDto.Code),
                CountryDto = _countryService.GetCountryById(beerDto.CountryDto.Code),
                Graduation = beerDto.Graduation
            };

            var newBeer = Beer.ToBeer();
            Context.Beer.Add(newBeer);
            var result = Context.SaveChanges();

            return result;
        }

    }
}
