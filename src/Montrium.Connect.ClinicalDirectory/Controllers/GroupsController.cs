using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Montrium.Connect.ClinicalDirectory.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Groups
        public ActionResult Index()
        {
            return View();
        }

        // GET: Groups/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Groups/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Groups/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}