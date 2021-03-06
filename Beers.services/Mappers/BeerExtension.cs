﻿using Beers.Common.Service.DTOs;
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
                Graduation = source.Graduation,
                Description = source.Name,
                BeerTypeDto = source.BeerType.ToBeerTypeDto(),
                CountryDto = source.Country.ToCountryDto(),
                CityDto = source.City.ToCityDto(),
            };

            return result;
        }

        public static BeerDto ToBeerDetailDto(this Beer source)
        {
            var result = new BeerDto
            {
                Code = source.Id,
                Graduation = source.Graduation,
                Description = source.Name,
                BeerTypeId = source.BeerType.Id,
                CountryId = source.Country.Id,
                CityId = source.City.Id
            };

            return result;
        }

        public static List<BeerDto> ToBeerDtoList(this IEnumerable<Beer> source)
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
        
        public static Beer ToBeer(this BeerDto source)
        {
            var result = new Beer
            {
                Id = source.Code,
                Name = source.Description,
                Graduation = source.Graduation,
                BeerType = source.BeerTypeDto.ToBeerType(),
                Country = source.CountryDto.ToCountry(),
                City = source.CityDto.ToCity()

            };

            return result;
        } 
    }
}
