using ADFMagnumOpus.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ADFMagnumOpus.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly MainView _window;
    public MainViewModel(MainView window)
    {
        _window = window;

    }

    
    
}