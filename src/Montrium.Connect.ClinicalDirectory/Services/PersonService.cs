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
    public class PersonService: IPersonService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBaseGraphRepository _repository;

        /// <summary>
        /// Initiate Repository
        /// </summary>
        /// <param name="repository"></param>
        public PersonService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates a person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public ActionResult<Person> CreatePerson(Person person)
        {
            return this._repository.Create<Person>(person);
        }

        /// <summary>
        /// Reads a person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Person> ReadPerson(Guid id)
        {
            return this._repository.Read<Person>(id);
        }

        /// <summary>
        /// Reads all person
        /// </summary>
        /// <returns></returns>
        public ActionResult<IEnumerable<Person>> ReadPersons()
        {
            return this._repository.Read<Person>();
        }

        /// <summary>
        /// Updates a person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public ActionResult<Person> UpdatePerson(Person person)
        {
            return this._repository.Update<Person>(person);
        }

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeletePerson(Guid id)
        {
            return this._repository.Delete<Person>(id);
        }
    }
}
