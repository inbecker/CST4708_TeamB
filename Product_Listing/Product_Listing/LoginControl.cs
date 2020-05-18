using System;
using System.Windows.Forms;
using Product_Listing.Data;

namespace Product_Listing
{
	public delegate void SucessfullLogin();
	public partial class LoginControl : UserControl
	{
		public SucessfullLogin OnSucessfullLogin;
		public LoginControl()
		{
			InitializeComponent();
			lblError.Text = string.Empty;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				lblError.Text = "Either email or password is missing";				
				return;
			}
			if (!txtEmail.Text.Contains("@"))
			{
				lblError.Text = "Invalid email address";
				return;
			}

			CustomerEmail email = new CustomerEmail
			{
				Email = txtEmail.Text,
				password = txtPassword.Text
			};

			ProductContext context = new ProductContext();
			var result = context.VerifyLoginDetails(email);
			var isCustomerValid = result.Item1;
			if (!isCustomerValid)
			{
				ConnectionManager.IsAuthenticated = false;
				ConnectionManager.ActiveCustomerId = -1;
				lblError.Text = "Invalid customer details. Please try again.";
			}
			else
			{
				ConnectionManager.IsAuthenticated = true;
				ConnectionManager.ActiveCustomerId = result.Item2.customerID;
				// navigate to home page
				OnSucessfullLogin?.Invoke();
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			// navigate to home page
			OnSucessfullLogin?.Invoke();
		}
	}
}
