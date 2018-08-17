
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Montrium.Connect.PDF.Shared.Events;

namespace Montrium.Connect.PDF.Web.Services
{
    public interface IEventPublisher
    {
        Task Publish(IEvent @event);
    }
}
