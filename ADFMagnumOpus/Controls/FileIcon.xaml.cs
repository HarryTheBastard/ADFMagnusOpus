using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ADFMagnumOpus.Controls;

/// <summary>
/// Interaction logic for FileIcon.xaml
/// </summary>
public partial class FileIcon : UserControl
{
    private bool _isDragging;
    private Point _dragStart;


    public FileIcon()
    {
        InitializeComponent();

        Loaded += OnLoaded;
        MouseLeftButtonDown += OnMouseLeftButtonDown;
        MouseMove += OnMouseMove;
        MouseLeftButtonUp += OnMouseLeftButtonUp;

    }


    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // Ensure the icon is focusable for keyboard later if needed
        Focusable = true;
    }


    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        _isDragging = true;
        _dragStart = e.GetPosition(null);
        CaptureMouse();
        e.Handled = true;
    }


    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (!_isDragging) return;
        if (DataContext is not Models.DiskImageBase vm) return;


        var canvas = FindCanvasAncestor(this);
        if (canvas is null) return;


        var pos = e.GetPosition(canvas);
        // Center drag around pointer by offsetting half the icon size if desired; here we align top-left to pointer
        vm.Left = pos.X - 32; // tweak if you change icon size
        vm.Top = pos.Y - 32;
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
            current = System.Windows.Media.VisualTreeHelper.GetParent(current);
        }
        return null;
    }
}
