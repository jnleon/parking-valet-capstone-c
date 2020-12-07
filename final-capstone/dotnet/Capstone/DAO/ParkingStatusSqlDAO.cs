using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class ParkingStatusSqlDAO : IParkingStatusDAO
    {
        private readonly string connectionString;

        public ParkingStatusSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public ParkingStatus Get(int id)
        {
            ParkingStatus ps = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parking_status_id, parking_status " +
                                                    "FROM parking_statuses " +
                                                    "WHERE parking_status_id = @parkingstatusid", conn);
                    cmd.Parameters.AddWithValue("@parkingstatusid", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        ps = GetParkingStatusFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return ps;
        }

        public List<ParkingStatus> List()
        {
            List<ParkingStatus> parkingStatuses = new List<ParkingStatus>();
            ParkingStatus ps = new ParkingStatus();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parking_status_id, parking_status " +
                                                    "FROM parking_statuses " +
                                                    "ORDER BY parking_status_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        ps = GetParkingStatusFromReader(reader);
                        parkingStatuses.Add(ps);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return parkingStatuses;
        }

        private ParkingStatus GetParkingStatusFromReader(SqlDataReader reader)
        {
            ParkingStatus ps = new ParkingStatus()
            {
                ParkingStatusId = Convert.ToInt32(reader["parking_status_id"]),
                ParkingStatusName = Convert.ToString(reader["parking_status"])
            };

            return ps;
        }
    }
}
