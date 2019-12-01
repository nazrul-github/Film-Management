using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Film_Management_System.DAL;
using Film_Management_System.Models.ViewModels;

namespace Film_Management_System.BLL
{
    public class FilmActorCategoryManager
    {
        FilmActorCategoryGateWay filmActorCategoryGateWay = new FilmActorCategoryGateWay();

        public List<FilmActorCategoryViewModel> GetAllFilmActorCategory()
        {
            return filmActorCategoryGateWay.GetAllFilmActorCategory();
        }
    }
}