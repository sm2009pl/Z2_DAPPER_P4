using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dapper;


namespace Z2_DAPPER
{
    class DB
    {
        public void SelectOrder(IDbConnection connection, int id)
        {
            var sql = "SELECT * FROM Orders O " +
                "JOIN [Order Details] OD on O.OrderId = OD.OrderId " +
                "WHERE O.OrderId = @id";

            var resultOrder = default(Order);

            var result = connection.Query<Order, OrderDetails, Order>
                (
                    sql,
                    (order, orderDetails) =>
                    {
                        if (resultOrder == null)
                        {
                            resultOrder = order;
                        }
                        //var foundOrder = order;
                        resultOrder.Details.Add(orderDetails);
                        return resultOrder;
                    }
                    ,
                    new { id },
                    splitOn: "OrderID"
                );
        }

        public void Select(IDbConnection connection)
        {
            var sql = "SELECT * FROM Region";
            var regions = connection.Query<Region>(sql);
            foreach (var item in regions)
            {
                Console.WriteLine($"{item.RegionId}, {item.RegionDescription}");
            }
        }

        public void Insert(IDbConnection connection, Region region)
        {

            var insertSql = "INSERT INTO Region(regionId, regionDescription) VALUES (@RegionId, @RegionDescription)";

            var result = connection.Execute(insertSql, region);
        }

        public void Insert(IDbConnection connection, int id, string desc)
        {

            var insertSql = "INSERT INTO Region(regionId, regionDescription) VALUES (@RegionId, @RegionDescription)";

            var result = connection.Execute(insertSql,
                new { RegionId = id, RegionDescription = desc }
            );
        }

        public void Delete(IDbConnection connection, int id)
        {
            var sql = "DELETE FROM Region WHERE regionId = @Id";
            var result = connection.Execute(sql, new { Id = id });
        }

        public void Update(IDbConnection connection, int id, string desc)
        {
            var sql = "UPDATE Region SET regionDescription = @RegionDescription WHERE regionId = @RegionId";
            var result = connection.Execute(sql,
                new { RegionId = id, RegionDescription = desc }
            );
        }
    }
}