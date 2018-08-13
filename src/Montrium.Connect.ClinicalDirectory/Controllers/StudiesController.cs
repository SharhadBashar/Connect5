using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Commands;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    /// <summary>
    /// controller for creating, updating and deleting studies
    /// </summary>
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StudiesController : Controller
    {
        private readonly IStudyService _studyService;
        private readonly IMediator _mediator;

        /// <summary>
        /// creates repo for studies
        /// </summary>
        /// <param name="studyService"></param>
        public StudiesController(IStudyService studyService, IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._studyService = studyService ?? throw new ArgumentNullException(nameof(studyService));
        }

        /// <summary>
        /// gets a certain study
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// gets all study
        /// </summary>
        /// <returns></returns>
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
        public async Task<ActionResult> PostAsync([FromBody]Study study)
        {
            if (study == null)
            {
                return BadRequest();
            }

            var commandResult = await _mediator.Send(new CreateStudyCommand(study));
            if (commandResult is BadRequestResult)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult> Put(Guid studyId, [FromBody]Study study)
        {
            if (study == null || studyId == null || studyId == Guid.Empty)
            {
                return NoContent();
            }

            var commandResult = await _mediator.Send(new UpdateStudyCommand(study));

            _studyService.UpdateStudy(study);

            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/studies/{0}", study.Id), UriKind.Relative), study);
        }

        /// <summary>
        /// deletes a study
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
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
