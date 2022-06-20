using Windows.UI.Xaml.Controls; 
using Balance.ViewModels;

namespace Balance.Views
{
    public sealed partial class OperationsLogPage : Page
    {
        public OperationsLogPage()
        {
            this.InitializeComponent();

            DataContext = new OperationsLogViewModel();
        }
    }
}