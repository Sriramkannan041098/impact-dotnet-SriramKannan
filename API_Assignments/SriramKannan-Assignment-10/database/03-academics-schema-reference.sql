USE AcademicsDb;
GO
IF OBJECT_ID('dbo.Teachers','U') IS NULL
CREATE TABLE dbo.Teachers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NULL, -- Identity user ID reference only; no cross-database FK
    FullName NVARCHAR(150) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    CreatedUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
IF OBJECT_ID('dbo.Courses','U') IS NULL
CREATE TABLE dbo.Courses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CourseCode NVARCHAR(30) NOT NULL UNIQUE,
    Title NVARCHAR(150) NOT NULL,
    Description NVARCHAR(1000) NULL,
    TeacherId INT NULL,
    CreatedUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Courses_Teachers FOREIGN KEY (TeacherId) REFERENCES dbo.Teachers(Id)
);
IF OBJECT_ID('dbo.Students','U') IS NULL
CREATE TABLE dbo.Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentNumber NVARCHAR(30) NOT NULL UNIQUE,
    FullName NVARCHAR(150) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    DateOfBirth DATE NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
IF OBJECT_ID('dbo.Enrollments','U') IS NULL
CREATE TABLE dbo.Enrollments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    EnrolledUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    Status NVARCHAR(30) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentId) REFERENCES dbo.Students(Id),
    CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseId) REFERENCES dbo.Courses(Id),
    CONSTRAINT UQ_Enrollments_Student_Course UNIQUE(StudentId, CourseId)
);
GO
