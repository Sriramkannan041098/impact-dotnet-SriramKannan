# Testing

Add test projects to the solution with `dotnet sln EduSphere.sln add tests/**/**/*.csproj` (or add each project explicitly in PowerShell).

Run unit tests:
```powershell
dotnet test tests/IdentityService.Tests
dotnet test tests/AcademicsService.Tests
dotnet test tests/ReportingService.Tests
```

Run Selenium only after the frontend is running and Chrome/ChromeDriver can be provisioned:
```powershell
$env:EDUSPHERE_FRONTEND_URL = "http://localhost:5173"
dotnet test tests/EduSphere.E2E
```

The included tests are starter tests, not proof of 80% coverage. Add controller/service integration tests and authorization tests until each service meets the target measured by CI.
