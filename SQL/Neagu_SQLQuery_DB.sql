CREATE DATABASE KruzeAutoDB;
GO

USE KruzeAutoDB;

CREATE TABLE [Users](
	[UserID] uniqueidentifier NOT NULL,
	[Email] nvarchar(50) NOT NULL,
	[UserName] nvarchar(50) NOT NULL,
	[Password] nvarchar(50) NOT NULL,
	[PhoneNumber] nvarchar(50) NOT NULL,
	[CreationDate] date NOT NULL,
	[Subscribed] bit NOT NULL,
CONSTRAINT [PK_Users] PRIMARY KEY ([UserID]));

CREATE TABLE [UserLocation](
	[UserID] uniqueidentifier NOT NULL,
	[Country] nvarchar(50) NOT NULL,
	[County] nvarchar(50) NOT NULL,
	[City] nvarchar(50) NOT NULL,
CONSTRAINT [PK_UserLocation] PRIMARY KEY ([UserID]),
CONSTRAINT [FK_UserLocation_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]));

--cars, motorcycles, motorhomes, vans, Truks, Trailers, Semitrailers, Buses, ConstructionMachines, AgriculturalVehicles, ForkliftTruks
CREATE TABLE [Annoucements](
	[AnnoucementID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[VehicleType] int NOT NULL,
	[Views] int NOT NULL,
	[Promoted] bit,
	[Active] bit,
	[CreationDate] date NOT NULL,
	[Update] date,
	[Condition] nvarchar(15) NOT NULL,
	[Title] nvarchar(50) NOT NULL,
	[Brand] nvarchar(50) NOT NULL,
	[Model] nvarchar(50) NOT NULL,
	[Type] nvarchar(50) NOT NULL,
	[Kilometer] int,
	[FabricationYear] int NOT NULL,
	[VIN] nvarchar(50),
	[FuelType] nvarchar(25) NOT NULL,
	[Price] int NOT NULL,
	[NegociablePrice] bit,
	[Currency] nvarchar(3) NOT NULL,
	[Color] nvarchar(15),
	[ColorType] nvarchar(15),
	[Power] int,
	[Transmission] nvarchar(25),
	[CubicCapacity] int,
	[EmissionClass] nvarchar(15),
	[NumberOfSeats] int,
	[GVW] int,
	[LoadCapacity] int,
	[OperatingHours] int,
	[Description] text,
CONSTRAINT [PK_Annoucements] PRIMARY KEY ([AnnoucementID]),
CONSTRAINT [FK_Annoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]));

CREATE TABLE [Options](
	[OptionID] uniqueidentifier NOT NULL,
	[Name] nvarchar(50) NOT NULL
CONSTRAINT [PK_Options] PRIMARY KEY ([OptionID]));

CREATE TABLE [AnnouncementsOptions](
	[AnnoucementID] uniqueidentifier NOT NULL,
	[OptionID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_AnnouncementsOptions] PRIMARY KEY ([AnnoucementID],[OptionID]),
CONSTRAINT [FK_AnnouncementsOptions_Annoucements] FOREIGN KEY ([AnnoucementID])
	REFERENCES [Annoucements]([AnnoucementID]),
CONSTRAINT [FK_AnnouncementsOptions_Options] FOREIGN KEY ([OptionID])
	REFERENCES [Options]([OptionID]));

CREATE TABLE [MessageImbox](
	[MessageID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[AnnoucementID] uniqueidentifier NOT NULL,
	[CreationDate] date NOT NULL,
	[Read] bit,
	[MesageContent] text NOT NULL,
CONSTRAINT [PK_MesageImbox] PRIMARY KEY ([MessageID]),
CONSTRAINT [FK_MesageImbox_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_MessageImbox_Annoucements] FOREIGN KEY ([AnnoucementID])
	REFERENCES [Annoucements]([AnnoucementID]));

CREATE TABLE [Pictures](
	[PictureID] uniqueidentifier NOT NULL,
	[Picture] image,
CONSTRAINT [PK_Pictures] PRIMARY KEY ([PictureID]));

CREATE TABLE [UsersPictures](
	[UserID] uniqueidentifier NOT NULL,
	[PictureID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_UsersPictures] PRIMARY KEY ([UserID]),
CONSTRAINT [FK_UsersPictures_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_UsersPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]));

CREATE TABLE [AnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_AnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_AnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_AnnoucementsPictures_Annoucements] FOREIGN KEY ([AnnoucementID])
	REFERENCES [Annoucements]([AnnoucementID]));
GO

CREATE PROCEDURE dbo.Users_Insert
(
	@UserID uniqueidentifier,
	@Email nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@PhoneNumber nvarchar(50),
	@CreationDate date,
	@Subscribed bit
)
AS
BEGIN
	INSERT INTO [Users]([UserID],[Email],[UserName],[Password],[PhoneNumber],[CreationDate],[Subscribed])
	VALUES(@UserID,@Email,@UserName,@Password,@PhoneNumber,@CreationDate,@Subscribed)
