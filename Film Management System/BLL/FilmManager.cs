using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;
using Film_Management_System.DAL;
using Film_Management_System.Models;
using Film_Management_System.Models.ViewModels;

namespace Film_Management_System.BLL
{
    public class FilmManager
    {
        FilmGateway filmGateway = new FilmGateway();

        public List<Film> GetAllFilms()
        {
            return filmGateway.GetAllFilms();
        }

        public bool SaveFilm(FilmActorCategoryViewModel filmActorCategoryViewModel)
        {
            bool isFilmExist = GetAllFilms().Any(f=>f.Title==filmActorCategoryViewModel.Title);
            if (isFilmExist)
            {
                return false;
            }

            return filmGateway.SaveFilm(filmActorCategoryViewModel);
        }

        public IEnumerable<string> GetAllRating()
        {
            return filmGateway.GetAllRating();
        }

        
    }
}