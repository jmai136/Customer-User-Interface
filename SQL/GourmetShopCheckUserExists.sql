CREATE PROCEDURE CheckUserExists
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Phone NVARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT COUNT(*) 
    FROM Customer
    WHERE @FirstName = @FirstName 
    AND @LastName = @LastName 
    AND @Phone = @Phone;
END;