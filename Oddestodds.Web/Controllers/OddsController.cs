﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oddestodds.Logic.Interfaces;

namespace Oddestodds.Web.Controllers
{
    public class OddsController : Controller
    {
        private readonly IOddsLogic _logic;
        public OddsController(IOddsLogic logic)
        {
            _logic = logic;
        }
        // GET: Odds
        public ActionResult Index()
        {
            var odds = _logic.GetOdds();
            return View(odds);
        }

        // GET: Odds/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Odds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Odds/Create
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

        // GET: Odds/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Odds/Edit/5
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

        // GET: Odds/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Odds/Delete/5
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