﻿using Beers.Common.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beers.Common.Service.Contrats
{
    public interface ICountryService
    {
        List<CountryDto> GetAll();
        CountryDto GetCountryById(Guid id);
    }
}
