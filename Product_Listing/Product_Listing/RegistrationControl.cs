using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Product_Listing.Data;

namespace Product_Listing
{
    public delegate void SucessfullRegistration();
    public delegate void LoginRequest();
    public partial class RegistrationControl : UserControl
    {
        public SucessfullRegistration OnSucessfullRegistration;
        public LoginRequest OnLoginRequest;
        public RegistrationControl()
        {
            InitializeComponent();
            lblError.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                lblError.Text = "First name can not be empty. Please try again.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                lblError.Text = "Last name can not be empty. Please try again.";
                return;
            }
            // check phone number
            if (!IsPhoneNumberValid(txtPhoneNumber.Text))
            {
                lblError.Text = "Entered phone number is invalid. Please try again.";
                return;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                lblError.Text = " Invalid email address. Please try again.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Password can not be empty. Please try again.";
                return;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                lblError.Text = "Confirm Password can not be empty. Please try again.";
                return;
            }
            if (!txtPassword.Text.Equals(txtConfirmPassword.Text))
            {
                lblError.Text = "Password mismatch. Please try again.";
                return;
            }            

            int customerId = (new Random()).Next();
            customerPhoneNumber phoneNo = new customerPhoneNumber { PhoneNumber = txtPhoneNumber.Text };
            CustomerEmail email = new CustomerEmail { Email = txtEmail.Text, password = txtConfirmPassword.Text };
            Customer customer = new Customer
            {
                customerID= customerId,
                customerFN = txtFirstName.Text,
                customerLN = txtLastName.Text,
                customerPhoneNumber = phoneNo,
                customerEmail = email,
                Created_date=DateTime.Now
            };

            ProductContext context = new ProductContext();
            bool isRegistered = context.RegisterCustomer(customer);
            if (!isRegistered)
            {
                // if registration is failed
                lblError.Text = "Email id already exists. Please try again.";
                return;
            }

            // navigate to home page
            OnSucessfullRegistration?.Invoke();
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            try
            {
                var matchPhoneNumberPattern1 = @"\d{3}-\d{3}-\d{4}";
                var matchPhoneNumberPattern2 = @"\d{2}-\d{2}-\d{4}-\d{4}";
                if ((Regex.IsMatch(phoneNumber, matchPhoneNumberPattern1) && phoneNumber.Length == 12)
                    || (Regex.IsMatch(phoneNumber, matchPhoneNumberPattern2) && phoneNumber.Length == 15))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

        }
        private bool IsValidEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            OnLoginRequest?.Invoke();
        }

        private void RegistrationControl_Load(object sender, EventArgs e)
        {

        }
    }
}
