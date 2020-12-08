using Capstone.Models;
using System;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PatronSqlDAO : IPatronDAO
    {
        private readonly string connectionString;

        public PatronSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Patron GetByUserId(int userId)
        {
            Patron p = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT patron_id, user_id, " +
                                                    "first_name, last_name, phone_number, email_address " +
                                                    "FROM patrons " +
                                                    "WHERE user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        p = GetPatronFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return p;
        }

        private Patron GetPatronFromReader(SqlDataReader reader)
        {
            Patron p = new Patron()
            {
                PatronId = Convert.ToInt32(reader["patron_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                PhoneNumber = Convert.ToString(reader["phone_number"]),
                EmailAddress = Convert.ToString(reader["email_address"])
            };

            return p;
        }
    }
}
