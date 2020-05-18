using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Listing
{
	public class ShoppingCardGridModel
	{
		public int ShoppingCardId { get; set; }
		public int ShoppingCardDetailId { get; set; }
		public int BeerId { get; set; }
		public string BeerName { get; set; }
		public string Description { get; set; }
		public string Brewery { get; set; }
		public Nullable<double> Price { get; set; }
		public Nullable<double> TotalPrice { get; set; }
		public int QuantityOrdered { get; set; }
	}
}
