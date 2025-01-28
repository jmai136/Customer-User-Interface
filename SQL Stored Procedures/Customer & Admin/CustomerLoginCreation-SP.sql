USE [GourmetShop]
GO
/****** Object:  Table [dbo].[CustomerLogin]    Script Date: 1/27/2025 11:28:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerLogin](
	[CustomerLoginID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerLoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CustomerLogin]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([Id])
GO









/****** Object:  StoredProcedure [dbo].[CreateCustomerAccount]    Script Date: 1/27/2025 11:28:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateCustomerAccount]
    @PhoneNumber NVARCHAR(15),
    @FirstName NVARCHAR(50) = NULL,      -- Optional if phone number exists
    @LastName NVARCHAR(50) = NULL,       -- Optional if phone number exists
    @Country NVARCHAR(50) = NULL,        -- Optional if phone number exists
    @Username NVARCHAR(50),
    @PasswordHash NVARCHAR(255),
    @City NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Id INT; -- Refers to the primary key of the Customer table

    BEGIN TRY
        -- Check if the phone number exists in the Customer table
        SELECT @Id = Id 
        FROM Customer
        WHERE Phone = @PhoneNumber;

        IF @Id IS NULL
        BEGIN
            -- Phone number does not exist; create a new customer
            INSERT INTO Customer (FirstName, LastName, Phone, Country, City)
          --  OUTPUT INSERTED.Id INTO @Id
            VALUES (@FirstName, @LastName, @PhoneNumber, @Country, @City);
			 SET @Id = SCOPE_IDENTITY();
        
        END

        -- Check if a login account already exists for this CustomerId in CustomerLogin table
        IF EXISTS (SELECT 1 FROM CustomerLogin WHERE CustomerId = @Id)
        BEGIN
            THROW 50001, 'A login account already exists for this customer.', 1;
        END

        -- Insert login details into CustomerLogin table
        INSERT INTO CustomerLogin (CustomerId, Username, PasswordHash)
        VALUES (@Id, @Username, @PasswordHash);

        -- Return the CustomerId
        SELECT @Id AS CustomerId;
    END TRY
    BEGIN CATCH
        -- Handle errors
        THROW;
    END CATCH
END;
GO
