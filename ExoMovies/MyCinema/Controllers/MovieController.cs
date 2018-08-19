using MyCinema.Data.Repository;
using MyCinema.DTO;
using MyCinema.Models.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MyCinema.Controllers
{
    public class MovieController : Controller
    {
        RepoMovie repo = new RepoMovie();

        // GET: Movie
        public ActionResult Index(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            var liste = repo.GetAll().ToDTO();

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                liste = liste.Where(m => m.Title.ToLower().Contains(search.Trim().ToLower()));
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(liste.ToPagedList(pageNumber, pageSize));
        }

        //term vient d'autocomplete et doit être écrit tel quel, il représente les lettres tappées par l'utilisateur dans la textbox.
        //Je dois retourner du Json car c'est comme çà qu'autocomplete fonctionne
        //Je dois préciser si j'accepte qu'on me demande du Json => oui
        public ActionResult Autocomplete(string term)
        {
            List<string> titres = repo.GetTitles().ToList();

            if (term.Length > 2)
            {
                titres = titres.Where(t => t.ToLower().Contains(term.ToLower())).Take(10).ToList();
            }
            else titres = new List<string>();

            return Json(titres, JsonRequestBehavior.AllowGet);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById(id).ToDTO());
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        //Pour récupérer un fichier uploadé par un utilisateur, je dois déclarer un paramètre "HttpPostedFileBase" qui aura pour nom le nom EXACT que j'ai donné à mon input file dans la vue
        [HttpPost]
        public ActionResult Create(MovieDTO m, HttpPostedFileBase file)
        {
            string fileName = "movie.jpg";
            
            //Si le modèle est valide
            if (ModelState.IsValid)
            {
                try
                {
                    //Si il y a un fichier uploadé
                    if(file != null)
                    {
                        //Je donne un identifiant unique à mon fichier pour prévenir le fait que parfois 2 films ont le même nom ou deux fichiers ont le même nom
                        fileName = $"{DateTime.Now.ToString("yyyyMMddHHmmssffff")}-{file.FileName}" ;
                        string pathFile = Path.Combine(Server.MapPath("~/Resources"), fileName);
                        //J'enregistre le fichier sur le disque dur
                        file.SaveAs(pathFile);
                    }
                    //Je complète le champs pour insertion en DB
                    string path = Path.Combine("~/Resources", fileName);

                    m.CoverURL = path;
                   
                    repo.Add(m.ToData());
                    repo.Save();

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Error");
                }
            }
            return View();
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id).ToDTO());
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieDTO m, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        var fileName = file.FileName;
                        string pathFile = Path.Combine(Server.MapPath("~/Resources"), fileName);
                        string path = Path.Combine("~/Resources", fileName);

                        m.CoverURL = path;
                        file.SaveAs(pathFile);
                    }

                    repo.Edit(m.ToData());
                    repo.Save();

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Error");
                }
            }
            return View();
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id).ToDTO());
        }

        [HttpPost] 
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                repo.Delete(id);
                repo.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
