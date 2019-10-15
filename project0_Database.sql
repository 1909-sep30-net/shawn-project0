
Go
--Drop Table Customers
Create Table Customers(
	CustomerId uniqueidentifier NOT NULL Default newid() Primary Key,
	FirstName nvarchar(40) NOT NULL,
	LastName nvarchar(40) NOT NULL)

--Drop Table Locations
Create Table Locations(
	LocationId int NOT NULL Identity(10, 10) Primary Key,
	LocationName varchar(80) NOT NULL)

--Drop Table Products
Create Table Products(
	ProductId uniqueidentifier NOT NULL Default newid() Primary Key,
	ProductName nvarchar(80) NOT NULL,
	ProductDesc nvarchar(200) NOT NULL
	)

--Drop Table LocationStock
Create Table LocationStock(
	LocationId int Not Null,
	ProductId uniqueidentifier Not Null,
	Quantity int Not Null,
	CONSTRAINT FK_LocationStockProducts Foreign Key (ProductId) References Products(ProductId),
	CONSTRAINT FK_LocationStockLocations Foreign Key (LocationId) References Locations,
	Primary Key(LocationId, ProductId)
	)

--Drop Table Orders
Create Table Orders(
	OrderId uniqueidentifier NOT NULL Default newid() Primary Key,
	OrderDate smalldatetime not null DEFAULT Getdate(),
	CustomerID uniqueidentifier Not null,
	LocationId int Not null,
	CONSTRAINT FK_OrdersLocationId Foreign Key (LocationId) References Locations(LocationId),
	CONSTRAINT FK_OrdersCustomerId Foreign Key (CustomerId) References Customers(CustomerId)
	)

--Drop Table OrderItems
Create Table OrderItems(
	OrderId uniqueidentifier Not Null,
	ProductId uniqueidentifier Not Null,
	Quantity int,
	CONSTRAINT FK_OrderItemsProductId Foreign Key (ProductId) References Products(ProductId),
	Primary Key(OrderId, ProductId)
	)

--Add A Customer
GO

INSERT INTO Customers
           (FirstName
           ,LastName)
     VALUES
           ('Elmer'
           ,'Fudd')
GO

select *
from customers

Select *
From locationstock

select *
from orders

select *
from orders
where customerid = '518B9A19-BD55-4497-A01F-2E48F23D8D30'

select *
from orderitems
where orderid = '3f365a89-ff03-4c93-8fc3-809bcfa718e6'

select * from locations

Update locationstock
set quantity = 80
where productid = '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'

Select *
from products

Select *
from orders

--Delete
--from Orders
--Where orderid = '58E594D2-E54A-43D1-AC89-2C27E835A343'

--Delete
--From Customers
--Where (Customers.FirstName='Marvin')


GO

INSERT INTO Locations
           (LocationName)
     VALUES
           ('Bananas Enlighten')

INSERT INTO Locations
           (LocationName)
     VALUES
           ('Retro Bananas')
INSERT INTO Locations
           (LocationName)
     VALUES
           ('HighFive Bananas')

GO

USE [project0]
GO

INSERT INTO Products
           (ProductName
           ,ProductDesc)
     VALUES
           ('Unit Testing Bananas'
           ,'These are for Unit Testing, do not mess with them!'),
		   ('Banana Phone'
           ,'Ring, Ding, Ding, Ding... BANANA PHONE!'),
		   ('Banana First Aid Kit'
           ,'A first aid kit to aid in helping bruised bananas.')

GO

Select *
from orderitems
where orderid = '641c0786-0923-46cf-882c-579cdcc1f549'

Select * from orderitems
where orderid='7DC7B837-30A0-4DE6-AEA7-1CE70CC18B20'

USE [project0]
GO

update LocationStock
set quantity = '1000'
where productid = '4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB'



INSERT INTO LocationStock
           (LocationId
           ,ProductId
           ,Quantity)
     VALUES
           (10
           ,'2676B569-53D9-4AA1-9139-457217B570E7'
           ,15),
		   (20
           ,'2676B569-53D9-4AA1-9139-457217B570E7'
           ,15),
		   (30
           ,'2676B569-53D9-4AA1-9139-457217B570E7'
           ,15),
		   (10
           ,'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336'
           ,15),
		   (20
           ,'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336'
           ,15),
		   (30
           ,'4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB'
           ,15)
GO
Select *
from Locationstock

Select *
from Products

select *
from Orders

GO

INSERT INTO Orders
           (
           [CustomerID]
           ,[LocationId])
     VALUES
           (
           '518B9A19-BD55-4497-A01F-2E48F23D8D30'
           ,10
		   ),
		   (
           '518B9A19-BD55-4497-A01F-2E48F23D8D30'
           ,10
		   ),
		   (
           '518B9A19-BD55-4497-A01F-2E48F23D8D30'
           ,10
		   ),
		   (
           'E21A6012-C4C4-48B8-B110-AA1AC9F64A32'
           ,20
		   ),
		   (
           'E21A6012-C4C4-48B8-B110-AA1AC9F64A32'
           ,20
		   ),
		   (
           '974C1959-4C66-4463-8E3C-EEC2B01B6AED'
           ,30
		   )
GO

USE [project0]
GO

INSERT INTO OrderItems
           (OrderId
           ,ProductId
           ,Quantity)
     VALUES
           ('7DC7B837-30A0-4DE6-AEA7-1CE70CC18B20'
           ,'1765FA42-3EB7-4B87-A48B-C00598263BFC'
           ,1),
		   ('7DC7B837-30A0-4DE6-AEA7-1CE70CC18B20'
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,3),
		   ('1FB374AC-5FC3-4926-A696-3DA5ADE08EDA'
           ,'1765FA42-3EB7-4B87-A48B-C00598263BFC'
           ,5),('583E423E-B4D2-4919-A9A9-75E9C86CF5FC'
           ,'5526D7E3-22AE-467F-993F-D9F0D8725DDF'
           ,1),
		   ('0AB53BC4-B9D5-4B73-A34C-634E891111F0'
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,3),
		   ('0AB53BC4-B9D5-4B73-A34C-634E891111F0'
           ,'5526D7E3-22AE-467F-993F-D9F0D8725DDF'
           ,5),('05A33886-F291-4941-9281-ED6736AADA0C'
           ,'1765FA42-3EB7-4B87-A48B-C00598263BFC'
           ,1),
		   ('05A33886-F291-4941-9281-ED6736AADA0C'
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,3),
		   ('3F365A89-FF03-4C93-8FC3-809BCFA718E6'
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,5)

GO
select *
From OrderItems

