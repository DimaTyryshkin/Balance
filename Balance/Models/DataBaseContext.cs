using System;
using System.Collections.Generic;

namespace Balance.Models
{  
    public class DataBaseContext
    {
        static DataBaseContext inst;

        public static DataBaseContext Inst
        {
            get
            {
                if (inst == null)
                    inst = new DataBaseContext();

                return inst;
            }
        }

        public List<Operation> Operations { get; set; } = new List<Operation>();

        public int CalculateActuelBalance()
        {
            int summ = 0;
            foreach (Operation operation in Operations)
            {

                if (operation.type == Operation.incomeTypeAlias)
                {
                    summ += operation.summ;
                    continue;
                }

                if (operation.type == Operation.expensesTypeAlias)
                {
                    summ -= operation.summ;
                    continue;
                }

                throw new Exception($"Неизвестный тип операции '{operation.type}'");
            }

            return summ;
        }
    }
}
