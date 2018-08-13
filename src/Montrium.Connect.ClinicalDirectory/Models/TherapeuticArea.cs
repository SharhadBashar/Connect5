using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class TherapeuticArea : BaseGraphEntity
    {
        public string Name { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id;
            this.Name = (string)jo["name"][0]["value"];
        }
    }
}
