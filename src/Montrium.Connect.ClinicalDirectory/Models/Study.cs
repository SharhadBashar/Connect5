using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Montrium.Connect.ClinicalDirectory.Models
{
    public class Study : BaseGraphEntity
    {
        public Study() { }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }

        [Required]
        [JsonProperty(PropertyName = "status")]
        public StudyStatus Status { get; set; }

        [JsonProperty(PropertyName = "phase")]
        public int Phase { get; set; }

        [JsonProperty(PropertyName = "isDeployed")]
        public bool isDeployed { get; set; }

        [JsonProperty(PropertyName = "isBlinded")]
        public bool isBlinded { get; set; }

        [JsonProperty(PropertyName = "isBlindLifted")]
        public bool isBlindLifted { get; set; }

        [JsonProperty(PropertyName = "blindLiftedDate")]
        public DateTime BlindLiftedDate{ get; set; }

        [JsonProperty(PropertyName = "studyDesign")]
        public StudyDesign StudyDesign { get; set; }

        /// <summary>
        /// Create Study
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jo"></param>
        public override void Load(Guid id, JObject jo)
        {
            this.Id = id;
            this.Name = (string)jo["name"][0]["value"];
            this.Phase = (int)jo["phase"][0]["value"];
            this.Status = (StudyStatus)((int)jo["status"][0]["value"]);
            this.isDeployed = bool.Parse((string)jo[nameof(isDeployed)][0]["value"]);
            this.isBlinded = bool.Parse((string)jo[nameof(isBlinded)][0]["value"]);
            this.isBlindLifted = bool.Parse((string)jo[nameof(isBlindLifted)][0]["value"]);
//            this.BlindLiftedDate = DateTime.Parse((string)jo["blindLiftedDate"][0]["value"], CultureInfo.CurrentCulture);
        }
    }
}
