using System;
using System.Collections.Generic;
namespace Product_Listing
{
    public partial class Brewery
    {
        public Brewery()
        {
            this.Beers = new List<Beer>();
        }
    
        public int breweryID { get; set; }
        public string breweryName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual ICollection<Beer> Beers { get; set; }
    }
}