END
GO

CREATE PROCEDURE dbo.UserLocation_Insert
(
	@UserID uniqueidentifier,
	@Country nvarchar(50),
	@County nvarchar(50),
	@City nvarchar(50)
)
AS
BEGIN
	INSERT INTO [UserLocation]([UserID],[Country],[County],[City])
	VALUES(@UserID,@Country,@County,@City)
END
GO

CREATE PROCEDURE dbo.Annoucements_Insert
(
	@AnnoucementID uniqueidentifier,
	@UserID uniqueidentifier,
	@VehicleType int,
	@Views int,
	@Promoted bit,
	@Active bit,
	@CreationDate date,
	@Update date,
	@Condition nvarchar(15),
	@Title nvarchar(50),
	@Brand nvarchar(50),
	@Model nvarchar(50),
	@Type nvarchar(50),
	@Kilometer int,
	@FabricationYear int,
	@VIN nvarchar(50),
	@FuelType nvarchar(25),
	@Price int,
	@NegociablePrice bit,
	@Currency nvarchar(3),
	@Color nvarchar(15),
	@ColorType nvarchar(15),
	@Power int,
	@Transmission nvarchar(25),
	@CubicCapacity int,
	@EmissionClass nvarchar(15),
	@NumberOfSeats int,
	@GVW int,
	@LoadCapacity int,
	@OperatingHours int,
	@Description text
)
AS
BEGIN
	INSERT INTO [Annoucements]([AnnoucementID],[UserID],[VehicleType],[Views],[Promoted],[Active],[CreationDate],
	[Update],[Condition],[Title],[Brand],[Model],[Type],[Kilometer],[FabricationYear],[VIN],[FuelType],[Price],
	[NegociablePrice],[Currency],[Color],[ColorType],[Power],[Transmission],[CubicCapacity],[EmissionClass],
	[NumberOfSeats],[GVW],[LoadCapacity],[OperatingHours],[Description])
	VALUES(@AnnoucementID ,@UserID ,@VehicleType ,@Views ,@Promoted ,@Active ,@CreationDate ,@Update ,@Condition ,
	@Title ,@Brand ,@Model ,@Type ,@Kilometer ,@FabricationYear ,@VIN ,@FuelType ,@Price ,@NegociablePrice ,
	@Currency ,@Color ,@ColorType ,@Power ,@Transmission ,@CubicCapacity ,@EmissionClass ,@NumberOfSeats ,@GVW ,
	@LoadCapacity ,@OperatingHours ,@Description)
END
GO


CREATE PROCEDURE dbo.Options_Insert
(
	@OptionID uniqueidentifier,
	@Name nvarchar(50)
)
AS
BEGIN
	INSERT INTO [Options]([OptionID],[Name])
	VALUES(@OptionID,@Name)
END
GO

CREATE PROCEDURE dbo.AnnouncementsOptions_Insert
(
	@AnnoucementID uniqueidentifier,
	@OptionID uniqueidentifier
)
AS
BEGIN
	INSERT INTO [AnnouncementsOptions]([AnnoucementID],[OptionID])
	VALUES(@AnnoucementID,@OptionID)
END
GO

CREATE PROCEDURE dbo.MessageImbox_Insert
(
	@MessageID uniqueidentifier,
	@UserID uniqueidentifier,
	@AnnoucementID uniqueidentifier,
	@CreationDate date,
	@Read bit,
	@MesageContent text
)
AS
BEGIN
	INSERT INTO [MessageImbox]([MessageID],[UserID],[AnnoucementID],[CreationDate],[Read],[MesageContent])
	VALUES(@MessageID,@UserID,@AnnoucementID,@CreationDate,@Read,@MesageContent)
END
GO

CREATE PROCEDURE dbo.Pictures_Insert
(
	@PictureID uniqueidentifier,
	@Picture image
)
AS
BEGIN
	INSERT INTO [Pictures]([PictureID],[Picture])
	VALUES(@PictureID,@Picture)
END
GO

CREATE PROCEDURE dbo.UsersPictures_Insert
(
	@UserID uniqueidentifier,
	@PictureID uniqueidentifier
)
AS
BEGIN
	INSERT INTO [UsersPictures]([UserID],[PictureID])
	VALUES(@UserID,@PictureID)
END
GO

CREATE PROCEDURE dbo.AnnoucementsPictures_Insert
(
	@PictureID uniqueidentifier,
	@AnnoucementID uniqueidentifier,
	@PrimaryPicture bit
)
AS
BEGIN
	INSERT INTO [AnnoucementsPictures]([PictureID],[AnnoucementID],[PrimaryPicture])
	VALUES(@PictureID,@AnnoucementID,@PrimaryPicture)
