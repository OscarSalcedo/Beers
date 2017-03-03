using Beers.Common.Const;
using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using Beers.Model;
using Beers.services.Contracts;
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
        public BeerService()
        {

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

        public bool ExistBeer(string name)
        {
            return Context.Beer.Any(w => w.Name == name);

        }

        public StateMessageDto CreateBeer(BeerDto beerDto)
        {

            var result = new StateMessageDto();

            if (ExistBeer(beerDto.Description.ToString()))
            {
                result.Message = GeneralConst.DuplicateName;
            }
            else
            {
                Guid id;
                id = Guid.NewGuid();
                beerDto.Code = id;


                var beer = beerDto.ToBeer();
                beer.Country = Context.Country.Find(beerDto.CountryId);
                beer.BeerType = Context.BeerType.Find(beerDto.BeerTypeId);
                beer.City = Context.City.Find(beerDto.CityId);
                Context.Beer.Add(beer);

                var resultContext = Context.SaveChanges();

                if (resultContext == 0)
                {
                    result.State = false;
                }
                else
                {
                    result.State = true;
                }
            }



            return result;
        }

    }
}
