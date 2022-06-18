using System.Linq; 
using Windows.UI.Xaml.Controls; 

using Balance.Models;
 
namespace Balance.Views
{ 
    public sealed partial class OperationsLogPage : Page
    {  
        public OperationsLogPage()
        {
            this.InitializeComponent();
              
            using (SQLiteContext db = new SQLiteContext())
            {
                dataGrid.ItemsSource = db.Operations.ToList(); 
            } 
        }
    }
}
