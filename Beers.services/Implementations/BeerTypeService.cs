using Beers.Common.Service.Contrats;
using Beers.Common.Service.DTOs;
using System.Collections.Generic;
using Beers.services.Mappers;
using System.Linq;
using System;

namespace Beers.services.Implementations
{
    public class BeerTypeService : ServiceBase, IBeerTypeService
    {
        public BeerTypeService()
        {
        }

        public List<BeerTypeDto> GetAll()
        {
            return Context.BeerType.ToBeerTypeDtoList();
        }

        public BeerTypeDto GetById(Guid id)
        {
            return Context.BeerType.Find(id).ToBeerTypeDto();
            //return Context.BeerType.FirstOrDefault(f => f.Id == id).ToBeerTypeDto();
        }

        public List<BeerTypeDto> GetByName(string name)
        {
            return Context.BeerType.Where(w => w.Name.Contains(name)).ToBeerTypeDtoList();
        }

        public void CreateBeerType(string type)
        {
            Guid guid;
            guid = Guid.NewGuid();

            BeerTypeDto newBeerTypeDto = new BeerTypeDto
            {
                Code = guid,
                Description = type
            };

            var newBeerType = newBeerTypeDto.ToBeerType();

            Context.BeerType.Add(newBeerType);
            var result = Context.SaveChanges();
        }

        public void DeleteBeerType(Guid id)
        {
            var beerTypeDelete = Context.BeerType.Find(id);

            Context.BeerType.Remove(beerTypeDelete);
            Context.SaveChanges();
        }

        public void UpdateBeerType(BeerTypeDto beerTypeDto)
        {
            var beerType = beerTypeDto.ToBeerType();

            Context.SaveChanges();
        }


    }
}
