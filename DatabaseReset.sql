Go
Delete
From OrderItems

Delete
From Orders

Delete
from Customers

INSERT INTO Customers
           (CustomerId, FirstName, LastName)
		   VALUES
           ('518B9A19-BD55-4497-A01F-2E48F23D8D30', 'Bugs','Bunny')
		   ,('01EEC648-89C6-4324-A732-165ADCD430C6','Porky', 'Pig')
		   ,('E21A6012-C4C4-48B8-B110-AA1AC9F64A32', 'Elmer', 'Fudd')
		   ,('974C1959-4C66-4463-8E3C-EEC2B01B6AED', 'Daffy','Duck')
		   ,('F88F8876-F298-4986-8CEA-5FDFDBEB85D9', 'Marvin','Martian')
		   ,('98607329-FADC-4FC6-9EEF-8A271AE0F590', 'Speedy','Gonzales')

Insert 
Into Orders
(OrderId, OrderDate, CustomerId, LocationId)
Values
('4B37C187-5959-4B6A-988F-11DD227544C8','2019-10-14 18:14:00','98607329-FADC-4FC6-9EEF-8A271AE0F590', 10)
,('1CAF42FC-456D-4C7E-9598-14660E4031F1','2019-10-15 08:40:00','E21A6012-C4C4-48B8-B110-AA1AC9F64A32', 30)
,('79E12058-AD00-42FA-A72C-3493CA422319','2019-10-14 19:53:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 30)
,('B7EB3974-BCE3-4F5C-B3AD-4BB67ED868F9','2019-10-15 08:33:00','E21A6012-C4C4-48B8-B110-AA1AC9F64A32', 30)
,('999A026A-C369-4951-9E1D-55BFD9E70263','2019-10-14 18:42:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 10)
,('6E0AD960-1B16-499C-80D4-6483C5A7D4DC','2019-10-14 18:59:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 20)
,('FC264CD2-E609-42D9-9257-66C87055C684','2019-10-14 18:13:00','01EEC648-89C6-4324-A732-165ADCD430C6', 30)
,('0FE785E1-05CF-4C67-A1C6-6A1BE439FFE3','2019-10-14 21:59:00','01EEC648-89C6-4324-A732-165ADCD430C6', 30)
,('426A4317-D379-498A-99B0-7B13CD9416B2','2019-10-14 18:06:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 20)
,('A529871D-9164-4576-9774-942917F2450A','2019-10-14 19:46:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 20)
,('1E2E71AB-6B95-4942-9B43-A12C9A4F06DE','2019-10-14 21:41:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 30)
,('C0B3D4F2-C8C2-4CD7-B590-A87829DB0CD9','2019-10-14 18:16:00','E21A6012-C4C4-48B8-B110-AA1AC9F64A32', 30)
,('89B37B3C-D3A3-475F-B6DD-C644FA9B761B','2019-10-14 00:14:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 10)
,('5FFF7297-78F6-441C-995C-F3A9903F6A8F','2019-10-14 23:48:00','01EEC648-89C6-4324-A732-165ADCD430C6', 20)
,('262383C6-072B-472E-9C31-F5A319692F46','2019-10-14 18:50:00','518B9A19-BD55-4497-A01F-2E48F23D8D30', 30)

Insert 
Into OrderItems
(OrderId, ProductId, Quantity)
Values
('1CAF42FC-456D-4C7E-9598-14660E4031F1', '4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB', 1)
,('79E12058-AD00-42FA-A72C-3493CA422319', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 2)
,('B7EB3974-BCE3-4F5C-B3AD-4BB67ED868F9', '4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB', 5)
,('999A026A-C369-4951-9E1D-55BFD9E70263', '2676B569-53D9-4AA1-9139-457217B570E7', 1)
,('999A026A-C369-4951-9E1D-55BFD9E70263', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 3)
,('999A026A-C369-4951-9E1D-55BFD9E70263', 'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336', 4)
,('6E0AD960-1B16-499C-80D4-6483C5A7D4DC', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 5)
,('FC264CD2-E609-42D9-9257-66C87055C684', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 2)
,('FC264CD2-E609-42D9-9257-66C87055C684', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 3)
,('0FE785E1-05CF-4C67-A1C6-6A1BE439FFE3', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 4)
,('0FE785E1-05CF-4C67-A1C6-6A1BE439FFE3', '5526D7E3-22AE-467F-993F-D9F0D8725DDF', 6)
,('426A4317-D379-498A-99B0-7B13CD9416B2', '2676B569-53D9-4AA1-9139-457217B570E7', 7)
,('426A4317-D379-498A-99B0-7B13CD9416B2', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 2)
,('426A4317-D379-498A-99B0-7B13CD9416B2', 'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336', 1)
,('A529871D-9164-4576-9774-942917F2450A', 'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336', 3)
,('A529871D-9164-4576-9774-942917F2450A', '5526D7E3-22AE-467F-993F-D9F0D8725DDF', 2)
,('1E2E71AB-6B95-4942-9B43-A12C9A4F06DE', '2676B569-53D9-4AA1-9139-457217B570E7', 4)
,('1E2E71AB-6B95-4942-9B43-A12C9A4F06DE', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 5)
,('C0B3D4F2-C8C2-4CD7-B590-A87829DB0CD9', '2676B569-53D9-4AA1-9139-457217B570E7', 6)
,('C0B3D4F2-C8C2-4CD7-B590-A87829DB0CD9', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 1)
,('C0B3D4F2-C8C2-4CD7-B590-A87829DB0CD9', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 2)
,('89B37B3C-D3A3-475F-B6DD-C644FA9B761B', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 5)
,('89B37B3C-D3A3-475F-B6DD-C644FA9B761B', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 3)
,('5FFF7297-78F6-441C-995C-F3A9903F6A8F', '1765FA42-3EB7-4B87-A48B-C00598263BFC', 6)
,('5FFF7297-78F6-441C-995C-F3A9903F6A8F', '5526D7E3-22AE-467F-993F-D9F0D8725DDF', 1)
,('262383C6-072B-472E-9C31-F5A319692F46', '2676B569-53D9-4AA1-9139-457217B570E7', 2)
,('262383C6-072B-472E-9C31-F5A319692F46', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 4)
,('4B37C187-5959-4B6A-988F-11DD227544C8', '4C992AA8-13E0-42DF-968D-5ECD08A8CBCB', 1)
,('4B37C187-5959-4B6A-988F-11DD227544C8', '5526D7E3-22AE-467F-993F-D9F0D8725DDF', 3)

Delete
from locationstock

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
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,15),
		   (20
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,15),
		   (30
           ,'4C992AA8-13E0-42DF-968D-5ECD08A8CBCB'
           ,15),
		   (10
           ,'4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB'
           ,1000),
		   (20
           ,'4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB'
           ,1000),
		   (30
           ,'4A4AA035-8FB3-40E4-8FFD-7FB18B89C3CB'
           ,1000),
		   (10
           ,'1765FA42-3EB7-4B87-A48B-C00598263BFC'
           ,15),
		   (20
           ,'1765FA42-3EB7-4B87-A48B-C00598263BFC'
           ,15),
		   (30
           ,'1765FA42-3EB7-4B87-A48B-C00598263BFC'
           ,15),
		   (10
           ,'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336'
           ,15),
		   (20
           ,'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336'
           ,15),
		   (30
           ,'E7DCB4FE-8C80-4778-ACF5-C5ADD991F336'
           ,15),
		   (10
           ,'5526D7E3-22AE-467F-993F-D9F0D8725DDF'
           ,15),
		   (20
           ,'5526D7E3-22AE-467F-993F-D9F0D8725DDF'
           ,15),
		   (30
           ,'5526D7E3-22AE-467F-993F-D9F0D8725DDF'
           ,15)