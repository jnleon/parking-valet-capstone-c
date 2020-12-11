using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Capstone.DAO
{
    public class VehicleSqlDAO : IVehicleDAO
    {
        private readonly string connectionString;
        public VehicleSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public Vehicle Create(NewVehicle vehicleToCreate, int valetId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO vehicles " +
                                                    "(vehicle_make, vehicle_model, vehicle_color, license_plate, patron_id) " +
                                                    "VALUES (@vehicle_make, @vehicle_model, @vehicle_color, @license_plate, " +
                                                    "(SELECT patron_id FROM patrons WHERE email_address like @email_address))"
                                                    , conn);
                    cmd.Parameters.AddWithValue("@vehicle_make", vehicleToCreate.VehicleMake);
                    cmd.Parameters.AddWithValue("@vehicle_model", vehicleToCreate.VehicleModel);
                    cmd.Parameters.AddWithValue("@vehicle_color", vehicleToCreate.VehicleColor);
                    cmd.Parameters.AddWithValue("@license_plate", vehicleToCreate.LicensePlate);
                    cmd.Parameters.AddWithValue("@email_address", vehicleToCreate.PatronEmail);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO valet_slips " +
                                         "(valet_id, license_plate, date, time_in, time_out, amount_owed, " +
                                         "parking_spot_id, parking_status_id) " +
                                         "VALUES (@valet_id, @license_plate, GETDATE(), GETDATE(), '1753-1-1', 0, NULL, " +
                                         "(SELECT parking_status_id FROM parking_statuses WHERE parking_status='Spot Requested'))", conn);
                    cmd.Parameters.AddWithValue("@valet_id", valetId);
                    cmd.Parameters.AddWithValue("@license_plate", vehicleToCreate.LicensePlate);
                    cmd.ExecuteNonQuery();

                    return Get(vehicleToCreate.LicensePlate);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public Vehicle Get(string licensePlate)
        {
            Vehicle v = new Vehicle();
      
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT license_plate, vehicle_make, vehicle_model, vehicle_color, patron_id " +
                                                    "FROM vehicles " +
                                                    "WHERE license_plate = @licensePlate", conn);
                    cmd.Parameters.AddWithValue("@licensePlate", licensePlate);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        v = GetVehicleFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return v;
        }

        public List<Vehicle> List()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            Vehicle v = new Vehicle();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT license_plate, vehicle_make, vehicle_model, vehicle_color, patron_id " +
                                                    "FROM vehicles", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        v = GetVehicleFromReader(reader);
                        vehicles.Add(v);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return vehicles;
        }

        private Vehicle GetVehicleFromReader(SqlDataReader reader)
        {
            Vehicle v = new Vehicle()
            {
                LicensePlate = Convert.ToString(reader["license_plate"]),
                VehicleMake = Convert.ToString(reader["vehicle_make"]),
                VehicleModel = Convert.ToString(reader["vehicle_model"]),
                VehicleColor = Convert.ToString(reader["vehicle_color"]),
                PatronId = Convert.ToInt32(reader["patron_id"])
            };

            return v;
        }
    }
}
