using Beers.Common.Service.DTOs;
using Beers.Model;
using System.Collections.Generic;
using System.Linq;

namespace Beers.services.Mappers
{
    public static class BeerTypeExtension
    {
        public static BeerTypeDto ToBeerTypeDto(this BeerType source)
        {
            var result = new BeerTypeDto
            {
                Code = source.Id,
                Description = source.Name
            };
            return result;
        }

        public static List<BeerTypeDto> ToBeerTypeDtoList(this IEnumerable<BeerType> source)
        {
            var resultList = new List<BeerTypeDto>();

            if (source.Any())
            {
                source.ToList().ForEach(f =>
                {
                    resultList.Add(f.ToBeerTypeDto());
                });
            }

            return resultList;

        }

        public static BeerType ToBeerType(this BeerTypeDto source)
        {
            var result = new BeerType
            {
                Name = source.Description,
                Id = source.Code
            };
            return result;
        }
    }
}
