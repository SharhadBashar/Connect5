using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface ISiteService
    {
        ActionResult<Site> CreateSite(Site site);
        ActionResult<Site> ReadSite(Guid id);
        ActionResult<IEnumerable<Site>> ReadSites();
        ActionResult<Site> UpdateSite(Site site);
        ActionResult DeleteSite(Guid id);
    }
}
