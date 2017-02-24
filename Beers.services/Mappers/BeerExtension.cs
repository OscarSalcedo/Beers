using Beers.Common.Service.DTOs;
using Beers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Mappers
{
    public static class BeerExtension
    {
        public static BeerDto ToBeerDto(this Beer source)
        {
            var result = new BeerDto
            {
                Code = source.Id,
                Description = source.Name,
                BeerTypeDto = source.BeerType.ToBeerTypeDto()
            };

            return result;
        }
        public static List<BeerDto> ToBeerDtoList(this List<Beer> source)
        {
            var resultList = new List<BeerDto>();

            if (source.Any())
            {
                source.ToList().ForEach(f =>
                {
                    resultList.Add(f.ToBeerDto());
                });
            }

            return resultList;
        } 
    }
}
