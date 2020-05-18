using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Product_Listing
{
	public class CustomerEmail
    {
        public int customerID { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual Customer Customer { get; set; }

        public static CustomerEmail CreateEntity(SqlDataReader reader)
        {
            return new CustomerEmail
            {
                customerID = Convert.ToInt32(reader["customerID"]),
                Email = Convert.ToString(reader["Email"]),
                password = Convert.ToString(reader["password"]),
            };
        }
    }
}
