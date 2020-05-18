//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace Product_Listing
{
    public class StandardBeer
    {
        public int beerID { get; set; }
        public string beerName { get; set; }
        public string description { get; set; }
        public string brewery { get; set; }
        public Nullable<double> price { get; set; }
        public string ImagePath { get; set; }

        public static StandardBeer CreateEntity(SqlDataReader reader,string categoryName="")
        {
            var beerId = Convert.ToInt32(reader["beerID"]);
            return new StandardBeer
            {
                beerID = beerId,
                beerName = Convert.ToString(reader["beerName"]),
                description = Convert.ToString(reader["description"]),
                brewery = Convert.ToString(reader["brewery"]),
                price = Convert.ToDouble(reader["price"]),
                ImagePath=$"Beer Images\\{categoryName}\\{beerId}.png"
            };
        }
    }
}
