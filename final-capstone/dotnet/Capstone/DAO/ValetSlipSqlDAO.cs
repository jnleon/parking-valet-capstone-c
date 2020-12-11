using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class ValetSlipSqlDAO : IValetSlipDAO
    {
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
    }
}
