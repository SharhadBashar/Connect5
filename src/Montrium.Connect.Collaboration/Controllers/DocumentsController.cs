using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.Collaboration.Models;

namespace Montrium.Connect.Collaboration.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        // GET api/documents
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Document))]
        public IActionResult Get()
        {
            return Ok(new string[] { "Doc1", "Doc2" });
        }

        // GET api/documents/5
        [HttpGet("{docId:Guid}")]
        [ProducesResponseType(200, Type = typeof(Document))]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid docId)
        {
            if (docId == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(/* doc */);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Document))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public IActionResult Post([FromBody]Document document)
        {
            if (document == null)
            {
                return BadRequest();
            }

           // _repository.CreateDocument(document);

            return Created(String.Format("/api/documents/{0}", document.Id), document);

        }

        /// <summary>
        /// Update an existing document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="value"></param>
        // PUT: api/documents/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpPut("{documentId:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)] // Not Found
        public void Put(Guid documentId, [FromBody]Document document)
        {
        }

        // DELETE api/documents/7817CD44-C316-4C31-93D2-2B95D6C16754
        [HttpDelete("{documentId:Guid}")]
        public void Delete(Guid documentId)
        {
        }
    }
}
