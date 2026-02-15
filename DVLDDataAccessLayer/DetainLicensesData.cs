using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class DetainLicensesData
    {
        public static DetainLicenseDTO GetDetainByLicenseID(int licenseID)
        {
            DetainLicenseDTO detain = null;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", licenseID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    detain = new DetainLicenseDTO
                    {
                        DetainID = (int)reader["DetainID"],
                        LicenseID = (int)reader["LicenseID"],
                        DetainDate = (DateTime)reader["DetainDate"],
                        FineFees = (decimal)reader["FineFees"],
                        CreatedByUserID = (int)reader["CreatedByUserID"],
                        IsReleased = (bool)reader["IsReleased"],
                        ReleaseDate = reader["ReleaseDate"] == DBNull.Value ? DateTime.MaxValue : (DateTime)reader["ReleaseDate"],
                        ReleasedByUserID = reader["ReleasedByUserID"] == DBNull.Value ? -1 : (int)reader["ReleasedByUserID"],
                        ReleaseApplicationID = reader["ReleaseApplicationID"] == DBNull.Value ? -1 : (int)reader["ReleaseApplicationID"]
                    };
                }

                reader.Close();
            }

            return detain;
        }
        public static bool IsLicenseDetained(int licenseID)
        {
            bool isDetained = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses 
                     WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    isDetained = true;

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return isDetained;
        }
        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM DetainedLicenses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    dt.Load(reader);

                reader.Close();
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static int AddNewDetain(DetainLicenseDTO detain)
        {
            int detainID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
INSERT INTO DetainedLicenses
(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
VALUES
(@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID);
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", detain.LicenseID);
            command.Parameters.AddWithValue("@DetainDate", detain.DetainDate);
            command.Parameters.AddWithValue("@FineFees", detain.FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", detain.CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", detain.IsReleased);
            if(detain.ReleaseDate==DateTime.MaxValue)
            {
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate",detain.ReleaseDate);
            }

            if (detain.ReleasedByUserID == -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", detain.ReleasedByUserID);
            }
            if (detain.ReleaseApplicationID == -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", detain.ReleaseApplicationID);
            }

           

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                    detainID = id;
            }
            finally
            {
                connection.Close();
            }

            return detainID;
        }
        public static bool ReleaseDetainedLicense(
       int licenseID,
       DateTime releaseDate,
       int releasedByUserID,
       int releaseApplicationID)
        {
            int rows = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"
UPDATE DetainedLicenses SET
IsReleased = 1,
ReleaseDate = @ReleaseDate,
ReleasedByUserID = @ReleasedByUserID,
ReleaseApplicationID = @ReleaseApplicationID
WHERE LicenseID = @LicenseID AND IsReleased = 0";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", licenseID);
            command.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);

            try
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            return rows > 0;
        }


    }
}
