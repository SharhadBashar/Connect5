using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Product : BaseGraphEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "sponsorCode")]
        public string SponsorCode { get; set; }

        [JsonProperty(PropertyName = "group")]
        public string Group { get; set; }

        [JsonProperty(PropertyName = "indication")]
        public Indication Indication { get; set; }

        [JsonProperty(PropertyName = "therapeuticArea")]
        public TherapeuticArea TherapeuticArea { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id;
            this.Name = (string)jo["name"][0]["value"];
        }
    }
}
