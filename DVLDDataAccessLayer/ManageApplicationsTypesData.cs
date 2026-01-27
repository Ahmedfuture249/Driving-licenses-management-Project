using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class ManageApplicationsTypesData
    {
        public static bool GetCountryApplicationTypeByID(int ID, ref string Title,ref decimal Fees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    Title = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];


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
        public static DataTable GetAllApplicationsTypes()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes";

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
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            int rowsaffected = 0;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"
UPDATE ApplicationTypes SET
    [ApplicationTypeTitle] = @ApplicationTypeTitle,
    [ApplicationFees] = @ApplicationFees
    WHERE ApplicationTypeID= @ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationTypeFees);
           


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
