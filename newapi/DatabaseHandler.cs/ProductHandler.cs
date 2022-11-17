using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections;



namespace newapi
{
    public class ProductHandler : DatabaseHandler
    {
        public IEnumerable < Product > GetProduct()
        { 
            List<Product> product = new List<Product> ();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand ("SELECT * FROM Product", conn))
                {
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
            return product;
        }

    }
}