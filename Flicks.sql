use master
go
CREATE DATABASE Flicks
go
use Flicks
go
create table Movies
(
	[Movie ID] varchar(6) primary key not null,
	Name varchar(30) not null,
	[Language] varchar(10) not null,
	Genres varchar(10),
	Rating smallint ,
	[Stock Available] smallint,
	[Total Stock] smallint,
	[BlueRay Price] money,
	[Total Units rented] smallint,
	[Revenue Generated] money
)

go
create PROCEDURE [dbo].[sp_InsertMovie]
	-- Add the parameters for the stored procedure here
	@Name varchar(30),
	@Language varchar(10),
	@Genres varchar(10),
	@BlueRayPrice money,
	@Rating smallint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Movies(Name,[Language],Genres,[BlueRay Price],Rating) values(@Name,@Language,@Genres,@BlueRayPrice,@Rating);
END



go
create table Customers 
(
	[Mobile Number] varchar(10) primary key not null,
	[Password] varchar(15) not null,
	CID varchar(6) unique not null,
	Name varchar(50) not null,
	Category varchar(1) not null,
	[Movies Rented] int not null,
	EmailID varchar(20) unique not null,
	BirthDate DateTime,
	[Address] varchar(60) not null,
	[City] varchar(15) not null,
	[Region] varchar(15) not null,
	[PostalCode] varchar(10) not null,
	[Country] varchar(15) not null,
)
go
create table Admin
(
	AdminID varchar(10) primary key not null,
	[Password] varchar(15) not null,
	Name varchar(50) not null
)
go
create table [Movies Rented]
(
	[RentID] varchar(10) primary key not null,
	MID varchar(6) foreign key references Movies, 
	[Mobile Number] varchar(10) unique not null Foreign key references Customers,
	[Rented DateTime] DateTime not null,
	[Returned DateTime] DateTime not null,
	[Rent Amount] money not null,
    [Paid Or Not] bit not null, 
)
go
create table [Currently Rented]
(
	[RentID] varchar(10) primary key not null,
	MID varchar(6) foreign key references Movies, 
	[Mobile Number] varchar(10) unique not null Foreign key references Customers, 
	[Rented DateTime] DateTime not null
)