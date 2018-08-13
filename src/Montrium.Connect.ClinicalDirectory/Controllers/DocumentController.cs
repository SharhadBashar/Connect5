using Gremlin.Net.Process.Traversal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Repositories;
using Montrium.Connect.ClinicalDirectory.Services;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Document))]
        public ActionResult<IEnumerable<Document>> Get()
        {
            // TODO: Handle empty Ids (will tell which route was matched)
            return _documentService.ReadDocuments();
        }

        [HttpGet("{documentId:Guid}")]
        [ProducesResponseType(200, Type = typeof(Document))]
        [ProducesResponseType(404)]
        public ActionResult<Document> Get(Guid documentId)
        {
            if (documentId == null || documentId == Guid.Empty)
            {
                return NotFound();
            }
            return _documentService.ReadDocument(documentId);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Document))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromBody]Document document)
        {
            if (document == null)
            {
                return BadRequest();
            }

            var created = _documentService.CreateDocument(document);

            return Created(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/document/{0}", document.Id), UriKind.Relative), document);
        }

        [HttpPut("{documentId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put([FromRoute]Guid documentId, [FromBody]Document document)
        {
            if (document == null || documentId == null || documentId == Guid.Empty)
            {
                return NoContent();
            }
            _documentService.UpdateDocument(document);


            return Accepted(new Uri(String.Format(CultureInfo.InvariantCulture, "/api/document/{0}", document.Id), UriKind.Relative), document);
        }

        [HttpDelete("{documentId:Guid}")]
        public ActionResult Delete([FromRoute]Guid documentId)
        {
            if (documentId == null || documentId == Guid.Empty)
            {
                return BadRequest();
            }

            return _documentService.DeleteDocument(documentId);
        }
    }
}