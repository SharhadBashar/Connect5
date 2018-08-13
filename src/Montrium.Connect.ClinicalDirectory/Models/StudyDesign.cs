using Newtonsoft.Json.Linq;
using System;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class StudyDesign : BaseGraphEntity
    {
        public string Indication { get; set; }
        public string TreatmentMinDose { get; set; }
        public string TreatmentMaxDose { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id; // new Guid((string)jo["id"][0]["value"]);
        }
    }
}
