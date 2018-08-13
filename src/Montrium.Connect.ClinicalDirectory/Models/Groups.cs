using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class Groups : BaseGraphEntity
    {
        [Required]
        [JsonProperty(PropertyName = "securityName")]
        public string SecurityName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "securityType")]
        public string SecurityType { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id; // new Guid((string)jo["id"][0]["value"]);
            this.SecurityName = (string)jo["securityName"][0]["value"];
            this.SecurityType = (string)jo["securityType"][0]["value"];
        }
    }
}
