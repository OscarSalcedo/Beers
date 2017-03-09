using Beers.Common.Service.DTOs;
using Beers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Mappers
{
    public static class CountryExtension
    {
        public static CountryDto ToCountryDto(this Country source)
        {
            if (source == null)
                return null;
            var result = new CountryDto
            {
                Code = source.Id,
                Description = source.Name
                //CitiesDto = source.Cities
            };
            return result;
        }
        public static List<CountryDto> ToCountryDtoList(this IQueryable<Country> source)
        {
            var result = new List<CountryDto>();

            if (source.Any())
            {
                source.ToList().ForEach(f =>
                {
                    result.Add(f.ToCountryDto());
                });
            }

            return result;
        }

        public static Country ToCountry(this CountryDto source)
        {
            if (source == null)
                return null;
            var result = new Country
            {
                Id = source.Code,
                Name = source.Description
            };
            return result;
        }
    }
}
