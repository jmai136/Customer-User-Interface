USE [GourmetShop]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomers]    Script Date: 1/27/2025 11:33:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCustomers]
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Retrieve all customers
        SELECT 
            Id,
            FirstName ,
            LastName,
            Phone,
            City,
            Country
        FROM 
            Customer
        ORDER BY 
            FirstName; -- Optional: Sort customers by name
    END TRY
    BEGIN CATCH
        -- Handle any errors that occur
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[GetAvailableProducts]    Script Date: 1/27/2025 11:33:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAvailableProducts] 
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id AS ProductID,       -- Include ProductID
        ProductName, 
        UnitPrice AS Price
    FROM Product
    WHERE IsDiscontinued = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerSales]    Script Date: 1/27/2025 11:33:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create stored procedure through filtr through customers and see sales

CREATE PROCEDURE [dbo].[GetCustomerSales]
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Variables to hold the total amount spent by the customer
    DECLARE @TotalSpent DECIMAL(12, 2);

    BEGIN TRY
        -- Get the list of products purchased by the customer and the total amount spent
        SELECT 
            p.ProductName AS ProductName,
            oi.Quantity AS QuantityPurchased,
            oi.UnitPrice AS UnitPrice,
            (oi.Quantity * oi.UnitPrice) AS TotalAmountSpentPerProduct
        FROM 
            Customer c
        INNER JOIN 
            [Order] o ON c.Id = o.CustomerId
        INNER JOIN 
            OrderItem oi ON o.Id = oi.OrderId
        INNER JOIN 
            Product p ON oi.ProductId = p.Id
        WHERE 
            c.Id = @CustomerID

        -- Calculate the total amount spent by the customer
        SELECT 
            @TotalSpent = SUM(oi.Quantity * oi.UnitPrice)
        FROM 
            Customer c
        INNER JOIN 
            [Order] o ON c.Id = o.CustomerId
        INNER JOIN 
            OrderItem oi ON o.Id = oi.OrderId
        WHERE 
            c.Id = @CustomerID;

        -- Return the total amount spent by the customer
        SELECT @TotalSpent AS TotalAmountSpent;

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[GetProductSales]    Script Date: 1/27/2025 11:33:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductSales]
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TotalUnitsSold INT;
    DECLARE @TotalSalesAmount DECIMAL(12, 2);

    BEGIN TRY
        -- Calculate total units sold and total sales amount for the product
        SELECT 
            @TotalUnitsSold = SUM(Quantity),
            @TotalSalesAmount = SUM(UnitPrice * Quantity)
        FROM OrderItem
        WHERE ProductId = @ProductID;

        -- If no sales exist for the product, set the values to 0
        IF @TotalUnitsSold IS NULL
        BEGIN
            SET @TotalUnitsSold = 0;
        END
        IF @TotalSalesAmount IS NULL
        BEGIN
            SET @TotalSalesAmount = 0;
        END

        -- Return the results
        SELECT @TotalUnitsSold AS TotalUnitsSold, @TotalSalesAmount AS TotalSalesAmount;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[GetProductsBySupplierName]    Script Date: 1/27/2025 11:33:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductsBySupplierName]   
    @SupplierName NVARCHAR(40)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.Id AS ProductID,      -- Include ProductID
        p.ProductName, 
        p.UnitPrice AS Price
    FROM Product p
    JOIN Supplier s ON p.SupplierId = s.Id
    WHERE s.CompanyName LIKE '%' + @SupplierName + '%'
      AND p.IsDiscontinued = 0  -- Only include products that are not discontinued
    ORDER BY p.ProductName;
END;
GO
