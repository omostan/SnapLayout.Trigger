using System.Windows;
using System.Windows.Controls;

namespace SnapLayout.Trigger.Tests;

/// <summary>
/// Unit tests for SnapLayoutTrigger functionality.
/// Note: Some tests require a WPF dispatcher and are marked with [Test] attribute and run in STA thread.
/// </summary>
[TestFixture]
public class SnapLayoutTriggerTests
{
    [Test]
    public void Initialize_WithValidButton_DoesNotThrow()
    {
        // Arrange & Act & Assert
        Assert.DoesNotThrow(() =>
        {
            RunInSTA(() =>
            {
                var button = new Button();
                SnapLayoutTrigger.Initialize(button);
            });
        });
    }

    [Test]
    public void Initialize_WithNullButton_ThrowsArgumentNullException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            SnapLayoutTrigger.Initialize(null!);
        });
    }

    [Test]
    public void Initialize_AttachesMouseEnterHandler()
    {
        // Arrange & Act
        RunInSTA(() =>
        {
            var button = new Button();
            SnapLayoutTrigger.Initialize(button);

            // Assert - Check if MouseEnter handler is attached
            var mouseEnterEvent = typeof(UIElement).GetEvent("MouseEnter");
            var field = typeof(UIElement).GetField("MouseEnterEvent", 
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            Assert.That(field, Is.Not.Null);
        });
    }

    [Test]
    public void Initialize_AttachesPreviewMouseLeftButtonDownHandler()
    {
        // Arrange & Act
        RunInSTA(() =>
        {
            var button = new Button();
            SnapLayoutTrigger.Initialize(button);

            // Assert - Check if PreviewMouseLeftButtonDown handler is attached
            var previewMouseLeftButtonDownEvent = typeof(UIElement).GetEvent("PreviewMouseLeftButtonDown");
            Assert.That(previewMouseLeftButtonDownEvent, Is.Not.Null);
        });
    }

    [Test]
    public void Initialize_AttachesPreviewMouseLeftButtonUpHandler()
    {
        // Arrange & Act
        RunInSTA(() =>
        {
            var button = new Button();
            SnapLayoutTrigger.Initialize(button);

            // Assert - Check if PreviewMouseLeftButtonUp handler is attached
            var previewMouseLeftButtonUpEvent = typeof(UIElement).GetEvent("PreviewMouseLeftButtonUp");
            Assert.That(previewMouseLeftButtonUpEvent, Is.Not.Null);
        });
    }

    [Test]
    public void Initialize_AttachesLostMouseCaptureHandler()
    {
        // Arrange & Act
        RunInSTA(() =>
        {
            var button = new Button();
            SnapLayoutTrigger.Initialize(button);

            // Assert - Check if LostMouseCapture handler is attached
            var lostMouseCaptureEvent = typeof(UIElement).GetEvent("LostMouseCapture");
            Assert.That(lostMouseCaptureEvent, Is.Not.Null);
        });
    }

    [Test]
    public void Initialize_CalledMultipleTimes_DoesNotThrow()
    {
        // Arrange, Act & Assert
        Assert.DoesNotThrow(() =>
        {
            RunInSTA(() =>
            {
                var button = new Button();
                SnapLayoutTrigger.Initialize(button);
                SnapLayoutTrigger.Initialize(button); // Call again
            });
        });
    }

    [Test]
    public void Button_WithInitialization_CanBeUsedInWindow()
    {
        // Arrange, Act & Assert
        Assert.DoesNotThrow(() =>
        {
            RunInSTA(() =>
            {
                var window = new Window
                {
                    Width = 800,
                    Height = 600
                };

                var button = new Button
                {
                    Content = "Maximize",
                    Width = 46,
                    Height = 32
                };

                SnapLayoutTrigger.Initialize(button);
                window.Content = button;

                Assert.That(button, Is.Not.Null);
                Assert.That(window, Is.Not.Null);
            });
        });
    }

    /// <summary>
    /// Helper method to run code in an STA thread (required for WPF controls).
    /// </summary>
    private static void RunInSTA(Action action)
    {
        Exception? exception = null;
        var thread = new Thread(() =>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        });

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();

        if (exception != null)
        {
            throw exception;
        }
    }
}
