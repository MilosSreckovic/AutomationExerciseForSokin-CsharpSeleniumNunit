# Selenium C# NUnit E2E Automation Framework

[![Selenium E2E Tests](https://github.com/MilosSreckovic/AutomationExerciseForSokin-CsharpSeleniumNunit/actions/workflows/selenium-tests.yml/badge.svg)](https://github.com/MilosSreckovic/AutomationExerciseForSokin-CsharpSeleniumNunit/actions/workflows/selenium-tests.yml)

A UI test automation project built with **C#**, **Selenium WebDriver**, **NUnit**, and **.NET 10**. It demonstrates a maintainable Page Object Model (POM) structure, reusable browser test setup and wait utilities, and automated execution through GitHub Actions.

**Application under test:** [Automation Exercise](https://automationexercise.com/)

## Tech stack

- C# / .NET 10
- Selenium WebDriver
- NUnit
- GitHub Actions

## Test coverage

The repository currently organizes its UI tests into three areas:

| Test class | Focus |
| --- | --- |
| `LoginTests.cs` | Login-related scenarios |
| `SearchAndCartTests.cs` | Product search and shopping-cart scenarios |
| `BrandTests.cs` | Brand navigation and brand-product page checks |

For example, `ViewAndCartBrandProducts` checks that the home page and brand section are visible, then navigates to the Polo and H&M brand pages and verifies the brand heading and URL.

## Project structure

```text
.
├── .github/
│   └── workflows/
│       └── selenium-tests.yml
├── Base/
│   └── BaseTest.cs
├── Pages/
│   ├── AccountDeletedPage.cs
│   ├── CartPage.cs
│   ├── HomePage.cs
│   ├── LoginPage.cs
│   └── ProductsPage.cs
├── Tests/
│   ├── BrandTests.cs
│   ├── LoginTests.cs
│   └── SearchAndCartTests.cs
├── Utilities/
│   ├── ApiHelper.cs
│   └── WaitHelper.cs
├── .gitignore
├── AutomationExerciseForSokin.csproj
└── AutomationExerciseForSokin.slnx
```

Generated build output (`bin/` and `obj/`) is intentionally omitted.

## Framework design

- **Page Object Model:** Page-specific elements and interactions live in `Pages/`, keeping test scenarios readable.
- **Shared test setup:** `Base/BaseTest.cs` provides a central place for test infrastructure.
- **Reusable utilities:** `Utilities/WaitHelper.cs` encapsulates element waits; `ApiHelper.cs` is also present in the project.
- **Test organization:** NUnit test classes are grouped by application feature.

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Google Chrome (for the existing Chrome-based Selenium execution)
- Git

### Clone and run

```bash
git clone https://github.com/MilosSreckovic/AutomationExerciseForSokin-CsharpSeleniumNunit.git
cd AutomationExerciseForSokin-CsharpSeleniumNunit
dotnet restore
dotnet test
```

To run an individual test class:

```bash
dotnet test --filter "FullyQualifiedName~BrandTests"
```

To produce a TRX test result file:

```bash
dotnet test --logger "trx;LogFileName=test-results.trx" --results-directory TestResults
```

> Browser setup and headless behavior depend on the current implementation of `BaseTest.cs` and the GitHub Actions workflow.

## Continuous integration

The project includes a GitHub Actions workflow at `.github/workflows/selenium-tests.yml`. It runs the .NET Selenium/NUnit suite in CI. The badge above reflects the latest workflow status; the suite has also completed a reported run with **3 passed and 0 failed**.

[View workflow runs](https://github.com/MilosSreckovic/AutomationExerciseForSokin-CsharpSeleniumNunit/actions)

## Notes on reliability

UI tests can behave differently between local and CI environments. The brand-navigation scenario previously encountered a CI-only element timeout; a later CI run passed. This does not by itself establish the root cause or prove the test is free of intermittent failures.

## Potential improvements

- Capture screenshots and current URLs automatically on test failures.
- Publish test result artifacts from CI, if not already configured.
- Re-run the suite to assess CI stability and investigate intermittent failures.
- Expand documented test coverage after verifying each scenario's assertions.

## Disclaimer

This is an independent QA portfolio project using the public Automation Exercise demo application. It is not affiliated with the application provider.
