USE [GourmetShop]
GO
/****** Object:  StoredProcedure [dbo].[GetAvailableProducts]    Script Date: 2/1/2025 5:28:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*==============================================================*/
/* Stored procedure: GetProducts                                  */
/*==============================================================*/

--CHECKME

/*==============================================================*/

--Description: This is used to see a list of available products that are not discontinued this would be used in the customer view 
--can be displayed in data grid view.


ALTER PROCEDURE [dbo].[GetAvailableProducts] 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id AS ProductID,       -- Include ProductID
        ProductName,
		SupplierId,
        UnitPrice AS Price
    FROM Product
    WHERE IsDiscontinued = 0;
END;

