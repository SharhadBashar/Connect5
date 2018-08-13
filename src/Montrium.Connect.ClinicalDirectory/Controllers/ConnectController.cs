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
    /// Adds, updates, deletes Edges between nodes
    /// </summary>
     //[Authorize]
    [ApiController]
    [Produces("application/json")]
    [Route("/api/{parent}/{parentId:Guid}/{child}/{childId:Guid}/[controller]")]
    public class ConnectController : Controller
    {
        private readonly IBaseGraphRepository _repository;
        public ConnectController(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates an Edge
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="parentId"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict - already exists
        public ActionResult Post([FromRoute]string parent, [FromRoute]string child, [FromRoute]Guid parentId = new Guid(), [FromRoute]Guid childId = new Guid())
        {
            if (parent == null || child == null || (parentId == null && childId == null))
            {
                return BadRequest();
            }
            if (parent.Equals("UserPermission") && child.Equals("Document"))
            {
                //gets all the user security and processzone details
                int[] userProcessZones;
                char[] userSecurity;
                List<Guid> documentsId = new List<Guid>();
                string userRole = _repository.GetProperty(parentId, "jobRole");
                userProcessZones = Roles.rolesTable[1].ProcessZone;
                userSecurity = Roles.rolesTable[1].Security;
                
                //Get a list of all documents the user has access to
                List<Guid> userAccessNodes = _repository.Transverse(parentId, true);
                foreach(Guid id in userAccessNodes)
                {
                    List<Guid> nodes = _repository.Transverse(id, true);
                    foreach (Guid nodeId in nodes)
                    {
                        string property = _repository.GetProperty(nodeId, "label");
                        if (property.Equals("document"))
                        {
                            documentsId.Add(nodeId);
                        }
                    }        
                }
                for (int i = 0; i < documentsId.Count; i++)
                {
                    int docProcessZone = Convert.ToInt32(_repository.GetProperty(documentsId[i], "processZone"));
                    int pos = Array.IndexOf(userProcessZones, docProcessZone);
                    if (pos > -1)
                    {
                        Guid hasEdge = _repository.ReadEdge(parentId, documentsId[i]);
                        if (hasEdge.Equals(Guid.Empty))
                        {
                            _repository.CreateEdge(parentId, documentsId[i], string.Format("User {0} access", userSecurity[pos]));
                        }
                    }
                }
            }

            //gives users access to studies, countries, sites
            else if (parent.Equals("UserAccess") && !child.Equals("Document"))
            {
                Guid hasEdge = _repository.ReadEdge(parentId, childId);
                if (hasEdge.Equals(Guid.Empty))
                {
                    _repository.CreateEdge(parentId, childId, string.Format("User access"));
                }
                List<Guid> childIds = new List<Guid>();
                childIds.Add(childId);
                while (childIds.Count > 0)
                {
                    try
                    {
                        List<Guid> ids = new List<Guid>();
                        
                        foreach (Guid id in childIds)
                        {
                            ids = _repository.GetChildNodes(id);
                            foreach (Guid individualChildId in ids)
                            {
                                hasEdge = _repository.ReadEdge(parentId, individualChildId);
                                if (hasEdge.Equals(Guid.Empty))
                                {
                                    _repository.CreateEdge(parentId, individualChildId, string.Format("User access"));
                                }
                            }  
                        }
                        childIds.Clear();
                        childIds.AddRange(ids);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine("Error: " + e.Message);
                    }
                }
            }
            else
            {
                _repository.CreateEdge(parentId, childId, string.Format("{0}-{1} relationship", parent, child));
            }
            //_repository.CreateEdge(parentId, childId, string.Format("{0}-{1} relationship", parent, child));
            return new OkResult();
        }

        /// <summary>
        /// Updates an Edge
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="parentId"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Put([FromRoute]string parent, [FromRoute]string child, [FromRoute]Guid parentId = new Guid(), [FromRoute]Guid childId = new Guid())
        {
            Guid edgeId = Guid.Empty;
            if (parent == null || child == null || (parentId == null && childId == null))
            {
                return BadRequest();
            }
            try
            {
                edgeId = _repository.ReadEdge(parentId, childId);
                
            }
            catch (NullReferenceException e)
            {
                edgeId = _repository.ReadEdge(childId, parentId);
            }
            _repository.UpdateEdge(edgeId, string.Format("Edited {0}-{1} relationship", parent, child));
            return new OkResult();
        }

        /// <summary>
        /// Patch an edge
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="parentId"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        [HttpPatch()]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)] // Not Found
        public ActionResult Patch([FromRoute]string parent, [FromRoute]string child, [FromRoute]Guid parentId = new Guid(), [FromRoute]Guid childId = new Guid())
        {
            Guid edgeId = Guid.Empty;
            if (parent == null || child == null || (parentId == null && childId == null))
            {
                return BadRequest();
            }
            try
            {
                edgeId = _repository.ReadEdge(parentId, childId);
            }
            catch (NullReferenceException e)
            {
                edgeId = _repository.ReadEdge(childId, parentId);
            }
            _repository.UpdateEdge(edgeId, string.Format("Edited {0}-{1} relationship", parent, child));
            return new OkResult();
        }

        /// <summary>
        /// Deletes an Edge
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="childId"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)] // No Content
        [ProducesResponseType(404)]
        public ActionResult Delete([FromRoute]Guid parentId = new Guid(), [FromRoute]Guid childId = new Guid())
        {
            if (parentId == null && childId == null)
            {
                return BadRequest();
            }
            Guid edgeId = Guid.Empty;
            try
            {
                edgeId = _repository.ReadEdge(parentId, childId);
            }
            catch (NullReferenceException e)
            {
                edgeId = _repository.ReadEdge(childId, parentId);
            }
            _repository.DeleteEdge(edgeId);
            return new OkResult();
        }
    }
}