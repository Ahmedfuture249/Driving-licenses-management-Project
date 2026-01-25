using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class UsersData
    {
        public static bool GetUser(int UserID, ref string UserName, ref int PersonID, ref bool IsActive,ref string Password)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from Users where UserID =@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    IsActive = (bool)reader["IsActive"];
                   



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
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            //string query = "\r\nSELECT [PersonID]\r\n      ,[NationalNo]\r\n      ,[FirstName]\r\n      ,[SecondName]\r\n      ,[ThirdName]\r\n      ,[LastName]\r\n      ,[DateOfBirth]\r\n      ,[Gendor],\r\n\t  case \r\n\t  when Gendor=0 Then 'MALE'\r\n\t  ELSE \r\n\t  'FEMALE' END AS GendorCaption\r\n      ,[Address]\r\n      ,[Phone]\r\n      ,[Email]\r\n      ,[NationalityCountryID]\r\n      ,[ImagePath]\r\n  FROM [dbo].[People]\r\n";
            string query = @"select UserID , People.PersonID, CONCAT(
        People.FirstName, ' ',
        People.SecondName, ' ',
        People.ThirdName, ' ',
        People.LastName
    ) AS FullName,Users.UserName ,Users.IsActive from users inner join People on Users.PersonID =People.PersonID;
";

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

        public static int AddNewUser(string UserName, string Password, bool IsActive,
    int PersonID)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
INSERT INTO users
(
    [PersonID],
    [UserName],
    [Password],
    [IsActive]
)
VALUES
(
    @PersonID,
    @UserName,
    @Password,
    @IsActive ); select SCOPE_IDENTITY();  ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
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


            return UserID;
         }
        public static bool UpdateUser(int UserID ,string UserName, string Password, bool IsActive,
    int PersonID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
UPDATE Users SET
    [UserName] = @UserName,
    [Password] = @Password,
    [IsActive] = @IsActive,
    [PersonID] = @PersonID
    WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);


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
        public static bool DeleteUser(int UserID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @" Delete From Users
               WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
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
