USE ReportingDb;
GO
-- Treat this schema as pre-existing/externally managed. ReportingService scaffolds it.
IF OBJECT_ID('dbo.EnrollmentSummary','U') IS NULL
CREATE TABLE dbo.EnrollmentSummary (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CourseCode NVARCHAR(30) NOT NULL,
    CourseTitle NVARCHAR(150) NOT NULL,
    TeacherName NVARCHAR(150) NULL,
    TotalStudents INT NOT NULL DEFAULT 0,
    ActiveEnrollments INT NOT NULL DEFAULT 0,
    SnapshotUtc DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
GO
