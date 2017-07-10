using Beers.Common.Service.DTOs;
using Beers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Mappers
{
    public static class TapasExtension
    {
        public static TapasDto ToTapasDto (this Tapas source)
        {
            var result = new TapasDto
            {
                Code = source.Id,
                Description = source.Name,
                Price = source.Price,
            };

            return result;
        }

        public static List<TapasDto> ToTapasDtoList(this IEnumerable<Tapas> source)
        {
            var resultList = new List<TapasDto>();
            if (source.Any())
            {
                source.ToList().ForEach(f =>
                {
                    resultList.Add(f.ToTapasDto());
                });
            }
            return resultList;
        }

        public static Tapas ToTapas(this TapasDto source)
        {
            var result = new Tapas
            {
                Id = source.Code,
                Name = source.Description,
                Price = source.Price,
            };

            return result;

        }

    }
}
