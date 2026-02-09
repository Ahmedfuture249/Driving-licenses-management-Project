using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLDDataAccessLayer.LicenseData;


namespace DVLDDataAccessLayer
{
    public class LicenseData
    {
        
            public static LicenseDTO GetLicenseByID(int licenseID)
            {
                LicenseDTO license = null;

                using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        license = new LicenseDTO
                        {
                            LicenseID = (int)reader["LicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            LicenseClassID = (int)reader["LicenseClassID"],
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            Notes = reader["Notes"].ToString(),
                            PaidFees = (decimal)reader["PaidFees"],
                            IsActive = (bool)reader["IsActive"],
                            IssueReason = (enIssueReason)reader["IssueReason"],
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };
                    }

                    reader.Close();
                }

                return license;
            }

            public static List<LicenseDTO> GetAllLicenses()
            {
                List<LicenseDTO> list = new List<LicenseDTO>();

                using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Licenses";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(new LicenseDTO
                        {
                            LicenseID = (int)reader["LicenseID"],
                            ApplicationID = (int)reader["ApplicationID"],
                            DriverID = (int)reader["DriverID"],
                            LicenseClassID = (int)reader["LicenseClassID"],
                            IssueDate = (DateTime)reader["IssueDate"],
                            ExpirationDate = (DateTime)reader["ExpirationDate"],
                            Notes = reader["Notes"].ToString(),
                            PaidFees = (decimal)reader["PaidFees"],
                            IsActive = (bool)reader["IsActive"],
                            IssueReason = (enIssueReason)reader["IssueReason"],
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        });
                    }

                    reader.Close();
                }

                return list;
            }

            public static int AddNewLicense(LicenseDTO license)
            {
                int licenseID = -1;

                using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
                {
                    string query = @"
INSERT INTO Licenses
(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
VALUES
(@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", license.DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", license.LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", license.Notes ?? "");
                    command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (int)license.IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int id))
                        licenseID = id;
                }

                return licenseID;
            }

            public static bool UpdateLicense(LicenseDTO license)
            {
                int rows = 0;

                using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
                {
                    string query = @"
UPDATE Licenses SET
ApplicationID=@ApplicationID,
DriverID=@DriverID,
LicenseClassID=@LicenseClassID,
IssueDate=@IssueDate,
ExpirationDate=@ExpirationDate,
Notes=@Notes,
PaidFees=@PaidFees,
IsActive=@IsActive,
IssueReason=@IssueReason
WHERE LicenseID=@LicenseID";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@LicenseID", license.LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", license.DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", license.LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", license.Notes ?? "");
                    command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (int)license.IssueReason);

                    connection.Open();
                    rows = command.ExecuteNonQuery();
                }

                return rows > 0;
            }

            public static bool DeleteLicense(int licenseID)
            {
                int rows = 0;

                using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
                {
                    string query = "DELETE FROM Licenses WHERE LicenseID=@LicenseID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LicenseID", licenseID);

                    connection.Open();
                    rows = command.ExecuteNonQuery();
                }

                return rows > 0;
            }

            public static bool IsLicenseExistForDriver(int driverID)
            {
                bool exists = false;

                using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT 1 FROM Licenses WHERE DriverID=@DriverID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DriverID", driverID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                        exists = true;

                    reader.Close();
                }

                return exists;
            }
        

    }
}
