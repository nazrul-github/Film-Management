using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Film_Management_System.Models;

namespace Film_Management_System.DAL
{
    public class CategoryGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

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
                       CategoryId = (int) reader["category_id"],
                       CategoryName = reader["name"].ToString()
                    });
                }
                reader.Close();
                connection.Close();
                return categories;
            }
        }
    }
}