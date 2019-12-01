using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Film_Management_System.Models;
using Film_Management_System.Models.ViewModels;

namespace Film_Management_System.DAL
{
    public class FilmActorCategoryGateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<FilmActorCategoryViewModel> GetAllFilmActorCategory()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllFilmCategoryActor", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<FilmActorCategoryViewModel> filmActorCategory = new List<FilmActorCategoryViewModel>();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    filmActorCategory.Add(new FilmActorCategoryViewModel()
                    {
                        FilmId = (int)reader["film_id"],
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        ReleaseYear =reader["release_year"].ToString(),
                        Rating = reader["rating"].ToString(),
                       CategoryName = reader["CategoryName"].ToString(),
                       FirstName = reader["FirstName"].ToString(),
                       LastName = reader["LastName"].ToString()
                    });
                }
                reader.Close();
                connection.Close();
                return filmActorCategory;
            }
        }
    }
}