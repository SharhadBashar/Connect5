using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public enum SiteStatus
    {
        Identified,
        Active,
        Ongoing,
        Closed,
        Archived
    }
    public enum StudyStatus
    {
        Startup,
        Ongoing,
        Closed,
        Archived
    }
    public enum PersonStatus
    {
        Inactive,
        Active,
        Deactivated
    }
    public enum CountryStatus
    {
        Inactive,
        Active
    }

    public enum ProcessStatus
    {
        Inactive,
        Active
    }
}
