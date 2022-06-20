using Balance.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace Balance.Views
{
    public sealed partial class BalancePage : Page
    {
        public BalancePage()
        {
            this.InitializeComponent();

            Draw();
        }

        void Draw()
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                balanceText.Text = CalculateActualBalance(db.Operations).ToString();
            }
        }

        /// <summary>
        /// Возвращает баланс, рассчитанный на основе истории операций.
        /// </summary>
        int CalculateActualBalance(DbSet<Operation> operations)
        {
            int summ = 0;
            foreach (Operation operation in operations.ToList())
            {

                if (operation.Type == Operation.incomeTypeAlias)
                {
                    summ += operation.Summ;
                    continue;
                }

                if (operation.Type == Operation.expensesTypeAlias)
                {
                    summ -= operation.Summ;
                    continue;
                }

                throw new Exception($"Неизвестный тип операции '{operation.Type}'");
            }

            return summ;
        }
    }
}