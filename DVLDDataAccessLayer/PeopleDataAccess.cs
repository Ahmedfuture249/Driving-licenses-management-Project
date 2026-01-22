using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DVLDDataAccessLayer
{
    public class PeopleDataAccess
    {
        public static bool GetPerson( int  PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
        ref int NationalityCountryID, ref string NationalNo, ref string Email, ref string Address, ref int Gendor
            , ref int CountryID, ref string ImagePath, ref DateTime DateOfBirth, ref string Phone,ref string LastName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from people where PersonID =@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    //  PersonID = (int)reader["PersonID"];

                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                   // CountryID = (int)reader["CountryID"];
                    //ThirdName = (string)reader["ThirdName"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    NationalNo = (string)reader["NationalNo"];
                    Gendor = (int)reader["Gendor"];
                    ImagePath = (string)reader["ImagePath"];
                    // ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


                    ImagePath = "adkjd";
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }
                    
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    NationalNo = (string)reader["NationalNo"]; 
                    Gendor = (int)reader["Gendor"];
                  
                    
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch(Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                connection.Close();
            }
            return isFound;

        }
        public static bool GetPersonNationalNo(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName,
      ref int NationalityCountryID, string NationalNo, ref string Email, ref string Address, ref int Gendor
          , ref int CountryID, ref string ImagePath, ref DateTime DateOfBirth, ref string Phone, ref string LastName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from people where NationalNo =@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //  PersonID = (int)reader["PersonID"];

                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    // CountryID = (int)reader["CountryID"];
                    //ThirdName = (string)reader["ThirdName"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    //NationalNo = (string)reader["NationalNo"];
                    Gendor = (int)reader["Gendor"];

                    //ImagePath: allows null in database so we should handle null
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    
                    


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
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            //string query = "\r\nSELECT [PersonID]\r\n      ,[NationalNo]\r\n      ,[FirstName]\r\n      ,[SecondName]\r\n      ,[ThirdName]\r\n      ,[LastName]\r\n      ,[DateOfBirth]\r\n      ,[Gendor],\r\n\t  case \r\n\t  when Gendor=0 Then 'MALE'\r\n\t  ELSE \r\n\t  'FEMALE' END AS GendorCaption\r\n      ,[Address]\r\n      ,[Phone]\r\n      ,[Email]\r\n      ,[NationalityCountryID]\r\n      ,[ImagePath]\r\n  FROM [dbo].[People]\r\n";
            string query = @"
SELECT
    PersonID,
    NationalNo,
    FirstName,
    SecondName,
    ThirdName,
    LastName,
    DateOfBirth,
    Gendor,
    CASE 
        WHEN Gendor = 0 THEN 'MALE'
        ELSE 'FEMALE'
    END AS GendorCaption,
    Address,
    Phone,
    Email,
    NationalityCountryID,
    ImagePath
FROM dbo.People;
";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())

                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
            
        }

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName,
            int NationalityCountryID, string NationalNo, int Gendor,
        string Email, string Phone, string Address, DateTime DateOfBirth,
           string ImagePath, string LastName)
        {
            int PersonID=-1; 
           SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
INSERT INTO [dbo].[People]
(
    [NationalNo],
    [FirstName],
    [SecondName],
    [ThirdName],
    [LastName],
    [DateOfBirth],
    [Gendor],
    [Address],
    [Phone],
    [Email],
    [NationalityCountryID],
    [ImagePath]
)
VALUES
(
    @NationalNo,
    @FirstName,
    @SecondName,
    @ThirdName,
    @LastName,
    @DateOfBirth,
    @Gendor,
    @Address,
    @Phone,
    @Email,
    @NationalityCountryID,
    @ImagePath
);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
           // command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "" )
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
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


            return PersonID;
        }
        public static bool UpdatePerson(int PersonID,string FirstName, string SecondName, string ThirdName,
            int NationalityCountryID, string NationalNo, int Gendor,
        string Email, string Phone, string Address, DateTime DateOfBirth,
            string ImagePath, string LastName)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
UPDATE People SET
    [NationalNo] = @NationalNo,
    [FirstName] = @FirstName,
    [SecondName] = @SecondName,
    [ThirdName] = @ThirdName,
    [LastName] = @LastName,
    [DateOfBirth] = @DateOfBirth,
    [Gendor] = @Gendor,
    [Address] = @Address,
    [Phone] = @Phone,
    [Email] = @Email,
    [NationalityCountryID] = @NationalityCountryID,
    [ImagePath] = @ImagePath
WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
         //   command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "" && ImagePath != null)
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                rowsaffected= command.ExecuteNonQuery();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return (rowsaffected!=0);
        }
        public static bool DeletePerson(int PersonID)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @" Delete From People
               WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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
        public static bool IsPersonExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM people WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", ID);

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

        public static bool IsPersonExist(string  NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM people WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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
    }
    public class clsPeopleDataAccessSettings
    {
        public static string ConnectionString = "server=.;Database = DVLD.bak; user = sa;password=123456;";

    }
}
