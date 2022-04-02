namespace Sandbox
{    
    using System.Data;
    using System.Data.SqlClient;

    internal class Program
    {
        static void Main(string[] args)
        {            

            using (var sqlConnection = new SqlConnection("CONNECTION_STRING"))
            {
                sqlConnection.Open();

                SqlCommand sql_cmnd = new SqlCommand("STORED_PROCEDURE_NAME", sqlConnection);
                
                sql_cmnd.CommandType = CommandType.StoredProcedure;                
                sql_cmnd.Parameters.AddWithValue("@PARAM_NAME", PARAM_VALUE);
                
                var data = sql_cmnd.ExecuteScalar();
                
                Console.WriteLine("Data:" + data);

                sqlConnection.Close();
            }
        }
    }   
}
