using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsKurs
{
    public class ExpenseSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ExpenseCategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
        public ExpenseSubcategory()
        {
            Expenses = new List<Expense>();
        }

    }
}
