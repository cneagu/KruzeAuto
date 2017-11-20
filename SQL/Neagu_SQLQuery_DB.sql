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

CREATE TABLE [MessageImbox](
	[MessageID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[ReciverID] uniqueidentifier NOT NULL,
	[CreationDate] date NOT NULL,
	[Read] bit,
	[MesageContent] text NOT NULL,
CONSTRAINT [PK_MesageImbox] PRIMARY KEY ([MessageID]),
CONSTRAINT [FK_MesageImbox_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]));

CREATE TABLE [Options](
	[OptionsID] uniqueidentifier NOT NULL,
	[4x2] bit,
	[4x4] bit,
	[6x2] bit,
	[6x4] bit,
	[6x6] bit, 
	[8x4] bit, 
	[8x6] bit, 
	[8x8] bit, 
	[ABS] bit, 
	[AdaptiveCruiseControl] bit,
	[AdaptiveLighting] bit,
	[AirSuspension] bit,
	[AlcantaraSeats] bit,
	[AlloyWheels] bit,
	[AutomaticAirConditioning] bit,
	[AuxiliaryHeating] bit,
	[Axles2] bit,
	[Axles3] bit,
	[AxlesMore] bit,
	[BSS] bit,
	[BlindSpotMonitor] bit,
	[Bluetooth] bit,
	[Box] bit,
	[CDPlayer] bit,
	[Cabin] bit,
	[CatalyticConverter] bit,
	[CentralLocking] bit,
	[CentralLubricantAplic] bit,
	[ColdStore] bit,
	[CollisionAvoidanceSystem] bit,
	[Compressor] bit,
	[Crane] bit,
	[CruiseControl] bit,
	[DaytimeRunningLights] bit,
	[DiscBrake] bit,
	[DriversSleepingCompartment] bit,
	[EBS] bit,
	[ESP] bit,
	[ElectricHeatedSeats] bit,
	[ElectricSeatAdjustment] bit,
	[ElectricSideMirror] bit,
	[ElectricStarter] bit,
	[ElectricWindows] bit,
	[FogLamp] bit,
	[FrontHydraulics] bit,
	[FrontJack] bit,
	[FrontParkingSensor] bit,
	[FullLeatherSeats] bit,
	[KeylessEntry] bit,
	[Kichen] bit,
	[Kickstarter] bit,
	[LEDHeadlight] bit,
	[LaserHeadlight] bit,
	[LaneDepartueWarningSystem] bit,
	[LightSensor] bit,
	[NavigationSystem] bit,
	[OnBoardComputer] bit,
	[ParticulateFilter] bit,
	[PowerAssistedSteering] bit,
	[QuickChangeAttachment] bit,
	[RainSensor] bit,
	[RearCamera] bit,
	[RearParkingSensor] bit,
	[RetarderIntarder] bit,
	[RollOverBar] bit,
	[SecondaryAirConditioning] bit,
	[SelfSteeringSystem] bit,
	[SilidingDoor] bit,
	[SleeperSeats] bit,
	[SportSeats] bit,
	[StartStopSystem] bit,
	[Sunroof] bit,
	[TV] bit,
	[TailLift] bit,
	[TractionControl] bit,
	[TrailerCoupling] bit,
	[TunerAudio] bit,
	[VentilatedSeats] bit,
	[WC] bit,
	[Windshield] bit,
	[XenonHeadlights] bit, 
CONSTRAINT [PK_Options] PRIMARY KEY ([OptionsID]));

