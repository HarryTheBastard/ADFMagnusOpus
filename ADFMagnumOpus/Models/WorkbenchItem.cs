using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace ADFMagnumOpus.Models;

public class WorkbenchItem : IWorkbenchItem
{
    private string _volumeName = string.Empty;
    private string? _filePath;
    private ImageSource _iconSource = default!; // set by derived type or DI

    // Position on the Workbench canvas (for drag/drop)
    private double _left;
    private double _top;

    // Size of the item
    private double _width = 96;
    private double _height = 96;

    public string VolumeName
    {
        get => _volumeName;
        protected set { if (_volumeName != value) { _volumeName = value; OnPropertyChanged(); } }
    }

    public string? FilePath
    {
        get => _filePath;
        protected set { if (_filePath != value) { _filePath = value; OnPropertyChanged(); } }
    }

    public ImageSource IconSource
    {
        get => _iconSource;
        protected set { if (_iconSource != value) { _iconSource = value; OnPropertyChanged(); } }
    }

    public virtual bool IsDisk => true;

    public double Left
    {
        get => _left;
        set { if (_left != value) { _left = value; OnPropertyChanged(); } }
    }

    public double Top
    {
        get => _top;
        set { if (_top != value) { _top = value; OnPropertyChanged(); } }
    }

    public double Width
    {
        get => _width;
        set { if (_width != value) { _width = value; OnPropertyChanged(); } }
    }

    public double Height
    {
        get => _height;
        set { if (_height != value) { _height = value; OnPropertyChanged(); } }
    }    

    // Helper to set name/icon quickly in derived types
    protected void Initialize(string volumeName, ImageSource icon, string? filePath = null,
                              double left = 32, double top = 32,
                              double width = 96, double height = 96)
    {
        VolumeName = volumeName;
        IconSource = icon;
        FilePath = filePath;
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
