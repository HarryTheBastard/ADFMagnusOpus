using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ADFMagnumOpus.Controls;

public class WorkbenchItemsControl : ItemsControl
{
    protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
    {
        base.PrepareContainerForItemOverride(element, item);

        // The container is a ContentPresenter. Bind its Canvas.Left/Top to the item's Left/Top.
        if (element is ContentPresenter cp)
        {
            BindingOperations.SetBinding(cp, Canvas.LeftProperty, new Binding("Left"));
            BindingOperations.SetBinding(cp, Canvas.TopProperty, new Binding("Top"));
        }
    }
}
