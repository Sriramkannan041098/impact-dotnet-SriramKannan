# EduSphere — Student Management & Academic Intelligence Platform

## Included
- Task 10.1: separate Identity, Academics, Reporting, and YARP gateway projects.
- Task 10.2: ADO.NET repository + stored procedures, PBKDF2 hashing, JWT issuance.
- Task 10.3: EF Core Code First entities, seed data, student/course/teacher CRUD endpoints, role restrictions.
- Task 10.4: Reporting DB First scaffolding instructions and read-only reporting endpoint.
- Task 10.5: YARP route configuration and JWT validation in gateway and services.
- Task 10.6: Dockerfiles and Compose baseline.
- Task 10.7: starter xUnit projects and Selenium smoke test; expand until each service reaches >=80% coverage.
- Task 10.8: React login/signup, student/course views, reporting view, logout.
- Task 10.9: architecture decision note.
- Task 10.10: reporting UI graceful error message.

## Baseline
.NET 8, EF Core 8, SQL Server, React + TypeScript + Vite, Axios, YARP 2.x.

## Build setup
1. Install .NET 8 SDK, Node.js, Docker Desktop, SQL Server/SSMS if running without Docker.
2. Run `scripts/create-solution.ps1` in PowerShell.
3. Restore packages: `dotnet restore`.
4. Configure connection strings and a shared strong JWT signing key via environment variables or local secret storage. Do not commit secrets.
5. Create databases and tables with scripts in `database/`, or implement a SQL initialization container for Compose.
6. Apply Academics migration: `dotnet ef migrations add InitialCreate --project src/backend/AcademicsService --startup-project src/backend/AcademicsService`, then `dotnet ef database update --project src/backend/AcademicsService --startup-project src/backend/AcademicsService`.
7. Scaffold Reporting DB First using `database/README.md`.
8. Start each API and gateway locally; start frontend with `cd src/frontend; npm install; npm run dev`.

## Caveats to close before production/demo
- Apply the initial Academics migration and commit generated files.
- Reporting EF scaffold output must be generated against the actual reporting schema.
- Compose must initialize databases, run migrations, and use readiness checks before the demo.
- Add a safe process to provision a Teacher account; public registration always assigns Student.
- JWT signing keys must be strong, private, and shared consistently across issuer/gateway/services.
- Ensure the gateway strips untrusted identity headers; backend services independently validate JWTs.
- Add controller/integration tests and measure coverage. Starter tests do not guarantee 80%.
- The Selenium test requires a working browser driver and a running frontend.
