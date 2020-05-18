namespace Product_Listing
{
    using System;
    using System.Collections.Generic;
	using System.Data.SqlClient;

	public class ShoppingCartDetail
    {
        public int shoppingCartDetailsID { get; set; }
        public int beerID { get; set; }
        public int quantityOrdered { get; set; }
        public int shoppingCartID { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual StandardBeer Beer { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        public static ShoppingCartDetail CreateEntity(SqlDataReader reader,bool includeCart=false,bool includeBeer=false)
        {
            return new ShoppingCartDetail
            {
                shoppingCartDetailsID = Convert.ToInt32(reader["shoppingCartDetailsID"]),
                beerID = Convert.ToInt32(reader["beerID"]),
                quantityOrdered = Convert.ToInt32(reader["quantityOrdered"]),
                shoppingCartID = Convert.ToInt32(reader["shoppingCartID"]),
                ShoppingCart= includeCart?ShoppingCart.CreateEntity(reader):null,
                Beer= includeBeer?StandardBeer.CreateEntity(reader): null
                //Created_date = Convert.ToDateTime(reader["Created_date"]),
            };
        }
    }
}
