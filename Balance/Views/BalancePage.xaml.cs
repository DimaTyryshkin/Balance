using Balance.Models;
using Windows.UI.Xaml.Controls; 

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Balance.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class BalancePage : Page
    {
        public BalancePage()
        {
            this.InitializeComponent();
            using (SQLiteContext db = new SQLiteContext())
            {
                balanceText.Text = db.CalculateActuelBalance().ToString();
            }
        }
    }
}