END
GO

CREATE PROCEDURE dbo.Users_UpdateByID
(
	@UserID uniqueidentifier,
	@Email nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@PhoneNumber nvarchar(50),
	@Subscribed bit
)
AS
BEGIN
	UPDATE [Users] SET 
	[Email] = @Email, 
	[UserName] =@UserName, 
	[Password] =  @Password, 
	[PhoneNumber] = @PhoneNumber,
	[Subscribed] = @Subscribed
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.UserLocation_UpdateByID
(
	@UserID uniqueidentifier,
	@Country nvarchar(50),
	@County nvarchar(50),
	@City nvarchar(50)
)
AS
BEGIN
	UPDATE [UserLocation] SET  
	[Country] = @Country, 
	[County] = @County, 
	[City] = @City
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.Annoucements_UpdateByID
(
	@AnnoucementID uniqueidentifier,
	@VehicleType int,
	@Views int,
	@Promoted bit,
	@Active bit,
	@CreationDate date,
	@Update date,
	@Condition nvarchar(15),
	@Title nvarchar(50),
	@Brand nvarchar(50),
	@Model nvarchar(50),
	@Type nvarchar(50),
	@Kilometer int,
	@FabricationYear int,
	@VIN nvarchar(50),
	@FuelType nvarchar(25),
	@Price int,
	@NegociablePrice bit,
	@Currency nvarchar(3),
	@Color nvarchar(15),
	@ColorType nvarchar(15),
	@Power int,
	@Transmission nvarchar(25),
	@CubicCapacity int,
	@EmissionClass nvarchar(15),
	@NumberOfSeats int,
	@GVW int,
	@LoadCapacity int,
	@OperatingHours int,
	@Description text
)
AS
BEGIN
	UPDATE [Annoucements] SET  
	[VehicleType] = @VehicleType, 
	[Views] = @Views,
	[Promoted] = @Promoted,
	[Active] = @Active,
	[CreationDate] = @CreationDate,
	[Update] = @Update,
	[Condition] = @Condition,
	[Title] = @Title,
	[Brand] = @Brand,
	[Model] = @Model, 
	[Type] = @Type,
	[Kilometer] = @Kilometer,
	[FabricationYear] = @FabricationYear,
	[VIN] = @VIN,
	[FuelType] = @FuelType,
	[Price] = @Price,
	[NegociablePrice] = @NegociablePrice,
	[Currency] = @Currency,
	[Color] = @Color,
	[ColorType] = @ColorType,
	[Power] = @Power,
	[Transmission] = @Transmission,
	[CubicCapacity] = @CubicCapacity,
	[EmissionClass] = @EmissionClass,
	[NumberOfSeats] = @NumberOfSeats,
	[GVW] = @GVW,
	[LoadCapacity] = @LoadCapacity,
	[OperatingHours] = @OperatingHours,
	[Description] =  @Description
	WHERE [AnnoucementID] = @AnnoucementID
END
GO


CREATE PROCEDURE dbo.Options_UpdateByID
(
	@OptionID uniqueidentifier,
	@Name nvarchar(50)
)
AS
BEGIN
	UPDATE [Options] SET 
	[Name] = @Name
	WHERE [OptionID] = @OptionID
END
GO

CREATE PROCEDURE dbo.MessageImbox_UpdateByID
(
	@MessageID uniqueidentifier,
	@Read bit,
	@MesageContent text
)
AS
BEGIN
	UPDATE [MessageImbox] SET 
	[Read] = @Read,
	[MesageContent] = @MesageContent
	WHERE [MessageID] = @MessageID
END
GO

CREATE PROCEDURE dbo.Pictures_UpdateByID
(
	@PictureID uniqueidentifier,
	@Picture image
)
AS
BEGIN
	UPDATE [Pictures] SET 
	[Picture] = @Picture
	WHERE [PictureID] = @PictureID
END
GO

CREATE PROCEDURE dbo.UsersPictures_UpdateByID
(
	@UserID uniqueidentifier,
	@PictureID uniqueidentifier
)
AS
BEGIN
	UPDATE [UsersPictures] SET 
	[PictureID] = @PictureID
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.AnnoucementsPictures_UpdateByID
(
	@PictureID uniqueidentifier,
	@PrimaryPicture bit
)
AS
BEGIN
	UPDATE [AnnoucementsPictures] SET 
	[PrimaryPicture] = @PrimaryPicture
	WHERE [PictureID] = @PictureID
END
GO

--select * FROM Annoucements;

--ALTER TABLE Annoucements
--   DROP CONSTRAINT FK_Annoucements_Users   -- or whatever it's called

