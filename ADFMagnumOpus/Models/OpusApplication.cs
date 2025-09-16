using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public class BatchConverter : WorkbenchItem, IWorkbenchItem
{
    public BatchConverter(string volumeName, ImageSource icon)
    {
        Initialize(volumeName, icon);

    }

}
