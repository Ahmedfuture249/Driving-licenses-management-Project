using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
   public class TestAppointmentsData
    {
        public static bool GetTestAppointment(int TestAppointmentID,ref int TestTypeID,ref int LocalDrivingLicenseApplicationID
            ,ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked,
            ref int RetakeTestApplicatonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from TestAppointments where TestAppointmentID =@TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    //if((int)reader["RetakeTestApplicatonID"]==null)
                    //{
                    //    RetakeTestApplicatonID = 0;
                    //}
                    //RetakeTestApplicatonID = (int)reader["RetakeTestApplicatonID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    IsLocked = (bool)reader["IsLocked"];                  
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];




                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }
        public static bool GetTestAppointmentByLDLApplication(ref int TestAppointmentID, ref int TestTypeID,  int LocalDrivingLicenseApplicationID
         , ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked,
         ref int RetakeTestApplicatonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from TestAppointments where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    //RetakeTestApplicatonID = (int)reader["RetakeTestApplicatonID"];
                    TestTypeID = (int)reader["TestTypeID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    IsLocked = (bool)reader["IsLocked"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];




                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }
        public static DataTable GetAllTestAppointments(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT TestAppointmentID, AppointmentDate,PaidFees, IsLocked
                        FROM TestAppointments
                        WHERE  
                        (TestTypeID = @TestTypeID) 
                        AND (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                        order by TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }
        
        public static bool IsApplicantHasAnActiveAppointmentForThisTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"select * from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID;

";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())

                {
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;


        }
        public static int AddTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID
            , DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked,
            int RetakeTestApplicatonID)
        {
            int applicationID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[TestAppointments]
      ([TestTypeID]
      ,[LocalDrivingLicenseApplicationID]
      ,[AppointmentDate]
      ,[PaidFees]
      ,[CreatedByUserID]
      ,[IsLocked]
      ,[RetakeTestApplicationID])
VALUES
      (@TestTypeID
      ,@LocalDrivingLicenseApplicationID
      ,@AppointmentDate
      ,@PaidFees
      ,@CreatedByUserID
      ,@IsLocked
      ,@RetakeTestApplicationID);

SELECT SCOPE_IDENTITY();"
;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
            
            if (RetakeTestApplicatonID == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicatonID);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    applicationID = insertedID;
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


            return applicationID;
        }
        public static int AddTestAppointmentWithRtakeTestID(int TestTypeID, int LocalDrivingLicenseApplicationID
            , DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked,
            int RetakeTestApplicatonID)
        {
            int applicationID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[TestAppointments]
      ([TestTypeID]
      ,[LocalDrivingLicenseApplicationID]
      ,[AppointmentDate]
      ,[PaidFees]
      ,[CreatedByUserID]
      ,[IsLocked]
      ,[RetakeTestApplicationID])
VALUES
      (@TestTypeID
      ,@LocalDrivingLicenseApplicationID
      ,@AppointmentDate
      ,@PaidFees
      ,@CreatedByUserID
      ,@IsLocked
    ;

SELECT SCOPE_IDENTITY();"
;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);
           

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    applicationID = insertedID;
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


            return applicationID;
        }
        public static bool IsApplicantAlreadySatForThisTestAndPass(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"select * from TestAppointments where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID and isLocked=1;

";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())

                {
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;


        }
        public static bool IsApplicantAlreadySatForThisTestAndFaild(int TestAppointmentID, int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"select TestAppointments.TestAppointmentID from TestAppointments Inner JOIN Tests ON
   TestAppointments.TestAppointmentID =Tests.TestAppointmentID 
   where Tests.TestResult=0 and TestAppointments.TestTypeID=@TestTypeID and TestAppointments.TestAppointmentID=@TestAppointmentID;

";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())

                {
                    IsFound = true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;


        }
        public static bool UpdateTestAppointmentDate(int TestAppointmentID,  DateTime TestAppointmentDate)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments
                    (AppointmentDate)
                    VALUES
                    (@AppointmentDate) where TestAppointmentID=TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@AppointmentDate", TestAppointmentDate);
          


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
        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @" Delete TestAppointments 
                               where TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        

    }
}
