USE [POSWebDB]
GO
/****** Object:  Table [Entity_Information]    Script Date: 12/27/2020 6:05:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Entity_Information](
	[LegalEntityId] [nvarchar](250) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[GenderId] [nvarchar](100) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Age]  AS ((CONVERT([int],CONVERT([char](8),getdate(),(112)))-CONVERT([char](8),[BirthDate],(112)))/(10000)),
	[CivilStatusTypeId] [nvarchar](100) NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [LegalEntityId] PRIMARY KEY CLUSTERED 
(
	[LegalEntityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [U_Entity_Information] UNIQUE NONCLUSTERED 
(
	[FirstName] ASC,
	[MiddleName] ASC,
	[LastName] ASC,
	[GenderId] ASC,
	[BirthDate] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [EntityCivilStatusType]    Script Date: 12/27/2020 6:05:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [EntityCivilStatusType](
	[CivilStatusTypeId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_CivilStatus] PRIMARY KEY CLUSTERED 
(
	[CivilStatusTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [EntityContact_Information]    Script Date: 12/27/2020 6:05:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [EntityContact_Information](
	[LegalEntityContactId] [nvarchar](100) NOT NULL,
	[LegalEntityId] [nvarchar](100) NOT NULL,
	[LegalContactTypeId] [bigint] NOT NULL,
	[Value] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_LegalContact_Information] PRIMARY KEY CLUSTERED 
(
	[LegalEntityContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [EntityGenderType]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [EntityGenderType](
	[GenderId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_EntityGender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Location]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Location](
	[LocationId] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [varbinary](50) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Sequence]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Sequence](
	[TableName] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](10) NOT NULL,
	[SequenceLength] [int] NOT NULL,
	[LastNumber] [bigint] NOT NULL,
 CONSTRAINT [U_Sequence] UNIQUE NONCLUSTERED 
(
	[TableName] ASC,
	[Prefix] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemConfig]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemConfig](
	[ConfigId] [int] NOT NULL,
	[ConfigGroup] [nvarchar](100) NULL,
	[Key] [nvarchar](100) NULL,
	[Value] [varchar](max) NULL,
	[EntityStatusId] [int] NULL,
	[SystemConfigTypeId] [bigint] NULL,
	[IsUserConfigurable] [bit] NULL,
 CONSTRAINT [PK_SystemConfig] PRIMARY KEY CLUSTERED 
(
	[ConfigId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [SystemMenu]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemMenu](
	[SystemMenuId] [bigint] NOT NULL,
	[ModuleName] [nvarchar](100) NOT NULL,
	[PageName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_SystemMenu] PRIMARY KEY CLUSTERED 
(
	[SystemMenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_SystemMenu] UNIQUE NONCLUSTERED 
(
	[ModuleName] ASC,
	[PageName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemMenuRole]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemMenuRole](
	[SystemMenuRoleId] [nvarchar](100) NOT NULL,
	[SystemRoleId] [nvarchar](100) NOT NULL,
	[SystemMenuId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[IsAllowed] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_SystemMenuRole] PRIMARY KEY CLUSTERED 
(
	[SystemMenuRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemPrivileges]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemPrivileges](
	[SystemPrivilegesId] [bigint] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SystemPrivileges] PRIMARY KEY CLUSTERED 
(
	[SystemPrivilegesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemRole]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemRole](
	[SystemRoleId] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED 
(
	[SystemRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_SystemRole] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemRolePrivileges]    Script Date: 12/27/2020 6:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemRolePrivileges](
	[SystemRolePrivilegesId] [nvarchar](100) NOT NULL,
	[SystemRoleId] [nvarchar](100) NOT NULL,
	[SystemPrivilegesId] [bigint] NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[IsAllowed] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_SystemRolePrivileges] PRIMARY KEY CLUSTERED 
(
	[SystemRolePrivilegesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemUser]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemUser](
	[SystemUserId] [nvarchar](100) NOT NULL,
	[LegalEntityId] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[SystemUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_SystemUser] UNIQUE NONCLUSTERED 
(
	[UserName] ASC,
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [SystemUserRoles]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SystemUserRoles](
	[SystemUserRoleId] [nvarchar](100) NOT NULL,
	[SystemUserId] [nvarchar](100) NOT NULL,
	[SystemRoleId] [nvarchar](100) NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [nvarchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_SystemUserRoles] PRIMARY KEY CLUSTERED 
(
	[SystemUserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [usp_entity_information_add]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_entity_information_add]
	@FirstName			NVARCHAR(100),
	@LastName			NVARCHAR(100),
	@MiddleName			NVARCHAR(100),
	@GenderId			NVARCHAR(100),
	@BirthDate			DATE,
	@CivilStatusTypeId	NVARCHAR(100),
	@LocationId			BIGINT,
	@CreatedBy			NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

		SET NOCOUNT ON;

		DECLARE @LegalEntityId nvarchar(100);
		
		exec [dbo].[usp_sequence_getNextCode] 'Entity_Information', @Id = @LegalEntityId OUTPUT

		INSERT INTO [dbo].[Entity_Information](
			[LegalEntityId], 
			[FirstName], 
			[LastName],
			[MiddleName],
			[GenderId],
			[BirthDate],
			[CivilStatusTypeId],
			[LocationId],
			[IsActive],
			[CreatedBy],
			[CreatedAt]
		)
		VALUES(
			@LegalEntityId,
			@FirstName,
			@LastName,
			@MiddleName,
			@GenderId,
			@BirthDate,
			@CivilStatusTypeId,
			@LocationId,
			1,
			@CreatedBy,
			GETDATE()
		);

		SELECT @LegalEntityId;
        
    END TRY
    BEGIN CATCH

        SELECT
			'Error - ' + ERROR_MESSAGE()   AS ErrorMessage,
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
/****** Object:  StoredProcedure [usp_Reset]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_Reset]
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
		SET NOCOUNT ON;
		
		DELETE FROM [dbo].[Entity_Information];
		DELETE FROM [dbo].[EntityContact_Information];
		DELETE FROM [dbo].[SystemMenuRole];
		DELETE FROM [dbo].[SystemRole];
		DELETE FROM [dbo].[SystemRolePrivileges];
		DELETE FROM [dbo].[SystemUser];
		DELETE FROM [dbo].[SystemUserRoles];
		
		Update [dbo].[Sequence] set [LastNumber] = 0 WHERE [TableName] = 'Entity_Information';
		Update [dbo].[Sequence] set [LastNumber] = 0 WHERE [TableName] = 'SystemMenuRole';
		Update [dbo].[Sequence] set [LastNumber] = 0 WHERE [TableName] = 'SystemRole';
		Update [dbo].[Sequence] set [LastNumber] = 0 WHERE [TableName] = 'SystemRolePrivileges';
		Update [dbo].[Sequence] set [LastNumber] = 0 WHERE [TableName] = 'SystemUser';
		Update [dbo].[Sequence] set [LastNumber] = 0 WHERE [TableName] = 'SystemUserRoles';
        
    END TRY
    BEGIN CATCH

        SELECT
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
/****** Object:  StoredProcedure [usp_sequence_getNextCode]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_sequence_getNextCode]
	@TableName	NVARCHAR(250),
    @Id NVARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

		SET NOCOUNT ON;
		
		DECLARE @LastNumber INT;
		DECLARE @SequenceLength BIGINT;
		DECLARE @GeneratedId NVARCHAR(100);
		DECLARE @Prefix NVARCHAR(100);
		SELECT @LastNumber = [LastNumber] + 1,@SequenceLength=[SequenceLength],@Prefix=[Prefix] FROM [Sequence] WHERE TableName = @TableName;
		SELECT @GeneratedId = CONCAT(@Prefix, [dbo].LPAD(@LastNumber, @SequenceLength, 0));
		SELECT @Id = IIF(datalength(@GeneratedId)=0,NULL,@GeneratedId);

		UPDATE [dbo].[Sequence] SET [LastNumber] = @LastNumber WHERE [TableName] = @TableName;
		
		RETURN 0
        
    END TRY
    BEGIN CATCH

        SELECT
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
/****** Object:  StoredProcedure [usp_systemuser_add]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_systemuser_add]
	@LegalEntityId		NVARCHAR(100),
	@UserName			NVARCHAR(100),
	@Password			NVARCHAR(100),
	@LocationId			BIGINT,
	@CreatedBy			NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

		SET NOCOUNT ON;

		DECLARE @SystemUserId nvarchar(100);
		
		exec [dbo].[usp_sequence_getNextCode] 'SystemUser', @Id = @SystemUserId OUTPUT

		INSERT INTO [dbo].[SystemUser](
			[SystemUserId], 
			[LegalEntityId], 
			[UserName],
			[Password],
			[LocationId],
			[IsActive],
			[CreatedBy],
			[CreatedAt]
		)
		VALUES(
			@SystemUserId,
			@LegalEntityId,
			@UserName,
			HashBytes('MD5', @Password),
			@LocationId,
			1,
			@CreatedBy,
			GETDATE()
		);

		SELECT @SystemUserId;
        
    END TRY
    BEGIN CATCH

        SELECT
			'Error - ' + ERROR_MESSAGE()   AS ErrorMessage,
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
/****** Object:  StoredProcedure [usp_systemuser_getByCredentials]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_systemuser_getByCredentials]
	@Username	NVARCHAR(100),
	@Password	NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

		SET NOCOUNT ON;
		
		DECLARE @SystemUserId	NVARCHAR(100);
		DECLARE @LegalEntityId	NVARCHAR(100);
		
		SELECT  @LegalEntityId = su.LegalEntityId, @SystemUserId = su.[SystemUserId]
		FROM [dbo].[SystemUser] su
		WHERE su.Username = @Username AND su.[Password] = HashBytes('MD5', @Password) AND IsActive = 1;

		SELECT  *
		FROM [dbo].[SystemUser] AS su
		WHERE su.[SystemUserId] = @SystemUserId;

		SELECT  *
		FROM [dbo].[Entity_Information] AS ei
		WHERE ei.[LegalEntityId] = @LegalEntityId;
		
		SELECT  *
		FROM [dbo].[EntityContact_Information] AS eci
		WHERE eci.[LegalEntityId] = @LegalEntityId;

		RETURN 0
        
    END TRY
    BEGIN CATCH

        SELECT
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
/****** Object:  StoredProcedure [usp_systemuser_getByID]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_systemuser_getByID]
	@SystemUserId	NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

		SET NOCOUNT ON;
		
		DECLARE @LegalEntityId	NVARCHAR(100);
		
		SELECT  @LegalEntityId = su.LegalEntityId, @SystemUserId = su.[SystemUserId]
		FROM [dbo].[SystemUser] su
		WHERE su.[SystemUserId] = @SystemUserId;

		SELECT  *
		FROM [dbo].[SystemUser] AS su
		WHERE su.[SystemUserId] = @SystemUserId;

		SELECT  *
		FROM [dbo].[Entity_Information] AS ei
		WHERE ei.[LegalEntityId] = @LegalEntityId;
		
		SELECT  *
		FROM [dbo].[EntityContact_Information] AS eci
		WHERE eci.[LegalEntityId] = @LegalEntityId;

		RETURN 0
        
    END TRY
    BEGIN CATCH

        SELECT
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
/****** Object:  StoredProcedure [usp_systemuser_getPaged]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		erwin
-- Create date: 2020-09-16
-- Description:	filter contract list by location
-- =============================================
CREATE PROCEDURE [usp_systemuser_getPaged]
	@SystemUserId NVARCHAR(100) = '',
	@UserName NVARCHAR(100) = '',
	@FullName NVARCHAR(300) = '',
	@Gender NVARCHAR(100) = '',
	@Role NVARCHAR(100) = '',
	@CreatedAt NVARCHAR(100) = '',
	@UpdatedAt NVARCHAR(100) = '',
	@PageNo BIGINT = 1,
	@PageSize BIGINT = 10,
	@LocationId NVARCHAR(100) = 0
AS
BEGIN
	SET NOCOUNT ON;

	
		WITH DATA_CTE
		AS
		(
			Select tableSource.*, ROW_NUMBER() OVER(ORDER BY SystemUserId ASC) AS row_num ,
			count(*) over() as TotalRows
			FROM (
			 SELECT 
			 su.SystemUserId,
			 MAX(su.[UserName])[UserName],
			 MAX(su.[Password])[Password],
			 MAX(su.[CreatedAt])[CreatedAt],
			 MAX(su.[UpdatedAt])[UpdatedAt],
			 MAX(ei.[LegalEntityId])[LegalEntityId],
			 MAX(ei.[FullName])[FullName],
			 MAX(ei.[BirthDate])[BirthDate],
			 MAX(ei.[LocationId])[LocationId],
			 MAX(eg.[GenderId])[GenderId],
			 MAX(eg.[Name])[GenderName],
			 MAX(ecst.[CivilStatusTypeId])[CivilStatusTypeId],
			 MAX(ecst.[Name])[CivilStatusName]
			FROM (SELECT * FROM [dbo].[SystemUser] WHERE [IsActive] = 1) AS su
			LEFT JOIN (SELECT * FROM [dbo].[SystemUserRoles] WHERE [IsActive] = 1) sur ON su.SystemUserId = sur.SystemUserId
			LEFT JOIN (SELECT * FROM [dbo].[SystemRole] WHERE [IsActive] = 1) sr ON sur.SystemRoleId = sr.SystemRoleId
			LEFT JOIN (SELECT *,[FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [FullName] FROM [dbo].[Entity_Information] WHERE [IsActive] = 1) AS ei ON su.LegalEntityId = ei.LegalEntityId
			LEFT JOIN (SELECT * FROM [dbo].[EntityGenderType] WHERE [IsActive] = 1) AS eg ON ei.GenderId = eg.GenderId
			LEFT JOIN (SELECT * FROM [dbo].[EntityCivilStatusType] WHERE [IsActive] = 1) AS ecst ON ei.CivilStatusTypeId = ecst.CivilStatusTypeId
			WHERE su.LocationId = @LocationId
			AND (su.SystemUserId like '%' + @SystemUserId + '%' OR @SystemUserId= '' OR @SystemUserId IS NULL)
			AND (su.[UserName] like '%' + @UserName + '%' OR @UserName= '' OR @UserName IS NULL)
			AND (su.[CreatedAt] like '%' + @CreatedAt + '%' OR @CreatedAt= '' OR @CreatedAt IS NULL)
			AND (su.[UpdatedAt] like '%' + @UpdatedAt + '%' OR @UpdatedAt= '' OR @UpdatedAt IS NULL)
			AND (sr.[Name] like '%' + @Role + '%' OR @Role= '' OR @Role IS NULL)
			AND (ei.[FullName] like '%' + @FullName + '%' OR @FullName= '' OR @FullName IS NULL)
			AND (eg.[Name] like '%' + @Gender + '%' OR @Gender= '' OR @Gender IS NULL)
			GROUP BY su.SystemUserId
			) tableSource
		)
		SELECT 
		src.SystemUserId,
		src.[UserName],
		src.[Password],
		src.[CreatedAt],
		src.[UpdatedAt],
		src.[LegalEntityId],
		src.[FullName],
		src.[BirthDate],
		src.[LocationId],
		src.[GenderId],
		src.[GenderName] AS [Name],
		src.[CivilStatusTypeId],
		src.[CivilStatusName] AS [Name],
		src.TotalRows
		 FROM DATA_CTE src
		WHERE src.row_num between ((@PageNo - 1) * @PageSize + 1 ) 
		and (@PageNo * @PageSize)
		ORDER BY src.row_num 

END
GO
/****** Object:  StoredProcedure [usp_systemuser_update]    Script Date: 12/27/2020 6:05:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ====================================================================
-- Created date: Sept 25, 2020
-- Author: 
-- ====================================================================
CREATE PROCEDURE [usp_systemuser_update]
	@SystemUserId		NVARCHAR(100),
	@UpdatedBy			NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY

		SET NOCOUNT ON;
		-- UPDATE HERE
		UPDATE [dbo].[SystemUser]
		SET 
		[UpdatedBy] = @UpdatedBy,
		[UpdatedAt] = GETDATE()
		WHERE [SystemUserId] = @SystemUserId;

		SELECT @@ROWCOUNT;
        
    END TRY
    BEGIN CATCH

        SELECT
			'Error - ' + ERROR_MESSAGE()   AS ErrorMessage,
            'Error'           AS Status,
            ERROR_NUMBER()    AS ErrorNumber,
            ERROR_SEVERITY()  AS ErrorSeverity,
            ERROR_STATE()     AS ErrorState,
            ERROR_PROCEDURE() AS ErrorProcedure,
            ERROR_LINE()      AS ErrorLine,
            ERROR_MESSAGE()   AS ErrorMessage;

    END CATCH

END
GO
