using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Film_Management_System.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public int RentalDuration { get; set; }
        public int RentalRate { get; set; }
        public string Rating { get; set; }
    }
}