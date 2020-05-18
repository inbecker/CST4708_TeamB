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
    public partial class ShoppingCartControl : UserControl
    {
        
        public ShoppingCartControl()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;
        }

        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
            var shoppingCardDetailId = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            var quantity = -1;
            var quantityCellValue = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if(shoppingCardDetailId == null || quantityCellValue == null || !int.TryParse(Convert.ToString(quantityCellValue), out quantity))
            {
                return;
            }
            if(quantity <= 0)
            {
                return;
            }
            ProductContext context = new ProductContext();
            context.UpdateCart((int)shoppingCardDetailId, quantity);

            var priceCellValue = this.dataGridView1.Rows[e.RowIndex].Cells["unitPrice"].Value;
            var total = (double)priceCellValue * quantity;
            this.dataGridView1.Rows[e.RowIndex].Cells["totalPrice"].Value= total;

            total = 0;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                total += (double)row.Cells["totalPrice"].Value;
            }
            lblTotalCartAmount.Text = total.ToString();
        }

        public void LoadShoppingCartItems()
        {
            if (!ConnectionManager.IsAuthenticated)
            {
                return;
            }
            ProductContext context = new ProductContext();
            var cartItems = context.GetCartItems(ConnectionManager.ActiveCustomerId);
            this.dataGridView1.DataSource = cartItems.ConvertCollection()?.ToList();

            var totalAmount = cartItems.Sum(c => c.quantityOrdered * c.Beer.price);
            lblTotalCartAmount.Text = totalAmount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ConnectionManager.IsAuthenticated)
            {
                return;
            }
            //create order
            ProductContext context = new ProductContext();
            var items = context.GetCartItems(ConnectionManager.ActiveCustomerId);
            if(items == null || !items.Any())
            {
            MessageBox.Show("Please add items to cart before checkout.", "Checkout items",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            context.CreateOrder(ConnectionManager.ActiveCustomerId, context.GetCartItems(ConnectionManager.ActiveCustomerId));
            //refresh
            this.LoadShoppingCartItems();

            MessageBox.Show("Order placed successfully", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = false;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void ShoppingCartControl_Load(object sender, EventArgs e)
        {
            this.dataGridView1.ReadOnly = true;
        }
    }
}
