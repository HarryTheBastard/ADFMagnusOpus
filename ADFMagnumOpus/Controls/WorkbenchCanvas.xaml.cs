using ADFMagnumOpus.Models;
using ADFMagnumOpus.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ADFMagnumOpus.Controls;

/// <summary>
/// Interaction logic for WorkbenchCanvas.xaml
/// </summary>
public partial class WorkbenchCanvas : UserControl
{
    private bool _isDragging;
    private Vector _grabOffset;        // offset inside the rect at grab time
    private WorkbenchItem? _dragItem;

    public WorkbenchCanvas()
    {
        InitializeComponent();
    }

    private void Draggable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is not FrameworkElement fe) return;
        _dragItem = fe.DataContext as WorkbenchItem;
        if (_dragItem is null) return;

        var mouse = e.GetPosition(DesktopHost);
        _grabOffset = new Vector(mouse.X - _dragItem.Left, mouse.Y - _dragItem.Top);

        fe.CaptureMouse();
        _isDragging = true;
        e.Handled = true;
    }

    private void Draggable_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_isDragging || _dragItem is null) return;

        var mouse = e.GetPosition(DesktopHost);
        double newLeft = mouse.X - _grabOffset.X;
        double newTop = mouse.Y - _grabOffset.Y;

        // Clamp to the host size (Canvas stretches to fill)
        double canvasW = DesktopHost.ActualWidth;
        double canvasH = DesktopHost.ActualHeight;
        double w = _dragItem.Width, h = _dragItem.Height;

        if (canvasW > 0) newLeft = Math.Clamp(newLeft, 0, Math.Max(0, canvasW - w));
        if (canvasH > 0) newTop = Math.Clamp(newTop, 0, Math.Max(0, canvasH - h));

        _dragItem.Left = newLeft;
        _dragItem.Top = newTop;
    }

    private void Draggable_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        (sender as IInputElement)?.ReleaseMouseCapture();
        _isDragging = false;
        _dragItem = null;
        e.Handled = true;
    }
       
}
