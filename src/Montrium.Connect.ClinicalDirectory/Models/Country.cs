using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class Country : BaseGraphEntity
    {
        public Country() { }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "iSO")]
        public string ISO { get; set; }

        /// <summary>
        /// Create Country
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jo"></param>
        public override void Load(Guid id, JObject jo)
        {
            this.Id = id;
            this.Name = (string)jo["name"][0]["value"];
            this.ISO = (string)jo["iSO"][0]["value"];
        }

    }
}
