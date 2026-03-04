using System.Windows;
using System.Windows.Input;

namespace SnapLayout.Trigger.Example;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Initialize SnapLayout functionality on the maximize button
        SnapLayoutTrigger.Initialize(MaximizeButton);
    }

    private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            ToggleMaximize();
        }
        else
        {
            DragMove();
        }
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        ToggleMaximize();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ToggleMaximize()
    {
        if (WindowState == WindowState.Maximized)
        {
            WindowState = WindowState.Normal;
            MaximizeButton.Content = "⬜";
        }
        else
        {
            WindowState = WindowState.Maximized;
            MaximizeButton.Content = "◱";
        }
    }
}
