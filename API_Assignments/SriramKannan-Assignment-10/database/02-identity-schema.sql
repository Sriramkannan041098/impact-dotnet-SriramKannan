USE IdentityDb;
GO
IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Email NVARCHAR(256) NOT NULL UNIQUE,
        DisplayName NVARCHAR(120) NOT NULL,
        PasswordHash NVARCHAR(512) NOT NULL,
        PasswordSalt NVARCHAR(256) NOT NULL,
        PasswordIterations INT NOT NULL,
        Role NVARCHAR(30) NOT NULL CONSTRAINT DF_Users_Role DEFAULT ('Student'),
        IsActive BIT NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1),
        CreatedUtc DATETIME2 NOT NULL CONSTRAINT DF_Users_CreatedUtc DEFAULT SYSUTCDATETIME()
    );
END;
GO

IF OBJECT_ID('dbo.usp_User_GetByEmail', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_User_GetByEmail;
GO
CREATE PROCEDURE dbo.usp_User_GetByEmail @Email NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Email, DisplayName, PasswordHash, PasswordSalt, PasswordIterations, Role, IsActive
    FROM dbo.Users WHERE Email = @Email;
END;
GO

IF OBJECT_ID('dbo.usp_User_Create', 'P') IS NOT NULL DROP PROCEDURE dbo.usp_User_Create;
GO
CREATE PROCEDURE dbo.usp_User_Create
    @Email NVARCHAR(256), @DisplayName NVARCHAR(120),
    @PasswordHash NVARCHAR(512), @PasswordSalt NVARCHAR(256),
    @PasswordIterations INT, @Role NVARCHAR(30)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT dbo.Users (Email, DisplayName, PasswordHash, PasswordSalt, PasswordIterations, Role)
    VALUES (@Email, @DisplayName, @PasswordHash, @PasswordSalt, @PasswordIterations, @Role);
    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;
GO
