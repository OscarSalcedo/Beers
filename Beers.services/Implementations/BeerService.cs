using Beers.Common.Const;
using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using Beers.Model;
using Beers.services.Contracts;
using Beers.services.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Beers.services.Implementations
{
    public class BeerService : ServiceBase, IBeerService
    {
        public BeerService()
        {

        }

        public List<BeerDto> GetAllBeers()
        {
            //var result = Context.Beer.ToList().ToBeerDtoList();

            if (Context.Beer.Any())
            {
                return Context.Beer.Include(i => i.BeerType).Include(i => i.Country).Include(i => i.City).ToBeerDtoList();
            }
            else
            {
                return null;
            }


        }

        public List<BeerDto> GetBeerByName(string source)
        {
            return Context.Beer.Where(w => w.Name.Contains(source)).Include(i=>i.BeerType).Include(i=>i.Country).Include(i=>i.City).ToBeerDtoList();
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
