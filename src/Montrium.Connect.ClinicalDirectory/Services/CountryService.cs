using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Montrium.Connect.ClinicalDirectory.Models;
using Montrium.Connect.ClinicalDirectory.Repositories;
using System;
using System.Collections.Generic;

namespace Montrium.Connect.ClinicalDirectory.Services
{
    /// <summary>
    /// Policies used by this Service:
    /// CanCreateCountry
    /// CanReadCountry
    /// CanUpdateCountry
    /// CanApproveCountryDesign
    /// CanDeleteCountry
    /// </summary>
    //[Authorize]
    public class CountryService : ICountryService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IBaseGraphRepository _repository;

        public CountryService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }

//        [Authorize(Policy = "CanManageProgram")]
        public ActionResult<Country> CreateCountry(Country country)
        {
            return this._repository.Create(country);
        }

        public ActionResult<Country> ReadCountry(Guid id)
        {
            return this._repository.Read<Country>(id);
        }

        public ActionResult<IEnumerable<Country>> ReadCountries()
        {
            return this._repository.Read<Country>();
        }

        public ActionResult<Country> UpdateCountry(Country country)
        {
            return this._repository.Update<Country>(country);
        }

        public ActionResult DeleteCountry(Guid id)
        {
            return this._repository.Delete<Country>(id);
        }

        public ActionResult ConnectCountry(Guid parentID, Guid childID, string relationship)
        {
            return this._repository.CreateEdge(parentID, childID, relationship);
        }
    }
}
