﻿using Beers.Common.Service.DTOs;
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
                Description = source.Name
            };
            return result;
        }

        public static City ToCity(this CityDto source)
        {
            if (source == null)
                return null;
            var result = new City
            {
                Id = source.Code,
                Country = source.CountryDto.ToCountry(),
                Name = source.Description
            };
            return result;
        }
    }
}
