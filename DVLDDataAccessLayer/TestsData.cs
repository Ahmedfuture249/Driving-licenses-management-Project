using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class TestsData
    {
        public static int TakeTest(int TestAppointmentID,bool TestResult,string Notes,int CreatedByUserID)
        {

            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsPeopleDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [dbo].[Tests]
      ([TestAppointmentID]
      ,[TestResult]
      ,[Notes]
      ,[CreatedByUserID])
VALUES
      (@TestAppointmentID
      ,@TestResult
      ,@Notes
      ,@CreatedByUserID);

SELECT SCOPE_IDENTITY();"

;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;
        }

    }
}
