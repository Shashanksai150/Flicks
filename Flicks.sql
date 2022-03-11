go
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
	[Language] varchar(30) not null,
	Genres varchar(30),
	[Year] int,
	Rating decimal,
	[Stock Available] smallint,
	[Total Stock] smallint,
	[BlueRay Price] money,
	[Total Units rented] smallint,
	[Revenue Generated] money
)
go
    -- Insert statements for procedure here
SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Movie ID], [Title], [Mnum], [Language], [Genres], [Year], [Rating], [Stock Available], [Total Stock], [BlueRay Price], [Total Units rented], [Revenue Generated]) VALUES (N'A1EnSc', N'Avatar', 1, N'English', N'Sci-fi/Action', 2009, CAST(8 AS Decimal(18, 0)), 25, 50, CAST(1310.0000 AS Money), 500, CAST(10000.0000 AS Money))
INSERT INTO [dbo].[Movies] ([Movie ID], [Title], [Mnum], [Language], [Genres], [Year], [Rating], [Stock Available], [Total Stock], [BlueRay Price], [Total Units rented], [Revenue Generated]) VALUES (N'I5EnAd', N'Interstellar', 5, N'English', N'Adventure/Sci-fi', 2014, CAST(9 AS Decimal(18, 0)), 90, 90, CAST(999.0500 AS Money), 158, CAST(9151.5500 AS Money))
INSERT INTO [dbo].[Movies] ([Movie ID], [Title], [Mnum], [Language], [Genres], [Year], [Rating], [Stock Available], [Total Stock], [BlueRay Price], [Total Units rented], [Revenue Generated]) VALUES (N'I5EnSc', N'Inception', 3, N'English', N'Sci-fi/Action', 2010, CAST(9 AS Decimal(18, 0)), 60, 60, CAST(565.0500 AS Money), 100, CAST(15124.1200 AS Money))
INSERT INTO [dbo].[Movies] ([Movie ID], [Title], [Mnum], [Language], [Genres], [Year], [Rating], [Stock Available], [Total Stock], [BlueRay Price], [Total Units rented], [Revenue Generated]) VALUES (N'T3EnRo', N'Titanic', 2, N'English', N'Romance/Drama', 1997, CAST(8 AS Decimal(18, 0)), 100, 100, CAST(1010.0500 AS Money), 999, CAST(14521.2560 AS Money))
INSERT INTO [dbo].[Movies] ([Movie ID], [Title], [Mnum], [Language], [Genres], [Year], [Rating], [Stock Available], [Total Stock], [BlueRay Price], [Total Units rented], [Revenue Generated]) VALUES (N'T5EnSc', N'Tenet', 4, N'English', N'Sci-fi/Action', 2020, CAST(7 AS Decimal(18, 0)), 40, 40, CAST(565.0500 AS Money), 485, CAST(15415.5200 AS Money))
SET IDENTITY_INSERT [dbo].[Movies] OFF
select * from Movies
go

go
create PROCEDURE [dbo].[sp_InsertMovie]
	-- Add the parameters for the stored procedure here
	@Title varchar(30),
	@year int,
	@Language varchar(10),
	@Genres varchar(10),
	@BlueRayPrice money,
	@Rating decimal,
	@TS smallint
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @MID varchar(10)
	select @MID = substring(SOUNDEX(@Title) ,1 , 2) + substring(@Language,1,2) + substring(@Genres,1,2); 
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
go
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table Customers 
(
	[Mobile Number] varchar(10) primary key not null,
	[Password] varchar(15) not null,
	CID int unique not null IDENTITY(1,1),
	Name varchar(50) not null,
	Category varchar(1) not null,
	[Last Password] DateTime ,
	[Password Limit Reached] bit,
	[Movies Rented] int not null,
	EmailID varchar(20) unique not null,
	[Address] varchar(60) not null,
	[City] varchar(15) not null,
	[Region] varchar(15) not null,
	[PostalCode] varchar(10) not null,
	[Country] varchar(15) not null
)
go
Insert into Customers([Mobile Number],Password,Name,Category,[Movies Rented],EmailID,Address,City,Region,PostalCode,Country) 
	values('8921254251','klm784de45!2%','Sham','P',3,'Sham938@gmail.com','Hno 41, Kindle srt','Nagpur','Maharastra','441414','India');

