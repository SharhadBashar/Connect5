using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrium.Connect.EventBus.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public IntegrationEvent(int version, string author, string ip)
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
            Version = version;
            Author = author;
            IP = ip;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public int Version { get; }
        public string Author { get; }
        public string IP { get; }
    }
}
