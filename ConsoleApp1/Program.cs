namespace ConsoleApp1
{
    using System;
    using System.Data.SqlClient;



    class Program
        {
            static void Main(string[] args)
            {
            // Step 2: Create a connection string
            string connectionString = "Data Source=finaccess-engg-01.database.windows.net;Initial Catalog=FinAccess_Mercury;User ID=fuaeng;Password=FUa_!@#$%^&";
            

            // Step 3: Establish a connection
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute SQL queries or operations here
                        // For example, you can retrieve data from the table
                        string query = "SELECT * FROM userprofile";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Access data from each row
                                    int personoelNumber = reader.GetInt32(0);
                                    int  UserProfileId = reader.GetInt32(1);
                                    string UserAlias = reader.GetString(2); ///,objectId:{objectId}
                                //Guid objectId = reader.GetGuid(3);
                                string UserEmail = reader.GetString(4);
                                string UserPin = reader.GetString(5);
                                string UserDisplayName = reader.GetString(6);
                                // ... continue accessing other columns
                                Console.WriteLine($"personoelNumber: {personoelNumber}, UserProfileId: {UserProfileId},UserAlias:{UserAlias},UserEmail:{UserEmail},UserPin:{UserPin},UserDisplayName:{UserDisplayName}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {
                        // Close the connection
                        connection.Close();
                    }
                }
            }
        }
    

}
