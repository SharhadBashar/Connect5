using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface IGroupsService
    {
        ActionResult<Groups> CreateGroup(Groups group);
        ActionResult<Groups> ReadGroup(Guid id);
        ActionResult<IEnumerable<Groups>> ReadGroups();
        ActionResult<Groups> UpdateGroup(Groups document);
        ActionResult DeleteGroup(Guid id);
    }
}
