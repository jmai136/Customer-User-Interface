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
-- Description:	Insert new products in the Products table>
-- =============================================
CREATE PROCEDURE AddProduct
	-- Add the parameters for the stored procedure here
	@ProductName NVARCHAR(50),
	@SupplierId INT,
	@UnitPrice DECIMAL(12,2) = null,
	@Package NVARCHAR(30) = null,
	@IsDiscontinued BIT
AS
BEGIN
	-- Insert statements for procedure here
	-- https://stackoverflow.com/questions/14142320/use-stored-procedure-to-insert-some-data-into-a-table
	INSERT INTO [GourmetShop].[dbo].[Product](ProductName, SupplierId, UnitPrice, Package, IsDiscontinued)
	VALUES(@ProductName, @SupplierId, @UnitPrice, @Package, @IsDiscontinued)
END
GO
