# RegulatoryCompliance

## Overview
I developed this personal project, RegulatoryCompliance, to demonstrate my expertise in building Web APIs using C# and .NET. The project incorporates a broad range of concepts, including Object-Oriented Programming, Design Patterns, SOLID principles, asynchronous programming, and multi-threading.

You’ll find these concepts applied in controllers, services, facades, and data access layers.

In the process, I also explored .NET 9, telemetry, and other new features. By combining hands-on coding with AI tools such as GitHub Copilot, I gained valuable insight into how AI can accelerate development and enhance productivity.

## About the Architecture
This project demonstrates advanced C# and .NET skills, including:
- **Object-Oriented Programming:** All business logic and models are designed using OOP principles for maintainability and extensibility.
  - The solution is organized into logical namespaces and folders (e.g., Models, Facade, Interfaces) reflecting real-world entities and responsibilities.
  - Core business logic is encapsulated in classes such as RegulatoryRulesEngine, LoanSqlManager, and various Facade implementations.
  - Core business logic is encapsulated in classes such as RegulatoryRulesEngine, LoanSqlManager, and various Facade implementations.
  - Inheritance and interfaces are used to enable extensibility and polymorphism (e.g., IRegulatoryRuleFacade, IAppSettingsService).
  - Encapsulation is maintained by keeping fields private and exposing only necessary properties and methods.
  - Composition is used for dependency injection, allowing services to be easily swapped or mocked for testing.
  - Controllers interact with models and services, demonstrating separation of concerns and clear object boundaries.

- **Design Patterns:**
  - **Facade Pattern:** Used in the BusinessManager/Facade/ layer to provide a unified interface to a set of regulatory rule subsystems (e.g., HighCostRuleFacade, SafeHarborRuleFacade).
  - **Dependency Injection:** All services, facades, and data access layers are injected via constructors and registered in Program.cs for loose coupling and testability.
  - **Singleton Pattern:** Used for configuration and caching services (e.g., IAppSettingsService, Redis cache registration).
  - **Strategy Pattern:** The rule engine and facade implementations allow for interchangeable algorithms for regulatory rule evaluation.
  - **Repository Pattern:** Data access logic is abstracted in manager classes (e.g., LoanSqlManager) for separation of concerns.
  - **Factory Pattern:** Connection factories (e.g., SqlDbConnectionFactory) are used to create database connections.
  - **Observer Pattern:** Application Insights telemetry and health checks act as observers for system events and metrics.
  - **Decorator Pattern:** Serilog enrichers add extra behavior to logging without modifying the core logger.

- **SOLID Principles:** The codebase follows SOLID for robust, flexible, and testable design.
  - **Single Responsibility Principle:** Each class and service (e.g., controllers, facades, managers) has one clear responsibility, making the codebase easier to maintain and extend.
  - **Open/Closed Principle:** Business logic and rule evaluation are designed to be extended via new facades or models without modifying existing code.
  - **Liskov Substitution Principle:** Interfaces and base types (e.g., IRegulatoryRuleFacade, IAppSettingsService) allow for substitutable implementations throughout the solution.
  - **Interface Segregation Principle:** Interfaces are focused and granular, so classes only implement what they need (e.g., separation of rule facades, data access, and configuration services).
  - **Dependency Inversion Principle:** High-level modules depend on abstractions (interfaces), and dependencies are injected via constructors, supporting loose coupling and testability.

- **Asynchronous Programming:**
  - The API uses async/await for controller actions and service methods to ensure non-blocking I/O and scalable request handling.
  - Database operations and external service calls are performed asynchronously to maximize throughput and responsiveness.
  - Asynchronous patterns are used in integration tests and health checks for realistic, production-grade testing.
  - The use of async APIs helps prevent thread starvation and improves performance under load.

