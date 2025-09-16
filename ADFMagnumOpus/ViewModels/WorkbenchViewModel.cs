using ADFMagnumOpus.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ADFMagnumOpus.ViewModels;

public partial class WorkbenchViewModel : ObservableObject
{
    public ObservableCollection<IWorkbenchItem> Icons { get; } = new();


    public WorkbenchViewModel()
    {
        // For now, instantiate one of each (you asked to just create one; feel free to comment one out)
        Icons.Add(new AdfImage("Workbench 2.1", LoadPackIcon("Assets/Icons/disk.png"))
        {
            Left = 200,
            Top = 48
        });
        Icons.Add(new OpusApplication("Applications", LoadPackIcon("Assets/Icons/drawer.png"))
        {
            Left = 48,
            Top = 48
        });

    }


    private static ImageSource LoadPackIcon(string relativePath)
    {
        var asmName = Assembly.GetExecutingAssembly().GetName().Name;
        var uri = new Uri($"pack://application:,,,/{asmName};component/{relativePath}", UriKind.Absolute);
        return new BitmapImage(uri);
    }

}
