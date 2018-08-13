using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface ICountryService
    {
        ActionResult<Country> CreateCountry(Country country);
        ActionResult<Country> ReadCountry(Guid id);
        ActionResult<IEnumerable<Country>> ReadCountries();
        ActionResult<Country> UpdateCountry(Country country);
        ActionResult DeleteCountry(Guid id);
        ActionResult ConnectCountry(Guid parentID, Guid childID, string relationship);
    }
}
