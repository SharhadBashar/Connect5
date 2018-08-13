using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Repositories;
using System;
using System.Collections.Generic;


namespace Montrium.Connect.ClinicalDirectory.Services
{
    public class GroupsService :IGroupsService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBaseGraphRepository _repository;

        public GroupsService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult<Groups> CreateGroup(Groups group)
        {
            return this._repository.Create<Groups>(group);
        }

        public ActionResult<Groups> ReadGroup(Guid id)
        {
            return this._repository.Read<Groups>(id);
        }

        public ActionResult<IEnumerable<Groups>> ReadGroups()
        {
            return this._repository.Read<Groups>();
        }

        public ActionResult<Groups> UpdateGroup(Groups group)
        {
            return this._repository.Update<Groups>(group);
        }

        public ActionResult DeleteGroup(Guid id)
        {
            return this._repository.Delete<Groups>(id);
        }
    }
}
