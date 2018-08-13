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

        public PersonService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

        public ActionResult<Person> CreatePerson(Person person)
        {
            return this._repository.Create<Person>(person);
        }

        public ActionResult<Person> ReadPerson(Guid id)
        {
            return this._repository.Read<Person>(id); ;
        }

        public ActionResult<IEnumerable<Person>> ReadPersons()
        {
            return this._repository.Read<Person>();
        }

        public ActionResult<Person> UpdatePerson(Person person)
        {
            return this._repository.Update<Person>(person);
        }

        public ActionResult DeletePerson(Guid id)
        {
            return this._repository.Delete<Person>(id);
        }
    }
}
