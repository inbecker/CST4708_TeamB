using System;
using System.Collections.Generic;
namespace Product_Listing
{    
    public class BeerStyle
    {
        public BeerStyle()
        {
            this.Beers = new List<Beer>();
        }
    
        public int styleID { get; set; }
        public int catID { get; set; }
        public string styleName { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual ICollection<Beer> Beers { get; set; }
        public virtual BeerCategory BeerCategory { get; set; }
    }
}
