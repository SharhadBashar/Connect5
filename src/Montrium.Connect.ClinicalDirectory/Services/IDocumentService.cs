using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface IDocumentService
    {
        ActionResult<Document> CreateDocument(Document document);
        ActionResult<Document> ReadDocument(Guid id);
        ActionResult<IEnumerable<Document>> ReadDocuments();
        ActionResult<Document> UpdateDocument(Document document);
        ActionResult DeleteDocument(Guid id);
    }
}
