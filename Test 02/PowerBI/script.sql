CREATE DATABASE MultiStoreDW;
GO

USE MultiStoreDW;
GO

CREATE SCHEMA stage;
GO

CREATE TABLE stage.MultiStore (
    OrderID NVARCHAR(20),
    OrderDate DATE,
    ShipDate DATE,
    ShipMode NVARCHAR(50),
    CustomerID NVARCHAR(20),
    CustomerName NVARCHAR(100),
    CustomerAge INT,
    CustomerBirthday NVARCHAR(5),
    CustomerState NVARCHAR(50),
    Segment NVARCHAR(50),
    Country NVARCHAR(50),
    City NVARCHAR(50),
    State NVARCHAR(50),
    RegionalManagerID NVARCHAR(20),
    RegionalManager NVARCHAR(100),
    PostalCode NVARCHAR(20),
    Region NVARCHAR(50),
    ProductID NVARCHAR(20),
    Category NVARCHAR(50),
    SubCategory NVARCHAR(50),
    ProductName NVARCHAR(MAX),
    Sales DECIMAL(18, 2),
    Quantity INT,
    Discount DECIMAL(18, 2),
    Profit DECIMAL(18, 2)
);
GO
