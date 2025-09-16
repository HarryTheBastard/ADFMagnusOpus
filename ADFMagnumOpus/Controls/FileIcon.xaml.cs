using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ADFMagnumOpus.Controls;

/// <summary>
/// Interaction logic for FileIcon.xaml
/// </summary>
public partial class FileIcon : UserControl
{
    private bool _isDragging;
    private Point _startPoint;

    public FileIcon()
    {
        InitializeComponent();

        MouseLeftButtonDown += OnMouseLeftButtonDown;
        MouseMove += OnMouseMove;
        MouseLeftButtonUp += OnMouseLeftButtonUp;
    }

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _isDragging = true;
        _startPoint = e.GetPosition(null);
        CaptureMouse();
        e.Handled = true;
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (!_isDragging) return;
        if (DataContext is not ADFMagnumOpus.Models.WorkbenchItem vm) return;

        var canvas = FindCanvasAncestor(this);
        if (canvas == null) return;

        var pos = e.GetPosition(canvas);
        vm.Left = pos.X - (ActualWidth / 2);
        vm.Top = pos.Y - (ActualHeight / 2);
        Debug.WriteLine($"{vm.Left}, {vm.Top}");
    }

    private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (!_isDragging) return;
        _isDragging = false;
        ReleaseMouseCapture();
        e.Handled = true;
    }

    private static Canvas? FindCanvasAncestor(DependencyObject current)
    {
        while (current != null)
        {
            if (current is Canvas c) return c;
            current = VisualTreeHelper.GetParent(current);
        }
        return null;
    }
}
