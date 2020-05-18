using System;
using System.Collections.Generic;
namespace Product_Listing
{
    
    public class BeerCategory
    {
        public BeerCategory()
        {
            this.Beers = new List<Beer>();
            this.BeerStyles = new List<BeerStyle>();
        }
    
        public int catID { get; set; }
        public string catName { get; set; }
    
        public virtual ICollection<Beer> Beers { get; set; }
        public virtual ICollection<BeerStyle> BeerStyles { get; set; }
    }
}
