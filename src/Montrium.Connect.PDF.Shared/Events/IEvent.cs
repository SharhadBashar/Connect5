using System;
using System.Collections.Generic;
using System.Text;

namespace Montrium.Connect.PDF.Shared.Events
{
    public interface IEvent
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; }
    }
}
