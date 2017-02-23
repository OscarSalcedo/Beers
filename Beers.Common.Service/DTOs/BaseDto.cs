using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.DTOs
{
    public class BaseDto
    {
        public Guid Code { get; set; }
        public string Description { get; set; }
    }
}
