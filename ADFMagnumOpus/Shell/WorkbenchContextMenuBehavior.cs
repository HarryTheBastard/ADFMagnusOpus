using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ADFMagnumOpus.Shell;

public static class WorkbenchContextMenuBehavior
{
    public static readonly DependencyProperty EnableProperty =
        DependencyProperty.RegisterAttached(
            "Enable", typeof(bool), typeof(WorkbenchContextMenuBehavior),
            new PropertyMetadata(false, OnEnableChanged));

    public static void SetEnable(DependencyObject obj, bool value) => obj.SetValue(EnableProperty, value);
    public static bool GetEnable(DependencyObject obj) => (bool)obj.GetValue(EnableProperty);

    public static readonly DependencyProperty MenuProperty =
        DependencyProperty.RegisterAttached(
            "Menu", typeof(ContextMenu), typeof(WorkbenchContextMenuBehavior),
            new PropertyMetadata(null));

    public static void SetMenu(DependencyObject obj, ContextMenu value) => obj.SetValue(MenuProperty, value);
    public static ContextMenu GetMenu(DependencyObject obj) => (ContextMenu)obj.GetValue(MenuProperty);

    private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is UIElement el)
        {
            if ((bool)e.NewValue)
                el.PreviewMouseRightButtonUp += OnPreviewMouseRightButtonUp;
            else
                el.PreviewMouseRightButtonUp -= OnPreviewMouseRightButtonUp;
        }
    }

    private static void OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (sender is not FrameworkElement fe) return;

        // Hit-test for any element whose DataContext is an IWorkbenchItem
        var pos = e.GetPosition(fe);
        bool onIcon = false;

        VisualTreeHelper.HitTest(
            fe,
            _ => HitTestFilterBehavior.Continue,
            result =>
            {
                var current = (result.VisualHit as DependencyObject);
                while (current != null)
                {
                    if (current is FrameworkElement fe2 && fe2.DataContext is ADFMagnumOpus.Models.IWorkbenchItem)
                    {
                        onIcon = true;
                        break;
                    }
                    current = VisualTreeHelper.GetParent(current);
                }
                return HitTestResultBehavior.Stop;
            },
            new PointHitTestParameters(pos));

        if (onIcon)
        {
            // Let the icon or its own ContextMenu handle it.
            return;
        }

        // Show the canvas menu (if provided)
        var menu = GetMenu(fe);
        if (menu != null)
        {
            menu.PlacementTarget = fe;
            menu.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            menu.IsOpen = true;
            e.Handled = true;
        }
    }
}
