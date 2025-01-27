USE [GourmetShop]
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[CartItemID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](12, 2) NOT NULL,
	[TotalAmount] [decimal](12, 2) NOT NULL,
	[OrderID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CartItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ShoppingCart]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
/****** Object:  StoredProcedure [dbo].[AddToCart]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddToCart]
    @CustomerID INT,
    @ProductID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Price DECIMAL(12, 2);
    DECLARE @TotalAmount DECIMAL(12, 2);

    BEGIN TRY
        -- Get the price of the product
        SELECT @Price = UnitPrice FROM Product WHERE Id = @ProductID;

        IF @Price IS NULL
        BEGIN
            THROW 50001, 'Product not found.', 1;
        END

        -- Calculate the total amount for the product
        SET @TotalAmount = @Price * @Quantity;

        -- Check if the product already exists in the cart
        IF EXISTS (SELECT 1 FROM ShoppingCart WHERE CustomerID = @CustomerID AND ProductID = @ProductID)
        BEGIN
            -- If it exists, update the quantity and total amount
            UPDATE ShoppingCart
            SET Quantity = Quantity + @Quantity,
                TotalAmount = TotalAmount + @TotalAmount
            WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
        END
        ELSE
        BEGIN
            -- If it doesn't exist, add the item to the cart
            INSERT INTO ShoppingCart (CustomerID, ProductID, Quantity, Price, TotalAmount)
            VALUES (@CustomerID, @ProductID, @Quantity, @Price, @TotalAmount);
        END
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromCart]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteFromCart]
    @CustomerID INT,
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Remove the item from the cart
        DELETE FROM ShoppingCart
        WHERE CustomerID = @CustomerID AND ProductID = @ProductID;

        -- Update and return the cart total
        EXEC UpdateCartTotal @CustomerID;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCartTotal]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCartTotal]
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CartTotal DECIMAL(12, 2);

    BEGIN TRY
        -- Calculate the current cart total by summing the TotalAmount for each item
        SELECT @CartTotal = SUM(TotalAmount)
        FROM ShoppingCart
        WHERE CustomerID = @CustomerID AND OrderID IS NULL;

        -- If no items in the cart, set total to 0
        IF @CartTotal IS NULL
        BEGIN
            SET @CartTotal = 0;
        END

        -- Return the current cart total
        SELECT @CartTotal AS CartTotal;
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[PlaceOrder]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PlaceOrder]
    @CustomerId INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @OrderId INT;
    DECLARE @OrderNumber NVARCHAR(10);
    DECLARE @TotalAmount DECIMAL(12, 2);

    BEGIN TRY
        -- Step 1: Get the last order number from the entire Order table
        DECLARE @LastOrderNumber INT;
        SELECT @LastOrderNumber = MAX(CAST(OrderNumber AS INT))
        FROM "Order";

        -- Step 2: Increment the last order number by 1
        SET @OrderNumber = CAST(@LastOrderNumber + 1 AS NVARCHAR(10));

        -- Step 3: Create a new order in the "Order" table with the generated OrderNumber
        INSERT INTO "Order" (OrderDate, OrderNumber, CustomerId, TotalAmount)
        VALUES (GETDATE(), @OrderNumber, @CustomerId, 0);  -- Initially set TotalAmount to 0

        -- Step 4: Use SCOPE_IDENTITY() to get the newly inserted OrderId
        SET @OrderId = SCOPE_IDENTITY();

        -- Step 5: Calculate the total amount from the ShoppingCart for this customer
        SELECT @TotalAmount = SUM(Price * Quantity)
        FROM ShoppingCart
        WHERE CustomerID = @CustomerId AND OrderID IS NULL;  -- Only consider items not already in an order

        -- Step 6: Update the TotalAmount in the "Order" table
        UPDATE "Order"
        SET TotalAmount = @TotalAmount
        WHERE Id = @OrderId;

        -- Step 7: Insert the cart items into the OrderItem table
        INSERT INTO OrderItem (OrderId, ProductId, UnitPrice, Quantity)
        SELECT @OrderId, ProductID, Price, Quantity
        FROM ShoppingCart
        WHERE CustomerID = @CustomerId AND OrderID IS NULL;  -- Ensure these items are not yet in an order

        -- Step 8: Delete the items from the ShoppingCart after placing the order
        DELETE FROM ShoppingCart
        WHERE CustomerID = @CustomerId AND OrderID IS NULL;

        -- Step 9: Return the new order details
        SELECT @OrderId AS OrderId, @OrderNumber AS OrderNumber, @TotalAmount AS TotalAmount;

    END TRY
    BEGIN CATCH
        -- Handle errors (optional)
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateCartTotal]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCartTotal]
    @CustomerID INT,
    @ProductID INT = NULL,
    @Quantity INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Check if @ProductID and @Quantity are provided
        IF @ProductID IS NOT NULL AND @Quantity IS NOT NULL
        BEGIN
            DECLARE @Price DECIMAL(12, 2);
            DECLARE @TotalAmount DECIMAL(12, 2);

            -- Get the price of the product
            SELECT @Price = UnitPrice FROM Product WHERE Id = @ProductID;

            IF @Price IS NULL
            BEGIN
                THROW 50001, 'Product not found.', 1;
            END

            -- Calculate the total amount for the updated quantity
            SET @TotalAmount = @Price * @Quantity;

            -- Update the quantity and total amount in the cart
            UPDATE ShoppingCart
            SET Quantity = @Quantity,
                TotalAmount = @TotalAmount
            WHERE CustomerID = @CustomerID AND ProductID = @ProductID;
        END

        -- Recalculate the cart total for the customer
        UPDATE ShoppingCart
        SET TotalAmount = Quantity * (SELECT UnitPrice FROM Product WHERE Product.Id = ProductID)
        WHERE CustomerID = @CustomerID;

    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[ViewShoppingCart]    Script Date: 1/27/2025 11:31:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ViewShoppingCart]
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Retrieve all cart items for the customer
    SELECT 
        SC.CartItemID,
        SC.CustomerID,
        SC.ProductID,
        P.ProductName,
        SC.Quantity,
        SC.Price,
        SC.TotalAmount -- Already stored in the table
    FROM 
        ShoppingCart SC
    INNER JOIN 
        Product P ON SC.ProductID = P.Id
    WHERE 
        SC.CustomerID = @CustomerID;

    -- Calculate the overall total for the cart
    SELECT 
        SUM(SC.TotalAmount) AS CartTotalAmount
    FROM 
        ShoppingCart SC
    WHERE 
        SC.CustomerID = @CustomerID;
END;
GO
