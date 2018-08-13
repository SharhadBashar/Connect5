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

        public SiteService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

//        [Authorize(Policy = "CanManageProgram")]
        public ActionResult<Site> CreateSite(Site site)
        {
            return this._repository.Create<Site>(site);
        }

        public ActionResult<Site> ReadSite(Guid id)
        {
            return this._repository.Read<Site>(id);
        }

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

        public ActionResult<Site> UpdateSite(Site site)
        {
            return this._repository.Update<Site>(site);
        }

        public ActionResult DeleteSite(Guid id)
        {
            return this._repository.Delete<Site>(id);
        }
        public ActionResult ConnectSite(Guid parentID, Guid childID, string relationship)
        {
            return this._repository.CreateEdge(parentID, childID, relationship);
        }
    }
}
