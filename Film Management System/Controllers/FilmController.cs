using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Film_Management_System.BLL;
using Film_Management_System.Models;
using Film_Management_System.Models.ViewModels;

namespace Film_Management_System.Controllers
{
    public class FilmController : Controller
    {
        ActorManaager actorManaager = new ActorManaager();
        CategoryManager categoryManager = new CategoryManager();
        FilmManager filmManager = new FilmManager();
        FilmActorCategoryManager filmActorCategoryManager = new FilmActorCategoryManager();

        // GET: Film
        public ActionResult Index()
        {
            IList<FilmActorCategoryViewModel> FilmActorCategoryViewModels =
                filmActorCategoryManager.GetAllFilmActorCategory();

            return View(FilmActorCategoryViewModels);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Rating = filmManager.GetAllRating();
            ViewBag.Category = categoryManager.GetAllCategories();
            ViewBag.Error = false;

            return View();
        }
        [HttpPost]
        public ActionResult Create(FilmActorCategoryViewModel filmActorCategoryViewModel)
        {
            bool isSaved = filmManager.SaveFilm(filmActorCategoryViewModel);
            if (isSaved)
            {
                ViewBag.Error = false;
                return RedirectToAction("Index");
            }
            ViewBag.Rating = filmManager.GetAllRating();
            ViewBag.Category = categoryManager.GetAllCategories();
            ViewBag.Error = true;
            return View();
        }
    }
}