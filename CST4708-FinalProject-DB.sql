-- Use the database created
USE CST4714FinalProject;

-- DROP TABLES IF THEY EXIST
DROP TABLE IF EXISTS ShoppingCartDetails;
DROP TABLE IF EXISTS ShoppingCart;
DROP TABLE IF EXISTS stateTAX;
DROP TABLE IF EXISTS orderdetails;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS beer;
DROP TABLE IF EXISTS brewery;
DROP TABLE IF EXISTS BeerStyle;
DROP TABLE IF EXISTS BeerCategory;
DROP TABLE IF EXISTS customerEmail;
DROP TABLE IF EXISTS customerPhoneNumber;
DROP TABLE IF EXISTS customer;

-- Customer table
CREATE TABLE Customer (
	customerID  INT NOT NULL IDENTITY(1,1),
	customerFN VARCHAR(255) NOT NULL,
	customerLN VARCHAR(255) NOT NULL,
	DOB DATE,
	address VARCHAR(255),
	City VARCHAR(255),
	State char(2),
	postalCode VARCHAR(7),
	Created_date DATETIME DEFAULT getdate(),
	CONSTRAINT PK_CST4714_IB_Customer PRIMARY KEY NONCLUSTERED (customerID)
);

-- Check constraint to enforce to enforce business rule 2: Every customer that registers to our system must be at least 21 years old 
ALTER TABLE Customer
ADD CONSTRAINT CHECK_CST4714_IB_CustomerAge
CHECK (DATEDIFF(yyyy, DOB, Created_date) > 21)

-- CustomerPhoneNumber table
CREATE TABLE customerPhoneNumber (
	customerID  INT NOT NULL ,
	PhoneNumber VARCHAR(15),
	Created_date DATETIME DEFAULT getdate(),
	CONSTRAINT FK_CST4714_IB_CustomerPhone FOREIGN KEY (customerID) 
	REFERENCES customer(customerID) 
);

-- Check constraint to enforce business rule 3: All phone numbers entered should be properly formatted
ALTER TABLE customerPhoneNumber
ADD CONSTRAINT CHECK_CST4714_IB_ValidPhone
CHECK (PhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'
OR PhoneNumber LIKE '[0-9][0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]')

-- customerEmail table
CREATE TABLE customerEmail (
	customerID  INT NOT NULL ,
	Email VARCHAR(255),
	password VARCHAR(255),
	Created_date DATETIME DEFAULT getdate(),
	CONSTRAINT FK_CST4714_IB_CustomerEmail FOREIGN KEY (customerID) 
	REFERENCES customer(customerID) 
);

--Beer Category
CREATE TABLE BeerCategory (
  catID INT NOT NULL IDENTITY(1,1),
  catName varchar(50) NOT NULL,
  CONSTRAINT PK_CST4714_IB_BeerCategory PRIMARY KEY NONCLUSTERED (catID),
) ;


--BeerStyle table
CREATE TABLE BeerStyle (
  styleID INT NOT NULL IDENTITY(1,1),
  catID INT NOT NULL,
  styleName varchar(50) NOT NULL,
  Created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_BeerStyle PRIMARY KEY NONCLUSTERED (styleID),
  CONSTRAINT FK_CST4714_IB_BeerStyleCategory FOREIGN KEY (catID) REFERENCES BeerCategory(catID) 

) ;

--Brewery table
CREATE TABLE Brewery (
  breweryID INT NOT NULL,
  breweryName varchar(50) NOT NULL,
  address varchar(100) ,
  city varchar(50) ,
  state varchar(50) ,
  postalCode varchar(15) ,
  country varchar(50) ,
  phone varchar(50) ,
  website varchar(50),
  description varchar(5000) ,
  Created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_Brewery PRIMARY KEY NONCLUSTERED (breweryID)

) ;

						
--Beer table
CREATE TABLE Beer (
  beerID INT NOT NULL,
  breweryID INT NOT NULL,
  beerName varchar(100) ,
  catID  INT  NOT  NULL,
  styleID  INT  NOT  NULL,
  ABV FLOAT ,
  price FLOAT,
  description varchar(5000) ,
  Created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_Beer PRIMARY KEY NONCLUSTERED (beerID),
  CONSTRAINT FK_CST4714_IB_BeerBrewery FOREIGN KEY (breweryID) REFERENCES Brewery(breweryID) ,
  CONSTRAINT FK_CST4714_IB_BeerBeerCategory FOREIGN KEY (catID) REFERENCES BeerCategory(catID) ,
  CONSTRAINT FK_CST4714_IB_BeerBeerStyle FOREIGN KEY (styleID) REFERENCES BeerStyle(styleID) 
) ;


--Orders table
CREATE TABLE Orders (
  orderID INT NOT NULL IDENTITY(1,1),
  total FLOAT,
  totalWithTAX FLOAT,
  shippedDate date DEFAULT NULL,
  status varchar(15) ,
  comments text,
  customerID INT NOT NULL,
  created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_Orders PRIMARY KEY NONCLUSTERED (orderID),
  CONSTRAINT FK_CST4714_IB_OrdersCustomer FOREIGN KEY (customerID) REFERENCES customer (customerID)
) ;


--OrderDetails Table
CREATE TABLE OrderDetails (
  orderDetailsID INT NOT NULL IDENTITY(1,1),
  orderID INT NOT NULL,
  beerID INT NOT NULL,
  quantityOrdered INT NOT NULL,
  Created_date DATETIME DEFAULT getdate(),
  CONSTRAINT FK_CST4714_IB_OrderDetailsBeer FOREIGN KEY (beerID) REFERENCES beer (beerID),
  CONSTRAINT FK_CST4714_IB_OrderDetailsOrderID FOREIGN KEY (orderID) REFERENCES Orders (orderID)
) ;

-- SalesTAX table 
CREATE TABLE StateTAX (
  salestTAXID INT NOT NULL IDENTITY(1,1),
  State char(2) NOT NULL,
  TAX FLOAT,
  created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_StateTAX PRIMARY KEY NONCLUSTERED (salestTAXID)
  );

  -- Shopping Cart Table
  CREATE TABLE ShoppingCart (
  shoppingCartID INT NOT NULL IDENTITY(1,1),
  customerID INT NOT NULL,
  Created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_ShoppingCart PRIMARY KEY NONCLUSTERED (shoppingCartID),
  CONSTRAINT FK_CST4714_IB_ShoppingCartCustomer FOREIGN KEY (customerID) REFERENCES customer (customerID)
) ;


  -- Cart Items
  CREATE TABLE ShoppingCartDetails (
  shoppingCartDetailsID INT NOT NULL IDENTITY(1,1),
  beerID INT NOT NULL,
  quantityOrdered INT NOT NULL,
  shoppingCartID INT NOT NULL,
  Created_date DATETIME DEFAULT getdate(),
  CONSTRAINT PK_CST4714_IB_ShoppingCartDetails PRIMARY KEY NONCLUSTERED (shoppingCartDetailsID),
  CONSTRAINT FK_CST4714_IB_ShoppingCartDetailsBeer FOREIGN KEY (beerID) REFERENCES beer (beerID),
  CONSTRAINT FK_CST4714_IB_ShoppingCartDetailsShoppingCart FOREIGN KEY (shoppingCartID) REFERENCES ShoppingCart (shoppingCartID)
) ;
