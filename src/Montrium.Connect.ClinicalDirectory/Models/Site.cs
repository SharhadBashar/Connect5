using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class Site : BaseGraphEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "status")]
        public SiteStatus Status { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Create Site
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jo"></param>
        public override void Load(Guid id, JObject jo)
        {
            this.Id = id;
            this.Name = (string)jo["name"][0]["value"];
            this.Location = (string)jo["location"][0]["value"];
            this.Status = (SiteStatus)((int)jo["status"][0]["value"]);
            this.Type = (string)jo["type"][0]["value"];
        }
    }
}
