using Windows.UI.Xaml.Controls;
using Balance.ViewModels;

namespace Balance.Views
{
    public sealed partial class AddOperation : Page
    { 
        public AddOperation()
        { 
            this.InitializeComponent();

            DataContext = new AddOperationViewModel();
        } 
    }
}