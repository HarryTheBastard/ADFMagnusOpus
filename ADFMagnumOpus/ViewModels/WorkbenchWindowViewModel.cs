using ADFMagnumOpus.Shell;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;

namespace ADFMagnumOpus.ViewModels;

public partial class WorkbenchWindowViewModel : ObservableObject
{
    private readonly WorkbenchWindow _window = null!;

    public WorkbenchViewModel Workbench { get; } = new();

    public WorkbenchWindowViewModel()
    {
         
    }

    public WorkbenchWindowViewModel(WorkbenchWindow window)
    {
        _window = window;
    }

    [ObservableProperty]
    private string _appTitle = "ADF Magnum Opus — Amiga Disk Image Utility";

    // The size of the resize border around the window
    [ObservableProperty]
    private double _resizeBorder = 6;

    public Thickness ResizeBorderThickness => new Thickness(ResizeBorder);

    /// <summary>
    /// Height of the title bar / cpation of the window
    /// </summary>
    [ObservableProperty]
    private double _titleHeight = 28;

    public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

    [RelayCommand]
    public void Close()
    {
        _window.Close();
    }

    [RelayCommand]
    public void Minimize()
    {
        _window.WindowState = WindowState.Minimized;
    }

    [RelayCommand]
    public void Maximize()
    {
        _window.WindowState ^= WindowState.Maximized;
    }

    [RelayCommand]
    public void ToggleFrontBehind()
    {

    }

    //[RelayCommand]
    //public void Menu()
    //{
    //    Point pos = Mouse.GetPosition(_window);
    //    Point screenPos = Application.Current.MainWindow.PointToScreen(pos);

    //    SystemCommands.ShowSystemMenu(_window, screenPos);
    //}

}
