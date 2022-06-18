using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls; 
 
namespace Balance.Views
{ 
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        private void menu_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            var item = args.SelectedItem as NavigationViewItem;
            System.Diagnostics.Debug.WriteLine(item.Tag.ToString());
            switch (item.Tag.ToString())
            {
                case "balance":
                    bodyFrame.Navigate(typeof(BalancePage));
                    break;

                case "addOperation":
                    bodyFrame.Navigate(typeof(AddOperation));
                    break;

                case "operationsLog":
                    bodyFrame.Navigate(typeof(OperationsLogPage));
                    break;
            } 
        }

        private void menu_Loaded(object sender, RoutedEventArgs e)
        {
            menu.SelectedItem = menu.MenuItems[0]; 
        }
    }
}
