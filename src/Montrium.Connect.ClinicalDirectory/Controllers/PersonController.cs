﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    /// <summary>
    /// controller for creating, updating, deleting person
    /// </summary>
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        /// <summary>
        /// creates repo for person
        /// </summary>
        /// <param name="studyService"></param>
        /// <param name="countryService"></param>
        /// <param name="siteService"></param>
        /// <param name="personService"></param>
        public PersonController(IPersonService personService)
        {
            this._personService = personService;
        }
        /// <summary>
        /// Gets all person
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Person))]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return _personService.ReadPersons();
        }

        /// <summary>
        /// gets a single person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet("{personId:Guid}")]
        [ProducesResponseType(200, Type = typeof(Person))]
        [ProducesResponseType(404)]
        public ActionResult<Person> Get(Guid personId)
        {
            if (personId == null || personId == Guid.Empty)
            {
                return NotFound();
            }
            return _personService.ReadPerson(personId);
        }


        /// <summary>
        /// Create a new person
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
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

        /// <summary>
        /// updates a person
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="person"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
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