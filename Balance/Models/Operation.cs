using System; 
 
namespace Balance.Models
{
    public class Operation
    {
        public static readonly string incomeTypeAlias = "Доход";
        public static readonly string expensesTypeAlias = "Расход";

        public static readonly string[] operationTypes = new string[]
        {
            incomeTypeAlias,
            expensesTypeAlias
        };

        public static readonly string[] incomeCategoryes = new string[]
        {
            "Заработная плата",
            "Возврат долга",
            "Дивиденды"
        };

        public static readonly string[] expensesCategoryes = new string[]
        {
            "Развлечение",
            "Еда",
            "Транспорт"
        };


        public static string[] GetCategoryesByType(string operationType)
        {
            if (operationType == incomeTypeAlias)
                return incomeCategoryes;

            if (operationType == expensesTypeAlias)
                return expensesCategoryes;

            throw new ArgumentException("Нет категорий для этого типа операции", operationType);
        }


        public DateTime dateTime { get; set; } 
        public string type { get; set; }
        public string category { get; set; }
        public int summ { get; set; }
        public string description { get; set; }
    }
}