---ALTER TABLE Annoucements
--   ADD CONSTRAINT FK_Annoucements_Users_Cascade
--  FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE

--delete from Annoucements where UserID = '6DEB815A-5F4B-D7A5-8571-168AB1DA8E67'
CREATE PROCEDURE dbo.Users_DeleteByID
(
	@UserID uniqueidentifier
)
AS
BEGIN

	DELETE FROM [Users] 
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.UserLocation_DeleteByID
(
	@UserID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [UserLocation] 
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.Annoucements_DeleteByID
(
	@AnnoucementID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [Annoucements] 
	WHERE [AnnoucementID] = @AnnoucementID
END
GO

CREATE PROCEDURE dbo.Options_DeleteByID
(
	@Options uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [Options] 
	WHERE [OptionID] = @Options
END
GO

CREATE PROCEDURE dbo.AnnouncementsOptions_DeleteByID
(
	@AnnoucementID uniqueidentifier,
	@OptionID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [AnnouncementsOptions] 
	WHERE [AnnoucementID] = @AnnoucementID AND [OptionID] = @OptionID
END
GO

CREATE PROCEDURE dbo.MessageImbox_DeleteByID
(
	@MessageID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [MessageImbox] 
	WHERE [MessageID] = @MessageID
END
GO

CREATE PROCEDURE dbo.Pictures_DeleteByID
(
	@PictureID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [Pictures] 
	WHERE [PictureID] = @PictureID
END
GO

CREATE PROCEDURE dbo.UsersPictures_DeleteByID
(
	@UserID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [UsersPictures] 
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.AnnoucementsPictures_DeleteByID
(
	@PictureID uniqueidentifier
)
AS
BEGIN
	DELETE  FROM [AnnoucementsPictures] 
	WHERE [PictureID] = @PictureID
END
GO

CREATE PROCEDURE dbo.Users_ReadAll
AS
BEGIN
	SELECT * FROM [Users]
END
GO

CREATE PROCEDURE dbo.Users_ReadByID
(
@UserID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [Users]
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.UserLocation_ReadByID
(
@UserID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [UserLocation]
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.Users_UserLocation_ReadByID
(
@UserID uniqueidentifier
)
AS
BEGIN
	SELECT  u.UserID,
			u.Email,
			u.UserName,
			u.PhoneNumber,
			l.Country,
			l.County,
			l.City
	FROM [Users] u
		INNER JOIN [UserLocation] l ON l.[UserID] = u.[UserID]
	WHERE u.[UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.Users_MessageImbox_ReadByID
(
@UserID uniqueidentifier
)
AS
BEGIN
	SELECT  u.UserID,
			u.UserName,
			m.MessageID,
			m.AnnoucementID,
			m.CreationDate,
			m.[Read],
			m.MesageContent
	FROM [Users] u
		INNER JOIN MessageImbox m ON m.[UserID] = u.[UserID]
	WHERE u.[UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.MessageImbox_Annoucements_ReadByID
(
@AnnoucementID uniqueidentifier
)
AS
BEGIN
	SELECT  m.MessageID,
			m.UserID,
			m.AnnoucementID,
			m.CreationDate,
			m.[Read],
			m.MesageContent
	FROM MessageImbox m
		INNER JOIN Annoucements a ON a.AnnoucementID = m.AnnoucementID
	WHERE m.AnnoucementID = @AnnoucementID
END
GO

CREATE PROCEDURE dbo.Annoucements_ReadByID
(
@AnnoucementID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [Annoucements]
	WHERE [AnnoucementID] = @AnnoucementID
END
GO

CREATE PROCEDURE dbo.Annoucements_Users_ReadByID
(
@UserID uniqueidentifier
)
AS
BEGIN
	SELECT *
	FROM Annoucements 
	WHERE [UserID] = @UserID
END
GO

CREATE PROCEDURE dbo.Options_ReadAll
AS
BEGIN
	SELECT * FROM [Options]
END
GO

CREATE PROCEDURE dbo.Options_ReadByID
(
@OptionID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [Options]
	WHERE [OptionID] = @OptionID
END
GO

CREATE PROCEDURE dbo.AnnouncementsOptions_ReadAnnouncementsOptionsByID
(
@AnnoucementID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [AnnouncementsOptions]
	WHERE [AnnoucementID] = @AnnoucementID
END
GO

CREATE PROCEDURE dbo.MessageImbox_ReadByID
(
@MessageID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [MessageImbox]
	WHERE [MessageID] = @MessageID
END
GO

CREATE PROCEDURE dbo.Pictures_ReadByID
(
@PictureID uniqueidentifier
)
AS
BEGIN
	SELECT * FROM [Pictures]
	WHERE [PictureID] = @PictureID
END
GO
-- CREATE NONCLUSTERED INDEX index_clustered ON Users(UserId asc)