- **Multi-threading:**
  - The solution leverages .NET's Task Parallel Library (TPL) and parallel LINQ (PLINQ) for concurrent data processing and performance optimization.
  - Multi-threading is used in scenarios such as batch rule evaluation, background jobs, and parallel database queries to reduce latency.
  - Thread-safe patterns and synchronization primitives (e.g., locks, concurrent collections) are applied where shared state is accessed.
  - The architecture ensures thread safety in caching, logging, and configuration services to prevent race conditions and data corruption.

- **.NET 9 Features Used**
  - **Enhanced Minimal APIs and Endpoint Routing:**
    - Utilizes improvements in minimal API design and endpoint routing for cleaner, more efficient controller and health check setup.
  - **Improved Telemetry & Diagnostics:**
    - Integrates Application Insights with more granular diagnostics and custom metrics/events.
  - **Performance Optimizations:**
    - Benefits from .NET 9's faster startup, reduced memory usage, and optimized async/await handling for better scalability.
  - **Advanced Containerization:**
    - Leverages improved .NET 9 support for building and running Docker containers, including diagnostics and resource management.

## Description
RegulatoryCompliance is a robust .NET API for regulatory rule validation, health checks, monitoring, and secure endpoints. It follows best practices for validation, error handling, logging, authentication, configuration, and CI/CD.

## Getting Started
1. **Clone the repository:**
	```sh
	git clone https://github.com/RADS12/RegulatoryCompliance.git
	cd RegulatoryCompliance
	```
2. **Install .NET 9 SDK:**
	- Download from https://dotnet.microsoft.com/download/dotnet/9.0
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
6. **Run in Docker:**
	```sh
	docker build -t regulatorycompliance:latest .
	docker run -p 8080:80 regulatorycompliance:latest
	```
7. **Generate Code Coverage Report:**
	```sh
	dotnet test ./RegulatoryCompliance.Tests/RegulatoryCompliance.Tests.csproj --collect:"XPlat Code Coverage"
	reportgenerator -reports:"./RegulatoryCompliance.Tests/TestResults/**/coverage.cobertura.xml" -targetdir:"./CoverageReport" -reporttypes:Html
	```

## Features
- Input validation (FluentValidation, DataAnnotations)
- Global exception handling (ProblemDetails)
- Structured logging (Serilog, enrichers, sinks)
- JWT authentication & OpenAPI security
 - Health checks (/health endpoint)
- Application Insights monitoring
- Performance profiling (MiniProfiler)
- In-memory and Redis distributed caching
- API versioning (Microsoft.AspNetCore.Mvc.Versioning)
- Rate limiting (AspNetCoreRateLimit)
- CI/CD automation (GitHub Actions)
- Code quality tools (StyleCop, FxCop, dotnet-format)
- Blue-green/slot deployments (see docs)
- API Gateway integration (see docs)
- Docker containerization (see Dockerfile)
- Code coverage reporting (Coverlet, ReportGenerator)

## API Documentation
- Swagger UI available at /swagger
- XML comments and example requests/responses
- JWT Bearer authentication supported in Swagger

## Developer Guide
- **Add new rules:** Implement IRegulatoryRuleFacade in BusinessManager/Facade/
- **Add new models:** Place in Common/Models/
- **Add new controllers:** Place in RegulatoryCompliance/Controllers/
- **Add tests:** Use xUnit in RegulatoryCompliance.Tests/
- **Configure settings:** Edit appsettings.json and use environment variables for secrets

## CI/CD
- Automated build, test, code coverage, and code quality checks via GitHub Actions
- See .github/workflows/ for pipeline definitions

## Health & Monitoring
- /health endpoint for health checks
- Application Insights for telemetry

## Security
- JWT authentication for protected endpoints
- OpenAPI security definitions for Swagger

## Documentation
- See Documents/ZeroDowntimeDeployment.md for deployment slots/blue-green
- See Documents/ApiGatewayIntegration.md for API Gateway setup
- See Documents/DockerBuildRun.md for Docker usage
- See Documents/CodeCoverageReporting.md and Documents/CodeCoverageCI.md for coverage reporting

## Contributing
Pull requests are welcome! Please follow code style guidelines and add tests for new features.

## License
MIT
