# SalesDatePrediction

Desarrollado en .Net Core 6 y Angular 15.0.0.1

# Configuracion .Net
en appsettings.json verificar la conexion cadena sql quien se conecta a nuestra base de datos, cambiar usuario y credencial, en este caso se utilizo el usuario SA

# Consultas SQL a la base de datos

# 1: Sales Date Prediction 
create procedure Date_Prediction
as
begin
select o.custid,C.contactname, max(O.orderdate) as LastOrderDate , dateadd(DAY,avg(cast(FORMAT(orderdate,'dd')as int)),max(orderdate)) as NextPredictedOrder from Sales.Orders as O inner join Sales.Customers as C on O.custid=C.custid group by  o.custid,C.contactname;
end

# 2: Get Client Orders
create procedure  Client_Orders
(
@custid int
)as
begin
select orderid,requireddate,shippeddate,shipname,shipaddress,shipcity from Sales.Orders where custid=@custid;
end

# 3: Get employees
create procedure Get_employees
as
begin
select empid, (firstname + ' ' + lastname) as nombres from HR.Employees;
end

# 4: Get Shippers
create procedure Get_Shippers
as
begin
select shipperid, companyname from Sales.Shippers;
end

# 5: Get Products
create procedure Get_Products
as
begin
select productid,productname from Production.Products;
end

# 6: AddNewOrder
create procedure AddNewOrder
(
@empid	int,
@shipperid int,
@shipname nvarchar(40),
@shipaddress nvarchar(60),
@shipcity nvarchar(15),	
@orderdate	datetime,
@requireddate datetime,
@shippeddate datetime,
@freight money,
@shipcountry nvarchar(15),
@productid int,
@unitprice money,
@qty smallint,
@discount numeric
)as
begin
insert into Sales.Orders(empid,shipperid,shipname,shipaddress,shipcity,orderdate,requireddate,shippeddate,freight,shipcountry) values (@empid,@shipperid,@shipname,@shipaddress,@shipcity,@orderdate,@requireddate,@shippeddate,@freight,@shipcountry)
insert into Sales.OrderDetails(orderid,productid,unitprice,qty,discount) values((select top 1 orderid from Sales.Orders order by orderid desc),@productid,@unitprice,@qty,@discount)
end

# Para correr:
En .Net utilizar Visual Studio, se hace implementacion en Swagger con endpoint http://localhost:5038/api/
En angular ejecutar ng serve se ejecutara en http://localhost:4200/

# Imagenes de funcionamiento

(https://github.com/bamc300/SalesDatePrediction/blob/main/Customers.png)
(https://github.com/bamc300/SalesDatePrediction/blob/main/ModalOrders.png)
(https://github.com/bamc300/SalesDatePrediction/blob/main/ModalAddOrder.png)