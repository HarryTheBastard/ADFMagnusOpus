using ADFMagnumOpus.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ADFMagnumOpus.Views;

/// <summary>
/// Interaction logic for WorkbenchDrawerWindow.xaml
/// </summary>
public partial class WorkbenchDrawerWindow : UserControl
{
    public WorkbenchDrawerWindow()
    {
        InitializeComponent();
    }

    // Title text
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(WorkbenchDrawerWindow),
            new FrameworkPropertyMetadata("Window"));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    // Expose inner content
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(nameof(Content), typeof(object), typeof(WorkbenchDrawerWindow),
            new FrameworkPropertyMetadata(null));

    public new object Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    // Commands you can bind to in your VM if you want, but defaults do local behavior.
    public ICommand CloseCommand => _close ??= new RoutedCommand();
    public ICommand ToggleZOrderCommand => _toggle ??= new RoutedCommand();
    private ICommand _close, _toggle;

    // Allow hosting page to handle the commands; otherwise default handlers
    public event RoutedEventHandler CloseRequested;
    public event RoutedEventHandler ToggleZOrderRequested;

    // wire default handlers
    protected override void OnInitialized(System.EventArgs e)
    {
        base.OnInitialized(e);
        CommandBindings.Add(new CommandBinding((RoutedCommand)CloseCommand, (s, _) =>
        {
            if (CloseRequested != null) CloseRequested(this, new RoutedEventArgs());
            else this.Visibility = Visibility.Collapsed; // default
        }));
        CommandBindings.Add(new CommandBinding((RoutedCommand)ToggleZOrderCommand, (s, _) =>
        {
            if (ToggleZOrderRequested != null) ToggleZOrderRequested(this, new RoutedEventArgs());
            else
            {
                // bring to front by bumping ZIndex
                var parent = this.Parent as Canvas;
                if (parent != null)
                {
                    int max = 0;
                    foreach (UIElement child in parent.Children) max = System.Math.Max(max, Panel.GetZIndex(child));
                    Panel.SetZIndex(this, max + 1);
                }
            }
        }));
    }

    // ---------- Dragging within parent Canvas ----------
    private bool _dragging;
    private Point _dragStart;
    private Point _origin;

    private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState != MouseButtonState.Pressed) return;
        var canvas = this.Parent as Canvas;
        if (canvas == null) return; // requires a Canvas parent
        _dragging = true;
        _dragStart = e.GetPosition(canvas);
        _origin = new Point(Canvas.GetLeft(this), Canvas.GetTop(this));
        CaptureMouse();
    }

    private void TitleBar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _dragging = false;
        ReleaseMouseCapture();
    }

    private void TitleBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_dragging) return;
        var canvas = this.Parent as Canvas;
        if (canvas == null) return;

        var p = e.GetPosition(canvas);
        var dx = p.X - _dragStart.X;
        var dy = p.Y - _dragStart.Y;

        double newLeft = _origin.X + dx;
        double newTop = _origin.Y + dy;

        // clamp inside canvas
        newLeft = System.Math.Max(0, System.Math.Min(newLeft, canvas.ActualWidth - this.ActualWidth));
        newTop = System.Math.Max(0, System.Math.Min(newTop, canvas.ActualHeight - this.ActualHeight));

        Canvas.SetLeft(this, newLeft);
        Canvas.SetTop(this, newTop);
    }
}
