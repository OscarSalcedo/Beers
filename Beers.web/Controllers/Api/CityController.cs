using Beers.Common.Service.Contrats;
using Beers.services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beers.web.Controllers.Api
{
    public class CityController : ApiController
    {
        private ICityService _cityService;
        public CityController()
        {
            _cityService = new CityService();
        }
        public IHttpActionResult Get(string id)
        {
            var result = _cityService.GetByCountryId(Guid.Parse(id));
            return Ok(result);
        }

    }
}
