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
-- Author:		Jude Mai
-- Create date: 1/19/2025
-- Description:	Getting the supplier from the ID
-- =============================================
CREATE PROCEDURE GetSupplierById 
	-- Add the parameters for the stored procedure here
	@SupplierId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [GourmetShop].[dbo].[Supplier]
	WHERE Id = @SupplierId
END
GO
