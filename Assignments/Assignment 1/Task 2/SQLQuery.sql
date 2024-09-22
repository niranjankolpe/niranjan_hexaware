-- Write an SQL query to calculate and update the number of orders placed by each customer
-- in the "Customers" table based on the data in the "Orders" table.
BEGIN TRANSACTION;
UPDATE Customers SET NumberOfOrders = (SELECT COUNT(*) FROM Orders WHERE Orders.CustomerID = Customers.CustomerID);
SELECT * FROM Customers;
COMMIT TRANSACTION;