using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Montrium.Connect.PDF.Web.Models;
using Montrium.Connect.PDF.Web.Services;
using Montrium.Connect.PDF.Shared.Events;

namespace Montrium.Connect.PDF.Web.Controllers
{
    public class UserReportingController : Controller
    {
        private readonly IEventPublisher _eventPublisher;
        public UserReportingController(IEventPublisher eventPublisher)
        {
            this._eventPublisher = eventPublisher;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm] NewUserDetailReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                var @event = new CreateReportRequested
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    DateOfBirth = model.DateOfBirth,
                    JoinedOn = model.JoinedOn
                };

                await _eventPublisher.Publish(@event);
                return Redirect("/Downloads");
            }

            return View("Index");
        }
    }
}
