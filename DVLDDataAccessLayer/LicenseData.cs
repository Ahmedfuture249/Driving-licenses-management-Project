using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
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
                            IssueReason = (int)reader["IssueReason"],
                            CreatedByUserID = (int)reader["CreatedByUserID"]
                        };
                    }

                    reader.Close();
                }

                return license;
            }
        public static LicenseDTO GetLicenseByApplicationID(int ApplicationID)
        {
            LicenseDTO license = null;

            using (SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    license = new LicenseDTO
                    {
                        LicenseID = (int)reader["LicenseID"],
                        ApplicationID = (int)reader["ApplicationID"],
                        DriverID = (int)reader["DriverID"],
                        LicenseClassID = (int)reader["LicenseClass"],
                        IssueDate = (DateTime)reader["IssueDate"],
                        ExpirationDate = (DateTime)reader["ExpirationDate"],
                        Notes = reader["Notes"] == DBNull.Value ? "No Notes" : reader["Notes"].ToString(),
                        PaidFees = (decimal)reader["PaidFees"],
                        IsActive = (bool)reader["IsActive"],
                        IssueReason = Convert.ToInt32(reader["IssueReason"]),
                        CreatedByUserID = (int)reader["CreatedByUserID"]
                        
                      



                    }
                ;
                }

                reader.Close();
            }

            return license;
        }
        public static DataTable GetAllLicenses()
            {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

                
                    string query = "SELECT * FROM Licenses";
                    SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) {

                }
            finally
            {
                connection.Close();
            }

                return dt;
            }

            public static int AddNewLicense(LicenseDTO license)
            {
                int licenseID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
               
                    string query = @"
INSERT INTO Licenses
(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
VALUES
(@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ApplicationID", license.ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", license.DriverID);
                    command.Parameters.AddWithValue("@LicenseClassID", license.LicenseClassID);
                    command.Parameters.AddWithValue("@IssueDate", license.IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", license.ExpirationDate);
                    command.Parameters.AddWithValue("@Notes", license.Notes);
                    command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (int)license.IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", license.CreatedByUserID);
            try
            {

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                    licenseID = id;
            }
            catch (Exception ex) 
            {
            }
            finally
            {
                connection.Close();
            }

                return licenseID;
            }

            public static bool UpdateLicense(LicenseDTO license)
            {
                int rows = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
                
                    string query = @"
UPDATE Licenses SET
ApplicationID=@ApplicationID,
DriverID=@DriverID,
LicenseClass=@LicenseClassID,
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
                    command.Parameters.AddWithValue("@Notes", license.Notes);
                    command.Parameters.AddWithValue("@PaidFees", license.PaidFees);
                    command.Parameters.AddWithValue("@IsActive", license.IsActive);
                    command.Parameters.AddWithValue("@IssueReason", (int)license.IssueReason);
            try  
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
            }
            catch (Exception ex) 
            { 
            }
            finally 
            { 
                connection.Close();
            }
                   
                

                return rows > 0;
            }

            public static bool DeleteLicense(int licenseID)
            {
                int rows = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
               
                 string query = "DELETE FROM Licenses WHERE LicenseID=@LicenseID";
                 SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                rows = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
                finally { connection.Close(); }

                return rows > 0;
            }

            public static bool IsLicenseExistForDriver(int driverID)
            {
                bool exists = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
               
                 string query = "SELECT 1 FROM Licenses WHERE DriverID=@DriverID";
                 SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.AddWithValue("@DriverID", driverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    exists = true;

                reader.Close();
            } catch (Exception ex) { }  
            finally { connection.Close(); }

                return exists;
            }
        

    }
}
