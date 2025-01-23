-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE GourmetShop
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jude Mai>
-- Create date: <1/6/2025>
-- Description:	Insert new suppliers in the Suppliers table>
-- =============================================
CREATE PROCEDURE AddSupplier
	-- Add the parameters for the stored procedure here
	@CompanyName NVARCHAR(40),
	@ContactName NVARCHAR(50) = null,
    @ContactTitle NVARCHAR(40) = null,
    @City NVARCHAR(40) = null,
    @Country NVARCHAR(40) = null,
    @Phone NVARCHAR(30)  =  null,
    @Fax NVARCHAR(30) = null
AS
BEGIN
    -- Insert statements for procedure here
	-- https://stackoverflow.com/questions/14142320/use-stored-procedure-to-insert-some-data-into-a-table
	INSERT INTO [GourmetShop].[dbo].[Supplier](CompanyName, ContactName, ContactTitle, City, Country, Phone, Fax)
	VALUES(@CompanyName, @ContactName, @ContactTitle, @City, @Country, @Phone, @Fax)
END
GO
