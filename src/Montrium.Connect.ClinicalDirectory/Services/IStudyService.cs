using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface IStudyService
    {
        Task<ActionResult<Study>> CreateStudy(Study study);
        ActionResult<Study> ReadStudy(Guid id);
        ActionResult<IEnumerable<Study>> ReadStudies();
        Task<ActionResult<Study>> UpdateStudy(Study study);
        ActionResult DeleteStudy(Guid id);

        bool AddSiteToStudy(Study model, Site site, string siteStatus);
        bool AddCountryToStudy(Study model, Country country, string countryStatus);
    }
}
