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
    /// 
    /// </summary>
    public class ProcessZoneService : IProcessZoneService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBaseGraphRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public ProcessZoneService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        //        [Authorize(Policy = "CanManageProgram")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processZone"></param>
        /// <returns></returns>
        public ActionResult<ProcessZone> CreateProcessZone(ProcessZone processZone)
        {
            return this._repository.Create<ProcessZone>(processZone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<ProcessZone> ReadProcessZone(Guid id)
        {
            return this._repository.Read<ProcessZone>(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult<IEnumerable<ProcessZone>> ReadProcessZones()
        {
            return this._repository.Read<ProcessZone>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processZone"></param>
        /// <returns></returns>
        public ActionResult<ProcessZone> UpdateProcessZone(ProcessZone processZone)
        {
            return this._repository.Update<ProcessZone>(processZone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteProcessZone(Guid id)
        {
            return this._repository.Delete<ProcessZone>(id);
        }
    }
}
