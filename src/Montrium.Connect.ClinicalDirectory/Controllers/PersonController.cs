using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IStudyService _studyService;
        private readonly ICountryService _countryService;
        private readonly ISiteService _siteService;
        private readonly IPersonService _personService;

        public PersonController(IStudyService studyService, ICountryService countryService, ISiteService siteService, IPersonService personService)
        {
            this._studyService = studyService;
            this._countryService = countryService;
            this._siteService = siteService;
            this._personService = personService;
        }

        [HttpGet]
        // GET api/person
        [ProducesResponseType(200, Type = typeof(Person))]
        public ActionResult<IEnumerable<Person>> Get([FromRoute]Guid personId = new Guid())
        {
            if (personId == Guid.Empty)
            {
                return _personService.ReadPersons();
            }
            else if (personId != Guid.Empty)
            {
                //return _personService.ReadPerson(personId);
            }
            return BadRequest();
        }


        /// <summary>
        /// Create a new site under a study (update if exists)
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        // POST api/sites
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            var created = _personService.CreatePerson(person);
            return Created(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/person/{0}", person.Id), UriKind.Relative), person);
        }

        [HttpPut("{personId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put([FromRoute]Guid personId, [FromBody]Person person)
        {
            if (person == null || personId == null || personId == Guid.Empty)
            {
                return NoContent();
            }
            _personService.UpdatePerson(person);
            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/person/{0}", person.Id), UriKind.Relative), person);
        }

        [HttpDelete("{personId:Guid}")]
        public ActionResult Delete([FromRoute]Guid personId)
        {
            if (personId == null || personId == Guid.Empty)
            {
                return BadRequest();
            }

            return _personService.DeletePerson(personId);
        }
    }
}