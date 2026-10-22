$ErrorActionPreference = "Stop"
dotnet new sln -n EduSphere
$projects = @(
  "src/backend/IdentityService/IdentityService.csproj",
  "src/backend/AcademicsService/AcademicsService.csproj",
  "src/backend/ReportingService/ReportingService.csproj",
  "src/backend/ApiGateway/ApiGateway.csproj",
  "tests/IdentityService.Tests/IdentityService.Tests.csproj",
  "tests/AcademicsService.Tests/AcademicsService.Tests.csproj",
  "tests/ReportingService.Tests/ReportingService.Tests.csproj",
  "tests/EduSphere.E2E/EduSphere.E2E.csproj"
)
foreach ($project in $projects) { dotnet sln EduSphere.sln add $project }
