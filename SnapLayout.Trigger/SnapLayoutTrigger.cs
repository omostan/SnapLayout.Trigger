#region copyright

/*****************************************************************************************
*                                     ______________________________________________     *
*                              o O   |                                              |    *
*                     (((((  o      <               DotNet WPF Tool Kit             |    *
*                    ( o o )         |______________________________________________|    *
* ------------oOOO-----(_)-----OOOo----------------------------------------------------- *
*             Project: SnapLayout.Trigger                                                *
*            Filename: SnapLayoutTrigger.cs                                              *
*              Author: Stanley Omoregie                                                  *
*        Created Date: 27.01.2026                                                        *
*       Modified Date: 27.01.2026                                                        *
*          Created By: Stanley Omoregie                                                  *
*    Last Modified By: Stanley Omoregie                                                  *
*           CopyRight: copyright © 2025 Omotech Digital Solutions                        *
*                  .oooO  Oooo.                                                          *
*                  (   )  (   )                                                          *
* ------------------\ (----) /---------------------------------------------------------- *
*                    \_)  (_/                                                            *
*****************************************************************************************/

#endregion copyright

using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SnapLayout.Trigger;

/// <summary>
/// Provides functionality to trigger the Windows 11 Snap Layout popup by simulating Win+Z
/// when the mouse enters or when the left mouse button is pressed and held on the maximize button.
/// </summary>
public static partial class SnapLayoutTrigger
{
    #region Fields

    [LibraryImport("user32.dll", SetLastError = true)]
    private static partial void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial void SetCursorPos(int x, int y);

    private const byte VkLWin = 0x5B;
    private const byte VkZ = 0x5A;
    private const uint KeyEventFKeyUp = 0x0002;

    private static bool _isLeftMouseHeld;
    private static System.Timers.Timer? _holdTimer;
    private const int HoldDurationMs = 400;

    #endregion Fields

    #region Initialize

    /// <summary>
    /// Initializes snap layout behavior by attaching MouseEnter and MouseDown handlers to the maximize button.
    /// </summary>
    /// <param name="maximizeButton">The maximize button that triggers the Windows snap layout popup.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="maximizeButton"/> is null.</exception>
    public static void Initialize(Button maximizeButton)
    {
        ArgumentNullException.ThrowIfNull(maximizeButton);

        maximizeButton.MouseEnter += CustomMaximizeButtonMouseEnter;
        maximizeButton.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
        maximizeButton.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
        maximizeButton.LostMouseCapture += OnLostMouseCapture;
    }

    #endregion Initialize

    #region PopupWindow

    /// <summary>
    /// Triggers the Windows 11 Snap Layout popup by moving the mouse to the center of the button and simulating Win+Z.
    /// </summary>
    /// <param name="button">The maximize button.</param>
    private static void PopupWindow(Button button)
    {
        var window = Window.GetWindow(button);
        if (window == null) return;

        var relativePoint = button.TransformToAncestor(window).Transform(new Point(0, 0));
        var centerX = relativePoint.X + button.ActualWidth / 2;
        var centerY = relativePoint.Y + button.ActualHeight / 2;
        var screenPoint = window.PointToScreen(new Point(centerX, centerY));

        SetCursorPos((int)screenPoint.X, (int)screenPoint.Y);
        window.Activate();

        keybd_event(VkLWin, 0, 0, IntPtr.Zero);
        keybd_event(VkZ, 0, 0, IntPtr.Zero);
        keybd_event(VkZ, 0, KeyEventFKeyUp, IntPtr.Zero);
        keybd_event(VkLWin, 0, KeyEventFKeyUp, IntPtr.Zero);
    }

    #endregion PopupWindow

    #region Event Handlers

    /// <summary>
    /// Handles the mouse enter event for the maximize button and triggers the snap layout popup.
    /// </summary>
    /// <param name="sender">The event source.</param>
    /// <param name="e">The mouse event data.</param>
    private static void CustomMaximizeButtonMouseEnter(object sender, MouseEventArgs e)
    {
        if (sender is Button button)
        {
            PopupWindow(button);
        }
    }

    /// <summary>
    /// Handles the event when the left mouse button is pressed down on the maximize button.
    /// Initiates a timer that will trigger the snap layout popup if the button is held for the specified duration.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The mouse button event data.</param>
    private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_isLeftMouseHeld) return;
        _isLeftMouseHeld = true;

        _holdTimer = new System.Timers.Timer(HoldDurationMs) { AutoReset = false };
        _holdTimer.Elapsed += (_, _) =>
        {
            _holdTimer?.Stop();
            _holdTimer?.Dispose();
            _holdTimer = null;
            if (_isLeftMouseHeld && sender is Button button)
            {
                Application.Current.Dispatcher.Invoke(() => PopupWindow(button));
            }
        };
        _holdTimer.Start();
    }

    /// <summary>
    /// Handles the event when the left mouse button is released from the maximize button.
    /// Resets the left mouse button state and cleans up the hold timer.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The mouse button event data.</param>
    private static void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _isLeftMouseHeld = false;
        _holdTimer?.Stop();
        _holdTimer?.Dispose();
        _holdTimer = null;
    }

    /// <summary>
    /// Handles the event when the mouse capture is lost from the maximize button.
    /// Resets the left mouse button state and cleans up the hold timer.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The mouse event data.</param>
    private static void OnLostMouseCapture(object sender, MouseEventArgs e)
    {
        _isLeftMouseHeld = false;
        _holdTimer?.Stop();
        _holdTimer?.Dispose();
        _holdTimer = null;
    }

    #endregion Event Handlers
}

