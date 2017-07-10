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
using System.Linq.Expressions;

namespace Beers.services.Implementations
{
    public class TapasService : ServiceBase, ITapasService
    {

        public TapasService()
        {

        }

        public List<TapasDto> GetAllTapas()
        {
            if (Context.Tapas.Any())
            {
                return Context.Tapas.ToTapasDtoList();
            }
            else
            {
                return null;
            }
        }

    }
}
