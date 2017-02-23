using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beers.web.Models.BeerType;


namespace Beers.web.Models.BeerType
{
    public class BeerTypeViewModelIndex
    {
        public BeerTypeViewModelIndex() {
            Filter = new BeerTypeViewModelFilter();
            BeerTypeViewModelList = new List<BeerTypeViewModel>();
        } 

        public BeerTypeViewModelIndex(BeerTypeViewModelFilter filter)
        {
            Filter = filter;
        }

        public IEnumerable<BeerTypeViewModel> BeerTypeViewModelList { get; set; }

        public BeerTypeViewModelFilter Filter { get; set; }
    }

    

}