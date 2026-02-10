using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
  public  class LicenseClassesData
    {
        public static DataTable GetAllLicenseClasses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses";

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
        public static bool GetLicensClassByLicensClassName(ref int LicensClassID, string ClassName, ref string LicensClassDescription, ref int MinimumAllowedAGE, ref decimal LicensClassFees,ref int DefaultValdityLength)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from LicenseClasses where ClassName =@ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LicensClassID = (int)reader["LicenseClassID"];
                    LicensClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAGE = (int)reader["MinimumAllowedAge"];

                    LicensClassFees = (decimal)reader["ClassFees"];

                    DefaultValdityLength = (int)reader["DefaultValidityLength"];


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
        public static bool GetLicensClassByLicensClassID(int LicensClassID, ref string ClassName, ref string LicensClassDescription, ref int MinimumAllowedAGE, ref decimal LicensClassFees,ref int DefaultValdityLength)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = "select * from LicenseClasses where LicenseClassID =@LicensClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicensClassID", LicensClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    LicensClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAGE = Convert.ToInt32(reader["MinimumAllowedAge"]);

                    LicensClassFees = (decimal)reader["ClassFees"];
                    DefaultValdityLength = Convert.ToInt32( reader["DefaultValidityLength"]);





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
    
}
}