#region Alternative Implementation with Only MouseEnter

/*/// <summary>
/// Provides functionality to trigger the Windows 11 Snap Layout popup by simulating Win+Z when the mouse enters the maximize button.
/// 
/// Usage:
/// Call <see cref="Initialize"/> with the maximize button instance. This will attach a MouseEnter handler that:
///   - Moves the mouse pointer to the center of the maximize button (using SetCursorPos)
///   - Sends the Win+Z key combination (using keybd_event)
///   - Ensures the Snap Layout popup appears precisely over the button, even on multi-monitor setups
/// </summary>
public static class SnapLayoutOnMouseEnter
{
    #region Fields

     /// <summary>
     /// Sends a virtual key event to the system.
     /// </summary>
     /// <param name="bVk">The virtual key code.</param>
     /// <param name="bScan">The hardware scan code.</param>
     /// <param name="dwFlags">The key event flags.</param>
     /// <param name="dwExtraInfo">Additional event information.</param>
     [DllImport("user32.dll", SetLastError = true)]
     private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);
    
     /// <summary>
     /// Sets the cursor position in screen coordinates.
     /// </summary>
     /// <param name="X">The horizontal screen coordinate.</param>
     /// <param name="Y">The vertical screen coordinate.</param>
     /// <returns>\`true\` if successful; otherwise, \`false\`.</returns>
     [DllImport("user32.dll", SetLastError = true)]
     private static extern bool SetCursorPos(int X, int Y);
    
     /// <summary>
     /// Virtual key code for the left Windows key.
     /// </summary>
     private const byte VkLWin =0x5B;
     
     /// <summary>
     /// Virtual key code for the Z key.
     /// </summary>
     private const byte VkZ =0x5A;
     
     /// <summary>
     /// Key event flag indicating a key release.
     /// </summary>
     private const uint KeyEventFKeyUp =0x0002;

    #endregion Fields

    #region Initialize

    /// <summary>
    /// Initializes snap layout behavior by attaching a <see cref="UIElement.MouseEnter"/> handler to the maximize button.
    /// </summary>
    /// <param name="maximizeButton">The maximize button that triggers the Windows snap layout popup on mouse enter.</param>
    public static void Initialize(Button maximizeButton)
    {
        // Attach event handlers to the custom maximize button
        maximizeButton.MouseEnter += CustomMaximizeButtonMouseEnter;
    }

    #endregion Initialize

    #region CustomMaximizeButtonMouseEnter

    // Improved: Move mouse to maximize button center, then send Win+Z
    /// <summary>
    /// Handles the MouseEnter event for the maximize button, triggering the Windows 11 Snap Layout popup.
    /// Moves the mouse cursor to the center of the maximize button and simulates the Win+Z keyboard shortcut.
    /// </summary>
    /// <param name="sender">The maximize button that raised the event.</param>
    /// <param name="e">The mouse event data.</param>
    private static void CustomMaximizeButtonMouseEnter(object sender, MouseEventArgs e)
    {
        if (sender is not Button button) return;

        // Get the center point of the button in screen coordinates
        var relativePoint = button.TransformToAncestor(Window.GetWindow(button)!).Transform(new Point(0, 0));
        var centerX = relativePoint.X + button.ActualWidth / 2;
        var centerY = relativePoint.Y + button.ActualHeight / 2;
        
        // Get the window that contains the button
        var window = Window.GetWindow(button);
        
        // Ensure we have a valid window reference
        if (window == null) return;
        
        // Convert the center point to screen coordinates
        var screenPoint = window.PointToScreen(new Point(centerX, centerY));

        // Move the mouse pointer to the center of the maximize button
        SetCursorPos((int)screenPoint.X, (int)screenPoint.Y);

        window.Activate();

        keybd_event(VkLWin, 0, 0, IntPtr.Zero);
        keybd_event(VkZ, 0, 0, IntPtr.Zero);
        keybd_event(VkZ, 0, KeyEventFKeyUp, IntPtr.Zero);
        keybd_event(VkLWin, 0, KeyEventFKeyUp, IntPtr.Zero);
    }

    #endregion CustomMaximizeButtonMouseEnter
}*/

#endregion Alternative Implementation with Only MouseEnter

#region Alternative Implementation with Only MouseDown and Hold

