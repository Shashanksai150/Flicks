use master
go
CREATE DATABASE Flicks
go
use Flicks
go
create table Movies
(
	[Movie ID] varchar(10) primary key not null,
	Title varchar(30) not null,
	Mnum int unique not null IDENTITY(1,1),
	[Language] varchar(10) not null,
	Genres varchar(10),
	[Year] int,
	Rating decimal,
	[Stock Available] smallint,
	[Total Stock] smallint,
	[BlueRay Price] money,
	[Total Units rented] smallint,
	[Revenue Generated] money
)

go
create PROCEDURE [dbo].[sp_InsertMovie]
	-- Add the parameters for the stored procedure here
	@Title varchar(30),
	@MID varchar(6),
	@year int,
	@Language varchar(10),
	@Genres varchar(10),
	@BlueRayPrice money,
	@Rating decimal,
	@TS smallint,
	@Mnum int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @MID = substring(SOUNDEX(@Title) ,1 , 2) + substring(@Language,1,2) + substring(@Language,1,1) + @Mnum;
    -- Insert statements for procedure here
	Insert into Movies([Movie ID],Title,[Language],[Year],Genres,[BlueRay Price],Rating,[Total Stock]) values(@MID,@Title,@Language,@year,@Genres,@BlueRayPrice,@Rating,@TS);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateMovie
	@MID varchar(6),
	@Title varchar(30),
	@Language varchar(10),
	@year int,
	@Genres varchar(10),
	@BlueRayPrice money,
	@Rating smallint,
	@TS smallint
AS
	UPDATE Movies
	Set  Title = @Title,
	[Language] = @Language,
	Genres = @Genres,
	[Year] = @year,
	[BlueRay Price] = @BlueRayPrice,
	Rating = @Rating,
	[Total Stock] = @TS
	where [Movie ID] = @MID;
RETURN 0


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table Customers 
(
	[Mobile Number] varchar(10) primary key not null,
	[Password] varchar(15) not null,
	CID int unique not null IDENTITY(1,1),
	Name varchar(50) not null,
	Category varchar(1) not null,
	[Movies Rented] int not null,
	EmailID varchar(20) unique not null,
	BirthDate DateTime,
	[Address] varchar(60) not null,
	[City] varchar(15) not null,
	[Region] varchar(15) not null,
	[PostalCode] varchar(10) not null,
	[Country] varchar(15) not null
)

go
create PROCEDURE [dbo].[sp_InsertCustomers]
	-- Add the parameters for the stored procedure here
	@MobileNumber varchar(10),
	@Password varchar(15),
	@CID varchar(6) ,
	@Name varchar(50),
	@Category varchar(1),
	@MR int,
	@EmailID varchar(20),
	@BirthDate DateTime,
	@Address varchar(60),
	@City varchar(15),
	@Region varchar(15),
	@PostalCode varchar(10),
	@Country varchar(15)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert into Customers([Mobile Number],Password,Name,Category,[Movies Rented],EmailID,BirthDate,Address,City,Region,PostalCode,Country) 
	values(@MobileNumber,@Password,@Name,@Category,@MR,@EmailID,@BirthDate,@Address,@City,@Region,@PostalCode,@Country);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateCustomers
	@MobileNumber varchar(10),
	@Password varchar(15),
	@CID varchar(6) ,
	@Name varchar(50),
	@Category varchar(1),
	@MR int,
	@EmailID varchar(20),
	@BirthDate DateTime,
	@Address varchar(60),
	@City varchar(15),
	@Region varchar(15),
	@PostalCode varchar(10),
	@Country varchar(15)
AS
	UPDATE Customers
	Set  
	Name = @Name,
	Category = @Category,
	[Movies Rented] = @MR,
	EmailID = @EmailID,
	BirthDate = @BirthDate,
	Address = @Address,
	City = @City,
	Region = @Region,
	PostalCode = @PostalCode,
	Country = @Country
	where [Mobile Number] = @MobileNumber or CID = @CID;
