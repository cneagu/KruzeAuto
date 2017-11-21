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
	[VehicleType] nvarchar(50) NOT NULL,
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
	[AnnouncementsOptionsID] uniqueidentifier NOT NULL,
	[AnnoucementID] uniqueidentifier NOT NULL,
	[OptionID] uniqueidentifier NOT NULL,
CONSTRAINT [PK_AnnouncementsOptions] PRIMARY KEY ([AnnouncementsOptionsID]),
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