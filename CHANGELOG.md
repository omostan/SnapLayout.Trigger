# Changelog

All notable changes to the SnapLayout.Trigger project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.1] - 2026-03-04

### Changed
- Migrated test framework from xUnit to NUnit for better Visual Studio integration
- Updated test project to use NUnit 4.3.1, NUnit3TestAdapter 4.6.0, and NUnit.Analyzers 4.5.0
- Refactored all test assertions to use NUnit's constraint-based model (`Assert.That()`)
- Updated GitHub Actions workflows to explicitly reference `SnapLayout.sln` to resolve MSBuild ambiguity
- Corrected .NET SDK version in CI/CD workflows to use stable .NET 10.0.x

### Fixed
- Fixed XAML resource ordering issue in example project - moved `Window.Resources` before content to prevent `StaticResource` resolution errors
- Updated `coverlet.collector` package from 6.0.0 to 8.0.0 to address security vulnerabilities
- Fixed GitHub Actions `publish.yml` workflow path separators for cross-platform compatibility
- Added explicit `ArgumentNullException.ThrowIfNull()` validation in `Initialize()` method
- Fixed MSBuild error "MSB1011" in GitHub Actions by specifying solution file in all dotnet commands
- Removed flawed reflection-based tests that checked WPF internals (event handler attachment tests)
- Replaced unreliable tests with meaningful property verification test
- Fixed NuGet pack failure by removing references to non-existent icon files
- Removed duplicate `<PackageIcon>` tags and invalid icon file references from project file
- Updated pack command to run without `--no-build` flag and with verbose output for better diagnostics

### Added
- Comprehensive troubleshooting guide for GitHub publishing (`docs/GITHUB_PUBLISH_TROUBLESHOOTING.md`)
- Enhanced XML documentation with `<exception>` tags for `Initialize()` method
- Added `[TestFixture]` attribute to test class for NUnit compatibility

### Security
- Updated `coverlet.collector` from 6.0.0 to 8.0.0 (addresses Mend.io reported vulnerabilities)

## [1.0.0] - 2025-01-27

### Added
- Initial release of SnapLayout.Trigger library
- `SnapLayoutTrigger.Initialize()` method to enable Snap Layout functionality on WPF buttons
- Mouse hover activation - Snap Layout popup appears on MouseEnter event
- Mouse hold activation - Snap Layout popup appears after holding left mouse button for 400ms
- Support for multi-monitor setups with automatic screen coordinate calculation
- P/Invoke implementation using `LibraryImport` for Win32 API calls (`keybd_event`, `SetCursorPos`)
- Comprehensive XML documentation for all public APIs
- Example project demonstrating custom window chrome with Snap Layout integration
- Unit test project with xUnit covering initialization and event handling scenarios
- NuGet package metadata and configuration
- MIT License
- README.md with quick start guide and complete examples
- Support for .NET 10.0-windows target framework

### Technical Details
- Uses Win+Z keyboard simulation to trigger native Windows 11 Snap Layouts
- Automatic cursor positioning to button center for consistent behavior
- Timer-based hold detection (400ms threshold)
- Proper cleanup of event handlers and timers
- Thread-safe implementation using WPF Dispatcher

### Known Limitations
- Requires Windows 11 (Snap Layouts feature)
- Uses keyboard simulation which may be restricted in sandboxed environments
- P/Invoke dependencies may require full trust execution context

---

## Release Notes Template for Future Versions

### [X.Y.Z] - YYYY-MM-DD

#### Added
- New features

#### Changed
- Changes in existing functionality

#### Deprecated
- Soon-to-be removed features

#### Removed
- Removed features

#### Fixed
- Bug fixes

#### Security
- Security fixes

---

[Unreleased]: https://github.com/omostan/SnapLayout.Trigger/compare/v1.0.1...HEAD
[1.0.1]: https://github.com/omostan/SnapLayout.Trigger/compare/v1.0.0...v1.0.1
[1.0.0]: https://github.com/omostan/SnapLayout.Trigger/releases/tag/v1.0.0

#### Removed
- Removed features

#### Fixed
- Bug fixes

#### Security
- Security fixes

---

[Unreleased]: https://github.com/omostan/SnapLayout.Trigger/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/omostan/SnapLayout.Trigger/releases/tag/v1.0.0
