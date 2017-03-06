using Beers.web.Models.BeerType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beers.web.Models.Beer
{
    public class BeerViewModelIndex : BeerViewModel
    {
        public BeerViewModelIndex()
        {
            Filter = new BeerViewModelFilter();
            BeerViewModelList = new List<BeerViewModel>(); 
        }
        public BeerViewModelIndex(BeerViewModelFilter filter) {
            Filter = filter;
        }
        public BeerViewModelFilter Filter { get; set; }
        public IEnumerable<BeerViewModel> BeerViewModelList { get; set; }
        public BeerViewModelCreate BeerViewModelCreate { get; set; }
    }
}