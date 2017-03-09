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

        public static BeerDto ModelDetailsToBeerDto(this BeerViewModelDetails source)
        {
            var result = new BeerDto
            {
                Code = source.Id,
                Description = source.Name,
                Graduation = source.Graduation,
                BeerTypeId = source.BeerTypeDto.Code,
                CountryId = source.CountryDto.Code,
                CityId = source.CityDto.Code
            };

            return result;
        }

        public static BeerViewModel ToBeerViewModel(this BeerDto source)
        {
            var result = new BeerViewModel
            {
                Id = source.Code,
                Name = source.Description,
                Graduation = source.Graduation,
                BeerTypeDto = source.BeerTypeDto,
                CountryDto = source.CountryDto,
                CityDto = source.CityDto

            };

            return result;
        }

        public static BeerViewModelDetails ToBeerViewModelDetails(this BeerDto source)
        {
            var result = new BeerViewModelDetails
            {
                Id = source.Code,
                Name = source.Description,
                Graduation = source.Graduation,
                BeerTypeDto = source.BeerTypeDto,
                CountryDto = source.CountryDto,
                CityDto = source.CityDto
            };

            return result;
        }

        public static List<BeerViewModel> ToBeerViewModelList(this List<BeerDto> source)
        {
            var resultList = new List<BeerViewModel>();

            if (source.Count > 0)
            {
                foreach (var item in source)
                {
                    resultList.Add(item.ToBeerViewModel());
                }
            }
            return resultList;
        }

        public static IEnumerable<SelectListItem> ToSelectListItemList(this List<BeerDto> source)
        {
            List<SelectListItem> resultList = new List<SelectListItem>();

            if (source.Count > 0)
            {
                foreach (var item in source)
                {
                    resultList.Add(item.ToSelectListItem());
                }
            }

            return resultList;
        }

        public static SelectListItem ToSelectListItem(this BeerDto source)
        {
            var result = new SelectListItem();

            result.Value = source.Code.ToString();
            result.Text = source.Description;

            return result;
        }

        //public static IEnumerable<SelectListItem> ToBeerViewModelFilter(this List<BeerTypeDto> soruce)
        //{

        //}

    }
}