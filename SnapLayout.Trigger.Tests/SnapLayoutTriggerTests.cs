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
    public void Initialize_WithButton_ButtonPropertiesRemainUnchanged()
    {
        // Arrange, Act & Assert
        RunInSTA(() =>
        {
            var button = new Button
            {
                Content = "Test",
                Width = 100,
                Height = 50,
                IsEnabled = true
            };

            SnapLayoutTrigger.Initialize(button);

            // Assert that initialization doesn't modify button properties
            Assert.That(button.Content, Is.EqualTo("Test"));
            Assert.That(button.Width, Is.EqualTo(100));
            Assert.That(button.Height, Is.EqualTo(50));
            Assert.That(button.IsEnabled, Is.True);
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
                Assert.That(window.Content, Is.EqualTo(button));
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
