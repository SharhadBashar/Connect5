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
    /// <summary>
    /// Controller for creates, updates, deletes document
    /// </summary>
    //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    [Route("/api/User/{userId:Guid}/Permission/{permission}/[controller]")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        /// <summary>
        /// creates repor for document
        /// </summary>
        /// <param name="documentService"></param>
        public DocumentController(IDocumentService documentService)
        {
            this._documentService = documentService;
        }

        /// <summary>
        /// gets all document
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Document))]
        public ActionResult<IEnumerable<Document>> Get([FromRoute]Guid userId = new Guid(), [FromRoute]string permission = null)
        {
            if (userId != Guid.Empty && permission != null)
            {
                return _documentService.GetDoc(userId, permission);
            }
            else 
            {
                return _documentService.ReadDocuments();
            }
        }

        /// <summary>
        /// getsa document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// creates a document
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
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

        /// <summary>
        /// edits a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="document"></param>
        /// <returns></returns>
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

        /// <summary>
        /// deletes a document
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
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