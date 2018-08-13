using Gremlin.Net.Process.Traversal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Repositories;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class ProcessZoneController : Controller
    {
        private readonly IProcessZoneService _processZoneService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processZoneService"></param>
        public ProcessZoneController(IProcessZoneService processZoneService)
        {
            this._processZoneService = processZoneService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ProcessZone))]
        public ActionResult<IEnumerable<ProcessZone>> Get()
        {
            // TODO: Handle empty Ids (will tell which route was matched)
            return _processZoneService.ReadProcessZones();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processzoneId"></param>
        /// <returns></returns>
        [HttpGet("{processzoneId:Guid}")]
        [ProducesResponseType(200, Type = typeof(ProcessZone))]
        [ProducesResponseType(404)]
        public ActionResult<ProcessZone> Get(Guid processzoneId)
        {
            if (processzoneId == null || processzoneId == Guid.Empty)
            {
                return NotFound();
            }
            return _processZoneService.ReadProcessZone(processzoneId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processZone"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProcessZone))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromBody]ProcessZone processZone)
        {
            if (processZone == null)
            {
                return BadRequest();
            }

            var created = _processZoneService.CreateProcessZone(processZone);

            return Created(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/processZone/{0}", processZone.Id), UriKind.Relative), processZone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processZoneId"></param>
        /// <param name="processZone"></param>
        /// <returns></returns>
        [HttpPut("{processZoneId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put([FromRoute]Guid processZoneId, [FromBody]ProcessZone processZone)
        {
            if (processZone == null || processZoneId == null || processZoneId == Guid.Empty)
            {
                return NoContent();
            }
            _processZoneService.UpdateProcessZone(processZone);
            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/processZone/{0}", processZone.Id), UriKind.Relative), processZone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processZoneId"></param>
        /// <returns></returns>
        [HttpDelete("{processZoneId:Guid}")]
        public ActionResult Delete([FromRoute]Guid processZoneId)
        {
            if (processZoneId == null || processZoneId == Guid.Empty)
            {
                return BadRequest();
            }
            return _processZoneService.DeleteProcessZone(processZoneId);
        }
    }
}