/*/// <summary>
/// Provides functionality to trigger the Windows 11 Snap Layout popup by simulating Win+Z when the left mouse button is pressed and held on the maximize button.
/// Windows 11-like behavior: maximize on left mouse press and hold
/// Usage:
/// Call <see cref="Initialize"/> with the maximize button instance. This will attach MouseDown and MouseUp handlers that:
///   - Start a timer on left mouse button down
///   - If the button is held for a specified duration, moves the mouse pointer to the center of the maximize button and sends Win+Z
///   - Cancels the action if the mouse button is released or the mouse capture is lost before the timer elapses
/// 
/// This approach closely mimics the native Windows 11 behavior for Snap Layouts.
/// </summary>
public static class SnapLayoutOnMouseDown
{
    #region Fields

    /// <summary>
    /// Simulates a key press event using the Win32 API.
    /// </summary>
    /// <param name="bVk">The virtual-key code of the key.</param>
    /// <param name="bScan">The hardware scan code of the key.</param>
    /// <param name="dwFlags">Specifies various function options.</param>
    /// <param name="dwExtraInfo">Additional data associated with the key press.</param>
    [DllImport("user32.dll", SetLastError = true)]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    /// <summary>
    /// Virtual key code for the Left Windows key
    /// </summary>
    private const byte VkLWin =0x5B;
    
    /// <summary>
    /// Virtual key code for the 'Z' key
    /// </summary>
    private const byte VkZ =0x5A;
    
    /// <summary>
    /// Flag for key release
    /// </summary>
    private const uint KeyEventFKeyUp =0x0002;
    
    /// <summary>
    /// Tracks whether the left mouse button is held
    /// </summary>
    private static bool _isLeftMouseHeld;
    
    /// <summary>
    /// Timer to detect the hold duration
    /// </summary>
    private static Timer? _holdTimer;
    
    /// <summary>
    /// Duration in milliseconds to detect a hold
    /// </summary>
    private const int HoldDurationMs = 400;

    #endregion Fields

    #region Initialize

    /// <summary>
    /// Initializes the SnapLayoutOnMouseDown functionality by attaching event handlers to the maximize button.
    /// </summary>
    /// <param name="maximizeButton">The maximize button to attach the handlers to.</param>
    public static void Initialize(Button maximizeButton)
    {
        // Attach event handlers to the custom maximize button
        maximizeButton.MouseEnter += CustomMaximizeButtonMouseEnter;
    }

    #endregion Initialize

    #region CustomMaximizeButtonMouseEnter

    /// <summary>
    /// Handles the MouseEnter event for the maximize button and attaches additional mouse event handlers.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private static void CustomMaximizeButtonMouseEnter(object sender, MouseEventArgs e)
    {
        if (sender is not UIElement element)
            return;

        element.PreviewMouseLeftButtonDown += OnMouseLeftButtonDown;
        element.PreviewMouseLeftButtonUp += OnMouseLeftButtonUp;
        element.LostMouseCapture += OnLostMouseCapture;
    }

    #endregion CustomMaximizeButtonMouseEnter

    #region OnMouseLeftButtonDown

    /// <summary>
    /// Handles the left mouse button down event and starts the hold timer.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (_isLeftMouseHeld)
            return;
        _isLeftMouseHeld = true;
        _holdTimer = new Timer(HoldDurationMs) { AutoReset = false };
        _holdTimer.Elapsed += (_, _) =>
        {
            _holdTimer?.Stop();
            _holdTimer?.Dispose();
            _holdTimer = null;
            if (_isLeftMouseHeld && sender is DependencyObject source)
            {
                // Simulate Win+Z
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Window.GetWindow(source)?.Activate();
                    keybd_event(VkLWin, 0, 0, IntPtr.Zero);
                    keybd_event(VkZ, 0, 0, IntPtr.Zero);
                    keybd_event(VkZ, 0, KeyEventFKeyUp, IntPtr.Zero);
                    keybd_event(VkLWin, 0, KeyEventFKeyUp, IntPtr.Zero);
                });
            }
        };
        _holdTimer.Start();
    }

    #endregion OnMouseLeftButtonDown

    #region OnMouseLeftButtonUp

    /// <summary>
    /// Handles the left mouse button up event and cancels the hold timer.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private static void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _isLeftMouseHeld = false;
        _holdTimer?.Stop();
        _holdTimer?.Dispose();
        _holdTimer = null;
    }

    #endregion OnMouseLeftButtonUp

    #region OnLostMouseCapture

    /// <summary>
    /// Handles the event when the mouse capture is lost and cancels the hold timer.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The event data.</param>
    private static void OnLostMouseCapture(object sender, MouseEventArgs e)
    {
        _isLeftMouseHeld = false;
        _holdTimer?.Stop();
        _holdTimer?.Dispose();
        _holdTimer = null;
    }

    #endregion OnLostMouseCapture
}*/

#endregion Alternative Implementation with Only MouseDown and Hold
