using System.Linq;
using Balance.Models;
using System.Collections.Generic;

namespace Balance.ViewModels
{
    public class OperationsLogViewModel : ViewModel
    {
        public List<Operation> Operations { get; }

        public OperationsLogViewModel()
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                Operations = db.Operations.ToList();
            }
        }
    }
}