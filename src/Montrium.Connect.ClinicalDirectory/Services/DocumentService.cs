using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBaseGraphRepository _repository;

        /// <summary>
        /// Initiate Repository
        /// </summary>
        /// <param name="repository"></param>
        public DocumentService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }
        
        /// <summary>
        /// Creates a document
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public ActionResult<Document> CreateDocument(Document document)
        {
            return this._repository.Create<Document>(document);
        }

        /// <summary>
        /// reads a document
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Document> ReadDocument(Guid id)
        {
            return this._repository.Read<Document>(id);
        }

        /// <summary>
        /// Reads all document
        /// </summary>
        /// <returns></returns>
        public ActionResult<IEnumerable<Document>> ReadDocuments()
        {
            return this._repository.Read<Document>();
        }

        /// <summary>
        /// Updates a document
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public ActionResult<Document> UpdateDocument(Document document)
        {
            return this._repository.Update<Document>(document);
        }

        /// <summary>
        /// Deletes a document
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteDocument(Guid id)
        {
            return this._repository.Delete<Document>(id);
        }

        /// <summary>
        /// Gets a document for a user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public ActionResult<IEnumerable<Document>> GetDoc (Guid userId, string permission)
        {
            return this._repository.ReadDoc<Document>(userId, permission);
        }
    }
}