CREATE TABLE [CarsAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[Description] text,
CONSTRAINT [PK_CarsAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_CarsAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_CarsAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [MotorcyclesAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[FuelType] nvarchar(25) NOT NULL,
	[Price] int NOT NULL,
	[NegociablePrice] bit,
	[Currency] nvarchar(3) NOT NULL,
	[Color] nvarchar(15),
	[ColorType] nvarchar(15),
	[Power] int,
	[Transmission] nvarchar(25),
	[CubicCapacity] int,
	[DrivingMode] nvarchar(25),	
	[Description] text,
CONSTRAINT [PK_MotorcyclesAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_MotorcyclesAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_MotorcyclesAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [VansAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[Description] text,
CONSTRAINT [PK_VansAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_VansAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_VansAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [TrucksAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[GVW] int,
	[Description] text,
CONSTRAINT [PK_TrucksAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_TrucksAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_TrucksAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [TrailersAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[FabricationYear] int NOT NULL,
	[Price] int NOT NULL,
	[NegociablePrice] bit,
	[Currency] nvarchar(3) NOT NULL,
	[GVW] int,
	[LoadCapacity] int,
	[Description] text,
CONSTRAINT [PK_TrailersAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_TrailersAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_TrailersAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [SemiTrailersAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[FabricationYear] int NOT NULL,
	[Price] int NOT NULL,
	[NegociablePrice] bit,
	[Currency] nvarchar(3) NOT NULL,
	[GVW] int,
	[LoadCapacity] int,
	[Description] text,
CONSTRAINT [PK_SemiTrailersAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_SemiTrailersAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_SemiTrailersAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [BusesAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[Description] text,
CONSTRAINT [PK_BusesAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_BusesAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_BusesAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [ConstructionMachinesAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[FabricationYear] int NOT NULL,
	[OperatingHours] int,
	[Price] int NOT NULL,
	[NegociablePrice] bit,
	[Currency] nvarchar(3) NOT NULL,
	[EmissionClass] nvarchar(15),
	[Description] text,
CONSTRAINT [PK_ConstructionMachinesAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_ConstructionMachinesAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_ConstructionMachinesAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

CREATE TABLE [AgriculturalMachinesAnnoucements](
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[UserID] uniqueidentifier NOT NULL,
	[OptionsID] uniqueidentifier NOT NULL,
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
	[FabricationYear] int NOT NULL,
	[OperatingHours] int,
	[Power] int,
	[Price] int NOT NULL,
	[NegociablePrice] bit,
	[Currency] nvarchar(3) NOT NULL,
	[EmissionClass] nvarchar(15),
	[Description] text,
CONSTRAINT [PK_AgriculturalMachinesAnnoucements] PRIMARY KEY ([AnnoucementsID]),
CONSTRAINT [FK_AgriculturalMachinesAnnoucements_Users] FOREIGN KEY ([UserID])
	REFERENCES [Users]([UserID]),
CONSTRAINT [FK_AgriculturalMachinesAnnoucements_Options] FOREIGN KEY ([OptionsID])
	REFERENCES [Options]([OptionsID]));

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

CREATE TABLE [CarsAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_CarsAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_CarsAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_CarsAnnoucementsPictures_CarsAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [CarsAnnoucements]([AnnoucementsID]));

CREATE TABLE [MotorcyclesAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_MotorcyclesAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_MotorcyclesAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_MotorcyclesAnnoucementsPictures_MotorcyclesAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [MotorcyclesAnnoucements]([AnnoucementsID]));

CREATE TABLE [VansAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_VansAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_VansAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_VansAnnoucementsPictures_VansAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [VansAnnoucements]([AnnoucementsID]));

CREATE TABLE [TrucksAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,	
	[PrimaryPicture] bit,
CONSTRAINT [PK_TrucksAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_TrucksAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_TrucksAnnoucementsPictures_TrucksAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [TrucksAnnoucements]([AnnoucementsID]));

CREATE TABLE [TrailersAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_TrailersAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_TrailersAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_TrailersAnnoucementsPictures_TrailersAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [TrailersAnnoucements]([AnnoucementsID]));

CREATE TABLE [SemiTrailersAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_SemiTrailersAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_SemiTrailersAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_SemiTrailersAnnoucementsPictures_SemiTrailersAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [SemiTrailersAnnoucements]([AnnoucementsID]));

CREATE TABLE [BusesAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,	
	[PrimaryPicture] bit,
CONSTRAINT [PK_BusesAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_BusesAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_BusesAnnoucementsPictures_BusesAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [BusesAnnoucements]([AnnoucementsID]));

CREATE TABLE [ConstructionMachinesAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_ConstructionMachinesAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_ConstructionMachinesAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_ConstructionMachinesAnnoucementsPictures_ConstructionMachinesAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [ConstructionMachinesAnnoucements]([AnnoucementsID]));

CREATE TABLE [AgriculturalMachinesAnnoucementsPictures](
	[PictureID] uniqueidentifier NOT NULL,
	[AnnoucementsID] uniqueidentifier NOT NULL,
	[PrimaryPicture] bit,
CONSTRAINT [PK_AgriculturalMachinesAnnoucementsPictures] PRIMARY KEY ([PictureID]),
CONSTRAINT [FK_AgriculturalMachinesAnnoucementsPictures_Pictures] FOREIGN KEY ([PictureID])
	REFERENCES [Pictures]([PictureID]),
CONSTRAINT [FK_AgriculturalMachinesAnnoucementsPictures_AgriculturalMachinesAnnoucements] FOREIGN KEY ([AnnoucementsID])
	REFERENCES [AgriculturalMachinesAnnoucements]([AnnoucementsID]));
