using Windows.UI.Xaml.Controls;
using Balance.ViewModels;

namespace Balance.Views
{
    public sealed partial class BalancePage : Page
    {
        public BalancePage()
        {
            this.InitializeComponent();

            DataContext = new BalanceViewModel();
        }
    }
}