using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.Collaboration.Models
{
    public class Document : BaseEntity
    {
        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public string Filename { get; set; }

        public string DocumentType { get; set; }

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        public string ModifiedBy { get; set; }

        public override void Load(JObject jo)
        {
            this.Id = new Guid((string)jo["id"][0]["value"]);
        }
    }
}
