using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Montrium.Connect.Collaboration.Models
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Every entity in the graph DB has its own Guid
        /// </summary>
        [Required]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonIgnore]
        public virtual string Label
        {
            get { return this.GetType().Name; }
        }

        public abstract void Load(JObject jo);

        public string ToGremlinPropertyChain()
        {
            string gremlinPropertyChain = string.Empty;

            dynamic jobj = JObject.FromObject(this);
            ;

            foreach (var item in jobj.Properties())
            {
                gremlinPropertyChain += string.Format(".property('{0}', '{1}')", item.Name, item.Value);
            }

            return gremlinPropertyChain;
        }
    }
}
