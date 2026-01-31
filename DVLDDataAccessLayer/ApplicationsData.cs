using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{  
public class ApplicationsData
    {
        public static bool GetApplication(int  applicationID,ref int applicantPersonlID,ref DateTime applicationDate,ref int applicationTypeID,ref byte applicationStatus, ref DateTime applicationLastStatusDate,ref decimal paidFees, ref int createdByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from Applications where applicationID =@applicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    applicantPersonlID = (int)reader["applicantPersonlID"];
                    applicationID= (int)reader["applicationID"];
                    applicationDate = (DateTime)reader["applicationDate"];
                    applicationTypeID = (int)reader["applicationTypeID"];
                    applicationStatus = (byte)reader["applicationStatus"];
                    applicationLastStatusDate = (DateTime)reader["applicationLastStatusDate"];
                    paidFees = (decimal)reader["paidFees"];

                    createdByUserID = (int)reader["createdByUserID"];




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
        //public static bool GetUserByUserName(ref int UserID, string UserName, ref int PersonID, ref bool IsActive, ref string Password)
        //{
        //    bool isFound = false;
        //    SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
        //    string query = "select * from Users where UserName =@UserName";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@UserName", UserName);
        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            isFound = true;
        //            UserID = (int)reader["UserID"];
        //            PersonID = (int)reader["PersonID"];
        //            Password = (string)reader["Password"];

        //            IsActive = (bool)reader["IsActive"];




        //        }
        //        else
        //        {
        //            isFound = false;
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception E)
        //    {
        //        Console.WriteLine(E.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return isFound;

        //}
//        public static DataTable GetAllApplications()
//        {
//            DataTable dt = new DataTable();
//            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
//            //string query = "\r\nSELECT [PersonID]\r\n      ,[NationalNo]\r\n      ,[FirstName]\r\n      ,[SecondName]\r\n      ,[ThirdName]\r\n      ,[LastName]\r\n      ,[DateOfBirth]\r\n      ,[Gendor],\r\n\t  case \r\n\t  when Gendor=0 Then 'MALE'\r\n\t  ELSE \r\n\t  'FEMALE' END AS GendorCaption\r\n      ,[Address]\r\n      ,[Phone]\r\n      ,[Email]\r\n      ,[NationalityCountryID]\r\n      ,[ImagePath]\r\n  FROM [dbo].[People]\r\n";
//            string query = @"select UserID , People.PersonID, CONCAT(
//        People.FirstName, ' ',
//        People.SecondName, ' ',
//        People.ThirdName, ' ',
//        People.LastName
//    ) AS FullName,Users.UserName ,Users.IsActive from users inner join People on Users.PersonID =People.PersonID;
//";

//            SqlCommand command = new SqlCommand(query, connection);

//            try
//            {
//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();
//                if (reader.Read())

//                {
//                    dt.Load(reader);
//                }
//                reader.Close();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                connection.Close();
//            }
//            return dt;

//        }

        public static int AddNewApplication( int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime applicationLastStatusDate, decimal paidFees, int createdByUserID)
        {
            int  applicationID= -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Applications]
           ([ApplicantPersonID]
           ,[ApplicationDate]
           ,[ApplicationTypeID]
           ,[ApplicationStatus]
           ,[LastStatusDate]
           ,[PaidFees]
           ,[CreatedByUserID])
     VALUES
           (@ApplicantPersonID
           ,@ApplicationDate
           ,@ApplicationTypeID
           ,@ApplicationStatus
           ,@LastStatusDate
           ,@PaidFees
           ,@CreatedByUserID);
 select SCOPE_IDENTITY();  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", applicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", applicationLastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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
        public static bool UpdateApplicaton(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime applicationLastStatusDate, decimal paidFees, int createdByUserID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Applications
                     (ApplicantPersonID,
                      ApplicationDate,
                      ApplicationTypeID,
                      ApplicationStatus,
                      LastStatusDate,
                      PaidFees,
                      CreatedByUserID)
                     VALUES
                     (@ApplicantPersonID,
                      @ApplicationDate,
                      @ApplicationTypeID,
                      @ApplicationStatus,
                      @LastStatusDate,
                      @PaidFees,
                      @CreatedByUserID)";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", applicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", applicationLastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);



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
        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @" Delete From Applications
               WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
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
        public static bool UpdateStatus(int ApplicationID,short NewStatus)
        {
            int rowsaffected = 0;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "Update Applications set ApplicationStatus=@NewStatus ,LastStatusDate=@LastStatusDate where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);


            try
            {
                connection.Open();
                rowsaffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
             
            }
            finally
            {
                connection.Close();
            }

            return (rowsaffected>0);
        }
        public static bool IsApplicationExist(int ApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Applications WHERE ApplicationID= @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT ActiveApplicationID=ApplicationID FROM Applications WHERE ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }
    }
}
