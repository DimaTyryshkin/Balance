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
            balanceText.Text = Models.DataBaseContext.Inst.CalculateActuelBalance().ToString();
        }
    }
}
