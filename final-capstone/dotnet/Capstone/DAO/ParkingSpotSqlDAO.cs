using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class ParkingSpotSqlDAO : IParkingSpotDAO
    {
        private readonly string connectionString;

        public ParkingSpotSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public ParkingSpot Create(ParkingSpot parkingSpotToCreate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO parking_spots (is_occupied) " +
                                                    "VALUES (@isoccupied)", conn);
                    cmd.Parameters.AddWithValue("@isoccupied", parkingSpotToCreate.IsOccupied);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT @@IDENTITY", conn);
                    int newId = Convert.ToInt32(cmd.ExecuteScalar());

                    return Get(newId);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public bool Delete(int idToDelete)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM parking_spots " +
                                                    "WHERE parking_spot_id=@parkingspotid", conn);
                    cmd.Parameters.AddWithValue("@parkingspotid", idToDelete);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 1)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public ParkingSpot Get(int id)
        {
            ParkingSpot ps = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parking_spot_id, is_occupied " +
                                                    "FROM parking_spots " +
                                                    "WHERE parking_spot_id = @parkingspotid", conn);
                    cmd.Parameters.AddWithValue("@parkingspotid", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        ps = GetParkingSpotFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return ps;
        }

        public List<ParkingSpot> List()
        {
            List<ParkingSpot> parkingSpots = new List<ParkingSpot>();
            ParkingSpot ps = new ParkingSpot();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parking_spot_id, is_occupied " +
                                                    "FROM parking_spots " +
                                                    "ORDER BY parking_spot_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        ps = GetParkingSpotFromReader(reader);
                        parkingSpots.Add(ps);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return parkingSpots;
        }

        public ParkingSpot Update(int idToUpdate, ParkingSpot parkingSpotToUpdate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE parking_spots " +
                                                    "SET is_occupied = @isoccupied" +
                                                    "WHERE parking_spot_id = @parkingspotid", conn);
                    cmd.Parameters.AddWithValue("@parkingspotid", parkingSpotToUpdate.ParkingSpotId);
                    cmd.Parameters.AddWithValue("@isoccupied", parkingSpotToUpdate.IsOccupied);
                    cmd.ExecuteNonQuery();

                    return Get(parkingSpotToUpdate.ParkingSpotId);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private ParkingSpot GetParkingSpotFromReader(SqlDataReader reader)
        {
            ParkingSpot ps = new ParkingSpot()
            {
                ParkingSpotId = Convert.ToInt32(reader["parking_spot_id"]),
                IsOccupied = Convert.ToBoolean(reader["is_occupied"])
            };

            return ps;
        }
    }
}
