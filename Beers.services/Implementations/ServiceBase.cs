using Beers.services.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.services.Implementations
{
    public class ServiceBase
    {
        private BeersBaseContext _context;

        public ServiceBase()
        {
            _context = new BeersBaseContext();
        }

        protected BeersBaseContext Context
        {
            get{
                return _context;
            }
            set
            {

            }
        }



    }
}
