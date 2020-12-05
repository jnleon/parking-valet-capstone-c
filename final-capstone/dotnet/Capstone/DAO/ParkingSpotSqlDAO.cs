using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public bool Delete(string idToDelete)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Get(string id)
        {
            throw new NotImplementedException();
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

                    SqlCommand cmd = new SqlCommand("SELECT parking_spot_id, is_occupied FROM parking_spots ORDER BY parking_spot_id", conn);
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

        public ParkingSpot Update(ParkingSpot parkingSpotToCreate)
        {
            throw new NotImplementedException();
        }

        private ParkingSpot GetParkingSpotFromReader(SqlDataReader reader)
        {
            ParkingSpot ps = new ParkingSpot()
            {
                ParkingSpotId = Convert.ToString(reader["parking_spot_id"]),
                IsOccupied = Convert.ToBoolean(reader["is_occupied"])
            };

            return ps;
        }
    }
}
