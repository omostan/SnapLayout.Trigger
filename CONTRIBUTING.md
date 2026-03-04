# Contributing to SnapLayout.Trigger

Thank you for your interest in contributing to SnapLayout.Trigger! We welcome contributions from the community.

## Code of Conduct

By participating in this project, you agree to maintain a respectful and collaborative environment.

## How to Contribute

### Reporting Bugs

If you find a bug, please create an issue on GitHub with:
- A clear, descriptive title
- Steps to reproduce the issue
- Expected behavior
- Actual behavior
- Your environment (OS version, .NET version, etc.)
- Screenshots or code samples if applicable

### Suggesting Features

Feature suggestions are welcome! Please create an issue with:
- A clear description of the feature
- Use cases and benefits
- Any relevant examples or mockups

### Submitting Pull Requests

1. **Fork the repository**
   ```bash
   git clone https://github.com/yourusername/SnapLayout.Trigger.git
   cd SnapLayout.Trigger
   ```

2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make your changes**
   - Follow the existing code style
   - Add or update tests as needed
   - Update documentation if required
   - Ensure all tests pass

4. **Commit your changes**
   ```bash
   git add .
   git commit -m "Add: brief description of your changes"
   ```
   
   Use conventional commit messages:
   - `Add:` for new features
   - `Fix:` for bug fixes
   - `Update:` for changes to existing features
   - `Remove:` for deleted features
   - `Docs:` for documentation changes

5. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create a Pull Request**
   - Go to the original repository
   - Click "New Pull Request"
   - Select your fork and branch
   - Provide a clear description of your changes

## Development Setup

### Prerequisites

- Visual Studio 2022 or later (or JetBrains Rider)
- .NET 10.0 SDK or later
- Windows 11 (for testing Snap Layout functionality)

### Building the Project

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run tests
dotnet test

# Run the example project
cd SnapLayout.Trigger.Example
dotnet run
```

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test
dotnet test --filter "FullyQualifiedName~Initialize_WithValidButton_DoesNotThrow"
```

## Coding Standards

### C# Style Guidelines

- Use C# 14.0 features where appropriate
- Follow Microsoft's C# coding conventions
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Use nullable reference types

### Code Example

```csharp
/// <summary>
/// Initializes snap layout behavior.
/// </summary>
/// <param name="button">The maximize button.</param>
public static void Initialize(Button button)
{
    ArgumentNullException.ThrowIfNull(button);
    // Implementation...
}
```

### Testing Guidelines

- Write tests for all new features
- Ensure tests are deterministic and isolated
- Use descriptive test names following the pattern: `MethodName_Scenario_ExpectedBehavior`
- Use STA threads for WPF-related tests
- Use NUnit attributes: `[Test]`, `[TestFixture]`, `[TestCase]`

### Documentation

- Update README.md for new features
- Update CHANGELOG.md following Keep a Changelog format
- Add XML documentation for all public APIs
- Include code examples where appropriate

## Project Structure

```
SnapLayout.Trigger/
├── SnapLayout.Trigger/              # Main library project
│   └── SnapLayoutTrigger.cs         # Core implementation
├── SnapLayout.Trigger.Example/      # Example WPF application
│   ├── MainWindow.xaml              # Example window
│   └── MainWindow.xaml.cs           # Example code-behind
├── SnapLayout.Trigger.Tests/        # Unit tests
│   └── SnapLayoutTriggerTests.cs    # Test suite
├── .github/workflows/               # CI/CD pipelines
├── README.md                        # Project documentation
├── CHANGELOG.md                     # Version history
└── LICENSE                          # MIT License
```

## Release Process

1. Update version in `SnapLayout.Trigger.csproj`
2. Update `CHANGELOG.md` with new version details
3. Create a new GitHub release with tag `vX.Y.Z`
4. GitHub Actions will automatically build and publish to NuGet

## Getting Help

- Create an issue for questions
- Check existing issues and discussions
- Review the documentation in README.md

## License

By contributing, you agree that your contributions will be licensed under the MIT License.

---

Thank you for contributing to SnapLayout.Trigger! 🎉
