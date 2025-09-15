using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public class AdfImage : DiskImageBase, IDiskImage
{

    public AdfImage(string volumeName, ImageSource icon, string? filePath = null)
    {
        Initialize(volumeName, icon, filePath);
    }

}
