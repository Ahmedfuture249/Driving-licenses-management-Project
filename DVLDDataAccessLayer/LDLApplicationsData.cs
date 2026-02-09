using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDDataAccessLayer
{
   public class LDLApplicationsData
    {
        public static DataTable GetAllTestLDLApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }
        public static bool GetLDLApplicationsByID(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicationID= (int)reader["ApplicationID"];
                    LicenseClassID= (int)reader["LicenseClassID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID ,int LicenseClass)
        {
            int LocalDrivingLicenseApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
INSERT INTO LocalDrivingLicenseApplications
(
    [ApplicationID],
    [LicenseClassID]
    
)
VALUES
(
    @ApplicationID,
    @LicenseClass); select SCOPE_IDENTITY();  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
          
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LocalDrivingLicenseApplicationID;
        }
        public static bool UpdateLocalDrivingLicenseApplicatioN(int LocalDrivingLicenseApplicationID, int ApplicationID , int LicenseClass)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
UPDATE LocalDrivingLicenseApplications SET
    
    [Password] = @ApplicationID,
    [LicenseClass] = @LicenseClass,
    [PersonID] = @PersonID
    WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@UserName", LicenseClass);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            
            


            try
            {
                connection.Open();

                rowsaffected = command.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return (rowsaffected != 0);
        }
        public static bool DeleteLocalDrivingLicenseApplication(int ID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @" Delete  LocalDrivingLicenseApplications
               WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);
            try
            {
                connection.Open();

                rowsaffected = command.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return (rowsaffected != 0);

        }
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool Result = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }
    }
}
