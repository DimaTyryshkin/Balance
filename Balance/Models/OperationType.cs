using System; 
 
namespace Balance.Models
{
    public class Operation
    {
        public static readonly string[] operationTypes = new string[]
        {
            "Доход",
            "Расход"
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
            if (operationType == operationTypes[0])
                return incomeCategoryes;

            if (operationType == operationTypes[1]) 
                return expensesCategoryes;

            throw new ArgumentException("Нет категорий для этого типа операции", operationType);
        }
    } 
}