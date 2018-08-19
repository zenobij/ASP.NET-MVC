using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testdrop.Models;

namespace testdrop.Controllers
{
    public class PersonneController : Controller
    {
        PersonneContext ctx = new PersonneContext();
        // GET: Personne
        public ActionResult Index()
        {
            return View(ctx.Personne);
        }

        // GET: Personne/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personne/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(ctx.Genre, "GenreId", "Civilite");
            return View();
        }

        // POST: Personne/Create
        [HttpPost]
        public ActionResult Create(Personne p)
        {
            try
            {
                ctx.Personne.Add(p);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Edit/5
        public ActionResult Edit(int id)
        {
            Personne p = ctx.Personne.FirstOrDefault(t => t.PersonneId == id);

            ViewBag.GenreId = new SelectList(ctx.Genre, "GenreId", "Civilite",p.GenreId);

            return View(p);

        }

        // POST: Personne/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Personne p)
        {
            try
            {
                Personne pe = ctx.Personne.FirstOrDefault(t => t.PersonneId == id);
                pe.GenreId = p.GenreId;
                pe.Genre = p.Genre;

                ctx.SaveChanges();



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personne/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
