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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Jude Mai>
-- Create date: <1/7/2025>
-- Description:	<Update a product in the Products table>
-- =============================================
CREATE PROCEDURE UpdateProduct
	-- Add the parameters for the stored procedure here
	@ProductId INT,
	@ProductName NVARCHAR(50),
	@SupplierId INT,
	@UnitPrice DECIMAL(12,2) = null,
	@Package NVARCHAR(30) = null,
	@IsDiscontinued BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE  [GourmetShop].[dbo].[Product] SET ProductName = @ProductName, SupplierId = @SupplierId, UnitPrice = @UnitPrice, Package = @Package, IsDiscontinued = @IsDiscontinued WHERE Id = @ProductId
END
GO
