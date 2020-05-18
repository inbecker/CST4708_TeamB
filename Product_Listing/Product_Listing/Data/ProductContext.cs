using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Product_Listing.Data
{
	public class ProductContext
	{
		private string ConnectionString = string.Empty;
		public ProductContext()
		{
			ConnectionString = ConfigurationManager.ConnectionStrings["CST4714FinalProjectEntities"].ConnectionString;
			//ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\ingri\\OneDrive\\Escritorio\\Final\\CST4714FinalProject.mdf; Integrated Security = True; Connect Timeout = 30";
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
			return ExecuteCommandAsReader(command);
		}
		private SqlDataReader ExecuteCommandAsReader(SqlCommand command)
		{
			return command.ExecuteReader();
		}

		private T ExecuteCommandAsScalar<T>(SqlCommand command)
		{
			var result=command.ExecuteScalar();
			return (T)result;
		}
		private int ExecuteQueryAsScalar(string sqlQuery, SqlConnection connection)
		{
			SqlCommand command = CreateCommand(sqlQuery, connection);
			return ExecuteCommandAsScalar<Int32>(command);
		}
		public (bool,CustomerEmail) VerifyLoginDetails(CustomerEmail email)
		{
			string query = "select * from customerEmail where Email='" + email.Email + "' AND password = '" + email.password + "'";
			using (var connection = OpenConnection())
			{
				var dataReader = ExecuteQueryAsReader(query, connection);
				CustomerEmail entity = null;
				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						entity = CustomerEmail.CreateEntity(dataReader);
					}
				}
				return (dataReader.HasRows, entity);
			}
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
		public ICollection<Customer> GetCustomers()
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
		public ICollection<ShoppingCartDetail> GetCartItems(int customerId)
		{
			var cartItems = new List<ShoppingCartDetail>();
			using (var connection = OpenConnection())
			{
				StringBuilder query = new StringBuilder();
				query.Append("SELECT shoppingCartDetailsID,ShoppingCartDetails.beerID");
				query.Append(",quantityOrdered,ShoppingCartDetails.shoppingCartID");
				query.Append(",ShoppingCartDetails.[Created_date],Beer.beerName,Beer.[description]"); 
				query.Append(",Beer.price,ShoppingCart.customerID,Brewery.[description] as brewery");
				query.Append(" ");
				query.Append("FROM  ShoppingCartDetails inner join Beer on ShoppingCartDetails.beerID = Beer.beerID ");
				query.Append(" inner join ShoppingCart on ShoppingCartDetails.shoppingCartID = ShoppingCart.shoppingCartID");
				query.Append(" inner join Brewery on Brewery.breweryID = Beer.breweryID");
				query.Append(" where customerID=@customerID");
				var command = CreateCommand(query.ToString(), connection);
				command.Parameters.AddWithValue("@customerID", customerId);
				var dataReader = ExecuteCommandAsReader(command);
				if (dataReader.HasRows)
				{
					while (dataReader.Read())
					{
						cartItems.Add(ShoppingCartDetail.CreateEntity(dataReader,true,true));
					}
				}
			}
			return cartItems;
		}
		public ShoppingCart GetActiveCart(int customerId)
		{
			ShoppingCart cart = null;
			using (var connection = OpenConnection())
			{
				StringBuilder query = new StringBuilder();
				query.Append("SELECT top 1 shoppingCartID,customerID,Created_date ");
				query.Append("FROM  ShoppingCart");
				query.Append(" where customerID=@customerID");
				var command = CreateCommand(query.ToString(), connection);
				command.Parameters.AddWithValue("@customerID", customerId);
				var dataReader = ExecuteCommandAsReader(command);
				if (dataReader.HasRows)
				{
					cart = new ShoppingCart();
					while (dataReader.Read())
					{
						cart = ShoppingCart.CreateEntity(dataReader);
					}
				}
			}
			return cart;
		}

		public ICollection<StandardBeer> GetBeers(ICollection<int> beerId, string category)
		{
			var berrs = new List<StandardBeer>();
			using (var connection = OpenConnection())
			{
				string viewName = $"v_CST4714_IB_{category}";
				string query = $"select * from {viewName} WHERE BEERID in ({string.Join(",", beerId)})";
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

		public ShoppingCartDetail GetItemFromShoppingCart(int shoppingCartID, int beerId)
		{
			ShoppingCartDetail cart = null;
			using (var connection = OpenConnection())
			{
				StringBuilder query = new StringBuilder();
				query.Append("SELECT shoppingCartDetailsID,beerID,quantityOrdered,shoppingCartID,Created_date ");
				query.Append("FROM  ShoppingCartDetails");
				query.Append(" where shoppingCartID=@shoppingCartID and beerId=@beerId");
				var command = CreateCommand(query.ToString(), connection);
				command.Parameters.AddWithValue("@shoppingCartID", shoppingCartID);
				command.Parameters.AddWithValue("@beerId", beerId);
				var dataReader = ExecuteCommandAsReader(command);
				if (dataReader.HasRows)
				{
					cart = new ShoppingCartDetail();
					while (dataReader.Read())
					{
						cart = ShoppingCartDetail.CreateEntity(dataReader);
					}
				}
			}
			return cart;
		}
		public void AddToCart(int customerId, int shoppingCartID, StandardBeer beer,int quantity)
		{
			using (TransactionScope scope = new TransactionScope())
			{	
				using (var connection = OpenConnection())
				{
					if(shoppingCartID == -1)
					{
						StringBuilder shoppingCartQuery = new StringBuilder();
						shoppingCartQuery.Append("insert into [ShoppingCart] (customerID,Created_date) ");
						shoppingCartQuery.Append(" OUTPUT INSERTED.shoppingCartID ");
						shoppingCartQuery.Append(" values(@customerID,@Created_date)");
						var shoppingCartCommand = CreateCommand(shoppingCartQuery.ToString(), connection);
						shoppingCartCommand.Parameters.AddWithValue("@customerID", customerId);
						shoppingCartCommand.Parameters.AddWithValue("@Created_date", DateTime.Now);
						shoppingCartID = this.ExecuteCommandAsScalar<Int32>(shoppingCartCommand);
					}

					StringBuilder shoppingCartDetailQuery = new StringBuilder();
					shoppingCartDetailQuery.Append("insert into [ShoppingCartDetails] (beerID,quantityOrdered,shoppingCartID,Created_date) ");
					shoppingCartDetailQuery.Append(" OUTPUT INSERTED.shoppingCartDetailsID ");
					shoppingCartDetailQuery.Append(" values(@beerID,@quantityOrdered,@shoppingCartID,@Created_date)");

					var shoppingCartDetailCommand = CreateCommand(shoppingCartDetailQuery.ToString(), connection);
					shoppingCartDetailCommand.Parameters.AddWithValue("@beerID", beer.beerID);
					shoppingCartDetailCommand.Parameters.AddWithValue("@quantityOrdered", quantity);
					shoppingCartDetailCommand.Parameters.AddWithValue("@shoppingCartID", shoppingCartID);
					shoppingCartDetailCommand.Parameters.AddWithValue("@Created_date", DateTime.Now);

					var shoppingCartDetailID = this.ExecuteCommandAsScalar<Int32>(shoppingCartDetailCommand);
				}
				scope.Complete();
			}
		}
		public void UpdateCart(int shoppingCartDetailsID, int quantity)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				using (var connection = OpenConnection())
				{
					StringBuilder shoppingCartDetailQuery = new StringBuilder();
					shoppingCartDetailQuery.Append("Update [ShoppingCartDetails] set quantityOrdered=@quantityOrdered ");
					shoppingCartDetailQuery.Append(" OUTPUT INSERTED.shoppingCartDetailsID");
					shoppingCartDetailQuery.Append(" where shoppingCartDetailsID=@shoppingCartDetailsID");

					var shoppingCartDetailCommand = CreateCommand(shoppingCartDetailQuery.ToString(), connection);
					shoppingCartDetailCommand.Parameters.AddWithValue("@shoppingCartDetailsID", shoppingCartDetailsID);
					shoppingCartDetailCommand.Parameters.AddWithValue("@quantityOrdered", quantity);
					var shoppingCartDetailID = this.ExecuteCommandAsScalar<Int32>(shoppingCartDetailCommand);
				}
				scope.Complete();
			}
		}
		public void DelereFromCart(int shoppingCartDetailsID)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				using (var connection = OpenConnection())
				{
					StringBuilder shoppingCartDetailQuery = new StringBuilder();
					shoppingCartDetailQuery.Append("Delete from [ShoppingCartDetails] ");
					shoppingCartDetailQuery.Append(" OUTPUT DELETED.shoppingCartDetailsID");
					shoppingCartDetailQuery.Append(" where shoppingCartDetailsID=@shoppingCartDetailsID");

					var shoppingCartDetailCommand = CreateCommand(shoppingCartDetailQuery.ToString(), connection);
					shoppingCartDetailCommand.Parameters.AddWithValue("@shoppingCartDetailsID", shoppingCartDetailsID);
					var shoppingCartDetailID = this.ExecuteCommandAsScalar<Int32>(shoppingCartDetailCommand);
				}
				scope.Complete();
			}
		}
		public void CreateOrder(int customerId, ICollection<ShoppingCartDetail> shoppingCartItems)
		{
			using (TransactionScope scope = new TransactionScope())
			{
				StringBuilder orderQuery = new StringBuilder();
				orderQuery.Append("insert into [Orders] (customerID,total,totalWithTAX,shippedDate,[status],comments,created_date) ");
				orderQuery.Append(" OUTPUT INSERTED.orderID ");
				orderQuery.Append(" values(@customerID,@total,@totalWithTAX,@shippedDate,@status,@comments,@created_date)");

				var total = shoppingCartItems.Sum(s => (s.quantityOrdered * s.Beer.price));
				var totalWithTax = total + (total * 0.1);
				using (var connection = OpenConnection())
				{
					var orderCommand = CreateCommand(orderQuery.ToString(), connection);
					orderCommand.Parameters.AddWithValue("@customerID", customerId);
					orderCommand.Parameters.AddWithValue("@total", total);
					orderCommand.Parameters.AddWithValue("@totalWithTAX", totalWithTax);
					orderCommand.Parameters.AddWithValue("@shippedDate",DateTime.Now.ToShortDateString());
					orderCommand.Parameters.AddWithValue("@status", "Placed");
					orderCommand.Parameters.AddWithValue("@comments", "Order placed");
					orderCommand.Parameters.AddWithValue("@created_date", DateTime.Now);

					var orderId = this.ExecuteCommandAsScalar<Int32>(orderCommand);
					//Insert to orderDetails
					var table = new DataTable();
					table.Columns.Add("orderDetailsID", typeof(int));
					table.Columns.Add("orderID", typeof(int));
					table.Columns.Add("beerID", typeof(int));
					table.Columns.Add("quantityOrdered", typeof(int));
					table.Columns.Add("Created_date", typeof(DateTime));
					foreach (var cartItem in shoppingCartItems)
					{
						DataRow row = table.NewRow();
						row["orderDetailsID"] = orderId;
						row["orderID"] = orderId;
						row["beerID"] = cartItem.beerID;
						row["quantityOrdered"] = cartItem.quantityOrdered;
						row["Created_date"] = DateTime.Now;

						table.Rows.Add(row);
					}
					using (var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, null))
					{						
						bulk.DestinationTableName = "OrderDetails";
						bulk.WriteToServer(table);
					}
					//Remove from shopping cart
					var cartId = shoppingCartItems.First().shoppingCartID;
					var shoppingCartDetailCommand = CreateCommand("delete from ShoppingCartDetails where shoppingCartID=@shoppingCartID", connection);
					shoppingCartDetailCommand.Parameters.AddWithValue("@shoppingCartID", cartId);
					var result  = shoppingCartDetailCommand.ExecuteScalar();
					var shoppingCartCommand = CreateCommand("delete from ShoppingCart where customerID=@customerID and shoppingCartID=@shoppingCartID", connection);
					shoppingCartCommand.Parameters.AddWithValue("@customerID", customerId);
					shoppingCartCommand.Parameters.AddWithValue("@shoppingCartID", cartId);
					shoppingCartCommand.ExecuteScalar();
				}
				scope.Complete();
			}
		}
	}
}
