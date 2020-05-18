using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Product_Listing.Data
{
	public class ProductContext
	{
		private string ConnectionString = string.Empty;
		public ProductContext()
		{
			ConnectionString = ConfigurationManager.ConnectionStrings["CST4714FinalProjectEntities"].ConnectionString;
		}

		private SqlConnection OpenConnection()
		{
			SqlConnection connection = new SqlConnection(ConnectionString);
			connection.Open();
			return connection;
		}
		private SqlCommand CreateCommand(string sqlQuery, SqlConnection connection)
		{
			SqlCommand command = new SqlCommand(sqlQuery, connection);
			return command;
		}
		private SqlDataReader ExecuteQueryAsReader(string sqlQuery, SqlConnection connection)
		{
			SqlCommand command = CreateCommand(sqlQuery, connection);
			return command.ExecuteReader();
		}

		public bool VerifyLoginDetails(customerEmail email)
		{
			string query = "select * from customerEmail where Email='" + email.Email + "' AND password = '" + email.password + "'";
			using (var connection = OpenConnection())
			{
				var dataReader = ExecuteQueryAsReader(query, connection);
				return (dataReader.HasRows);
			}
		}

		private int ExecuteQueryAsScalar(string sqlQuery, SqlConnection connection)
		{
			SqlCommand command = CreateCommand(sqlQuery, connection);
			return (Int32)command.ExecuteScalar();
		}

		public List<Customer> GetCustomers()
		{
			var customers = new List<Customer>();
			using (var connection = OpenConnection())
			{
				var dataReader = ExecuteQueryAsReader("select * from Customer", connection);
				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						customers.Add(Customer.CreateEntity(dataReader));
					}
				}
			}
			return customers;
		}

		public List<StandardBeer> GetBeers(ICollection<int> beerId, string category)
		{
			var berrs = new List<StandardBeer>();
			using (var connection = OpenConnection())
			{
				string viewName = $"v_CST4714_IB_{category}";
				string query = $"select * from {viewName} WHERE BEERID in ({string.Join(",",beerId)})";
				var dataReader = ExecuteQueryAsReader(query, connection);
				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						berrs.Add(StandardBeer.CreateEntity(dataReader, category));
					}
				}
			}
			return berrs;
		}

		public bool RegisterCustomer(Customer customer)
		{
			string query = string.Empty;
			// Check if user already exists
			using (var connection = OpenConnection())
			{
				query = "Select * from customerEmail where Email='" + customer.customerEmail.Email + "'";
				var dataReader = ExecuteQueryAsReader(query, connection);
				if (dataReader.HasRows)
				{
					// error - email already exists
					return false;
				}

				query = "Insert into Customer(customerFN, customerLN, Created_date) OUTPUT INSERTED.customerID values('" + customer.customerFN + "','" + customer.customerLN + "','" + customer.Created_date + "')";
				int customerId = ExecuteQueryAsScalar(query, connection);
				if (customerId > 0)
				{
					query = "Insert into customerEmail(customerID,Email,password,Created_date) OUTPUT INSERTED.customerID values(" + customerId + ",'" + customer.customerEmail.Email + "','" + customer.customerEmail.password + "','" + customer.Created_date + "')";
					ExecuteQueryAsScalar(query, connection);
					query = "Insert into customerPhoneNumber(customerID, PhoneNumber, Created_date) OUTPUT INSERTED.customerID values(" + customerId + ",'" + customer.customerPhoneNumber.PhoneNumber + "', '" + customer.Created_date + "')";
					ExecuteQueryAsScalar(query, connection);
				}
			}
			return true;
		}
	}
}
