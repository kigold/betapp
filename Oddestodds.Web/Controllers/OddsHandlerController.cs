using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oddestodds.Logic.DataObjects;
using Oddestodds.Logic.Interfaces;

namespace Oddestodds.Web.Controllers
{
    public class OddsHandlerController : Controller
    {
        private readonly IOddsLogic _oddsLogic;
        public OddsHandlerController(IOddsLogic oddsLogic)
        {
            _oddsLogic = oddsLogic;
        }
        // GET: OddsHandler
        public ActionResult Index()
        {
            return View(new List<OddsData>());
        }


        // GET: OddsHandler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OddsHandler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OddsData data)
        {
            try
            {
                _oddsLogic.CreateOdds(data);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: OddsHandler/Edit/5
        public ActionResult Edit(int id)
        {
            var odd = _oddsLogic.GetOdds(new[] { id });
            if (odd != null) ;
            return View(odd.FirstOrDefault());
        }

        // POST: OddsHandler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OddsData data)
        {
            try
            {
                data.Id = id;
                _oddsLogic.EditOdds(data);
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