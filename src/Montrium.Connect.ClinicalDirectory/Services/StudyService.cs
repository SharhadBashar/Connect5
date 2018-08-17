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
    /// CanCreateStudy
    /// CanReadStudy
    /// CanUpdateStudy
    /// CanApproveStudyDesign
    /// CanDeleteStudy
    /// </summary>
    //[Authorize]
    public class StudyService : IStudyService
    {
        private readonly IBaseGraphRepository _repository;

        /// <summary>
        /// Initiate Repository
        /// </summary>
        /// <param name="repository"></param>
        public StudyService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates a study
        /// </summary>
        /// <param name="study"></param>
        /// <returns></returns>
        public async Task<ActionResult<Study>> CreateStudy(Study study)
        {
            return this._repository.Create<Study>(study);
        }

        /// <summary>
        /// Reads a study
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Study> ReadStudy(Guid id)
        {
            return this._repository.Read<Study>(id);
        }

        /// <summary>
        /// Reads all studies
        /// </summary>
        /// <returns></returns>
        public ActionResult<IEnumerable<Study>> ReadStudies()
        {
            return this._repository.Read<Study>();
        }

        /// <summary>
        /// Get all studies occuring in a given country
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public ActionResult<IEnumerable<Study>> ReadStudies(Guid countryId)
        {
            return this._repository.Read<Study>();
        }

        /// <summary>
        /// updates a study
        /// </summary>
        /// <param name="study"></param>
        /// <returns></returns>
        public async Task<ActionResult<Study>> UpdateStudy(Study study)
        {
            return  this._repository.Update<Study>(study);
        }

        /// <summary>
        /// deletes a study
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteStudy(Guid id)
        {
            return this._repository.Delete<Study>(id);
        }

        //        [Authorize(Policy = "CanManageStudy")]
        public bool AddCountryToStudy(Study model, Country country, string countryStatus)
        {
            throw new NotImplementedException();
        }

        //        [Authorize(Policy = "CanManageStudy")]
        public bool AddSiteToStudy(Study model, Site site, string siteStatus)
        {
            throw new NotImplementedException();
        }
    }
}
