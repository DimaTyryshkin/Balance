using System;

namespace Balance.Models
{
    public class Operation
    {
        public static readonly string incomeTypeAlias = "Доход";
        public static readonly string expensesTypeAlias = "Расход";

        /// <summary>
        /// Доступные типы операций над балансом
        /// </summary>
        public static readonly string[] operationTypes = new string[]
        {
            incomeTypeAlias,
            expensesTypeAlias
        };

        /// <summary>
        /// Категории операций типа 'Доход'
        /// </summary>
        public static readonly string[] incomeCategoryes = new string[]
        {
            "Заработная плата",
            "Возврат долга",
            "Дивиденды"
        };

        /// <summary>
        /// Категории операций типа 'Расход'
        /// </summary>
        public static readonly string[] expensesCategoryes = new string[]
        {
            "Развлечения",
            "Еда",
            "Транспорт",
        };


        public static string[] GetCategoryesByType(string operationType)
        {
            if (operationType == incomeTypeAlias)
                return incomeCategoryes;

            if (operationType == expensesTypeAlias)
                return expensesCategoryes;

            throw new ArgumentException("Нет категорий для этого типа операции", operationType);
        }


        public int      Id          { get; set; }
        public DateTime DateTime    { get; set; }
        public string   Type        { get; set; }
        public string   Category    { get; set; }
        public double   Summ        { get; set; }
        public string   Description { get; set; }
    }
}