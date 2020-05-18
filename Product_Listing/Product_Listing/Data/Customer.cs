using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Product_Listing
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
            this.ShoppingCarts = new List<ShoppingCart>();
        }
    
        public int customerID { get; set; }
        public string customerFN { get; set; }
        public string customerLN { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string postalCode { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual CustomerEmail customerEmail { get; set; }
        public virtual customerPhoneNumber customerPhoneNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public static Customer CreateEntity(SqlDataReader reader)
        {
            return new Customer
            {
                customerID = Convert.ToInt32(reader["customerID"]),
                customerFN = Convert.ToString(reader["customerFN"]),
                customerLN = Convert.ToString(reader["customerLN"]),
                //DOB = Convert.ToDateTime(reader["customerLN"]),
                address = Convert.ToString(reader["address"]),
                City = Convert.ToString(reader["City"]),
                State = Convert.ToString(reader["State"]),
                postalCode = Convert.ToString(reader["postalCode"]),
                //Created_date = Convert.ToDateTime(reader["Created_date"]),
            };
        }
    }
}
