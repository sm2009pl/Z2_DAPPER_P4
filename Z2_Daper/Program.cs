using System;
using Dapper;
using System.Data.SqlClient;
namespace Z2_DAPPER
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using var connection = new SqlConnection(connectionString);
            var db = new DB();
            db.Select(connection);

            var region = new Region()
            {
                RegionDescription = "dapper obiekt",
                RegionId = 101
            };


            db.Delete(connection, 101);
            db.Delete(connection, 13);
            db.Delete(connection, 10);

            db.Insert(connection, region);
            Console.ReadLine();
            db.Insert(connection, 13, "Bielsko");
            Console.ReadLine();
            db.Update(connection, 13, "Andrychow");
            Console.ReadLine();
            db.Delete(connection, 101);
            Console.ReadLine();
            db.Delete(connection, 13);
            Console.ReadLine();
            db.Delete(connection, 10);
            Console.ReadLine();
            db.SelectOrder(connection, 10290);
            
        }
    }
}