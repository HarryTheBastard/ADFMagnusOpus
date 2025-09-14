using ADFMagnumOpus.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
namespace ADFMagnumOpus.Shell
{
    public partial class WorkbenchWindow : Window
    {
        public WorkbenchWindow()
        {
            InitializeComponent();
            // Only assign runtime VM when NOT in design mode
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                this.DataContext = new WorkbenchWindowViewModel(this);
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) ToggleMaxRestore();
            else DragMove();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void MaximizeRestore_Click(object sender, RoutedEventArgs e) => ToggleMaxRestore();
        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleMaxRestore() =>
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }
}
