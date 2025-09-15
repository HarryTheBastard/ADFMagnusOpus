using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public interface IDiskImage
{
    string VolumeName { get; }
    string? FilePath { get; }
    ImageSource IconSource { get; }

}
