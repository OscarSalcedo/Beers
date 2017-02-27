using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beers.web.Models.Beer
{
    public class BeerViewModelIndex :BeerViewModel
    {
        public BeerViewModelIndex()
        {
            BeerViewModelList = new List<BeerViewModel>(); 
        }
        public IEnumerable<BeerViewModel> BeerViewModelList { get; set; }
    }
}