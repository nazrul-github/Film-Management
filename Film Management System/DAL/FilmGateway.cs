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
    public class FilmGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<Film> GetAllFilms()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllFilms", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Film> films = new List<Film>();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    films.Add(new Film()
                    {
                        FilmId = (int)reader["film_id"],
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        ReleaseYear = reader["release_year"].ToString(),
                        RentalDuration = (int)reader["rental_duration"],
                        Rating = reader["rating"].ToString(),
                        RentalRate = (int)reader["rental_rate"]
                    });
                }
                reader.Close();
                connection.Close();
                return films;
            }
        }

        public bool SaveFilm(FilmActorCategoryViewModel filmActorCategoryViewModel)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_CreateFilms", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", filmActorCategoryViewModel.Title);
                command.Parameters.AddWithValue("@Description", filmActorCategoryViewModel.Description);
                command.Parameters.AddWithValue("@ReleaseYear", filmActorCategoryViewModel.ReleaseYear);
                command.Parameters.AddWithValue("@RentalDuration", filmActorCategoryViewModel.RentalDuration);
                command.Parameters.AddWithValue("@RentalRate", filmActorCategoryViewModel.RentalRate);
                command.Parameters.AddWithValue("@Rating", filmActorCategoryViewModel.Rating);
                command.Parameters.AddWithValue("@ActorFirstName", filmActorCategoryViewModel.FirstName);
                command.Parameters.AddWithValue("@ActorLastName", filmActorCategoryViewModel.LastName);
                command.Parameters.AddWithValue("@CategoryId", filmActorCategoryViewModel.CategoryId);
                SqlParameter filmId = new SqlParameter();
                filmId.DbType = DbType.Int32;
                filmId.ParameterName = "@FilmId";
                filmId.Direction = ParameterDirection.Output;
                command.Parameters.Add(filmId);
                SqlParameter actorId = new SqlParameter();
                actorId.DbType = DbType.Int32;
                actorId.ParameterName = "@ActorId";
                actorId.Direction = ParameterDirection.Output;
                command.Parameters.Add(actorId);
               
                connection.Open();
              int rowAffected =  command.ExecuteNonQuery();
    /*          int one = Convert.ToInt32(filmId);
              int two = Convert.ToInt32(actorId);*/
                connection.Close();
                if (rowAffected>0)
                {
                    return true;
                }
                return false;
            }
        }
        public List<Category> GetAllCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllCategory", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Category> categories = new List<Category>();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Category()
                    {
                        CategoryId = (int)reader["category_id"],
                        CategoryName = reader["name"].ToString()
                    });
                }
                reader.Close();
                connection.Close();
                return categories;
            }
        }
        public List<string> GetAllRating()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllRating", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<string> rating = new List<string>();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rating.Add(reader["rating"].ToString());
                }
                reader.Close();
                connection.Close();
                return rating;
            }
        }
    }
}