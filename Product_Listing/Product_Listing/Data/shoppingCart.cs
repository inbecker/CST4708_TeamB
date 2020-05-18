namespace Product_Listing
{
    using System;
    using System.Collections.Generic;
	using System.Data.SqlClient;

	public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.ShoppingCartDetails = new List<ShoppingCartDetail>();
        }
    
        public int shoppingCartID { get; set; }
        public int customerID { get; set; }
        public Nullable<System.DateTime> Created_date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetails { get; set; }

        public static ShoppingCart CreateEntity(SqlDataReader reader)
        {
            return new ShoppingCart
            {
                shoppingCartID = Convert.ToInt32(reader["shoppingCartID"]),
                customerID = Convert.ToInt32(reader["customerID"]),
                //Created_date = Convert.ToDateTime(reader["Created_date"]),
            };
        }
    }
}
