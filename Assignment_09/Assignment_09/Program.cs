using System;
using System.Data;
using System.Data.SqlClient;
namespace Assignment_09
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string conString = "server=LAPTOP-48IGP581;database=OrderDB;trusted_connection=true;";

        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conString);
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "pro_PlaceOrder";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                Console.WriteLine("Input Customer ID: ");
                cmd.Parameters.AddWithValue("@cid", int.Parse(Console.ReadLine()));
                Console.WriteLine("Input Total Amount: ");
                cmd.Parameters.AddWithValue("@totalamt", double.Parse(Console.ReadLine()));

                int display = (int)cmd.ExecuteScalar();
                if (display >= 1)
                {
                    Console.WriteLine("Order has been placed successfully!");
                }
                else
                {
                    Console.WriteLine("Order couldn't be placed");
                }
            }
            catch (Exception ex) { Console.WriteLine("Error!!" + ex.Message); }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
