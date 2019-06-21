using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oddestodds.Logic.DataObjects;

namespace Oddestodds.Web.Controllers
{
    public class OddsHandlerController : Controller
    {
        // GET: OddsHandler
        public ActionResult Index()
        {
            return View(new List<OddsData>());
        }

        // GET: OddsHandler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OddsHandler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OddsHandler/Create
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

        // GET: OddsHandler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OddsHandler/Edit/5
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

        // GET: OddsHandler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OddsHandler/Delete/5
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