# Code Coverage Reporting with Coverlet

This guide explains how to collect and report code coverage for your .NET tests using Coverlet, both locally and in CI.

---

## 1. Prerequisites
- `coverlet.collector` NuGet package is installed in your test project (already added).

---

## 2. Run Tests with Coverage Locally

Open a terminal in your project root and run:

```powershell
# Run tests and collect code coverage

dotnet test ./RegulatoryCompliance.Tests/RegulatoryCompliance.Tests.csproj --collect:"XPlat Code Coverage"
```

- Coverage results will be saved in the `TestResults` folder.
- Look for `coverage.cobertura.xml` or similar files.

---

## 3. Integrate Coverage in CI (GitHub Actions Example)

Add these steps to your workflow YAML:

```yaml
- name: Run tests with coverage
  run: dotnet test ./RegulatoryCompliance.Tests/RegulatoryCompliance.Tests.csproj --collect:"XPlat Code Coverage"

- name: Upload coverage report
  uses: actions/upload-artifact@v3
  with:
    name: coverage-report
    path: RegulatoryCompliance.Tests/TestResults/**/*.xml
```

---

## 4. View and Publish Coverage
- Use tools like [ReportGenerator](https://github.com/danielpalme/ReportGenerator) to convert coverage reports to HTML.
- Services like Codecov or Azure DevOps can publish and visualize coverage results.

---

## 5. References
- [Coverlet Documentation](https://github.com/coverlet-coverage/coverlet)
- [GitHub Actions for .NET](https://docs.github.com/en/actions/guides/building-and-testing-net)

---

For advanced scenarios (thresholds, exclusions, multiple projects), let me know!
