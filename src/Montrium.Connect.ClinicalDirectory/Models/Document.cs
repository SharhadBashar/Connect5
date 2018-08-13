using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class Document : BaseGraphEntity
    {
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string Filename { get; set; }

        [JsonProperty(PropertyName = "documentType")]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTime Modified { get; set; }

        [JsonProperty(PropertyName = "modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty(PropertyName = "processZone")]
        public int ProcessZone { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id; // new Guid((string)jo["id"][0]["value"]);
            this.Name = (string)jo["name"][0]["value"];
            this.Filename = (string)jo["fileName"][0]["value"];
            this.DocumentType = (string)jo["documentType"][0]["value"];
            this.Created = (DateTime)jo["created"][0]["value"];
            this.CreatedBy = (string)jo["createdBy"][0]["value"];
            this.Modified = (DateTime)jo["modified"][0]["value"];
            this.ModifiedBy = (string)jo["modifiedBy"][0]["value"];
            this.ProcessZone = (int)jo["processZone"][0]["value"];
        }
    }
}
