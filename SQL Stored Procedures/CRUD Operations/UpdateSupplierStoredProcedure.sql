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
-- Create date: <1/14/2025>
-- Description:	<Update a supplier in the Suppliers table>
-- =============================================
CREATE PROCEDURE UpdateSupplier
	-- Add the parameters for the stored procedure here
	@SupplierId INT,
	@CompanyName NVARCHAR(40),
	@ContactName NVARCHAR(50) = null,
    @ContactTitle NVARCHAR(40) = null,
    @City NVARCHAR(40) = null,
    @Country NVARCHAR(40) = null,
    @Phone NVARCHAR(30)  =  null,
    @Fax NVARCHAR(30) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE  [GourmetShop].[dbo].[Supplier] SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, City = @City , Country = @Country, Phone = @Phone, Fax = @Fax WHERE Id = @SupplierId
END
GO
