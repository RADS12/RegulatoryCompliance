
# RegulatoryCompliance

## Overview
RegulatoryCompliance is a robust .NET API for regulatory rule validation, health checks, monitoring, and secure endpoints. It follows best practices for validation, error handling, logging, authentication, configuration, and CI/CD.

## Getting Started
1. **Clone the repository:**
	```sh
	git clone https://github.com/RADS12/RegulatoryCompliance.git
	cd RegulatoryCompliance
	```
2. **Install .NET 8 SDK:**
	- Download from https://dotnet.microsoft.com/download/dotnet/8.0
3. **Restore dependencies:**
	```sh
	dotnet restore RegulatoryCompliance/RegulatoryCompliance.csproj
	```
4. **Build the project:**
	```sh
	dotnet build RegulatoryCompliance/RegulatoryCompliance.csproj
	```
5. **Run the API:**
	```sh
	dotnet run --project RegulatoryCompliance/RegulatoryCompliance.csproj
	```

## Features
- Input validation (FluentValidation, DataAnnotations)
- Global exception handling (ProblemDetails)
- Structured logging (Serilog, enrichers, sinks)
- JWT authentication & OpenAPI security
- Health checks (`/health` endpoint)
- Application Insights monitoring
- Performance profiling (MiniProfiler)
- In-memory caching
- CI/CD automation (GitHub Actions)
- Code quality tools (StyleCop, FxCop, dotnet-format)

## API Documentation
- Swagger UI available at `/swagger`
- XML comments and example requests/responses
- JWT Bearer authentication supported in Swagger

## Developer Guide
- **Add new rules:** Implement `IRegulatoryRuleFacade` in `BusinessManager/Facade/`
- **Add new models:** Place in `Common/Models/`
- **Add new controllers:** Place in `RegulatoryCompliance/Controllers/`
- **Add tests:** Use xUnit in `RegulatoryCompliance.Tests/`
- **Configure settings:** Edit `appsettings.json` and use environment variables for secrets

## CI/CD
- Automated build, test, and code quality checks via GitHub Actions
- See `.github/workflows/` for pipeline definitions

## Health & Monitoring
- `/health` endpoint for health checks
- Application Insights for telemetry

## Security
- JWT authentication for protected endpoints
- OpenAPI security definitions for Swagger

## Contributing
Pull requests are welcome! Please follow code style guidelines and add tests for new features.

## License
MIT
