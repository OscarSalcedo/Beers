using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beers.web.Models.Beer
{
    public static class BeerViewModelExtension
    {
        public static BeerDto ToBeerDto(this BeerViewModelCreate model)
        {
            var result = new BeerDto
            {
                Description = model.Name,
                Graduation = model.Graduation,
                BeerTypeDto = model.BeerTypeDto,
                CountryDto = model.CountryDto,
                BeerTypeId = model.BeerTypeId,
                CityId = model.CityId,
                CountryId = model.CountryId
            };
            return result;
        }

        //public static BeerViewModel ToBeerViewModel(this BeerTypeDto model)
        //{

        //}

    }
}