using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Capstone.DAO
{
    public class ValetSlipSqlDAO : IValetSlipDAO
    {
        private const decimal HOURLY_RATE = 5.00M;

        private readonly string connectionString;
        public ValetSlipSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public ValetSlip Get(int ticketId)
        {
            ValetSlip vs = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ticket_id, valet_id, license_plate, " +
                                                    "parking_spot_id, time_in, time_out, amount_owed, parking_status " +
                                                    "FROM valet_slips " +
                                                    "INNER JOIN parking_statuses ON parking_statuses.parking_status_id = valet_slips.parking_status_id " +
                                                    "WHERE ticket_id = @ticket_id", conn);
                    cmd.Parameters.AddWithValue("@ticket_id", ticketId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        vs = GetValetSlipFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return vs;
        }

        public ValetSlip GetByLicensePlate(string licensePlate)
        {
            ValetSlip vs = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ticket_id, valet_id, license_plate, " +
                                                    "parking_spot_id, time_in, time_out, amount_owed, parking_status " +
                                                    "FROM valet_slips " +
                                                    "INNER JOIN parking_statuses ON parking_statuses.parking_status_id = valet_slips.parking_status_id " +
                                                    "WHERE license_plate = @license_plate", conn);
                    cmd.Parameters.AddWithValue("@license_plate", licensePlate);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        vs = GetValetSlipFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return vs;
        }

        public List<ValetSlip> GetByValetId(int valetId)
        {
            List<ValetSlip> valetSlips = new List<ValetSlip>();
            ValetSlip vs = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT ticket_id, valet_id, license_plate, " +
                                                    "parking_spot_id, time_in, time_out, amount_owed, parking_status " +
                                                    "FROM valet_slips " +
                                                    "INNER JOIN parking_statuses ON parking_statuses.parking_status_id = valet_slips.parking_status_id " +
                                                    "WHERE valet_id = @valet_id", conn);
                    cmd.Parameters.AddWithValue("@valet_id", valetId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        vs = GetValetSlipFromReader(reader);
                        valetSlips.Add(vs);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return valetSlips;
        }

        public ValetSlip ParkVehicle(int ticketIdToUpdate, int parkingSpotId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE valet_slips " +
                                                    "SET parking_spot_id=@parking_spot_id, " +
                                                    "parking_status_id=(SELECT parking_status_id FROM parking_statuses WHERE parking_status='Parked') " +
                                                    "WHERE ticket_id=@ticket_id", conn);
                    cmd.Parameters.AddWithValue("@parking_spot_id", parkingSpotId);
                    cmd.Parameters.AddWithValue("@ticket_id", ticketIdToUpdate);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE parking_spots " +
                                         "SET is_occupied=@is_occupied " +
                                         "WHERE parking_spot_id=@parking_spot_id", conn);
                    cmd.Parameters.AddWithValue("@parking_spot_id", parkingSpotId);
                    cmd.Parameters.AddWithValue("@is_occupied", (SqlBoolean)true);

                    cmd.ExecuteNonQuery();

                    return Get(ticketIdToUpdate);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public ValetSlip PickupVehicle(int ticketIdToUpdate)
        {
            try
            {
                DateTime timeIn = GetTimeInFromValetSlip(ticketIdToUpdate);
                int parkingSpotId = GetParkingSpotIdFromValetSlip(ticketIdToUpdate);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE valet_slips " +
                                                    "SET parking_spot_id=@parking_spot_id, " +
                                                    "parking_status_id=(SELECT parking_status_id FROM parking_statuses WHERE parking_status='Picked Up'), " +
                                                    "amount_owed=@amount_owed, " +
                                                    "time_out=GETDATE() " +
                                                    "WHERE ticket_id=@ticket_id", conn);
                    cmd.Parameters.AddWithValue("@parking_spot_id", DBNull.Value);
                    cmd.Parameters.AddWithValue("@ticket_id", ticketIdToUpdate);
                    cmd.Parameters.AddWithValue("@amount_owed", (SqlMoney)CalculateAmountOwed(timeIn));
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("UPDATE parking_spots " +
                                         "SET is_occupied=@is_occupied " +
                                         "WHERE parking_spot_id=@parking_spot_id", conn);
                    cmd.Parameters.AddWithValue("@parking_spot_id", parkingSpotId);
                    cmd.Parameters.AddWithValue("@is_occupied", (SqlBoolean)false);

                    cmd.ExecuteNonQuery();

                    return Get(ticketIdToUpdate);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        public ValetSlip RequestPickupVehicle(int ticketIdToUpdate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE valet_slips " +
                                                    "SET parking_status_id=(SELECT parking_status_id FROM parking_statuses WHERE parking_status='Pickup Requested') " +
                                                    "WHERE ticket_id=@ticket_id", conn);
                    cmd.Parameters.AddWithValue("@ticket_id", ticketIdToUpdate);
                    cmd.ExecuteNonQuery();

                    return Get(ticketIdToUpdate);
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }

        private ValetSlip GetValetSlipFromReader(SqlDataReader reader)
        {

            ValetSlip vs = new ValetSlip()
            {
                TicketId = Convert.ToInt32(reader["ticket_id"]),
                ValetId = Convert.ToInt32(reader["valet_id"]),
                LicensePlate = Convert.ToString(reader["license_plate"]),
                //ParkingSpotId = Convert.ToInt32(reader["parking_spot_id"]),
                TimeIn = Convert.ToDateTime(reader["time_in"]),
                TimeOut = Convert.ToDateTime(reader["time_out"]),
                AmountOwed = Convert.ToDecimal(reader["amount_owed"]),
                ParkingStatus = Convert.ToString(reader["parking_status"])
            };
            if (reader["parking_spot_id"] == DBNull.Value)
            {
                vs.ParkingSpotId = 0;
            }
            else
            {
                vs.ParkingSpotId = Convert.ToInt32(reader["parking_spot_id"]);
            }

            return vs;
        }

        private decimal CalculateAmountOwed(DateTime timeIn)
        {
            decimal totalHours = (decimal)(DateTime.Now - timeIn).TotalHours;
            decimal amountOwed = totalHours * HOURLY_RATE;
            return amountOwed;
        }

        private int GetParkingSpotIdFromValetSlip(int ticketId)
        {
            int parkingSpotId = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT parking_spot_id FROM valet_slips WHERE ticket_id=@ticket_id", conn);
                    cmd.Parameters.AddWithValue("@ticket_id", ticketId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        parkingSpotId = Convert.ToInt32(reader["parking_spot_id"]);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return parkingSpotId;

        }

        private DateTime GetTimeInFromValetSlip(int ticketId)
        {
            DateTime timeIn = DateTime.MinValue;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT time_in FROM valet_slips WHERE ticket_id=@ticket_id", conn);
                    cmd.Parameters.AddWithValue("@ticket_id", ticketId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        timeIn = Convert.ToDateTime(reader["time_in"]);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return timeIn;
        }
    }
}
