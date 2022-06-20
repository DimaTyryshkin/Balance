using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Balance.Models;
using System.Globalization;

namespace Balance.ViewModels
{
    public class BalanceViewModel : ViewModel
    {
        public string Balance { get; }

        public BalanceViewModel()
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                Balance = CalculateActualBalance(db.Operations).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Возвращает баланс, рассчитанный на основе истории операций.
        /// </summary>
        double CalculateActualBalance(DbSet<Operation> operations)
        {
            double summ = 0;
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