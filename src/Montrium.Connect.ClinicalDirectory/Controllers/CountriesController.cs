using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    /// <summary>
    /// controller for adding, updating, deleting countries
    /// </summary>
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        /// <summary>
        /// Creates the repo for adding countries 
        /// </summary>
        /// <param name="studyService"></param>
        /// <param name="countryService"></param>
        public CountriesController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        /// <summary>
        /// gets an country
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        // GET: api/countries/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpGet("{countryId:Guid}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(404)]
        public ActionResult<Country> Get(Guid countryId, [FromRoute]Guid studyId = new Guid())
        {
            if (countryId == null || countryId == Guid.Empty)
            {
                return NotFound();
            }

            return _countryService.ReadCountry(countryId);
        }

        /// <summary>
        /// gets all the countries
        /// </summary>
        /// <returns></returns>
        // GET: api/countries
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Country))]
        public ActionResult<IEnumerable<Country>> Get()
        {
            return _countryService.ReadCountries();
        }

        /// <summary>
        /// Create a new country
        /// </summary>
        /// <param name="value"></param>
        // POST: api/countries
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Country))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromBody]Country country, [FromRoute]Guid studyId = new Guid())
        {
            if (country == null)
            {
                return BadRequest();
            }

            var created = _countryService.CreateCountry(country);
            
            return Created(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/countries/{0}", country.Id), UriKind.Relative), country);
        }

        /// <summary>
        /// Update an existing country
        /// </summary>
        /// <param name="countryId"></param>
        /// <param name="value"></param>
        // PUT: api/countries/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpPut("{countryId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put(Guid countryId, [FromBody]Country country)
        {
            if (country == null || countryId == null || countryId == Guid.Empty)
            {
                return NoContent();
            }

            _countryService.UpdateCountry(country);

            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/countries/{0}", country.Id), UriKind.Relative), country);
        }

        /// <summary>
        /// deletes an edge
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        // DELETE: api/countries/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpDelete("{countryId:Guid}")]
        public ActionResult Delete(Guid countryId)
        {
            if (countryId == null || countryId == Guid.Empty)
            {
                return BadRequest();
            }

            return _countryService.DeleteCountry(countryId);
        }
    }
}
