using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    public interface IPersonService
    {
        ActionResult<Person> CreatePerson(Person person);
        ActionResult<Person> ReadPerson(Guid id);
        ActionResult<IEnumerable<Person>> ReadPersons();
        ActionResult<Person> UpdatePerson(Person person);
        ActionResult DeletePerson(Guid id);
    }
}
