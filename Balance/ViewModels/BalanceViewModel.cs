using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Balance.Models;

namespace Balance.ViewModels
{
    public class BalanceViewModel : ViewModel
    {
        public string Balance { get; set; }

        public BalanceViewModel()
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                Balance = CalculateActualBalance(db.Operations).ToString();
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