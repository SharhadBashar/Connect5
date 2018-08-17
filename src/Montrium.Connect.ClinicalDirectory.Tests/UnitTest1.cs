using MediatR;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory;
using Montrium.Connect.ClinicalDirectory.Controllers;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Linq;
using Xunit;
namespace Montrium.Connect.ClinicalDirectory.Tests
{
    public class ControllerTest
    {
        private IMediator mediator;
        private IStudyService studyService;

        [Fact]
        public void Get_Study()
        {
            ActionResult<Study> studyType = null; 
            Guid id = Guid.Parse("a0d88659-47e0-41e1-af04-d287fcdd5453");
            var study = new StudiesController(studyService, mediator);
            var get = study.Get(id);
            Assert.Same(studyType, get);
        }
    }
}
