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

        public DocumentService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        //        [Authorize(Policy = "CanManageProgram")]
        public ActionResult<Document> CreateDocument(Document document)
        {
            return this._repository.Create<Document>(document);
        }

        public ActionResult<Document> ReadDocument(Guid id)
        {
            return this._repository.Read<Document>(id);
        }

        public ActionResult<IEnumerable<Document>> ReadDocuments()
        {
            return this._repository.Read<Document>();
        }

        public ActionResult<Document> UpdateDocument(Document document)
        {
            return this._repository.Update<Document>(document);
        }

        public ActionResult DeleteDocument(Guid id)
        {
            return this._repository.Delete<Document>(id);
        }

        public ActionResult<IEnumerable<Document>> GetDoc (Guid userId, string permission)
        {
            return this._repository.ReadDoc<Document>(userId, permission);
        }
    }
}
