using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Capstone.DAO
{
    public class ValetSqlDAO : IValetDAO
    {
        private readonly string connectionString;
        public ValetSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }      

        public Valet GetByUserId(int user_id)
        {
            Valet v = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT valet_id, user_id, " +
                                                    "first_name, last_name " +
                                                    "FROM valets " +
                                                    "WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        v = GetValetFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return v;
        }

        private Valet GetValetFromReader(SqlDataReader reader)
        {
            Valet v = new Valet()
            {
                ValetId = Convert.ToInt32(reader["valet_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"])
            };

            return v;
        }
    }
}
