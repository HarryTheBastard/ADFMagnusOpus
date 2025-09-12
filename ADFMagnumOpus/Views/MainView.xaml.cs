using ADFMagnumOpus.ViewModels;
using System.Windows.Controls;

namespace ADFMagnumOpus.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        this.DataContext = new MainViewModel(this);
    }
}