go
create PROCEDURE [dbo].[sp_InsertCustomers]
	-- Add the parameters for the stored procedure here
	@MobileNumber varchar(10),
	@Password varchar(15),
	@Name varchar(50),
	@Category varchar(1),
	@MR int,
	@LastPasschanged DateTime,
	@PLR bit,
	@EmailID varchar(20),
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
	set @LastPasschanged = CURRENT_TIMESTAMP;
	set @PLR = 0;
    -- Insert statements for procedure here
	Insert into Customers([Mobile Number],Password,Name,Category,[Movies Rented],EmailID,Address,City,Region,PostalCode,Country) 
	values(@MobileNumber,@Password,@Name,@Category,@MR,@EmailID,@Address,@City,@Region,@PostalCode,@Country);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateCustomers
	@MobileNumber varchar(10),
	@Password varchar(15),
	@Name varchar(50),
	@CID int,
	@Category varchar(1),
	@MR int,
	@EmailID varchar(20),
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
	Address = @Address,
	City = @City,
	Region = @Region,
	PostalCode = @PostalCode,
	Country = @Country
	where [Mobile Number] = @MobileNumber or CID = @CID;
RETURN 0

go
create procedure [dbo].Sp_PasswordResetCustomer
@number varchar(10),
@Paswordnew varchar(15)
as
update Customers 
set [Password] = @Paswordnew,
	[Last Password] = CURRENT_TIMESTAMP,
	[Password Limit Reached] = 0
where [Mobile Number] = @number;
return 0;

go
CREATE PROCEDURE [dbo].Sp_PasswordValidityCustomer
@number varchar(10),
@Today DateTime
AS
Declare @Lastpasswordreset DateTime;
Select @Lastpasswordreset = [Last Password] from Customers where @number = [Mobile Number];
set @Today = CURRENT_TIMESTAMP;
if ( abs(DATEDIFF(day,@Lastpasswordreset,@Today)) >= 30 )
update [Customers] set [Password Limit Reached] = 1 where @number = [Mobile Number];
Return 0
go

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table Admin
(
	AdminID varchar(10) primary key not null,
	[Password] varchar(15) not null,
	Name varchar(50) not null,
	Adminnum int not null unique IDENTITY(1,1),
	[Last Password] DateTime ,
	[Password Limit Reached] bit
)
go
Insert into Admin(AdminID,Password,Name) values('Judy4151','Judy','kdjme3234');
go
Insert into Admin(AdminID,Password,Name) values('Blake3451','Blake','flaked3102');
go
Insert into Admin(AdminID,Password,Name) values('Jane1894','Jane','mvkd212334@!');
go
Insert into Admin(AdminID,Password,Name) values('Sham31475','Sham','duillsdj4762');
go
Insert into Admin(AdminID,Password,Name) values('Ramu7451','Ramu','ramjjf54815');
go
select * from Admin
go
create PROCEDURE [dbo].[sp_InsertAdmin]
	-- Add the parameters for the stored procedure here
	@AdminID varchar(10),
	@Name varchar(50),
	@Password varchar(15),
	@LastPasschanged DateTime,
	@PLR bit
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	set @LastPasschanged = CURRENT_TIMESTAMP;
	set @PLR = 0;
	Insert into Admin(AdminID,Password,Name,[Password Limit Reached],[Last Password]) values(@AdminID,@Password,@Name,@PLR,@LastPasschanged);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateAdmin
	@AdminID varchar(10),
	@Password varchar(15),
	@Name varchar(50),
	@LastPasschanged DateTime,
	@PLR bit
AS
set @LastPasschanged = CURRENT_TIMESTAMP;
	set @PLR = 0;
	UPDATE Admin
	Set  Name = @Name,
	Password = @Password,
	[Last Password] = @LastPasschanged,
	[Password Limit Reached] = @PLR
	where @AdminID = AdminID;
RETURN 0

go
create procedure [dbo].Sp_PasswordResetAdmin
@AdminID varchar(10),
@Paswordnew varchar(15)
as
update Admin
set [Password] = @Paswordnew,
	[Last Password] = CURRENT_TIMESTAMP,
	[Password Limit Reached] = 0
where @AdminID = AdminID;
return 0;

