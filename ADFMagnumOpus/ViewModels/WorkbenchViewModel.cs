using ADFMagnumOpus.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ADFMagnumOpus.ViewModels;

public partial class WorkbenchViewModel : ObservableObject
{
    public ObservableCollection<object> Icons { get; } = new();


    public WorkbenchViewModel()
    {
        // For now, instantiate one of each (you asked to just create one; feel free to comment one out)
        var disk = new AdfImage("Workbench_Install", LoadPackIcon("Assets/Icons/disk.png"));
        disk.Left = 48;
        disk.Top = 48;

        Icons.Add(disk);

    }


    private static ImageSource LoadPackIcon(string relativePath)
    {
        var asmName = Assembly.GetExecutingAssembly().GetName().Name;
        var uri = new Uri($"pack://application:,,,/{asmName};component/{relativePath}", UriKind.Absolute);
        return new BitmapImage(uri);
    }

}
