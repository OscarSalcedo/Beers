using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Model
{
    public class City:BaseEntity
    {
        public Country Country { get; set; }
    }
}
