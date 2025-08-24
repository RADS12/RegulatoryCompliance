# Code Coverage Reporting: CI Integration & HTML Reports

This guide explains how to automate code coverage reporting in CI and generate HTML reports for your .NET solution.

---

## 1. Prerequisites
- `coverlet.collector` is installed in your test project.
- `dotnet-reportgenerator-globaltool` is installed globally (for HTML reports).

---

## 2. Local Workflow
1. Run tests and collect coverage:
   ```powershell
   dotnet test ./RegulatoryCompliance.Tests/RegulatoryCompliance.Tests.csproj --collect:"XPlat Code Coverage"
   ```
2. Generate HTML report:
   ```powershell
   reportgenerator -reports:"./RegulatoryCompliance.Tests/TestResults/**/coverage.cobertura.xml" -targetdir:"./CoverageReport" -reporttypes:Html
   ```
3. Open `CoverageReport/index.html` in your browser.

---

## 3. GitHub Actions CI Example
```yaml
jobs:
  test-and-coverage:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '8.0.x'
      - name: Restore dependencies
        run: dotnet restore
      - name: Run tests with coverage
        run: dotnet test ./RegulatoryCompliance.Tests/RegulatoryCompliance.Tests.csproj --collect:"XPlat Code Coverage"
      - name: Install ReportGenerator
        run: dotnet tool install -g dotnet-reportgenerator-globaltool
      - name: Generate HTML coverage report
        run: reportgenerator -reports:"./RegulatoryCompliance.Tests/TestResults/**/coverage.cobertura.xml" -targetdir:"./CoverageReport" -reporttypes:Html
      - name: Upload coverage report
        uses: actions/upload-artifact@v3
        with:
          name: coverage-html
          path: CoverageReport
```

---

## 4. Azure DevOps Example
- Use the built-in `PublishCodeCoverageResults` task after running tests with Coverlet.

---

## 5. References
- [Coverlet Documentation](https://github.com/coverlet-coverage/coverlet)
- [ReportGenerator](https://github.com/danielpalme/ReportGenerator)
- [GitHub Actions for .NET](https://docs.github.com/en/actions/guides/building-and-testing-net)

---

For advanced scenarios (thresholds, exclusions, multi-project), let me know!
