using Beers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Contracts
{
    public interface IBeerTypeInternalService
    {
        BeerType GetEntityById(Guid id);
    }
}
