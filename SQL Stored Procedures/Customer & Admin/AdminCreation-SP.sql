USE [GourmetShop]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 1/27/2025 11:26:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminLogin]    Script Date: 1/27/2025 11:26:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLogin](
	[AdminLoginID] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminLoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdminLogin]  WITH CHECK ADD FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admin] ([AdminId])
GO
/****** Object:  StoredProcedure [dbo].[CreateAdminAndLogin]    Script Date: 1/27/2025 11:26:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateAdminAndLogin]
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100),
    @PhoneNumber NVARCHAR(15) = NULL,      -- Optional
    @Username NVARCHAR(50),
    @PasswordHash NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AdminId INT;

    BEGIN TRY
        -- Check if an admin with the same email already exists
        IF EXISTS (SELECT 1 FROM Admin WHERE Email = @Email)
        BEGIN
            THROW 50002, 'An admin with this email already exists.', 1;
        END

        -- Check if an admin with the same phone number exists (if provided)
        IF @PhoneNumber IS NOT NULL AND EXISTS (SELECT 1 FROM Admin WHERE PhoneNumber = @PhoneNumber)
        BEGIN
            THROW 50003, 'An admin with this phone number already exists.', 1;
        END

        -- Insert a new admin into the Admin table
        INSERT INTO Admin (FirstName, LastName, Email, PhoneNumber)
        VALUES (@FirstName, @LastName, @Email, @PhoneNumber);

        -- Retrieve the newly inserted AdminId
        SET @AdminId = SCOPE_IDENTITY();

        -- Insert login details into the AdminLogin table
        INSERT INTO AdminLogin (AdminId, Username, PasswordHash)
        VALUES (@AdminId, @Username, @PasswordHash);

        -- Return the AdminId
        SELECT @AdminId AS AdminId;
    END TRY
    BEGIN CATCH
        -- Handle errors
        THROW;
    END CATCH
END;
GO
