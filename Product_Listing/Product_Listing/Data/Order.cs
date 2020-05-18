using System;
using System.Collections.Generic;

namespace Product_Listing
{
   
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
    
        public int orderID { get; set; }
        public Nullable<double> total { get; set; }
        public Nullable<double> totalWithTAX { get; set; }
        public Nullable<System.DateTime> shippedDate { get; set; }
        public string status { get; set; }
        public string comments { get; set; }
        public int customerID { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
