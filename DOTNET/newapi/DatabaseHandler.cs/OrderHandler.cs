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
        
        public int Delete(Order order)
        { 
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand ("DElETE FROM [ORDER] WHERE OrderDate = @order AND ProdID = @ProdID AND CustID = @CustID", conn))
                {
                    command.Parameters.AddWithValue("@Order", order.OrderDate);
                    command.Parameters.AddWithValue("@ProdID", order.ProdID);
                    command.Parameters.AddWithValue("@CustID", order.CustID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                conn.Close();
            }
        }

        public int AddOrder(Order order)
        {
          using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand ("INSERT INTO [ORDER] VALUES(@OrderDate, @Quantity, @ShipDate, @ShipMode, @ProdID, @CustID)", conn))
                {
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    command.Parameters.AddWithValue("@ProdID", order.ProdID);
                    command.Parameters.AddWithValue("@CustID", order.CustID);
                    command.Parameters.AddWithValue("@Quantity", order.Quantity);
                    command.Parameters.AddWithValue("@ShipDate", order.ShipDate);
                    command.Parameters.AddWithValue("@ShipMode", order.ShipMode);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
                conn.Close();
            }  
        }
        public float Total (Order order){
            List<Product> product = new List<Product> ();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand ("SELECT * FROM Product WHERE ProdID = @ProdID", conn))
                { 
                    command.Parameters.AddWithValue("@ProdID", order.ProdID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Add(new Product(){
                                ProdID = reader.GetString(0),
                                Description = reader.GetString(1),
                                UnitPrice = reader.GetInt32(2),
                                CatID = reader.GetInt32(3)

                            });
                        }
                    }
                }
            }
            return order.total((int)order.Quantity, (int)product[0].UnitPrice);
        }
public float GST (Order order){
            List<Product> product = new List<Product> ();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand ("SELECT * FROM Product WHERE ProdID = @ProdID", conn))
                { 
                    command.Parameters.AddWithValue("@ProdID", order.ProdID);
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product.Add(new Product(){
                                ProdID = reader.GetString(0),
                                Description = reader.GetString(1),
                                UnitPrice = reader.GetInt32(2),
                                CatID = reader.GetInt32(3)

                            });
                        }
                    }
                }
            }
            return order.GST((int)order.Quantity, (int)product[0].UnitPrice);
        }
    }
}