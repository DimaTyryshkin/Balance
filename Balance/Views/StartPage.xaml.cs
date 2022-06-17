using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Balance.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
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
