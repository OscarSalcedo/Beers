using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beers.web.Models.Tapas
{
    public class TapasViewModel
    {
        public IEnumerable<TapasViewModel> TapasViewModelList { get; set; }
        public string Name { get; set; }
    }
}