go
CREATE PROCEDURE [dbo].Sp_PasswordvalidityAdmin
@AdminID varchar(10),
@Today DateTime
AS
Declare @Lastpasswordreset DateTime;
Select @Lastpasswordreset = [Last Password] from Admin where AdminID = @AdminID;
set @Today = CURRENT_TIMESTAMP;
if ( abs(DATEDIFF(day,@Lastpasswordreset,@Today)) >= 30 )
update Admin set [Password Limit Reached] = 1 where AdminID = @AdminID;
Return 0
go
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
	@MID varchar(10), 
	@MN varchar(10),
	@RentDT DateTime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @RentID varchar(20), @TS smallint , @midt varchar(10);
	set @RentID = @MID + substring(@MN,1,3);
	SET @RentDT = CURRENT_TIMESTAMP;

	SELECT @TS = [Total Stock], @midt = [Movie ID] FROM Movies as m where m.[Movie ID] = @MID
	update Movies set [Stock Available] = [Stock Available] - 1, [Total Units rented] = [Total Units rented] + 1 where @MID = @midt
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
declare @TS smallint , @midt varchar(10);
	set @RentID = @MID + substring(@MN,1,3);
	SET @RentDT = CURRENT_TIMESTAMP;

	SELECT @TS = [Total Stock], @midt = [Movie ID] FROM Movies as m where m.[Movie ID] = @MID
	update Movies set [Stock Available] = [Stock Available] - 1, [Total Units rented] = [Total Units rented] + 1 where @MID = @midt
	UPDATE[Currently Rented]
	Set  MID = @MID,
	[Mobile Number] = @MN,
	[Rented DateTime] = @RentDT
	where @RentID = RentID;
RETURN 0

go
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

go
create table [Movies Rented]
(
	[RentID] varchar(10) primary key not null,
	MID varchar(10) foreign key references Movies, 
	[Mobile Number] varchar(10) unique not null Foreign key references Customers,
	[Rented DateTime] DateTime not null ,
	[Returned DateTime] DateTime not null,
	[Days Rented] int,
	[Rent Amount] money not null,
	[Returned] bit,
    [Paid Or Not] bit not null, 
)

go
create PROCEDURE [dbo].[sp_InsertMR]
	-- Add the parameters for the stored procedure here
	@RentID varchar(16),
	@Returned bit,
    @PON bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	declare @RentAmount money,@BRP money, @RentDT DateTime, @DaysR int,@MID varchar(10),@MN varchar(10),@ReturnDT DateTime;
	Select @RentID = RentID,@RentDT = [Rented DateTime],@MID = MID,@MN = [Mobile Number] from [Currently Rented] as cr where cr.RentID = @RentID;
	select @BRP =[BlueRay Price] from Movies as m where m.[Movie ID] = @MID 

	SET NOCOUNT ON;
	SET @ReturnDT = CURRENT_TIMESTAMP  while (@Returned = 1)
	set @DaysR = Datediff(day ,@RentDT,@ReturnDT) while (@Returned = 1)
	set @RentAmount = ((@DaysR * (@BRP * 0.1)) * 1.8) while (@Returned = 1)
	update Movies set [Revenue Generated] = [Revenue Generated] + @BRP where [Movie ID] = @MID and @PON = 1 and @Returned = 1
    -- Insert statements for procedure here
	Insert into [Movies Rented] (RentID,MID,[Mobile Number],[Rented DateTime],[Returned DateTime],[Rent Amount],[Paid Or Not]) 
	values(@RentID,@MID,@MN,@RentDT,@ReturnDT,@RentAmount,@PON);
END

go
CREATE PROCEDURE [dbo].Sp_UpdateMR
	@RentID varchar(10),
	@Returned bit,
    @PON bit
AS
	declare @RentAmount money,@BRP money, @RentDT DateTime, @DaysR int,@MID varchar(10),@MN varchar(10),@ReturnDT DateTime;
	Select @RentID = RentID,@RentDT = [Rented DateTime],@MID = MID,@MN = [Mobile Number] from [Currently Rented] as cr where cr.RentID = @RentID;
	select @BRP =[BlueRay Price] from Movies as m where m.[Movie ID] = @MID

	SET NOCOUNT ON;
	SET @ReturnDT = CURRENT_TIMESTAMP  while (@Returned = 1)
	set @DaysR = Datediff(day ,@RentDT,@ReturnDT) while (@Returned = 1)
	set @RentAmount = ((@DaysR * (@BRP * 0.1)) * 1.8) while (@Returned = 1)
	update Movies set [Revenue Generated] = [Revenue Generated] + @BRP where [Movie ID] = @MID and @Returned = 1
	UPDATE [Movies Rented]
	Set  MID = @MID,
	[Mobile Number] = @MN,
	[Rented DateTime] = @RentDT,
	[Returned DateTime] = @ReturnDT,
	[Returned] = @Returned,
	[Rent Amount] = @RentAmount,
	[Paid Or Not] = @PON
	where @RentID = RentID;
RETURN 0