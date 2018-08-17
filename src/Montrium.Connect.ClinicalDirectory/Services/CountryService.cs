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

        /// <summary>
        /// Initiate Repository
        /// </summary>
        /// <param name="repository"></param>
        public CountryService(IBaseGraphRepository repository)
        {
            this._repository = repository;
        }
        
        /// <summary>
        /// Create Country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public ActionResult<Country> CreateCountry(Country country)
        {
            return this._repository.Create(country);
        }

        /// <summary>
        /// Read a country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Country> ReadCountry(Guid id)
        {
            return this._repository.Read<Country>(id);
        }

        /// <summary>
        /// Read countries
        /// </summary>
        /// <returns></returns>
        public ActionResult<IEnumerable<Country>> ReadCountries()
        {
            return this._repository.Read<Country>();
        }

        /// <summary>
        /// Update Countries
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public ActionResult<Country> UpdateCountry(Country country)
        {
            return this._repository.Update<Country>(country);
        }

        /// <summary>
        /// Delete Country
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteCountry(Guid id)
        {
            return this._repository.Delete<Country>(id);
        }
    }
}
