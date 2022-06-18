using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace Balance.Models
{
    public class SQLiteContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }

        public SQLiteContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SQLite.db");
        }

        public int CalculateActuelBalance()
        {
            int summ = 0;
            foreach (Operation operation in Operations.ToList())
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
