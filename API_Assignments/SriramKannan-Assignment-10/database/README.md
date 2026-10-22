# Database setup
Run `01-create-databases.sql`, 
then `02-identity-schema.sql`, `03-academics-schema-reference.sql`, and `04-reporting-schema.sql` in SSMS.

Academics is Code First: the SQL file is a schema reference for understanding the intended tables. 
In the application, migrations are the source of schema changes.


Reporting is DB First. After creating `ReportingDb` and its schema, run:
```powershell
dotnet ef dbcontext scaffold "Name=ConnectionStrings:ReportingDb" Microsoft.EntityFrameworkCore.SqlServer --project src/backend/ReportingService --startup-project src/backend/ReportingService --context ReportingDbContext --context-dir Data --output-dir Models --no-onconfiguring --force
```
If `Name=ConnectionStrings:ReportingDb` is not supported by your installed tooling, 
pass a connection string through a secure local environment variable. Do not commit credentials.
