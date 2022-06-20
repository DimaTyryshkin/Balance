using System;
using System.Collections.Generic; 
using System.Linq; 
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls; 

using Balance.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
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