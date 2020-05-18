
namespace Product_Listing
{
    using System;
    using System.Collections.Generic;
	using System.Data.SqlClient;

	public class Beer
    {
     public Beer()
        {
            this.OrderDetails = new List<OrderDetail>();
            this.ShoppingCartDetails = new List<ShoppingCartDetail>();
        }
    
        public int beerID { get; set; }
        public int breweryID { get; set; }
        public string beerName { get; set; }
        public int catID { get; set; }
        public int styleID { get; set; }
        public Nullable<double> ABV { get; set; }
        public Nullable<double> price { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual BeerCategory BeerCategory { get; set; }
        public virtual BeerStyle BeerStyle { get; set; }
        public virtual Brewery Brewery { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }

    }
}
