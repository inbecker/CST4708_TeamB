namespace Product_Listing
{
    partial class ShoppingCartControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.lblTotalCartAmount = new System.Windows.Forms.Label();
			this.shoppingCardDetailId = new System.Windows.Forms.DataGridViewLinkColumn();
			this.beerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.beerDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.quantityOrdered = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.unitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(168, 27);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(360, 41);
			this.label1.TabIndex = 1;
			this.label1.Text = "ITEMS IN YOUR SHOPPING CART";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(428, 306);
			this.button1.Margin = new System.Windows.Forms.Padding(2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 26);
			this.button1.TabIndex = 2;
			this.button1.Text = "PROCEED TO CHECKOUT";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(65, 306);
			this.button2.Margin = new System.Windows.Forms.Padding(2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(204, 26);
			this.button2.TabIndex = 3;
			this.button2.Text = "EDIT ITEMS IN SHOPPING CART";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shoppingCardDetailId,
            this.beerName,
            this.beerDescription,
            this.quantityOrdered,
            this.unitPrice,
            this.totalPrice});
			this.dataGridView1.Location = new System.Drawing.Point(65, 70);
			this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 62;
			this.dataGridView1.RowTemplate.Height = 28;
			this.dataGridView1.Size = new System.Drawing.Size(523, 190);
			this.dataGridView1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(62, 277);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Total";
			// 
			// lblTotalCartAmount
			// 
			this.lblTotalCartAmount.AutoSize = true;
			this.lblTotalCartAmount.Location = new System.Drawing.Point(514, 277);
			this.lblTotalCartAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTotalCartAmount.Name = "lblTotalCartAmount";
			this.lblTotalCartAmount.Size = new System.Drawing.Size(22, 13);
			this.lblTotalCartAmount.TabIndex = 5;
			this.lblTotalCartAmount.Text = "0.0";
			// 
			// shoppingCardDetailId
			// 
			this.shoppingCardDetailId.DataPropertyName = "ShoppingCardDetailId";
			this.shoppingCardDetailId.HeaderText = "shoppingCartDetailID";
			this.shoppingCardDetailId.MinimumWidth = 10;
			this.shoppingCardDetailId.Name = "shoppingCardDetailId";
			this.shoppingCardDetailId.ReadOnly = true;
			this.shoppingCardDetailId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.shoppingCardDetailId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.shoppingCardDetailId.Visible = false;
			this.shoppingCardDetailId.Width = 200;
			// 
			// beerName
			// 
			this.beerName.DataPropertyName = "BeerName";
			this.beerName.HeaderText = "Name";
			this.beerName.MinimumWidth = 10;
			this.beerName.Name = "beerName";
			this.beerName.ReadOnly = true;
			this.beerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.beerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.beerName.Width = 160;
			// 
			// beerDescription
			// 
			this.beerDescription.DataPropertyName = "Description";
			this.beerDescription.HeaderText = "Description";
			this.beerDescription.MinimumWidth = 10;
			this.beerDescription.Name = "beerDescription";
			this.beerDescription.ReadOnly = true;
			this.beerDescription.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.beerDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.beerDescription.Width = 200;
			// 
			// quantityOrdered
			// 
			this.quantityOrdered.DataPropertyName = "QuantityOrdered";
			this.quantityOrdered.HeaderText = "Quantity";
			this.quantityOrdered.MinimumWidth = 10;
			this.quantityOrdered.Name = "quantityOrdered";
			this.quantityOrdered.ReadOnly = true;
			this.quantityOrdered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.quantityOrdered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.quantityOrdered.Width = 60;
			// 
			// unitPrice
			// 
			this.unitPrice.DataPropertyName = "Price";
			this.unitPrice.HeaderText = "Price";
			this.unitPrice.MinimumWidth = 10;
			this.unitPrice.Name = "unitPrice";
			this.unitPrice.ReadOnly = true;
			this.unitPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.unitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.unitPrice.Width = 60;
			// 
			// totalPrice
			// 
			this.totalPrice.DataPropertyName = "TotalPrice";
			this.totalPrice.HeaderText = "Total";
			this.totalPrice.MinimumWidth = 10;
			this.totalPrice.Name = "totalPrice";
			this.totalPrice.ReadOnly = true;
			this.totalPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.totalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.totalPrice.Width = 60;
			// 
			// ShoppingCartControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkSeaGreen;
			this.Controls.Add(this.lblTotalCartAmount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ShoppingCartControl";
			this.Size = new System.Drawing.Size(651, 350);
			this.Load += new System.EventHandler(this.ShoppingCartControl_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblTotalCartAmount;
		private System.Windows.Forms.DataGridViewLinkColumn shoppingCardDetailId;
		private System.Windows.Forms.DataGridViewTextBoxColumn beerName;
		private System.Windows.Forms.DataGridViewTextBoxColumn beerDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn quantityOrdered;
		private System.Windows.Forms.DataGridViewTextBoxColumn unitPrice;
		private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
	}
}
