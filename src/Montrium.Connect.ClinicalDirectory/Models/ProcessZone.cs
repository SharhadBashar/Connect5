using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class ProcessZone : BaseGraphEntity
    {
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ProcessStatus Status { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id; // new Guid((string)jo["id"][0]["value"]);
            this.Name = (string)jo["name"][0]["value"];
            this.Status = (ProcessStatus)((int)jo["status"][0]["value"]);
        }
    }
}
