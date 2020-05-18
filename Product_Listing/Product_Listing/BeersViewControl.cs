using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Product_Listing.Data;

namespace Product_Listing
{
	public partial class BeersViewControl : UserControl
	{
		public BeersViewControl()
		{
			InitializeComponent();
			this.listViewBeers.View = View.Details;
		}

		public void SetBeer(ICollection<StandardBeer> beers)
		{
			this.listViewBeers.Items.Clear();
			this.picBeer.Visible = false;
			this.lblDescription.Visible = false;
			this.btnAddToCart.Visible = false;
			var images = new ImageList
			{
				ImageSize = new Size(30, 50)
			};
			images.Images.AddRange(beers.Select(b => Image.FromFile(b.ImagePath)).ToArray());

			this.listViewBeers.SmallImageList = images;
			int imageIndex = 0;
			foreach (var beer in beers)
			{
				var viewItem = new ListViewItem($"{beer.beerName}\n{beer.brewery}\n{beer.price}", imageIndex);
				viewItem.Tag = beer;
				this.listViewBeers.Items.Add(viewItem);
				imageIndex++;
			}
			this.listViewBeers.Update();
		}

		private void listViewBeers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(this.listViewBeers.SelectedItems == null || this.listViewBeers.SelectedItems.Count == 0)
			{
				return;
			}
			var selectedItems = this.listViewBeers.SelectedItems;
			var selectedbeer = selectedItems[0].Tag as StandardBeer;

			this.picBeer.Image = Image.FromFile(selectedbeer.ImagePath);
			this.picBeer.SizeMode = PictureBoxSizeMode.StretchImage;
			this.lblDescription.Text = selectedbeer.description;
			this.picBeer.Visible = true;
			this.lblDescription.Visible = true;
			this.btnAddToCart.Visible = true;
		}

		private void btnAddToCart_Click(object sender, EventArgs e)
		{
			if (!ConnectionManager.IsAuthenticated)
			{
				MessageBox.Show("Please login before adding to cart.","Authentication required",MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			//add to cart
			if (this.listViewBeers.SelectedItems == null || this.listViewBeers.SelectedItems.Count == 0)
			{
				return;
			}
			var customerID = ConnectionManager.ActiveCustomerId;
			var context = new ProductContext();
			var activeCart = context.GetActiveCart(customerID);
			var selectedItems = this.listViewBeers.SelectedItems;
			var selectedbeer = selectedItems[0].Tag as StandardBeer;
			int quantity = 1;
			if(activeCart != null)
			{
				ShoppingCartDetail cartDeatil = context.GetItemFromShoppingCart(activeCart.shoppingCartID, selectedbeer.beerID);
				if (cartDeatil != null)
				{
					quantity += cartDeatil.quantityOrdered;
					context.UpdateCart(cartDeatil.shoppingCartDetailsID, quantity);
					return;
				}				
			}			
			context.AddToCart(customerID, activeCart != null ? activeCart.shoppingCartID : -1, selectedbeer, quantity);

		}
	}
}
