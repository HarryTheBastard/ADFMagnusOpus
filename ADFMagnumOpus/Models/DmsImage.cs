using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public class DmsImage : DiskImageBase, IDiskImage
{
    public DmsImage(string volumeName, ImageSource icon, string? filePath = null)
    {
        Initialize(volumeName, icon, filePath);
    }

}
