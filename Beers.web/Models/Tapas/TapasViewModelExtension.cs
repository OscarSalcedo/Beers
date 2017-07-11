using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beers.web.Models.Tapas
{
    public static class TapasViewModelExtension
    {
        public static TapasViewModel ToTapasViewModel(this TapasDto source)
        {
            var result = new TapasViewModel
            {
                Name = source.Description,
                Price = source.Price
            };

            return result;
        }

        public static List<TapasViewModel> ToTapasViewModelList(this List<TapasDto> source)
        {
            var resultList = new List<TapasViewModel>();
            if (source != null)
            {
                foreach (var item in source)
                {
                    resultList.Add(item.ToTapasViewModel());
                }
            }
            return resultList;
        }
    }
}