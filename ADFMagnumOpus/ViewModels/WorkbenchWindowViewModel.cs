using ADFMagnumOpus.Shell;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ADFMagnumOpus.ViewModels;

public class WorkbenchWindowViewModel : ObservableObject
{
    private readonly WorkbenchWindow _window;

    public WorkbenchWindowViewModel(WorkbenchWindow window)
    {
        _window = window;
    }

    public string AppTitle => "ADFMagnumOpus — Amiga Disk Utility";
}
