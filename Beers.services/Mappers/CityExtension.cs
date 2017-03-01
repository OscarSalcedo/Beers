using Beers.Common.Service.DTOs;
using Beers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Mappers
{
    public static class CityExtension
    {
        public static List<CityDto> ToCityDtoList(this IEnumerable<City> source)
        {
            List<CityDto> resultList = new List<CityDto>();

            if (source.Any())
            {
                source.ToList().ForEach(f =>
                {
                    resultList.Add(f.ToCityDto());
                });
            }

            return resultList;
        }
        public static CityDto ToCityDto(this City source)
        {
            var result = new CityDto
            {
                Code = source.Id,
                Description = source.Name,
                CountryDto = source.Country != null ? source.Country.ToCountryDto() : null
            };
            return result;
        }
    }
}
