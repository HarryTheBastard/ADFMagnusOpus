using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public class DmsImage : WorkbenchItem, IWorkbenchItem
{
    public DmsImage(string volumeName, ImageSource icon, string? filePath = null)
    {
        Initialize(volumeName, icon, filePath);
    }

}
