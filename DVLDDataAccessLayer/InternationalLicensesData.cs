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
    public class InternationalLicensesData
    {
        public static InternationalLicenseDTO GetInternationalLicenseByID(int internationalLicenseID)
        {
            InternationalLicenseDTO license = null;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", internationalLicenseID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    license = new InternationalLicenseDTO
                    {
                        InternationalLicenseID = (int)reader["InternationalLicenseID"],
                        ApplicationID = (int)reader["ApplicationID"],
                        DriverID = (int)reader["DriverID"],
                        IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"],
                        IssueDate = (DateTime)reader["IssueDate"],
                        ExpirationDate = (DateTime)reader["ExpirationDate"],
                        IsActive = (bool)reader["IsActive"],
                        CreatedByUserID = (int)reader["CreatedByUserID"]
                    };
                }

                reader.Close();
            }

            return license;
        }
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM InternationalLicenses";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    dt.Load(reader);

                reader.Close();
            }

            return dt;
        }
        public static int AddNewInternationalLicense(InternationalLicenseDTO license)
        {
            int id = -1;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = @"
INSERT INTO InternationalLicenses
(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
VALUES
(@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", license.DriverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", license.IssuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                command.Parameters.AddWithValue("@IsActive", license.IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    id = insertedID;
            }

            return id;
        }
            public static bool IsLicenseExpired(int id)
    {
        bool expired = false;

        using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
        {
            string query = "SELECT 1 FROM InternationalLicenses WHERE InternationalLicenseID=@ID AND ExpirationDate < GETDATE()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
                expired = true;

            reader.Close();
        }

        return expired;
    }

    }
}
