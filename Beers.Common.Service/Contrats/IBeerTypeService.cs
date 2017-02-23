using Beers.Common.Service.DTOs;
using Beers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.Contrats
{
    public interface IBeerTypeService
    {
        List<BeerTypeDto>GetAll();
        BeerTypeDto GetById(Guid id);
        List<BeerTypeDto> GetByName(string name);
        List<BeerTypeDto> CreateBeerType(BeerTypeDto type);
    }
}
