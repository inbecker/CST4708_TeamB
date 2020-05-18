namespace Product_Listing
{
	partial class BeersViewControl
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
			this.listViewBeers = new System.Windows.Forms.ListView();
			this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.picBeer = new System.Windows.Forms.PictureBox();
			this.btnAddToCart = new System.Windows.Forms.Button();
			this.lblDescription = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picBeer)).BeginInit();
			this.SuspendLayout();
			// 
			// listViewBeers
			// 
			this.listViewBeers.BackColor = System.Drawing.SystemColors.Window;
			this.listViewBeers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1});
			this.listViewBeers.HideSelection = false;
			this.listViewBeers.Location = new System.Drawing.Point(14, 20);
			this.listViewBeers.Name = "listViewBeers";
			this.listViewBeers.Size = new System.Drawing.Size(559, 474);
			this.listViewBeers.TabIndex = 0;
			this.listViewBeers.UseCompatibleStateImageBehavior = false;
			this.listViewBeers.SelectedIndexChanged += new System.EventHandler(this.listViewBeers_SelectedIndexChanged);
			// 
			// column1
			// 
			this.column1.Text = "Available Beers";
			this.column1.Width = 260;
			// 
			// picBeer
			// 
			this.picBeer.Location = new System.Drawing.Point(596, 21);
			this.picBeer.Name = "picBeer";
			this.picBeer.Size = new System.Drawing.Size(546, 281);
			this.picBeer.TabIndex = 1;
			this.picBeer.TabStop = false;
			// 
			// btnAddToCart
			// 
			this.btnAddToCart.Location = new System.Drawing.Point(596, 440);
			this.btnAddToCart.Name = "btnAddToCart";
			this.btnAddToCart.Size = new System.Drawing.Size(248, 54);
			this.btnAddToCart.TabIndex = 2;
			this.btnAddToCart.Text = "Add To Cart";
			this.btnAddToCart.UseVisualStyleBackColor = true;
			this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(601, 329);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(541, 76);
			this.lblDescription.TabIndex = 3;
			this.lblDescription.Text = "label1";
			// 
			// BeersViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.btnAddToCart);
			this.Controls.Add(this.picBeer);
			this.Controls.Add(this.listViewBeers);
			this.Name = "BeersViewControl";
			this.Size = new System.Drawing.Size(1186, 529);
			((System.ComponentModel.ISupportInitialize)(this.picBeer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewBeers;
		private System.Windows.Forms.ColumnHeader column1;
		private System.Windows.Forms.PictureBox picBeer;
		private System.Windows.Forms.Button btnAddToCart;
		private System.Windows.Forms.Label lblDescription;
	}
}
