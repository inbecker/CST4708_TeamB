using System;
using System.Windows.Forms;

namespace Product_Listing
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.registrationControl1.OnSucessfullRegistration += SucessfullRegistration;
			this.registrationControl1.OnLoginRequest += ShowLoginForm;
			this.loginControl.OnSucessfullLogin += OnSucessfullLogin;
			homeControl.BringToFront();
			button7.SendToBack();
		}

		private void OnSucessfullLogin()
		{
			homeControl.BringToFront();
		}

		private void ShowLoginForm()
		{
			loginControl.BringToFront();
		}

		private void SucessfullRegistration()
		{
			homeControl.BringToFront();			
		}

		
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void Home_Click(object sender, EventArgs e)
		{
			homeControl.BringToFront();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			categoriesControl1.ShowCategories();
			categoriesControl1.BringToFront();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			shoppingCart2.LoadShoppingCartItems();
			shoppingCart2.BringToFront();
		}

		private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void panel9_Paint(object sender, PaintEventArgs e)
		{

		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			registrationControl1.BringToFront();
			button7.BringToFront();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			registrationControl1.SendToBack();
			button7.SendToBack();
		}

		private void pictureBox8_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
