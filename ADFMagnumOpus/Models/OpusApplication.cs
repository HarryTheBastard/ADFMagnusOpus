using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public class OpusApplication : WorkbenchItem, IWorkbenchItem
{
    public override bool IsDisk => false;

    public OpusApplication(string volumeName, ImageSource icon)
    {
        Initialize(volumeName, icon);

    }

}
