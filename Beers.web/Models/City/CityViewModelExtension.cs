using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.City
{
    public static class CityViewModelExtension
    {
        public static SelectListItem ToSelectListItem(this CityDto source)
        {
            var result = new SelectListItem
            {
                Value = source.Code.ToString(),
                Text = source.Description
            };

            return result;
        }

        public static IEnumerable<SelectListItem> ToSelectListItemList(this List<CityDto> source)
        {
            List<SelectListItem> resultList = new List<SelectListItem>();

            source.ForEach(f=>
            {
                resultList.Add(f.ToSelectListItem());
            });

            return resultList;
        }
    }
}