RETURN 0

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table Admin
(
	AdminID varchar(10) primary key not null,
	[Password] varchar(15) not null,
	Name varchar(50) not null,
	Adminnum int not null unique IDENTITY(1,1)
)

go
create PROCEDURE [dbo].[sp_InsertAdmin]
	-- Add the parameters for the stored procedure here
	@AdminID varchar(10),
	@Password varchar(15),
	@Name varchar(50),
	@NUM int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @AdminID =  SUBSTRING(@Name,1,3) + @NUM 
    -- Insert statements for procedure here
	Insert into Admin(AdminID,Password,Name) values(@AdminID,@Password,@Name);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateAdmin
	@AdminID varchar(10),
	@Password varchar(15),
	@Name varchar(50)
AS
	UPDATE Admin
	Set  Name = @Name,
	Password = @Password
	where @AdminID = AdminID;
RETURN 0

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table [Currently Rented]
(
	[RentID] varchar(16) primary key not null ,
	MID varchar(10) foreign key references Movies, 
	[Mobile Number] varchar(10) unique not null Foreign key references Customers, 
	[Rented DateTime] DateTime not null,
	NUM int not null unique IDENTITY(1,1)
)

go
create PROCEDURE [dbo].[sp_InsertCR]
	-- Add the parameters for the stored procedure here
	@RentID varchar(16),
	@MID varchar(10), 
	@MN varchar(10),
	@RentDT DateTime,
	@num int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @RentID = @MID + @num;
	SET @RentDT = CURRENT_TIMESTAMP;
    -- Insert statements for procedure here
	Insert into [Currently Rented] (RentID,MID,[Mobile Number],[Rented DateTime]) values(@RentID,@MID,@MN,@RentDT);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateCR
	@RentID varchar(16),
	@MID varchar(6), 
	@MN varchar(10),
	@RentDT DateTime
AS
	UPDATE [Movies Rented]
	Set  MID = @MID,
	[Mobile Number] = @MN,
	[Rented DateTime] = @RentDT
	where @RentID = RentID;
RETURN 0


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table [Movies Rented]
(
	[RentID] varchar(10) primary key not null,
	MID varchar(10) foreign key references Movies, 
	[Mobile Number] varchar(10) unique not null Foreign key references Customers,
	[Rented DateTime] DateTime not null ,
	[Returned DateTime] DateTime not null,
	[Rent Amount] money not null,
    [Paid Or Not] bit not null, 
)

go
create PROCEDURE [dbo].[sp_InsertMR]
	-- Add the parameters for the stored procedure here
	@RentID varchar(10),
	@MID varchar(10), 
	@MN varchar(10),
	@RentDT DateTime,
	@ReturnDT DateTime,
	@RentAmount money,
    @PON bit,
	@CRTD DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Select @RentDT = [Rented DateTime] from [Currently Rented] as cr where cr.[Rented DateTime] = @RentDT;
	Select @RentID = RentID from [Currently Rented] as cr where cr.RentID = @RentID;
	SET NOCOUNT ON;
	SET @RentDT = @CRTD;
    -- Insert statements for procedure here
	Insert into [Movies Rented] (RentID,MID,[Mobile Number],[Rented DateTime],[Returned DateTime],[Rent Amount],[Paid Or Not]) values(@RentID,@MID,@MN,@RentDT,@ReturnDT,@RentAmount,@PON);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateMR
	@RentID varchar(10),
	@MID varchar(6), 
	@MN varchar(10),
	@RentDT DateTime,
	@ReturnDT DateTime,
	@RentAmount money,
    @PON bit
AS
	UPDATE [Movies Rented]
	Set  MID = @MID,
	[Mobile Number] = @MN,
	[Rented DateTime] = @RentDT,
	[Returned DateTime] = @ReturnDT,
	[Rent Amount] = @RentAmount,
	[Paid Or Not] = @PON
	where @RentID = RentID;
RETURN 0