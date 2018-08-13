using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Montrium.Connect.Collaboration.Models
{
    public class FilePlan : BaseEntity
    {
        public override void Load(JObject jo)
        {
            this.Id = new Guid((string)jo["id"][0]["value"]);
        }
    }
}
