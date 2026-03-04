# Changelog

All notable changes to the SnapLayout.Trigger project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[Unreleased]: https://github.com/omostan/SnapLayout.Trigger/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/omostan/SnapLayout.Trigger/releases/tag/v1.0.0
