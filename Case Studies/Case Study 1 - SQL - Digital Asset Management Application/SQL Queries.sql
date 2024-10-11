-- Name: Niranjan Kolpe, Batch: C# batch-2
-- Case Study: SQL - Digital Asset Management Application

USE master;
CREATE DATABASE AssetDB;

USE AssetDB;

-- Schema Design
-- 1. Employees Table:
CREATE TABLE employees (employee_id INT PRIMARY KEY IDENTITY, name VARCHAR(20) NOT NULL,
						department VARCHAR(20) NOT NULL, email VARCHAR(30) NOT NULL, password VARCHAR(30) NOT NULL);
INSERT INTO employees VALUES ('Niranjan', 'Technical', 'niranjan@gmail.com', 'niranjan@123');
INSERT INTO employees VALUES ('Steve',    'Finance',   'steve@gmail.com',    'steve@123');
INSERT INTO employees VALUES ('Tony',     'Legal',     'tony@gmail.com',     'tony@123');
INSERT INTO employees VALUES ('Mark',     'Technical', 'mark@gmail.com',     'mark@123');
INSERT INTO employees VALUES ('Jessica',  'R and D',     'jessica@gmail.com',  'jessica@123');
INSERT INTO employees VALUES ('Chris',    'Finance',   'chris@gmail.com',    'chris@123');
INSERT INTO employees VALUES ('Benedict', 'Sales',     'benedict@gmail.com', 'benedict@123');
INSERT INTO employees VALUES ('Scarlett', 'Legal',     'scarlett@gmail.com', 'scarlett@123');
INSERT INTO employees VALUES ('Clint',    'Sales',     'clint@gmail.com',    'clint@123');
INSERT INTO employees VALUES ('Sam',      'Technical', 'sam@gmail.com',      'sam@123');
SELECT * FROM employees;

-- 2. Assets Table:
CREATE TABLE assets (asset_id INT PRIMARY KEY IDENTITY, name VARCHAR(20) NOT NULL, type VARCHAR(10) NOT NULL,
					 serial_number INT NOT NULL, purchase_date DATE NOT NULL, location VARCHAR(20) NOT NULL,
					 status VARCHAR(20) NOT NULL, owner_id INT FOREIGN KEY REFERENCES employees(employee_id));
INSERT INTO assets VALUES ('DELL Computer Setup', 'Laptop',     1, '2024-01-02', 'Chennai',   'Under Maintenance',  2);
INSERT INTO assets VALUES ('HP Computer Setup',   'Laptop',     2, '2024-01-03', 'Mumbai',    'In Use',             3);
INSERT INTO assets VALUES ('Fortuner',            'Vehicle',    3, '2024-01-03', 'Delhi',     'Decommissioned',     4);
INSERT INTO assets VALUES ('Hardware Kit',        'Equipment',  4, '2024-01-09', 'Bengaluru', 'In Use',             2);
INSERT INTO assets VALUES ('Google Pixel Mobile', 'Equipment',  5, '2024-01-10', 'Pune',      'In Use',             1);
INSERT INTO assets VALUES ('Activa',              'Vehicle',    6, '2024-02-15', 'Bengaluru', 'Decommissioned',     4);
INSERT INTO assets VALUES ('Measurement Kit',     'Equipment',  7, '2024-02-24', 'Chennai',   'Decommissioned',     4);
INSERT INTO assets VALUES ('Generator',           'Equipment',  8, '2024-03-27', 'Mumbai',    'Under Maintenance',  9);
INSERT INTO assets VALUES ('ASUS Computer Setup', 'Laptop',     9, '2024-04-14', 'Delhi',     'In Use',             5);
INSERT INTO assets VALUES ('Ola EV Scooter',      'Vehicle',   10, '2024-05-21', 'Pune',      'Decommissioned',     4);
SELECT * FROM assets;
-- 3. Maintenance Records Table:CREATE TABLE maintenance_records (maintenance_id INT PRIMARY KEY IDENTITY,								  asset_id INT FOREIGN KEY REFERENCES assets(asset_id) NOT NULL,								  maintenance_date DATE NOT NULL, description VARCHAR(50) NOT NULL, cost FLOAT NOT NULL);INSERT INTO maintenance_records VALUES (1, '2024-03-31', 'Cleanup and Software Updates',  200.00);INSERT INTO maintenance_records VALUES (8, '2024-04-27', 'Sensor and Meter Calibration', 1000.00);SELECT * FROM maintenance_records;
-- 4. Asset Allocations Table:
CREATE TABLE asset_allocations (allocation_id INT PRIMARY KEY IDENTITY,
								asset_id INT FOREIGN KEY REFERENCES assets(asset_id) NOT NULL,
								employee_id INT FOREIGN KEY REFERENCES employees(employee_id) NOT NULL,
								allocation_date DATE NOT NULL, return_date DATE DEFAULT NULL);
INSERT INTO asset_allocations VALUES (1, 2, '2024-01-09', NULL);
INSERT INTO asset_allocations VALUES (2, 3, '2024-01-04', '2024-01-21');
INSERT INTO asset_allocations VALUES (4, 2, '2024-01-10', NULL);
INSERT INTO asset_allocations VALUES (5, 1, '2024-01-11', NULL);
INSERT INTO asset_allocations VALUES (8, 9, '2024-04-01', NULL);
INSERT INTO asset_allocations VALUES (9, 5, '2024-04-15', NULL);
SELECT * FROM asset_allocations;-- 5. Reservations TableCREATE TABLE reservations (reservation_id INT PRIMARY KEY IDENTITY,						   asset_id INT FOREIGN KEY REFERENCES assets(asset_id) NOT NULL,						   employee_id INT FOREIGN KEY REFERENCES employees(employee_id) NOT NULL,						   reservation_date DATE NOT NULL, start_date DATE NOT NULL,						   end_date DATE NOT NULL, status VARCHAR(10) NOT NULL);INSERT INTO reservations VALUES ( 3, 1, '2024-09-12', '2024-10-01', '2024-10-07', 'Cancelled');INSERT INTO reservations VALUES ( 5, 2, '2024-09-18', '2024-10-01', '2024-10-31', 'Pending');INSERT INTO reservations VALUES ( 7, 8, '2024-09-20', '2024-10-08', '2024-10-21', 'Approved');INSERT INTO reservations VALUES (10, 4, '2024-09-21', '2024-10-09', '2024-10-15', 'Pending');SELECT * FROM reservations;