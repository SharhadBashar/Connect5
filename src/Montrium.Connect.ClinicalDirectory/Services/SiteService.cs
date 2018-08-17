using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    /// <summary>
    /// Policies used by this Service:
    /// CanCreateSite
    /// CanReadSite
    /// CanUpdateSite
    /// CanApproveSiteDesign
    /// CanDeleteSite
    /// </summary>
    //[Authorize]
    public class SiteService : ISiteService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBaseGraphRepository _repository;

        /// <summary>
        /// Initiate Repository
        /// </summary>
        /// <param name="repository"></param>
        public SiteService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates a site
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public ActionResult<Site> CreateSite(Site site)
        {
            return this._repository.Create<Site>(site);
        }

        /// <summary>
        /// Reads a site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Site> ReadSite(Guid id)
        {
            return this._repository.Read<Site>(id);
        }

        /// <summary>
        /// reads all sites
        /// </summary>
        /// <returns></returns>
        public ActionResult<IEnumerable<Site>> ReadSites()
        {
            return this._repository.Read<Site>();
        }

        public ActionResult<IEnumerable<Site>> ReadSites(Guid studyId)
        {
            return this._repository.Read<Site>();
        }

        public ActionResult<IEnumerable<Site>> ReadSites(Guid studyId, Guid countryId)
        {
            return this._repository.Read<Site>();
        }

        /// <summary>
        /// Updates a site
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public ActionResult<Site> UpdateSite(Site site)
        {
            return this._repository.Update<Site>(site);
        }

        /// <summary>
        /// Deletes a site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteSite(Guid id)
        {
            return this._repository.Delete<Site>(id);
        }
    }
}
