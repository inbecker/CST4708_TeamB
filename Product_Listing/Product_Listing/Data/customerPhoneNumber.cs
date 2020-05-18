namespace Product_Listing
{
    using System;
    using System.Collections.Generic;
    
    public partial class customerPhoneNumber
    {
        public int customerID { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
