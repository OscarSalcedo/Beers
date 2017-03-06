using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public static BeerViewModel ToBeerViewModel(this BeerDto source)
        {
            var result = new BeerViewModel
            {
                Name = source.Description,
                Graduation = source.Graduation,
                BeerTypeDto = source.BeerTypeDto,
                CountryDto = source.CountryDto,
                CityDto = source.CityDto

            };

            return result;
        }

        public static List<BeerViewModel> ToBeerViewModel (this List<BeerDto> source)
        {
            var resultList = new List<BeerViewModel>();

            if (source.Count>0)
            {
                foreach (var item in source)
                {
                    resultList.Add(item.ToBeerViewModel());
                }
            }


            return resultList;
        }

        //public static IEnumerable<SelectListItem> ToBeerViewModelFilter(this List<BeerTypeDto> soruce)
        //{

        //}

    }
}