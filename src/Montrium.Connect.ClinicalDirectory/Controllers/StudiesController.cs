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
    [Route("api/[controller]")]
    public class StudiesController : Controller
    {
        private readonly IStudyService _studyService;

        public StudiesController(IStudyService studyService)
        {
            this._studyService = studyService;
        }

        // GET: api/studies/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpGet("{studyId:Guid}")]
        [ProducesResponseType(200, Type = typeof(Study))]
        [ProducesResponseType(404)]
        public ActionResult<Study> Get(Guid studyId)
        {
            if (studyId == null || studyId == Guid.Empty)
            {
                return NotFound();
            }
            return _studyService.ReadStudy(studyId);
        }

        // GET: api/studies
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Study))]
        public ActionResult<IEnumerable<Study>> Get()
        {
            return _studyService.ReadStudies();
        }

        /// <summary>
        /// Create a new study
        /// </summary>
        /// <param name="value"></param>
        // POST: api/studies
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Study))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromBody]Study study)
        {
            if (study == null)
            {
                return BadRequest();
            }

            _studyService.CreateStudy(study);

            return Created(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/studies/{0}", study.Id), UriKind.Relative), study);
        }

        /// <summary>
        /// Update an existing study
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="value"></param>
        // PUT: api/studies/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpPut("{studyId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put(Guid studyId, [FromBody]Study study)
        {
            if (study == null || studyId == null || studyId == Guid.Empty)
            {
                return NoContent();
            }

            _studyService.UpdateStudy(study);

            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/studies/{0}", study.Id), UriKind.Relative), study);
        }

        // DELETE: api/studies/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpDelete("{studyId:Guid}")]
        public ActionResult Delete(Guid studyId)
        {
            if (studyId == null || studyId == Guid.Empty)
            {
                return BadRequest();
            }

            return _studyService.DeleteStudy(studyId);
        }
    }
}
