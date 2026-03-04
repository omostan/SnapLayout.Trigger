# Quick Start Guide - SnapLayout.Trigger

Get up and running with SnapLayout.Trigger in under 5 minutes!

## Installation

```bash
dotnet add package SnapLayout.Trigger
```

## Minimal Example

### Step 1: Create a WPF Window with Custom Chrome

**MainWindow.xaml:**
```xml
<Window x:Class="MyApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        WindowStyle="None"
        ResizeMode="CanResize"
        Title="My App" Height="450" Width="800">
    
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="32"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <!-- Title Bar -->
        <Grid Grid.Row="0" Background="#2D2D30">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                <Button x:Name="MaximizeButton" Content="⬜" Width="46" Height="32"/>
            </StackPanel>
        </Grid>

        <!-- Content -->
        <Grid Grid.Row="1">
            <TextBlock Text="Hello, World!" HorizontalAlignment="Center" VerticalAlignment="Center"/>
        </Grid>
    </Grid>
</Window>
```

### Step 2: Initialize SnapLayout in Code-Behind

**MainWindow.xaml.cs:**
```csharp
using System.Windows;
using SnapLayout.Trigger;

namespace MyApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // ✨ That's it! One line enables Snap Layout
        SnapLayoutTrigger.Initialize(MaximizeButton);
    }
}
```

### Step 3: Run Your App

```bash
dotnet run
```

Now hover over or hold the maximize button to see Windows 11 Snap Layouts! 🎉

## What Just Happened?

The `Initialize` method attaches event handlers to your maximize button that:
- Show Snap Layout popup on **mouse hover**
- Show Snap Layout popup on **400ms hold**
- Preserve normal maximize behavior on **quick click**

## Next Steps

- [View the full example project](../SnapLayout.Trigger.Example)
- [Read the complete documentation](../README.md)
- [Check out the API reference](../README.md#api-reference)

## Requirements

- Windows 11 (Snap Layouts are a Windows 11 feature)
- .NET 10.0-windows or later
- WPF Application

## Troubleshooting

**Q: Snap Layout doesn't appear**
- Ensure you're running on Windows 11
- Verify WindowStyle is set to "None" (custom chrome)
- Check that the button is visible and clickable

**Q: It interferes with my maximize logic**
- The library preserves normal click behavior
- Only hover and hold (400ms) trigger Snap Layout

**Q: Multi-monitor issues**
- The library automatically handles multi-monitor setups
- Ensure your window positioning logic is correct

## Need Help?

- 📖 [Full Documentation](../README.md)
- 🐛 [Report Issues](https://github.com/yourusername/SnapLayout.Trigger/issues)
- 💬 [GitHub Discussions](https://github.com/yourusername/SnapLayout.Trigger/discussions)

---

Made with ❤️ for the WPF community
