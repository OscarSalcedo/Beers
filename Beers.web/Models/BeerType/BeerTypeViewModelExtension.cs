using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.BeerType
{
    public static class BeerTypeViewModelExtension
    {

        public static IEnumerable<SelectListItem> ToSelectListItemList(this List<BeerTypeDto> source)
        {
            List<SelectListItem> result = new List<SelectListItem>();

            source.ForEach(it => {
                result.Add(it.ToSelectListItem());
            });

            return result;
        }

        public static SelectListItem ToSelectListItem(this BeerTypeDto source)
        {
            var result = new SelectListItem();

            result.Value = source.Code.ToString();
            result.Text = source.Description;

            return result;
        }

        public static BeerTypeViewModel ToBeerTypeViewModel(this BeerTypeDto source)
        {
            var result = new BeerTypeViewModel
            {
                Code = source.Code,
                Description = source.Description
            };
            return result;
        }


        public static List<BeerTypeViewModel> ToBeerTypeModelList(this List<BeerTypeDto> source)
        {
            var resultList = new List<BeerTypeViewModel>();

            if (source.Count>0)
            {
                foreach (var item in source)
                {
                    resultList.Add(item.ToBeerTypeViewModel());
                }
            }

            return (resultList);
        }

        public static BeerTypeViewModelDelete ToBeerTypeViewModelDelete(this BeerTypeDto source)
        {
            var result = new BeerTypeViewModelDelete
            {
                Code = source.Code,
                Description = source.Description
            };
            return result;
        }

        public static BeerTypeDto ToBeerTypeDto(this BeerTypeViewModel source)
        {
            var result = new BeerTypeDto
            {
                Code = source.Code,
                Description = source.Description
            };
            return result;
        }

        /*public static BeerTypeViewModel ToBeerTypeViewModelDetails(this BeerTypeDto source)
        {
            var result = new BeerTypeViewModel
            {
                Code = source.Code,
                Description = source.Description
            };
            return result;
        }*/

    }
}