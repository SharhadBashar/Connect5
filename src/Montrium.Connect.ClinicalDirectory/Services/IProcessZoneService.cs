using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface IProcessZoneService
    {
        ActionResult<ProcessZone> CreateProcessZone(ProcessZone processZone);
        ActionResult<ProcessZone> ReadProcessZone(Guid id);
        ActionResult<IEnumerable<ProcessZone>> ReadProcessZones();
        ActionResult<ProcessZone> UpdateProcessZone(ProcessZone processZone);
        ActionResult DeleteProcessZone(Guid id);
    }
}
