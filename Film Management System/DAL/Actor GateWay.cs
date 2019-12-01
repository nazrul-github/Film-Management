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
    public class Actor_GateWay
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<Actor> GetAllActors()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllActros", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Actor> actors = new List<Actor>();
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    actors.Add(new Actor()
                    {
                        ActorId = (int)reader["actor_id"],
                        FirstName = reader["first_name"].ToString(),
                        LastName = reader["last_name"].ToString()
                    });
                }
                reader.Close();
                connection.Close();
                return actors;
            }
        }
    }
}