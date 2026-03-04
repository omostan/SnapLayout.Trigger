# SnapLayout.Trigger

[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/download)
[![NuGet](https://img.shields.io/nuget/v/SnapLayout.Trigger.svg)](https://www.nuget.org/packages/SnapLayout.Trigger/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SnapLayout.Trigger.svg)](https://www.nuget.org/packages/SnapLayout.Trigger/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A lightweight WPF library that enables Windows 11 Snap Layout functionality on custom window maximize buttons. Provides native Windows 11-like behavior with both mouse hover and mouse hold interactions.

## Features

- ✨ **Mouse Hover Activation**: Snap Layout popup appears when hovering over the maximize button
- 🖱️ **Mouse Hold Activation**: Snap Layout popup appears after holding the mouse button for 400ms
- 🎯 **Single Method Integration**: One line of code to enable functionality
- 🪟 **Windows 11 Native Behavior**: Mimics the native Windows 11 Snap Layout experience
- 🎨 **Custom Window Chrome Support**: Perfect for applications with custom title bars
- ⚡ **Lightweight**: Minimal dependencies and performance overhead
- 🖥️ **Multi-Monitor Support**: Works seamlessly across multiple displays

## Requirements

- .NET 10.0-windows or later
- WPF Application
- Windows 11 (Snap Layouts are a Windows 11 feature)

## Installation

### NuGet Package Manager

Install-Package SnapLayout.Trigger

### .NET CLI

```bash
dotnet add package SnapLayout.Trigger
```

### Package Reference

```xml
<PackageReference Include="SnapLayout.Trigger" Version="1.0.0" />
```

## Quick Start

### Basic Usage

```csharp
using System.Windows;
using SnapLayout.Trigger;

public partial class MainWindow : Window
{ 
    public MainWindow() {
        InitializeComponent();

        // Enable Snap Layout on your custom maximize button
        SnapLayoutTrigger.Initialize(MaximizeButton);
    }
}
```

That's it! Just one line of code. 🎉

## How It Works

The library uses P/Invoke to simulate the Win+Z keyboard shortcut that triggers Windows 11's native Snap Layout functionality:

1. **Mouse Hover**: When the mouse enters the maximize button, the Snap Layout popup appears immediately
2. **Mouse Hold**: When the left mouse button is pressed and held for 400ms, the Snap Layout popup appears
3. **Quick Click**: Normal maximize/restore behavior is preserved

## API Reference

```bash
public static class SnapLayoutTrigger
{

    /// <summary>
    /// Initializes snap layout behavior by attaching MouseEnter and MouseDown handlers to the maximize button.
    /// </summary> /// <param name="maximizeButton">The maximize button that triggers the Windows snap layout popup.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="maximizeButton"/> is null.</exception>
    public static void Initialize(Button maximizeButton);
}
```

## Example Project

Run the example project:

````bash
cd SnapLayout.Trigger.Example
dotnet run
````

## Testing

Run the NUnit tests:

```bash
dotnet test
```

## Known Limitations

- **Windows 11 Only**: Snap Layouts are a Windows 11 feature
- **P/Invoke Dependency**: Uses Win32 APIs which may be restricted in sandboxed environments
- **Keyboard Simulation**: Simulates Win+Z keypress

## Documentation

- [Quick Start Guide](docs/QUICK_START.md)
- [Release Instructions](docs/RELEASE_INSTRUCTIONS.md)
- [Contributing Guidelines](CONTRIBUTING.md)
- [Changelog](CHANGELOG.md)

## Contributing

Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Stanley Omoregie**  
Omotech Digital Solutions

## Support

- 🐛 [Issues](https://github.com/yourusername/SnapLayout.Trigger/issues)
- 💬 [Discussions](https://github.com/yourusername/SnapLayout.Trigger/discussions)
- 📖 [Documentation](https://github.com/yourusername/SnapLayout.Trigger/wiki)

## Roadmap

- [ ] Support for customizable hold duration
- [ ] Configuration options for hover/hold behavior
- [ ] Additional snap layout customization
- [ ] .NET 9.0 and .NET 8.0 support

---

**Made with ❤️ by Stanley Omoregie**  
Copyright © 2025 Omotech Digital Solutions

