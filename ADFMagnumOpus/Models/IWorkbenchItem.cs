using System.ComponentModel;
using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public interface IWorkbenchItem : INotifyPropertyChanged
{
    string VolumeName { get; }
    string? FilePath { get; }
    ImageSource IconSource { get; }

}
