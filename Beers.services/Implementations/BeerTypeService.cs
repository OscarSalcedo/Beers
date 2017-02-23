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
        public BeerTypeService(){
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

        public List<BeerTypeDto> CreateBeerType(BeerTypeDto type)
        {
            Guid guid;
            guid = Guid.NewGuid();

            type.Code = guid;

            var newBeerType = type.ToBeerType();

            Context.BeerType.Add(newBeerType);

            return Context.BeerType.ToBeerTypeDtoList();
        }


    }
}
