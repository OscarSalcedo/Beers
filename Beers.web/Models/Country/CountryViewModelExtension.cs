using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.Country
{
    public static class CountryViewModelExtension
    {
        public static IEnumerable<SelectListItem> ToSelectListItemList(this List<CountryDto> source)
        {
            List<SelectListItem> resultList = new List<SelectListItem>();

            source.ForEach(f =>
            {
                resultList.Add(f.ToSelectListItem());
            });

            return resultList;
        }

        public static SelectListItem ToSelectListItem(this CountryDto source)
        {
            var result = new SelectListItem();

            result.Value = source.Code.ToString();
            result.Text = source.Description;

            return result;

        }
    }
}