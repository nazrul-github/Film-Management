using System.Collections.Generic;

namespace Film_Management_System.Models.ViewModels
{
    public class FilmCategory
    {
        public List<Film> Films { get; set; }

        public List<Category> Categories { get; set; }
    }
}