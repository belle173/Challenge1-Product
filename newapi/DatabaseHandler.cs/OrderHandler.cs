using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections;


namespace newapi
{
    public class OrderHandler : DatabaseHandler
    {
        public IEnumerable < Order > GetOrder()
        { 
            List<Order> Order = new List<Order> ();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand ("SELECT * FROM [Order]", conn))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order.Add(new Order(){
                                OrderDate = reader.GetString(0),
                                Quantity = reader.GetInt32(1),
                                ShipDate = reader.GetString(2),
                                ShipMode = reader.GetString(3),
                                ProdID = reader.GetString(4),
                                CustID = reader.GetString(5),
                            });
                        }
                    }
                }
            }
            return Order;
        }

    }
}