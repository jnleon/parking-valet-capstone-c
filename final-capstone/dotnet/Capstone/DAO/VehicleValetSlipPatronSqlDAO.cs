using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class VehicleValetSlipPatronSqlDAO : IVehicleValetSlipPatronDAO
    {
            private readonly string connectionString;

            public VehicleValetSlipPatronSqlDAO(string dbConnectionString)
            {
                connectionString = dbConnectionString;
            }

            public List<VehicleValetSlipPatron> List()
        {

            List<VehicleValetSlipPatron> vlist = new List<VehicleValetSlipPatron>();
            
            VehicleValetSlipPatron v = null;


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"SELECT ticket_id, valet_id, valet_slips.license_plate AS license_plate, 
                                                    parking_spot_id, time_in, time_out, amount_owed, 
                                                    parking_statuses.parking_status AS parking_status,
                                                    vehicle_make, vehicle_model, vehicle_color, first_name, 
                                                    last_name, phone_number, email_address
                                                    FROM valet_slips
                                                    INNER JOIN vehicles ON vehicles.license_plate = valet_slips.license_plate
                                                    INNER JOIN patrons ON vehicles.patron_id = patrons.patron_id
                                                    INNER JOIN parking_statuses ON parking_statuses.parking_status_id = valet_slips.parking_status_id
                                                    WHERE parking_statuses.parking_status_id != 3 AND parking_statuses.parking_status_id != 5", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        v = GetEverythingFromReader(reader);
                        vlist.Add(v);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return vlist;
        }

        private VehicleValetSlipPatron GetEverythingFromReader(SqlDataReader reader)
        {
            VehicleValetSlipPatron p = new VehicleValetSlipPatron()
            {
                TicketId = Convert.ToInt32(reader["ticket_id"]),
                ValetId = Convert.ToInt32(reader["valet_id"]),
                LicensePlate = Convert.ToString(reader["license_plate"]),
                TimeIn = Convert.ToDateTime(reader["time_in"]),
                TimeOut = Convert.ToDateTime(reader["time_out"]),
                AmountOwed = Convert.ToDecimal(reader["amount_owed"]),
                ParkingStatus = Convert.ToString(reader["parking_status"]),
                VehicleMake = Convert.ToString(reader["vehicle_make"]),
                VehicleModel = Convert.ToString(reader["vehicle_model"]),
                VehicleColor = Convert.ToString(reader["vehicle_color"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                PhoneNumber = Convert.ToString(reader["phone_number"]),
                EmailAddress = Convert.ToString(reader["email_address"])
            };
            if (reader["parking_spot_id"] == DBNull.Value)
            {
                p.ParkingSpotId = 0;
            }
            else
            {
                p.ParkingSpotId = Convert.ToInt32(reader["parking_spot_id"]);
            }

            return p;
        }
    }
}
