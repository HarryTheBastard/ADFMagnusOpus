using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;

namespace ADFMagnumOpus.ViewModels;

public partial  class WorkbenchDrawerWindowViewModel : ObservableObject
{
    private readonly UserControl _userControl;
    public WorkbenchDrawerWindowViewModel(UserControl userControl)
    {
        _userControl = userControl;
    }


    [RelayCommand]
    public void Close()
    {
        //_userControl.hid;
    }

}
