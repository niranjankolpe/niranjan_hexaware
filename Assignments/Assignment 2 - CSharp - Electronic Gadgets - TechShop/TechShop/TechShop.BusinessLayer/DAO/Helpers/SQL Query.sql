USE master;
-- DROP DATABASE TechShopDB;
CREATE DATABASE TechShopDB;
USE TechShopDB;

CREATE TABLE Customers (CustomerID INT PRIMARY KEY IDENTITY, FirstName VARCHAR(20) NOT NULL, LastName VARCHAR(20), Email VARCHAR(50), Phone DECIMAL NOT NULL, Address VARCHAR(60));
INSERT INTO Customers VALUES ('Niranjan', 'Kolpe',    'niranjan@gmail.com', 9999999991, 'San Fransisco');
INSERT INTO Customers VALUES ('Steve',    'Rogers',   'steve@gmail.com',    9999999992, 'Brooklyn');
INSERT INTO Customers VALUES ('Tony',     'Stark',    'tony@gmail.com',     9999999993, 'New York');
INSERT INTO Customers VALUES ('Natasha',  'Romanoff', 'natasha@gmail.com',  9999999994, 'New York');
INSERT INTO Customers VALUES ('Bruce',    'Banner',   'bruce@gmail.com',    9999999995, 'Delhi');
INSERT INTO Customers VALUES ('Thor',     'Odinson',  'thor@gmail.com',     9999999996, 'Washington');
INSERT INTO Customers VALUES ('Clint',    'Barton',   'clint@gmail.com',    9999999997, 'Chennai');
INSERT INTO Customers VALUES ('Wanda',    'Maximoff', 'wanda@gmail.com',    9999999998, 'Mumbai');
INSERT INTO Customers VALUES ('Sam',      'Wilson',   'sam@gmail.com',      9999999999, 'San Fransisco');
INSERT INTO Customers VALUES ('Peter',    'Parker',   'peter@gmail.com',    9999999981, 'Queens');
SELECT * FROM Customers;

CREATE TABLE Products (ProductID INT PRIMARY KEY IDENTITY, ProductName VARCHAR(30) NOT NULL, Description VARCHAR(60), Price INT NOT NULL);
INSERT INTO Products VALUES ('Smartphone', 'Android Smartphone',        10000);
INSERT INTO Products VALUES ('Powerbank',  'Powerbank for Smartphones', 3000);
INSERT INTO Products VALUES ('Airpods',    'Wireless Airpods',          1000);
INSERT INTO Products VALUES ('Earphones',  'Wired Earphones',           100);
INSERT INTO Products VALUES ('USB Cable',  'USB Cable',                 100);
INSERT INTO Products VALUES ('Mouse',      'Wired Mouse',               300);
INSERT INTO Products VALUES ('Router',     'Wifi Router',               1500);
INSERT INTO Products VALUES ('Monitor',    'Desktop Monitor',           4000);
INSERT INTO Products VALUES ('Keyboard',   'PC Keyboard',               1000);
INSERT INTO Products VALUES ('Charger',    'Mobile Charger',            200);
SELECT * FROM Products;

CREATE TABLE Orders (OrderID INT PRIMARY KEY IDENTITY, CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID), OrderDate DATETIME, TotalAmount INT, OrderStatus VARCHAR(20));
INSERT INTO Orders VALUES (5,  '2024-09-01', 1000,  'Processing');
INSERT INTO Orders VALUES (7,  '2024-09-02', 3000,  'Pending');
INSERT INTO Orders VALUES (6,  '2024-09-02', 10000, 'Processing');
INSERT INTO Orders VALUES (4,  '2024-09-03', 4000,  'Pending');
INSERT INTO Orders VALUES (9,  '2024-09-04', 2000,  'Pending');
INSERT INTO Orders VALUES (2,  '2024-09-06', 500,   'Shipped');
INSERT INTO Orders VALUES (1,  '2024-09-15', 200,   'Pending');
INSERT INTO Orders VALUES (3,  '2024-09-16', 10000, 'Pending');
INSERT INTO Orders VALUES (8,  '2024-09-17', 6000,  'Pending');
INSERT INTO Orders VALUES (10, '2024-09-18', 7000,  'Pending');
SELECT * FROM Orders;

CREATE TABLE OrderDetails (OrderDetailID INT PRIMARY KEY IDENTITY, OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
						   ProductID INT FOREIGN KEY REFERENCES Products(ProductID), Quantity INT);
INSERT INTO OrderDetails VALUES (1,  3,  1);
INSERT INTO OrderDetails VALUES (2,  2,  1);
INSERT INTO OrderDetails VALUES (3,  1,  1);
INSERT INTO OrderDetails VALUES (4,  8,  1);
INSERT INTO OrderDetails VALUES (5,  9,  2);
INSERT INTO OrderDetails VALUES (6,  4,  5);
INSERT INTO OrderDetails VALUES (7,  10, 1);
INSERT INTO OrderDetails VALUES (8,  9,  10);
INSERT INTO OrderDetails VALUES (9,  7,  4);
INSERT INTO OrderDetails VALUES (10, 3,  7);
SELECT * FROM OrderDetails;

CREATE TABLE Inventory (InventoryID INT PRIMARY KEY IDENTITY, ProductID INT FOREIGN KEY REFERENCES Products(ProductID), QuantityInStock INT, LastStockUpdate DATETIME);
INSERT INTO Inventory VALUES (1,  23, '2024-09-19');
INSERT INTO Inventory VALUES (2,  26, '2024-09-19');
INSERT INTO Inventory VALUES (3,  63, '2024-09-19');
INSERT INTO Inventory VALUES (4,  52, '2024-09-19');
INSERT INTO Inventory VALUES (5,  92, '2024-09-19');
INSERT INTO Inventory VALUES (6,  12, '2024-09-19');
INSERT INTO Inventory VALUES (7,  38, '2024-09-19');
INSERT INTO Inventory VALUES (8,  84, '2024-09-20');
INSERT INTO Inventory VALUES (9,  97, '2024-09-20');
INSERT INTO Inventory VALUES (10, 14, '2024-09-20');
SELECT * FROM Inventory;