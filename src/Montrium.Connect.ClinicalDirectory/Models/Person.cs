using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class Person : BaseGraphEntity
    {
        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "status")]
        public PersonStatus Status { get; set; }

        [JsonProperty(PropertyName = "jobRole")]
        public string JobRole { get; set; }

        [JsonProperty(PropertyName = "jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty(PropertyName = "applicationName")]
        public string ApplicationName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "upn")]
        public string UPN { get; set; }

        public override void Load(Guid id, JObject jo)
        {
            this.Id = id; // new Guid((string)jo["id"][0]["value"]);
            this.Name = (string)jo["name"][0]["value"];
            this.Status = (PersonStatus)((int)jo["status"][0]["value"]);
            this.JobRole = (string)jo["jobRole"][0]["value"];
            this.JobTitle = (string)jo["jobTitle"][0]["value"];
            this.ApplicationName = (string)jo["applicationName"][0]["value"];
            this.Email = (string)jo["email"][0]["value"];
            this.UPN = (string)jo["upn"][0]["value"];
        }
    }
}
