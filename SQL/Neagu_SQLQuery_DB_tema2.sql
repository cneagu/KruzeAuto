USE KruzeAutoDB;

GO
CREATE VIEW [dbo].[AnnoucementsPhoto]
AS
SELECT  a.[AnnoucementsID],
		a.Title,
		COUNT(p.[PictureID]) as NoOfPictures
FROM [CarsAnnoucements] a
	LEFT JOIN [CarsAnnoucementsPictures] c ON c.[AnnoucementsID] = a.[AnnoucementsID]
	LEFT JOIN [Pictures] p ON p.[PictureID] = c.[PictureID]
GROUP BY a.[AnnoucementsID],a.Title


GO
CREATE VIEW [dbo].[UserAnnouncements]
AS
SELECT  u.[UserID],
		u.[UserName],
		COUNT(c.[AnnoucementsID]) as NoOfAnnounce
FROM [Users] u
	LEFT JOIN [CarsAnnoucements] c ON c.[UserID] = u.[UserID]
GROUP BY u.[UserID],u.[UserName]
GO

CREATE PROCEDURE [CreateNewAualTable]
(
	@tabName nvarchar(30)
)
AS
BEGIN
	DECLARE @SQLString NVARCHAR(MAX)
    Set @SQLString = 'CREATE TABLE ' +@tabName+
    '(
		[UserID] uniqueidentifier NOT NULL,
		[UserName] nvarchar(50) NOT NULL,
		[CreationDate] datetime NOT NULL,
		[NoOfAnnouncements] int
	CONSTRAINT [PK_AnualUsers] PRIMARY KEY ([UserID])
	) ON [PRIMARY]'
EXEC (@SQLString)
END
GO

DECLARE @tabName nvarchar(30)  = 'AnualUsers'
EXECUTE dbo.[CreateNewAualTable] @tabNAME
GO

 
	
--INSERT INTO [AnualUsers]([[UserID],[UserName],[CreationDate],[NoOfAnnouncements])
--	VALUES ('8bfbfabb-c613-43fb-839f-577b6fa2b704','AnualUsers''2013-02-01 15:00:00.001',3)





CREATE PROCEDURE [UpdateAnualUsers]
(
	@UserID uniqueidentifier,
	@Password nvarchar(50),
	@PhoneNumber nvarchar(50)
)
AS
BEGIN
	UPDATE Users SET 
	[Password] = @Password, [PhoneNumber] = @PhoneNumber
	WHERE [UserID] = @UserID
END
GO

EXECUTE dbo.UpdateAnualUsers
	@UserID = '561FC9B6-74AB-D604-337F-3D83F8504E01',
	@Password = 'UMT2',
	@PhoneNumber = '07854332985'
GO

CREATE PROCEDURE [ReadUserAnnouncementsByID]
(
	@UserID uniqueidentifier
)
AS
BEGIN
		SELECT [AnnoucementsID],[Title],[Price] 
		FROM [CarsAnnoucements] 
		WHERE [UserID] = @UserID
END
GO

EXECUTE dbo.[ReadUserAnnouncementsByID]
	@UserID = '561FC9B6-74AB-D604-337F-3D83F8504E01'
GO

CREATE FUNCTION dbo.MessageImbox_GetNoOFMessages
(
	@UserID uniqueidentifier
)
RETURNS int
AS
BEGIN
	DECLARE @NoOFMessages int

	SELECT @NoOFMessages = COUNT(m.[MessageID])
	FROM Users u
		LEFT JOIN MessageImbox m ON m.UserID = u.UserID


	RETURN @NoOFMessages
END
GO


CREATE PROCEDURE dbo.NoMessages_ReadById
(
	@UserID uniqueidentifier
)
AS
BEGIN
	SELECT u.UserId,
			u.UserName,
			dbo.MessageImbox_GetNoOFMessages(UserId) as NoOfMessages
	FROM Users u
	WHERE u.UserId = @UserID
END
GO

DECLARE @UserID uniqueidentifier = 'E5C24E7A-A819-1E62-E37C-0700402A1B8C'
EXECUTE dbo.NoMessages_ReadById @UserID

CREATE NONCLUSTERED INDEX index_clustered ON Users(UserId asc)