create database OrderDb
use OrderDb

create table Customers
(CId int primary key identity(101,1),
FName nvarchar(50) not null,
LName nvarchar(50) not null
)

insert into Customers(FName, LName) values
('Anup','Gupta'),
('Ravi','Kisan'),
('Pavan','Kalyan')
select * from Customers

create table Orders
(OId int primary key identity(1001,2),
ODate datetime,
TotalAmt float,
CId int foreign key (CId) references Customers (CId)
)

insert into Orders (ODate,TotalAmt,CId) values 
('05/04/2023 11:15:00',350.00,101),
('12/01/2023 16:30:45',550.99,102),
('07/07/2023 20:20:20',150.99,103)

select * from Orders


create proc pro_PlaceOrder
@cid int,
@totalamt float
as 
begin
declare @orderId int
insert into Orders (CId, ODate, TotalAmt)
values (@cid, GETDATE(), @totalamt)
set @orderId = SCOPE_IDENTITY()
select @orderId as OrderId
end

exec pro_PlaceOrder
@cid = 103,
@totalamt = 780.65

select * from Orders