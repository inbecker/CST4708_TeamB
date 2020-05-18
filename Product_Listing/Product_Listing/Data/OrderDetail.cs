namespace Product_Listing
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int orderDetailsID { get; set; }
        public int orderID { get; set; }
        public int beerID { get; set; }
        public int quantityOrdered { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual Beer Beer { get; set; }
        public virtual Order Order { get; set; }
    }
}
