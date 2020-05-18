using Product_Listing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Mapper
{
	public static ShoppingCardGridModel Convert(this ShoppingCartDetail cartDetail)
	{
		var entity = new ShoppingCardGridModel
		{
			 BeerId=cartDetail.beerID,
			 BeerName= cartDetail.Beer.beerName,
			 Brewery= cartDetail.Beer.brewery,
			 Description= cartDetail.Beer.description,
			 Price= cartDetail.Beer.price,
			 ShoppingCardDetailId= cartDetail.shoppingCartDetailsID,
			 ShoppingCardId= cartDetail.shoppingCartID,
			 QuantityOrdered=cartDetail.quantityOrdered,
			 TotalPrice = cartDetail.Beer.price * cartDetail.quantityOrdered
		};
		return entity;
	}
	public static IEnumerable<ShoppingCardGridModel> ConvertCollection(this ICollection<ShoppingCartDetail> cartDetails)
	{
		foreach (var item in cartDetails)
		{
			yield return item.Convert();
		}
	}
}

