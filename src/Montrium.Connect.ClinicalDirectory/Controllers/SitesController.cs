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
    /// controller for creating, updating, deleting sites
    /// </summary>
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class SitesController : Controller
    {
        private readonly IStudyService _studyService;
        private readonly ICountryService _countryService;
        private readonly ISiteService _siteService;

        /// <summary>
        /// creates repo for sites
        /// </summary>
        /// <param name="studyService"></param>
        /// <param name="countryService"></param>
        /// <param name="siteService"></param>
        public SitesController(IStudyService studyService, ICountryService countryService, ISiteService siteService)
        {
            this._studyService = studyService;
            this._countryService = countryService;
            this._siteService = siteService;
        }

        /// <summary>
        /// Depending on the route matched:
        ///   Return all Sites, regardless of Study or Country (both Guids will be empty)
        ///   Return all Sites in a Study, regardless of Country (countryId will be empty)
        ///   Return all Sites in a Country, regardless of Study (studyId will be empty)
        ///   Return all Sites in a Study and Country (both Guids will have values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // GET api/sites
        [ProducesResponseType(200, Type = typeof(Site))]
        public ActionResult<IEnumerable<Site>> Get([FromRoute]Guid studyId = new Guid(), [FromRoute]Guid countryId = new Guid())
        {
            // TODO: Handle empty Ids (will tell which route was matched)
            return _siteService.ReadSites();
            
        }

        /// <summary>
        /// Create a new site under a study (update if exists)
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        // POST api/sites
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Site))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromBody]Site site, [FromRoute]Guid studyId = new Guid(), [FromRoute]Guid countryId = new Guid())
        {
            
            if (site == null)
            {
                return BadRequest();
            }

            var created = _siteService.CreateSite(site);
                    
            return Created(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/sites/{0}", site.Id), UriKind.Relative), site);
        }

        /// <summary>
        /// Update an existing site
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        // PUT api/sites/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpPut("{siteId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put([FromRoute]Guid siteId, [FromBody]Site site)
        {
            if (site == null || siteId == null || siteId == Guid.Empty)
            {
                return NoContent();
            }
           _siteService.UpdateSite(site);
           
            
            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/sites/{0}", site.Id), UriKind.Relative), site);
        }

        /// <summary>
        /// patch a site
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="site"></param>
        /// <returns></returns>
        [HttpPatch("{siteId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Patch([FromRoute]Guid siteId, [FromBody]Site site)
        {
            if (site == null || siteId == null || siteId == Guid.Empty)
            {
                return NoContent();
            }
            _siteService.UpdateSite(site);


            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/sites/{0}", site.Id), UriKind.Relative), site);
        }

        /// <summary>
        /// Delete a site from under a study or country
        /// Only the relationship will be deleted
        /// </summary>
        /// <param name="siteId"></param>
        // DELETE api/studies/485b8327-a184-4230-b5ec-102e77a59c28/sites/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpDelete("{siteId:Guid}")]

        public ActionResult Delete([FromRoute]Guid siteId)
        {
            if (siteId == null || siteId == Guid.Empty)
            {
                return BadRequest();
            }

            return _siteService.DeleteSite(siteId);
        }
    }
}
