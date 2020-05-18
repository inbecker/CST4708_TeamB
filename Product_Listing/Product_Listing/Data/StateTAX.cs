namespace Product_Listing
{
    using System;
    using System.Collections.Generic;
    
    public partial class StateTAX
    {
        public int salestTAXID { get; set; }
        public string State { get; set; }
        public Nullable<double> TAX { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
    }
}
